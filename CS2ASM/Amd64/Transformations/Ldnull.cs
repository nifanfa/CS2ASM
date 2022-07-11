using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldnull)]
        public static void Ldnull(Context context)
        {
            //Here can be implementation of disposing
            context.Append($"mov qword rax,0");
            context.Push($"rax");
            context.StackOperationCount += 1;
        }
    }
}
