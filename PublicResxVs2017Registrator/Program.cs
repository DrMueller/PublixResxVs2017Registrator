using System;
using PublicResxVs2017Registrator.Areas;
using PublicResxVs2017Registrator.Infrastructure.Application;
using PublicResxVs2017Registrator.Infrastructure.ConsoleHandling;

namespace PublicResxVs2017Registrator
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                if (StartUpService.CheckIfUserIsAdmin())
                {
                    RegistryService.SetRegistryEntries();
                }
                else
                {
                    ConsoleLoggingService.LogErrorMessage("Please start the program as Admin.");
                }
            }

            catch (Exception ex)
            {
                ConsoleLoggingService.LogErrorMessage($"{ex.Message}: {ex.StackTrace}");
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