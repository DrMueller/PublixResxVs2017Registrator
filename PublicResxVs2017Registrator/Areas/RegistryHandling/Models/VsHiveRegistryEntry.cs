using System;
using Microsoft.Win32;
using PublicResxVs2017Registrator.Areas.FileHandling.Models;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Infrastructure;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Models.Native;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Models
{
    internal class VsHiveRegistryEntry : IDisposable
    {
        private readonly BinFile _binFile;

        public VsHiveRegistryEntry(BinFile binFile)
        {
            _binFile = binFile;
            NativeMethods.RegLoadKey((uint)HKEY.USERS, binFile.KeyName, binFile.FullPath);
        }

        internal void SetResxExValues(string generatorGuid)
        {
            var subPath = CreateSubPath();
            var subKeyPath = $@"{ subPath }\{{{generatorGuid}}}\PublicResXFileCodeGeneratorEx";
            var subKey = Registry.Users.OpenSubKey(subKeyPath, true) ?? Registry.Users.CreateSubKey(subKeyPath, true);

            subKey.SetValue(string.Empty, "Extended PublicResXFileCodeGenerator");
            subKey.SetValue("CLSID", "{67a13f54-4297-4df2-abfd-cdb88a340288}");
            subKey.SetValue("GeneratesDesignTimeSource", "dword:00000001");
        }

        internal bool HiveIsLoaded
        {
            get
            {
                var subPath = CreateSubPath();
                var regKey = Registry.Users.OpenSubKey(subPath);
                return regKey != null;
            }
        }

        public void Dispose()
        {
            try
            {
                NativeMethods.RegUnLoadKey((uint)HKEY.USERS, _binFile.KeyName);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception)
            {
            }
        }

        private string CreateSubPath()
        {
            var result = $@"{_binFile.KeyName}\Software\Microsoft\VisualStudio\{_binFile.KeyName}_Config\Generators";
            return result;
        }
    }
}