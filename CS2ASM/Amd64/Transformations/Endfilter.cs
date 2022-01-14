using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Endfilter)]
        public static void Endfilter(Context context)
        {
            throw new NotImplementedException("Endfilter is not implemented");
        }
    }
}
