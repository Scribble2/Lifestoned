using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Lifestoned.Lib.ClientLib.Enum;
using System.Drawing.Imaging;

namespace Lifestoned.Lib.ClientLib
{
    public class RenderSurface
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public uint Id;
        public uint Unknown;
        public int Width;
        public int Height;
        public ImagePixelFormat Format;
        public List<int> Colors = new List<int>();

        // This is used by Indexed image types, but we can override. It will be a 0x04 palette DID.
        // If PaletteColors are set, parts of this will be ignored.
        public uint DefaultPalette;

        // Used to store a custom palette. Each Key represents the PaletteIndex and the Value is the color.
        public Dictionary<int, uint> CustomPaletteColors = new Dictionary<int, uint>();

        public static RenderSurface Unpack(BinaryReader reader)
        {
            RenderSurface obj = new RenderSurface();

            obj.Id = reader.ReadUInt32();
            obj.Unknown = reader.ReadUInt32();
            obj.Width = reader.ReadInt32();
            obj.Height = reader.ReadInt32();
            obj.Format = (ImagePixelFormat)reader.ReadUInt32();

            obj.Colors = GetColorData(reader, obj);

            switch (obj.Format)
            {
                case ImagePixelFormat.PFID_INDEX16:
                    obj.DefaultPalette = reader.ReadUInt32();
                    break;
            }

            return obj;
        }

        private static List<int> GetColorData(BinaryReader reader, RenderSurface obj)
        {
            List<int> colors = new List<int>();
            uint byteLength = reader.ReadUInt32();

            if (byteLength > 0)
            {
                switch (obj.Format)
                {
                    case ImagePixelFormat.PFID_R8G8B8: // RGB format. 3 bytes per pixel
                        for (uint i = 0; i < obj.Height; i++)
                            for (uint j = 0; j < obj.Width; j++)
                            {
                                byte b = reader.ReadByte();
                                byte g = reader.ReadByte();
                                byte r = reader.ReadByte();
                                int color = (r << 16) + (g << 8) + b;
                                colors.Add(color);
                            }

                        break;
                    case ImagePixelFormat.PFID_A8R8G8B8: // ARGB format... Most UI textures fall into this category
                        for (uint i = 0; i < obj.Height; i++)
                            for (uint j = 0; j < obj.Width; j++)
                                colors.Add(reader.ReadInt32());
                        break;
                    case ImagePixelFormat.PFID_INDEX16: // 16 indexed. Textures are colored via a palette.
                        for (uint y = 0; y < obj.Height; y++)
                            for (uint x = 0; x < obj.Width; x++)
                                colors.Add(reader.ReadInt16());
                        break;
                    default:
                        log.Warn("Unhandled ImagePixelFormat " + obj.Format.ToString() + " in RenderSurface " + obj.Id.ToString("X8"));
                        break;
                }
            }
            return colors;
        }

        public byte[] GetPngByteArray()
        {
            var imageArray = new byte[] { };
            if (Colors.Count > 0)
            {
                var image = GetBitmap();
                using (MemoryStream ms = new MemoryStream())
                {
                    // Currently using PNG for use with mordern browsers.
                    image.Save(ms, ImageFormat.Png);
                    imageArray = ms.ToArray();
                }
            }
            return imageArray;
        }

        public Bitmap GetBitmap()
        {
            Bitmap image = new Bitmap(Width, Height);
            switch (this.Format)
            {
                case ImagePixelFormat.PFID_R8G8B8:
                    for (int i = 0; i < Height; i++)
                        for (int j = 0; j < Width; j++)
                        {
                            int idx = (i * Height) + j;
                            int r = (Colors[idx] & 0xFF0000) >> 16;
                            int g = (Colors[idx] & 0xFF00) >> 8;
                            int b = Colors[idx] & 0xFF;
                            image.SetPixel(j, i, Color.FromArgb(r, g, b));
                        }
                    break;

                case ImagePixelFormat.PFID_A8R8G8B8:
                    for (int i = 0; i < Height; i++)
                        for (int j = 0; j < Width; j++)
                        {
                            int idx = (i * Height) + j;
                            int a = (int)((Colors[idx] & 0xFF000000) >> 24);
                            int r = (Colors[idx] & 0xFF0000) >> 16;
                            int g = (Colors[idx] & 0xFF00) >> 8;
                            int b = Colors[idx] & 0xFF;
                            image.SetPixel(j, i, Color.FromArgb(a, r, g, b));
                        }
                    break;

                case ImagePixelFormat.PFID_INDEX16:
                    Palette pal = PortalDatReader.Current.Unpack<Palette>(DefaultPalette);

                    // Apply any custom palette colors, if any, to our loaded palette (note, this may be all of them!)
                    if (CustomPaletteColors.Count > 0)
                    {
                        foreach (KeyValuePair<int, uint> entry in CustomPaletteColors)
                        {
                            if (entry.Key <= pal.NumColors)
                                pal.Colors[entry.Key] = entry.Value;
                        }
                    }

                    for (int i = 0; i < Height; i++)
                    {
                        for (int j = 0; j < Width; j++)
                        {
                            int idx = (i * Width) + j;
                            int a = (int)((pal.Colors[Colors[idx]] & 0xFF000000) >> 24);
                            int r = (int)(pal.Colors[Colors[idx]] & 0xFF0000) >> 16;
                            int g = (int)(pal.Colors[Colors[idx]] & 0xFF00) >> 8;
                            int b = (int)pal.Colors[Colors[idx]] & 0xFF;
                            image.SetPixel(j, i, Color.FromArgb(a, r, g, b));
                        }
                    }
                    break;
            }
            return image;
        }

        public static RenderSurface FromBitmap(Bitmap surface)
        {
            RenderSurface obj = new RenderSurface();
            
            obj.Unknown = 6;
            obj.Width = surface.Width;
            obj.Height = surface.Height;
            obj.Format = ImagePixelFormat.PFID_A8R8G8B8;
            obj.Colors = GetBitmapColors(surface);

            return obj;
        }

        private static List<int> GetBitmapColors(Bitmap bmp)
        {
            List<int> colors = new List<int>();

            int x, y, rgb, val;
            for (y = 0; y < bmp.Height; y++)
            {
                for (x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    rgb = c.ToArgb();
                    if ((uint)rgb == 0xff000000) // if black
                    {
                        val = 0;
                    }
                    else val = rgb;
                    colors.Add(val);
                }
            }
            return colors;
        }
    }
}