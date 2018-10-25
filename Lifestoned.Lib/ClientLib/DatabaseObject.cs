using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestoned.Lib.ClientLib
{
    /// <summary>
    /// DBObj in the client
    /// </summary>
    public class DatabaseObject
    {
        /// <summary>
        /// +0x004 m_dataCategory   : Uint4B
        /// </summary>
        public uint DataCategory;

        /// <summary>
        /// +0x008 m_bLoaded        : Bool
        /// </summary>
        public uint IsLoaded;

        /// <summary>
        /// +0x010 m_timeStamp      : Float
        /// </summary>
        public float Timestamp;

        /// <summary>
        /// +0x018 m_pNext          : Ptr32 DBObj
        /// </summary>
        public uint Next;

        /// <summary>
        /// +0x01c m_pLast          : Ptr32 DBObj
        /// </summary>
        public uint Last;

        /// <summary>
        /// +0x020 m_pMaintainer    : Ptr32 DBOCache
        /// </summary>
        public uint Maintainer;

        /// <summary>
        /// +0x024 m_numLinks       : Int4B
        /// </summary>
        public int NumLinks;

        /// <summary>
        /// property instead of a field because it's part of the interface
        /// +0x028 m_DID            : IDClass
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// +0x02c m_AllowedInFreeList : Bool
        /// </summary>
        public bool AllowedInFreeList;
    }
}
