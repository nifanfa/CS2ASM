using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    class ILTransformationAttribute : Attribute
    {
        public Code code;

        public ILTransformationAttribute(Code c)
        {
            this.code = c;
        }
    }
}
