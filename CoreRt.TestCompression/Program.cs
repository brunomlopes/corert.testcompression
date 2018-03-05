using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace CoreRt.TestCompresssion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using(var stream = File.OpenRead(args[0]))
            using (var compressed = new ZipArchive(stream, ZipArchiveMode.Read))
            {
                foreach (var zipArchiveEntry in compressed.Entries)
                {
                    using (var fileStream = zipArchiveEntry.Open())
                    using (var outputStream = new MemoryStream())
                    {
                        fileStream.CopyTo(outputStream);
                    }

                    Console.WriteLine($"Wrote {zipArchiveEntry.FullName}");
                }
            }

        }
    }
}
