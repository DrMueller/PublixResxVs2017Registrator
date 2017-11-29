using System.Collections.Generic;
using PublicResxVs2017Registrator.Areas.FileHandling.Models;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Models;
using PublicResxVs2017Registrator.Infrastructure.ConsoleHandling;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Services
{
    // https://stackoverflow.com/questions/7894909/load-registry-hive-from-c-sharp-fails
    internal static class VsHiveRegistryService
    {
        private static readonly List<string> _generatorGuids = new List<string>
        {
            "164B10B9-B200-11D0-8C61-00A0C91E29D5",
            "FAE04EC1-301F-11D3-BF4B-00C04F79EFBC",
            "E6FDF8B0-F3D1-11D4-8576-0002A516ECE8"
        };

        internal static void TrySettingPublicResxGenerator(BinFile binFile)
        {
            using (var registryEntry = new VsHiveRegistryEntry(binFile))
            {
                if (registryEntry.HiveIsLoaded)
                {
                    ConsoleLoggingService.LogInfoMessage($"Trying to set values to Hive { binFile.KeyName }..");
                    SetValuesInSubGeneratorGuids(registryEntry);
                }
            }
        }

        private static void SetValuesInSubGeneratorGuids(VsHiveRegistryEntry registryEntry)
        {
            foreach (var genGuid in _generatorGuids)
            {
                registryEntry.SetResxExValues(genGuid);
            }
        }
    }
}