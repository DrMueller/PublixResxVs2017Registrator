using System.Runtime.InteropServices;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Models.Native
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LUID
    {
        public uint LowPart;
        public int HighPart;
    }
}