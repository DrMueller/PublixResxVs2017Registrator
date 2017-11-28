using System;

namespace PublicResxVs2017Registrator.Infrastructure.ConsoleHandling
{
    internal static class ConsoleLoggingService
    {
        internal static void LogErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal static void LogSuccessMessage(string successMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(successMessage);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}