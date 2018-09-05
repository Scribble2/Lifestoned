using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestoned.Lib
{
    public class DatEntry
    {
        public uint BitFlags { get; set; }

        public uint ObjectId { get; set; }

        public uint FileOffset { get; set; }

        public uint FileSize { get; set; }

        public uint Date { get; set; }

        public uint Iteration { get; set; }
    }
}
