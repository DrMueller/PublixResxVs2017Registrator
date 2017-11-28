using System;
using Microsoft.Win32;
using PublicResxVs2017Registrator.Areas.FileHandling.Models;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Infrastructure;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Models.Native;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Models
{
    internal class VsHiveSubKey : IDisposable
    {
        private readonly BinFile _binFile;

        public VsHiveSubKey(BinFile binFile)
        {
            _binFile = binFile;
            NativeMethods.RegLoadKey((uint)HKEY.USERS, binFile.KeyName, binFile.FullPath);
        }

        internal bool HiveIsLoaded
        {
            get
            {
                var subPath = CreateGeneratorSubPath();
                var regKey = Registry.Users.OpenSubKey(subPath);
                return regKey != null;
            }
        }

        internal void SetGeneratorExValues(string generatorGuid)
        {
            var subPath = CreateGeneratorSubPath();
            var generatorSubKey = $"{subPath}\\{{{generatorGuid}}}";
            var regKey = Registry.Users.OpenSubKey(generatorSubKey) ?? Registry.Users.CreateSubKey(generatorSubKey, true);

            regKey.SetValue(string.Empty, "Extended PublicResXFileCodeGenerator");
            regKey.SetValue("CLSID", "{67a13f54-4297-4df2-abfd-cdb88a340288}");
            regKey.SetValue("GeneratesDesignTimeSource", "dword:00000001");
        }

        private string CreateGeneratorSubPath()
        {
            var result = $@"{_binFile.KeyName}\Software\Microsoft\VisualStudio\{_binFile.KeyName}_Config\Generators";
            return result;
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
    }
}