using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
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
