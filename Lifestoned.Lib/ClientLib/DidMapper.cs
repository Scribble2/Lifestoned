using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestoned.Lib.ClientLib
{
    /// <summary>
    /// These are client_portal.dat files starting with 0x25.
    /// This contains a list of DataIDs (a file in the .dat)
    /// </summary>
    public class DidMapper
    {
        public uint DidMapperId; // The "file" id
        public short DidUnknown, EnumUnknown, Did2Unknown, Enum2Unknown; // Unsure what these are
        public Dictionary<uint, uint> Did = new Dictionary<uint, uint>();
        public Dictionary<uint, string> Enum = new Dictionary<uint, string>();

        // It feels like these are server specific, but that is just a guess - IronGolem
        public Dictionary<int, uint> Did2 = new Dictionary<int, uint>();
        public Dictionary<int, string> Enum2 = new Dictionary<int, string>();
        public uint Unknown_2; // Unsure what this is

        // This is the mapped dictionary, compiled from the Did and Enum Dictionaries
        public Dictionary<uint, string> Enums = new Dictionary<uint, string>();

        public static DidMapper Unpack(BinaryReader reader)
        {
            DidMapper obj = new DidMapper();

            obj.DidMapperId = reader.ReadUInt32();

            obj.DidUnknown = reader.ReadPackedByte();
            short numberDid = reader.ReadPackedByte();
            for (int i = 0; i < numberDid; i++)
            {
                uint key = reader.ReadUInt32();
                uint val = reader.ReadUInt32();
                obj.Did.Add(key, val);
            }

            obj.EnumUnknown = reader.ReadPackedByte();
            short numberEnums = reader.ReadPackedByte();
            for (int i = 0; i < numberEnums; i++)
            {
                uint key = reader.ReadUInt32();
                var name = reader.ReadTabooString();
                obj.Enum.Add(key, name);
            }

            obj.Did2Unknown = reader.ReadPackedByte();
            short numberDid2 = reader.ReadPackedByte();
            for (int i = 0; i < numberDid2; i++)
            {
                int key = reader.ReadInt32();
                uint val = reader.ReadUInt32();
                obj.Did2.Add(key, val);
            }

            obj.Enum2Unknown = reader.ReadPackedByte();
            short numberEnum2 = reader.ReadPackedByte();
            for (int i = 0; i < numberEnum2; i++)
            {
                int key = reader.ReadInt32();
                string val = reader.ReadTabooString();
                obj.Enum2.Add(key, val);
            }

            // Map the Did to the Enum for easier, more practical use
            // Some have multiple mappings, so something to keep in mind!
            foreach (KeyValuePair<uint, uint> entry in obj.Did)
            {
                if (!obj.Enums.ContainsKey(entry.Value))
                    obj.Enums.Add(entry.Value, obj.Enum[entry.Key]);
            }
            foreach (KeyValuePair<int, uint> entry in obj.Did2)
            {
                if (!obj.Enums.ContainsKey(entry.Value))
                    obj.Enums.Add(entry.Value, obj.Enum2[entry.Key]);
            }

            return obj;
        }
    }
}
