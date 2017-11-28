using System.Runtime.InteropServices;

namespace PublicResxVs2017Registrator.Areas.RegistryHandling.Models.Native
{
    // CAREFUL: THE ORDER OF THE FIELDS MATTER, DO NOT CHANGE
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TokPriv1Luid
    {
        public int Count;
        public LUID Luid;
        public uint Attr;
    }
}