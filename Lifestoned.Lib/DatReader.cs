using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Lifestoned.Lib
{
    public class DatReader
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly string _filePath;
        private uint _blockSize;
        private readonly Dictionary<uint, DatEntry> _tableOfContents = new Dictionary<uint, DatEntry>();

        private readonly ConcurrentDictionary<Type, MethodInfo> _reflectionCache = new ConcurrentDictionary<Type, MethodInfo>();
        private readonly ConcurrentDictionary<uint, object> _dataCache = new ConcurrentDictionary<uint, object>();

        public DatReader(string filePath)
        {
            _filePath = filePath;
            BuildTableOfContents();
        }

        public IReadOnlyDictionary<uint, DatEntry> TableOfContents
        {
            get => _tableOfContents;
        }

        public IReadOnlyDictionary<uint, object> Cache
        {
            get => _dataCache;
        }

        private void BuildTableOfContents()
        {
            // read file to build ToC
            using (FileStream stream = new FileStream(_filePath, FileMode.Open))
            {
                byte[] blockSizeBuffer = new byte[4];
                stream.Seek(0x144u, SeekOrigin.Begin);
                stream.Read(blockSizeBuffer, 0, sizeof(uint));
                _blockSize = BitConverter.ToUInt32(blockSizeBuffer, 0);

                stream.Seek(0x160u, SeekOrigin.Begin);
                byte[] firstDirBuffer = new byte[4];
                stream.Read(firstDirBuffer, 0, sizeof(uint));
                uint firstDirectoryOffset = BitConverter.ToUInt32(firstDirBuffer, 0);

                ReadDatDirectory(stream, firstDirectoryOffset);
            }
        }

        private void ReadDatDirectory(FileStream stream, uint offset)
        {
            byte[] blockHeader = new byte[_blockSize];
            stream.Seek(offset, SeekOrigin.Begin);

            stream.Read(blockHeader, 0, blockHeader.Length);

            uint nextBlock = BitConverter.ToUInt32(blockHeader, 0);
            uint fileCount = BitConverter.ToUInt32(blockHeader, 252);

            int directories = 0;
            uint directory = BitConverter.ToUInt32(blockHeader, sizeof(uint));
            List<uint> directoryList = new List<uint>();

            while (directories < (fileCount + 1) && directory > 0)
            {
                directoryList.Add(directory);
                directories++;
                directory = BitConverter.ToUInt32(blockHeader, (1 + directories) * sizeof(uint));
            }

            // directories done, on to files

            uint blockArrayUsage = 0;

            // buffer for 10 blocks just in case
            byte[] block = new byte[(_blockSize - 4) * 10];

            if (_blockSize > 256)
            {
                Array.Copy(blockHeader, 256, block, 0, _blockSize - 256);
                blockArrayUsage += (_blockSize - 256);
            }

            // separate buffer for the next block location
            byte[] nextBlockBuffer = new byte[4];

            while (nextBlock > 0)
            {
                // go to this block
                stream.Seek(nextBlock, SeekOrigin.Begin);

                // read the next block pointer
                stream.Read(nextBlockBuffer, 0, sizeof(uint));

                // read this block
                stream.Read(block, (int)blockArrayUsage, ((int)_blockSize - 4));

                // maths for next loop
                blockArrayUsage += (_blockSize - 4);
                nextBlock = BitConverter.ToUInt32(nextBlockBuffer, 0);
            }

            // block has all the daters

            // read all the files
            for (int i = 0; i < fileCount; i++)
            {
                int entryOffset = i * 6 * sizeof(uint);

                DatEntry de = new DatEntry()
                {
                    BitFlags = BitConverter.ToUInt32(block, entryOffset),
                    ObjectId = BitConverter.ToUInt32(block, entryOffset + 4),
                    FileOffset = BitConverter.ToUInt32(block, entryOffset + 8) + 4,
                    FileSize = BitConverter.ToUInt32(block, entryOffset + 12),
                    Date = BitConverter.ToUInt32(block, entryOffset + 16),
                    Iteration = BitConverter.ToUInt32(block, entryOffset + 20)
                };

                _tableOfContents.Add(de.ObjectId, de);
            }

            // files done, go back and iterate directories
            foreach (uint directoryOffset in directoryList)
            {
                ReadDatDirectory(stream, directoryOffset);
            }
        }

        public T Unpack<T>(uint fileId) where T : class
        {
            if (!_tableOfContents.ContainsKey(fileId))
            {
                log.Warn($"{typeof(T).Name} of file id {fileId:x8} was requested but not found.");
                return null;
            }

            if (_dataCache.ContainsKey(fileId))
                return (T)_dataCache[fileId];

            MethodInfo method;

            if (!_reflectionCache.ContainsKey(typeof(T)))
            {
                method = typeof(T).GetMethod("Unpack", new[] { typeof(BinaryReader) });

                if (method == null || !method.IsStatic)
                {
                    // check for 1 other method that takes a BinaryReader and DatReader (ie, Landblocks)
                    method = typeof(T).GetMethod("Unpack", new[] { typeof(BinaryReader), typeof(DatReader) });
                }

                if (method == null || !method.IsStatic)
                {
                    log.Error($"type {typeof(T).Name} was asked to be Unpacked but no matching method signature was found.");
                    throw new ArgumentException($"type {typeof(T).Name} does not have a static Unpack(BinaryReader[, DatReader]) method");
                }

                _reflectionCache.TryAdd(typeof(T), method);
            }
            else
            {
                method = _reflectionCache[typeof(T)];
            }
            
            byte[] data = GetRawFile(fileId);

            using (var reader = new BinaryReader(new MemoryStream(data)))
            {
                T result;
                if (method.GetParameters().Length == 1)
                    result = (T)method.Invoke(null, new object[] { reader });
                else // (method.GetParameters().Length == 2)
                    result = (T)method.Invoke(null, new object[] { reader, this });

                _dataCache.TryAdd(fileId, result);
                return result;
            }
        }

        public byte[] GetRawFile(uint fileId)
        {
            if (!_tableOfContents.ContainsKey(fileId))
            {
                log.Warn($"file id {fileId:x8} was requested but not found.");
                return null;
            }

            DatEntry de = _tableOfContents[fileId];
            byte[] results = new byte[de.FileSize];

            using (var stream = File.OpenRead(_filePath))
            {
                byte[] addressBuffer = new byte[4];
                uint address = de.FileOffset;
                int bytesRead = 0;
                int remainingBytes = (int)de.FileSize;
                address -= 4; // before the block is the "next" address

                while (remainingBytes > 0)
                {
                    int bytesToRead;
                    stream.Seek(address, SeekOrigin.Begin);
                    stream.Read(addressBuffer, 0, 4);
                    address = BitConverter.ToUInt32(addressBuffer, 0);

                    if (remainingBytes > _blockSize)
                        bytesToRead = (int)_blockSize - 4;
                    else
                        bytesToRead = remainingBytes;

                    stream.Read(results, bytesRead, bytesToRead);
                    bytesRead += bytesToRead;
                    remainingBytes -= bytesToRead;
                }
            }

            return results;
        }
    }
}
