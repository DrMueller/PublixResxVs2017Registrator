using System;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Infrastructure;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Models.Native;
using PublicResxVs2017Registrator.Infrastructure.ErrorHandling;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Services
{
    internal static class RegistryPriviligesService
    {
        private const string SeBackupName = "SeBackupPrivilege";
        private const uint SePrivilegeEnabled = 0x00000002;
        private const string SeRestoreName = "SeRestorePrivilege";
        private const uint TokenAdjustPrivileges = 0x0020;
        private const uint TokenQuery = 0x0008;

        internal static void AssureCurrentProcessHasPriviliges()
        {
            var restoreTokenPrivileges = new TokPriv1Luid();
            var backupTokenPrivileges = new TokPriv1Luid();

            var processToken = IntPtr.Zero;
            var restoreLuid = new LUID();
            var backupLuid = new LUID();

            var currentProcess = NativeMethods.GetCurrentProcess();

            InvocationErrorService.HandledInvocationFunc(
                () => NativeMethods.OpenProcessToken(currentProcess, TokenAdjustPrivileges | TokenQuery, out processToken),
                "Could not open the Process token.");

            InvocationErrorService.HandledInvocationFunc(
                () => NativeMethods.LookupPrivilegeValue(null, SeRestoreName, out restoreLuid),
                "Could not find the privileges for restore.");

            InvocationErrorService.HandledInvocationFunc(
                () => NativeMethods.LookupPrivilegeValue(null, SeBackupName, out backupLuid),
                "Could not find the privileges for backup.");

            restoreTokenPrivileges.Attr = SePrivilegeEnabled;
            restoreTokenPrivileges.Luid = restoreLuid;
            restoreTokenPrivileges.Count = 1;
            backupTokenPrivileges.Attr = SePrivilegeEnabled;
            backupTokenPrivileges.Luid = backupLuid;
            backupTokenPrivileges.Count = 1;

            InvocationErrorService.HandledInvocationFunc(
                () => NativeMethods.AdjustTokenPrivileges(processToken, false, ref restoreTokenPrivileges, 0, IntPtr.Zero, IntPtr.Zero),
                "Could not adjust the privileges for restore.");

            InvocationErrorService.HandledInvocationFunc(
                () => NativeMethods.AdjustTokenPrivileges(processToken, false, ref backupTokenPrivileges, 0, IntPtr.Zero, IntPtr.Zero),
                "Could not adjust the privileges for restore.");
        }
    }
}