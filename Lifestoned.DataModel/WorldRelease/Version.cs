/*****************************************************************************************
Copyright 2018 Dereth Forever

Permission is hereby granted, free of charge, to any person obtaining a copy of this
software and associated documentation files (the "Software"), to deal in the Software
without restriction, including without limitation the rights to use, copy, modify, merge,
publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.
*****************************************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Lifestoned.DataModel.WorldRelease
{
    /// <summary>
    /// A package or container item for a single or group of World Releases
    /// </summary>
    public class Version
    {
        private string _version { get; set; }
        private Release _worldRelease { get; set; }

        /// <summary>
        /// Versions are Named by Tag + DateTimeStamp
        /// versionTag might come from a ConfigurationManager, ie: ConfigurationManager.AppSettings["VersionTag"]
        /// versionDateTimeFormat might come from a ConfigurationManager, ie: ConfigurationManager.AppSettings["VersionDateTimeFormat"]
        /// </summary>
        public Version(string versionTag, string versionDateTimeFormat) {
            _version = versionTag + DateTime.Now.ToString(versionDateTimeFormat);
        }

        /// <summary>
        /// Instances a premade version.
        /// </summary>
        public Version(string versionName)
        {
            _version = versionName;
        }

        /// <summary>
        /// The current Full Release
        /// </summary>
        public Release CurrentFullRelease
        {
            get
            {
                return _worldRelease;
            }
            set {
                _version = value.Version;
                _worldRelease = value;
            }
        }

        /// <summary>
        /// An ordered? list of updates since the last full release.
        /// </summary>
        public List<Release> Partials { get; set; }
    }
}
