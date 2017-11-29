using System.Security.Principal;

namespace PublicResxVs2017Registrator.Infrastructure.Application
{
    internal static class StartUpService
    {
        internal static bool CheckIfUserIsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}