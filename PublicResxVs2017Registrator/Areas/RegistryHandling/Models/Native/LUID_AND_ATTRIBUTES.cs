using System.Runtime.InteropServices;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Models.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct LUID_AND_ATTRIBUTES
    {
        public uint Attributes;
        public LUID pLuid;
    }
}