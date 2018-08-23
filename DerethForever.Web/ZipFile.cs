using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;

namespace DerethForever.Web
{
    public class ZipFile
    {
        public string Filename;
        public List<ZippedFile> Files;

        public ZipFile()
        {
            Files = new List<ZippedFile>();
        }

        public void AddFile(string filename, string contents)
        {
            Files.Add(new ZippedFile(filename, contents));
        }

        public byte[] BuildZip()
        {
            var stream = new MemoryStream();
            var zipStream = new ZipOutputStream(stream);

            zipStream.SetLevel(9); // 0-9, 9 being the highest level of compression

            foreach (var file in Files)
            {
                var entry = new ZipEntry(file.Filename);
                entry.DateTime = DateTime.Now;
                entry.Size = file.Contents.Length;

                zipStream.PutNextEntry(entry);

                var bytes = Encoding.UTF8.GetBytes(file.Contents);
                zipStream.Write(bytes, 0, bytes.Length);

                zipStream.CloseEntry();
            }

            zipStream.IsStreamOwner = false;
            zipStream.Flush();
            zipStream.Finish();
            zipStream.Close();

            return stream.ToArray();
        }
    }

    public class ZippedFile
    {
        public string Filename;
        public string Contents;

        public ZippedFile(string filename, string contents)
        {
            Filename = filename;
            Contents = contents;
        }
    }
}
