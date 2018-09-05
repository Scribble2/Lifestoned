using System;

namespace Lifestoned.Lib.ClientLib.Enum
{
    [Flags]
    public enum RegionPartsMask
    {
        Sound       = 1,   // 0x001
        Scene       = 2,   // 0x002

        /// <summary>
        /// unused
        /// </summary>
        Terrain     = 4,   // 0x004

        /// <summary>
        /// unused
        /// </summary>
        Encounter   = 8,   // 0x008
        Sky         = 16,  // 0x010

        /// <summary>
        /// unused
        /// </summary>
        Fog         = 64,  // 0x040

        /// <summary>
        /// unused
        /// </summary>
        DistanceFog = 128, // 0x080

        /// <summary>
        /// unused
        /// </summary>
        Map         = 256, // 0x100
        Misc        = 512, // 0x200
    }
}
