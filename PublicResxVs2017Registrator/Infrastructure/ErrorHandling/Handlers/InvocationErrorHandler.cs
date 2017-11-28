using System;
using System.ComponentModel;

namespace PublicResxVs2017Registrator.Infrastructure.ErrorHandling.Handlers
{
    internal static class InvocationErrorHandler
    {
        internal static void CheckThrowInvocationException(int resultCode)
        {
            if (resultCode != 0)
            {
                throw new Win32Exception(resultCode);
            }
        }

        internal static void CheckThrowInvocationException(bool invocationResult, string errorText)
        {
            if (!invocationResult)
            {
                throw new Exception(errorText);
            }
        }
    }
}