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
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerethForever.Web.Models.WorldRelease
{
    /// <summary>
    /// Database archive of the World
    /// </summary>
    public class WorldRelease
    {
        /// <summary>
        /// Server Name Responsible for creating the World Release
        /// </summary>
        [Display(Name = "Source")]
        public string OriginName { get; set; }

        /// <summary>
        /// CDN or Server URL for the download.
        /// </summary>
        public string ContentUrl { get; set; }

        /// <summary>
        /// URL for the WorldRelease info download (created from this object).
        /// </summary>
        public string ResourceInfoUrl { get; set; }

        /// <summary>
        /// Timestamp when release was cut
        /// </summary>
        [Display(Name = "Release Date")]
        public string ReleaseDateTime { get; set; }

        /// <summary>
        /// Release version string
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Filename of the Archive
        /// </summary>
        [Display(Name = "File")]
        public string FileName { get; set; }

        /// <summary>
        /// Path to the Archive
        /// </summary>
        public string ArchivePath { get; set; }

        /// <summary>
        /// SHA256 Calulcated Hash of the Archive
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Full or Partial Archive type
        /// </summary>
        public ReleaseType Type { get; set; }

        /// <summary>
        /// Previous Release
        /// </summary>
        [Display(Name = "Previous Release")]
        public string PreviousRelease { get; set; }

        /// <summary>
        /// Extracted the pre-pended Tag name, from the Version.
        /// </summary>
        public string TagName
        {

            get
            {
                if (Version?.Length > 0)
                {
                    return Version.Replace(ReleaseDateTime, string.Empty);
                }
                else return string.Empty;
            }
        }

        public bool FileExists
        {
            get
            {
                if (FileName?.Length > 0)
                {
                    var filePath = Path.GetFullPath(Path.Combine(ConfigurationManager.AppSettings["WorldReleaseDir"], FileName));
                    return File.Exists(filePath);
                }
                return false;
            }
        }

        /// <summary>
        /// Silze of the Release in Megabytes
        /// </summary>
        public string FileSize
        {
            get
            {
                if (FileName?.Length > 0)
                {
                    var filePath = Path.GetFullPath(Path.Combine(ConfigurationManager.AppSettings["WorldReleaseDir"], FileName));
                    if (File.Exists(filePath))
                    {
                        long length = new System.IO.FileInfo(filePath).Length;

                        string label = "bytes";

                        if (length > 1000)
                        {
                            length /= 1024;
                            label = "KB";
                        }
                        if (length > 1000)
                        {
                            length /= 1024;
                            label = "MB";
                        }
                        if (length > 1000)
                        {
                            length /= 1024;
                            label = "GB";
                        }

                        return length + label;
                    }
                }
                return string.Empty;
            }
        }
    }
}
