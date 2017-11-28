using System;
using PublicResxVs2017Registrator.Areas.FileHandling.Services;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Services;
using PublicResxVs2017Registrator.Infrastructure.ConsoleHandling;

namespace PublicResxVs2017Registrator
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                RegistryPriviligesService.AssureCurrentProcessHasPriviliges();
                var binFiles = BinFileSearchService.LoadAllVs2017BinFiles();
                foreach (var binFile in binFiles)
                {
                    VsHiveRegistryService.TrySettingPublicResxGenerator(binFile);
                }
            }
            catch (Exception ex)
            {
                ConsoleLoggingService.LogErrorMessage($"{ ex.Message }: { ex.StackTrace }");
            }

            ConsoleLoggingService.LogSuccessMessage("Finished! (Press Esc to close)");

            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
    }
}