using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lifestoned.Lib
{
    /// <summary>
    /// wrapper for reading portal.dat
    /// </summary>
    public class PortalDatReader : DatReader
    {
        private static object _mutex = new object();
        private static PortalDatReader _singleton;

        public static PortalDatReader Current
        { get { return _singleton; } }

        private PortalDatReader(string filePath) : base(filePath)
        {
        }
        
        public static void Initialize(string filePath)
        {
            if (_singleton == null)
            {
                lock (_mutex)
                {
                    if (_singleton == null)
                    {
                        _singleton = new PortalDatReader(filePath);
                    }
                }
            }
        }
    }
}
