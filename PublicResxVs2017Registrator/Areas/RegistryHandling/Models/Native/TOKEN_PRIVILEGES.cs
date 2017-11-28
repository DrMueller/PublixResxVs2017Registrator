using System.Runtime.InteropServices;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Models.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TOKEN_PRIVILEGES
    {
        public int Attributes;
        public LUID Luid;
        public int PrivilegeCount;
    }
}