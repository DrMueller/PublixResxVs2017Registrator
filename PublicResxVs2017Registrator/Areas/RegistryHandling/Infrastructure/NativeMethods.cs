using System;
using System.Runtime.InteropServices;
using PublicResxVs2017Registrator.Areas.RegistryHandling.Models.Native;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Infrastructure
{
    internal static class NativeMethods
    {
        [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
        internal static extern bool AdjustTokenPrivileges(
            IntPtr htok,
            bool disableAllPrivileges,
            ref TokPriv1Luid newState,
            int len,
            IntPtr prev,
            IntPtr relen);

        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetCurrentProcess();

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool LookupPrivilegeValue(string lpSystemName, string lpName, out LUID lpLuid);

        [DllImport("advapi32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int RegLoadKey(uint hKey, string lpSubKey, string lpFile);

        [DllImport("advapi32.dll", SetLastError = true)]
        internal static extern int RegUnLoadKey(uint hKey, string lpSubKey);

        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern int RegCloseKey(uint hKey);

    }
}