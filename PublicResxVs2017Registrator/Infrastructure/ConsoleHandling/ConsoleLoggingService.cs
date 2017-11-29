using System;

namespace PublicResxVs2017Registrator.Infrastructure.ConsoleHandling
{
    internal static class ConsoleLoggingService
    {
        internal static void LogErrorMessage(string errorMessage)
        {
            Log(errorMessage, ConsoleColor.DarkRed);
        }

        internal static void LogInfoMessage(string infoMessage)
        {
            Log(infoMessage, ConsoleColor.White);
        }

        internal static void LogSuccessMessage(string successMessage)
        {
            Log(successMessage, ConsoleColor.DarkGreen);
        }

        private static void Log(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}