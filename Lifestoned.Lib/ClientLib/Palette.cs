using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestoned.Lib.ClientLib
{
    /// <summary>
    /// Palette in the client
    /// </summary>
    public class Palette : DatabaseObject
    {
        /// <summary>
        /// 0x038 num_colors : Uint4B
        /// </summary>
        public uint NumColors { get; set; }

        /// <summary>
        /// 0x03c min_lighting : Float
        /// </summary>
        public float MinLighting { get; set; }

        /// <summary>
        /// 0x040 ARGB : Ptr32 Uint4B
        /// </summary>
        public uint ARGB { get; set; }

        public List<uint> Colors { get; set; }

        public static Palette Unpack(BinaryReader reader)
        {
            Palette obj = new Palette();
            obj.Id = reader.ReadUInt32();

            obj.NumColors = reader.ReadUInt32();

            for (uint i = 0; i < obj.NumColors; i++)
                obj.Colors.Add(reader.ReadUInt32());
            
            return obj;
        }
    }
}
