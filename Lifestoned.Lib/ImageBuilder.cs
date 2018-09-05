using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestoned.Lib.ClientLib;
using Lifestoned.Lib.ClientLib.Enum;

namespace Lifestoned.Lib
{
    internal class ImageBuilder
    {
        private static uint itemTypeMap = 0x25000008;
        private static uint itemEffectMap = 0x25000009;
        private static uint defaultBackground = 0x060011D4;

        /// <summary>
        /// Returns RenderSurface for a weenieclass.
        /// </summary>
        public static byte[] GetFullyLayeredPngIcon(int? itemType, uint? underlayDid, uint? overlayDid, uint? iconDid, UiEffectIcons? uiEffects)
        {
            List<Bitmap> imageBuffer = new List<Bitmap>();

            // Start with the background:
            var background = GetBackgroundPngIcon((uint?)itemType);
            imageBuffer.Add(background.GetBitmap());

            if (underlayDid != null)
            {
                // Add Underlay:
                var underlay = PortalDatReader.Current.Unpack<RenderSurface>(underlayDid.Value);
                imageBuffer.Add(underlay.GetBitmap());
            }

            // Add Icon:
            var icon = GetPrimaryPngIcon(iconDid);

            if (icon != null)
            {
                var effect = GetUiEffect(uiEffects ?? UiEffectIcons.Default);
                if (effect != null)
                {
                    imageBuffer.Add(BlendEffect(icon.GetBitmap(), effect.GetBitmap()));
                }
                else
                    imageBuffer.Add(icon.GetBitmap());
            }

            // Add Overlay:
            if (overlayDid != null)
            {
                var overlay = PortalDatReader.Current.Unpack<RenderSurface>(overlayDid.Value);
                if (overlay != null)
                    imageBuffer.Add(overlay.GetBitmap());
            }

            // Combine
            var compositeImage = CombineImageList(imageBuffer);
            
            var imageArray = new byte[] { };
            using (MemoryStream ms = new MemoryStream())
            {
                compositeImage.Save(ms, ImageFormat.Png);
                imageArray = ms.ToArray();
            }

            return imageArray;
        }

        /// <summary>
        /// Returns a RenderSurface for an ItemType.
        /// </summary>
        private static RenderSurface GetBackgroundPngIcon(uint? itemType)
        {
            // Lookup the background ID from the DIDMapper in the Dat file
            // Magic number 620757000 : 0x25000008 : UIBackgrounds
            var itemMap = PortalDatReader.Current.Unpack<DidMapper>(itemTypeMap);
            uint backgroundId = defaultBackground;

            foreach (var enumMap in itemMap.Enum)
            {
                if (enumMap.Value == itemType.ToString())
                {
                    var didKey = enumMap.Key;
                    foreach (var didMap in itemMap.Did)
                    {
                        if (didMap.Key == didKey)
                        {
                            backgroundId = didMap.Value;
                            break;
                        }
                    }
                }
            }

            return PortalDatReader.Current.Unpack<RenderSurface>(backgroundId);
        }

        /// <summary>
        /// Returns a RenderSurface for UiEffects.
        /// </summary>
        private static RenderSurface GetUiEffect(UiEffectIcons uiEffects)
        {
            // Lookup the UIEffect ID from the DIDMapper in the Dat file
            // Ref: http://ac.yotesfan.com/25-DidMapper/?id=25000009
            // Magic number 620757001 : 0x25000009 : UIBackgrounds

            var itemMap = PortalDatReader.Current.Unpack<DidMapper>(itemEffectMap);
            uint effectId = 0;

            // Compare names of the effect with the did mapper
            foreach (var enumName in itemMap.Enum)
            {
                if (enumName.Value.ToUpperInvariant() == uiEffects.ToString().ToUpperInvariant())
                {
                    var didKey = enumName.Key;
                    effectId = itemMap.Did[didKey];
                    break;
                }
            }

            if (effectId == 0)
                return null;

            return PortalDatReader.Current.Unpack<RenderSurface>(effectId);
        }

        /// <summary>
        /// Returns RenderSurface for a bare Icon.
        /// </summary>
        private static RenderSurface GetPrimaryPngIcon(uint? iconId)
        {
            RenderSurface image = null;
            if (iconId != null)
            {
                // Convert RenderFile to bitmap with iconId
                image = PortalDatReader.Current.Unpack<RenderSurface>(iconId.Value);
            }
            else
            {
                // load a default/blank
                image = new RenderSurface() { Height = 32, Width = 32, Format = ImagePixelFormat.PFID_UNKNOWN };
            }
            return image;
        }

        /// <summary>
        /// Combines images.
        /// </summary>
        /// <returns>Bitmap containing all layers</returns>
        private static Bitmap CombineImageList(List<Bitmap> imageBuffer)
        {
            Bitmap iconImage = new Bitmap(32, 32, PixelFormat.Format32bppRgb);
            // iconImage.MakeTransparent();
            using (Graphics g = Graphics.FromImage(iconImage))
            {
                Brush effectBrush = new SolidBrush(Color.Black);
                // Allow composting ontop?
                g.CompositingMode = CompositingMode.SourceOver;
                foreach (Bitmap image in imageBuffer)
                {
                    // image.MakeTransparent(Color.Transparent);
                    // add the bitmap
                    g.DrawImage(image, 0, 0);
                }
                return iconImage;
            }
        }

        private static Bitmap BlendEffect(Bitmap baseImage, Bitmap effect)
        {
            Bitmap iconImage = new Bitmap(32, 32, PixelFormat.Format32bppPArgb);

            iconImage.MakeTransparent();

            for (int y = 0; y < baseImage.Height; y++)
            {
                for (int x = 0; x < baseImage.Width; x++)
                {
                    var pixel = baseImage.GetPixel(x, y);

                    if (pixel.A > 0)
                    {
                        iconImage.SetPixel(x, y, pixel);
                    }

                    if (pixel.A == 255 && pixel.R == 255 && pixel.G == 255 && pixel.B == 255)
                    {
                        iconImage.SetPixel(x, y, effect.GetPixel(x, y));
                    }
                }
            }

            baseImage.Dispose();
            effect.Dispose();

            return iconImage;
        }
    }
}
