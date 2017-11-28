using System;
using System.Linq;

namespace PublicResxVs2017Registrator.Areas.FileHandling.Models
{
    internal class BinFile
    {
        public BinFile(string fullPath)
        {
            FullPath = fullPath;
        }

        public string FullPath { get; }

        public string KeyName
        {
            get
            {
                var pathParts = FullPath.Split(new[] { @"\" }, StringSplitOptions.None);
                var result = pathParts.ElementAt(pathParts.Length - 2);
                return result;
            }
        }
    }
}