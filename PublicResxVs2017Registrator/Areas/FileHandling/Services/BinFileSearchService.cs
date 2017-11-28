using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PublicResxVs2017Registrator.Areas.FileHandling.Models;

namespace PublicResxVs2017Registrator.Areas.FileHandling.Services
{
    internal static class BinFileSearchService
    {
        internal static IReadOnlyCollection<BinFile> LoadAllVs2017BinFiles()
        {
            var mainVspath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "VisualStudio");
            var vs2017Directories = Directory.GetDirectories(mainVspath, "15.0_*");

            var result = new List<BinFile>();

            foreach (var dir in vs2017Directories)
            {
                var binFilePath = Directory.GetFiles(dir, "privateregistry.bin").FirstOrDefault();
                if (binFilePath != null)
                {
                    result.Add(new BinFile(binFilePath));
                }
            }

            return result;
        }
    }
}