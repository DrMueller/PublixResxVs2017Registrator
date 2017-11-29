using PublicResxVs2017Registrator.Areas.FileHandling.Services;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Services;

namespace PublicResxVs2017Registrator.Areas
{
    internal static class RegistryService
    {
        internal static void SetRegistryEntries()
        {
            RegistryPriviligesService.AssureCurrentProcessHasPriviliges();
            var binFiles = BinFileSearchService.LoadAllVs2017BinFiles();
            foreach (var binFile in binFiles)
            {
                VsHiveRegistryService.TrySettingPublicResxGenerator(binFile);
            }
        }
    }
}