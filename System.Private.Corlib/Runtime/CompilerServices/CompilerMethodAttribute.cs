namespace System.Runtime.CompilerServices
{
    public enum Methods
    {
        ASM,
        Allocate,
        StringCtor,
        Dispose,
        ArrayCtor,
        Stackalloc,
        EntryPoint,
        Newobj
    }

    class CompilerMethodAttribute : Attribute
    {
        private Methods Methods;

        public CompilerMethodAttribute(Methods methods) { }
    }
}
