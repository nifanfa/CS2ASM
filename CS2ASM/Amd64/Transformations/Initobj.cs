using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Initobj)]
        public static void Initobj(Context context)
        {
            //Amd64.cs Line 47
            context.Append($"add rsp,8"); //clean ldloc/ldsflda/ldflda
            context.StackOperationCount -= 1;

            Sizeof(new Context(context.text, new Instruction() { Operand = (TypeDef)context.operand }, context.def, context.arch));
            context.Pop($"rdi");
            context.StackOperationCount -= 1;
            context.Append($"call {context.arch.GetCompilerMethod(Methods.Allocate)}");
            context.Push($"rax");
            context.StackOperationCount += 1;

            if (context.prevInstruction.OpCode.Code == Code.Ldsflda)
            {
                Stsfld(new Context(context.text, context.prevInstruction, context.def, context.arch));
            }else if(
                context.prevInstruction.OpCode.Code == Code.Ldloca ||
                context.prevInstruction.OpCode.Code == Code.Ldloca_S
                )
            {
                Stloc(new Context(context.text, new Instruction(OpCodes.Stloc, ((int)context.prevInstruction.Operand)), context.def, context.arch));
            }
            else if(context.prevInstruction.OpCode.Code == Code.Ldflda)
            {
                Stfld(new Context(context.text, context.prevInstruction, context.def, context.arch));
            }else
            {
                throw new NotImplementedException("Initobj is not implemented");
            }
        }
    }
}
