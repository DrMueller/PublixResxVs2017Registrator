using System;
using PublicResxVs2017Registrator.Infrastructure.ErrorHandling.Handlers;

namespace PublicResxVs2017Registrator.Infrastructure.ErrorHandling
{
    internal static class InvocationErrorService
    {
        internal static void HandledInvocationFunc(Func<int> invocationFunc)
        {
            var resultCode = invocationFunc();
            InvocationErrorHandler.CheckThrowInvocationException(resultCode);
        }

        internal static void HandledInvocationFunc(Func<bool> invocationFunc, string errorText)
        {
            var invocationResult = invocationFunc();
            InvocationErrorHandler.CheckThrowInvocationException(invocationResult, errorText);
        }
    }
}