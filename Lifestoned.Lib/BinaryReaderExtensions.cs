using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lifestoned.Lib
{
    public static class BinaryReaderExtentions
    {
        /// <summary>
        /// this currently only accounts for strings of length less than 64k
        /// </summary>
        /// <param name="reader"></param>
        public static string ReadPString(this BinaryReader reader, bool align = true)
        {
            ushort len16 = reader.ReadUInt16();
            uint length = len16;

            if (len16 == 0xFFFF)
            {
                length = reader.ReadUInt32();
            }

            byte[] str = reader.ReadBytes((int)length);

            if (align)
            {
                int extraBytes = (sizeof(ushort) + (int)length) & 3;
                if (extraBytes > 0)
                    reader.ReadBytes(4 - extraBytes);
            }

            return Encoding.Default.GetString(str);
        }

        public static short ReadPackedByte(this BinaryReader reader)
        {
            short data = reader.ReadByte();

            if ((data & 0x80) > 0)
            {
                short lowbyte = reader.ReadByte();
                short hiByte = (short)((data & 0x7f) << 8);
                data = (short)(hiByte | lowbyte);
            }

            return data;
        }

        public static string ReadTabooString(this BinaryReader reader)
        {
            ushort len = reader.ReadByte();
            byte[] str = reader.ReadBytes(len);
            return Encoding.Default.GetString(str);
        }
        
        public static uint ReadPackedUint32(this BinaryReader reader, out uint bytesRead)
        {
            short data = reader.ReadByte();
            bytesRead = 1;

            if ((data & 0x80) > 0)
            {
                short lowbyte = reader.ReadByte();
                short hiByte = (short)((data & 0x7f) << 8);
                data = (short)(hiByte | lowbyte);
                bytesRead = 2;
            }

            return (uint)data;
        }

        public static uint ReadPackedUint16(this BinaryReader reader, out uint bytesRead)
        {
            ushort d1 = reader.ReadByte();
            ushort result = d1;
            bytesRead = 1;

            while ((d1 & 0x80u) != 0 && bytesRead < 2)
            {
                result = (ushort)(d1 & 0x7F);
                result = (ushort)(result << 7);
                result |= d1;
                d1 = reader.ReadByte();
                bytesRead++;
            }

            return result;
        }

        public static Plane ReadPlane(this BinaryReader reader)
        {
            Plane p;
            p.Normal = reader.ReadVector();
            p.D = reader.ReadSingle();
            return p;
        }

        /// <summary>
        /// ----- (00516540) --------------------------------------------------------
        /// int __thiscall AC1Legacy::Vector3::UnPack(AC1Legacy::Vector3 *this, void **addr, unsigned int size)
        /// acclient.c 323540
        /// </summary>
        public static Vector3 ReadVector(this BinaryReader reader)
        {
            Vector3 result;
            result.X = reader.ReadSingle();
            result.Y = reader.ReadSingle();
            result.Z = reader.ReadSingle();
            return result;
        }

        // commented until/unless this is needed
        //public static Sphere ReadSphere(this BinaryReader datReader)
        //{
        //    Sphere obj = new Sphere();
        //    obj.Center = new Vector3(datReader.ReadSingle(), datReader.ReadSingle(), datReader.ReadSingle());
        //    obj.Radius = datReader.ReadSingle();
        //    return obj;
        //}
    }
}
