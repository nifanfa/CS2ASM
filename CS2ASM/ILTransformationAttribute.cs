using dnlib.DotNet.Emit;
using System;

namespace CS2ASM;

public sealed class ILTransformationAttribute : Attribute
{
    public Code Code;

    public ILTransformationAttribute(Code c) => Code = c;
}