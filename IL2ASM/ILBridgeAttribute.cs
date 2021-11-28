using dnlib.DotNet.Emit;
using System;

namespace IL2ASM
{
    class ILBridgeAttribute : Attribute
    {
        public Code code;

        public ILBridgeAttribute(Code c)
        {
            this.code = c;
        }
    }
}
