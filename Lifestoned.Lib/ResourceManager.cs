using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lifestoned.Lib.ClientLib;
using Lifestoned.Lib.ClientLib.Enum;

namespace Lifestoned.Lib
{
    public static class ResourceManager
    {
        /// <summary>
        /// Returns RenderSurface for a weenieclass.
        /// </summary>
        public static byte[] GetFullyLayeredPngIcon(int? itemType, uint? underlayDid, uint? overlayDid, uint? iconDid, int? uiEffects)
        {
            return ImageBuilder.GetFullyLayeredPngIcon(itemType, underlayDid, overlayDid, iconDid, (UiEffectIcons?)uiEffects);
        }

    }
}
