using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newobj)]
        public static void Newobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            int argumentNum = 0;
            if(ins.Operand is MemberRef) 
            {
                argumentNum = ((MemberRef)ins.Operand).MethodSig.Params.Count;
            }
            else 
            {
                argumentNum = ((MethodDef)ins.Operand).MethodSig.Params.Count;
            }

            Sizeof(arch, new Instruction() { Operand = ins.Operand is MemberRef ? ((MemberRef)ins.Operand).DeclaringType.ScopeType : ((MethodDef)ins.Operand).DeclaringType }, def);
            arch.Append($"call System.GC.Allocate.UInt64");

            //Get result value from System.GC.Allocate.UInt64 and make a copy for ldloc because call will pop the params
            arch.Append($"pop r15");
            arch.Append($"push r15");
            arch.Append($"push r15");

            if (argumentNum != 0) 
            {
                //Move up stack
                for(int i = 0; i < argumentNum; i++) 
                {
                    arch.Append($"mov rax,[rsp+{(i+1) * 8}]");
                    arch.Append($"mov [rsp+{(i) * 8}],rax");
                }

                arch.Append($"mov [rsp+{(argumentNum + 0) * 8}],r15");
                //For ldloc
                arch.Append($"mov [rsp+{(argumentNum + 1) * 8}],r15");
            }

            Sizeof(arch, new Instruction() { Operand = ins.Operand is MemberRef ? ((MemberRef)ins.Operand).DeclaringType.ScopeType : ((MethodDef)ins.Operand).DeclaringType }, def);

            //Object.Size
            arch.Append($"xor rdx,rdx");
            arch.Append($"pop rcx");
            arch.Append($"mov [r15],rcx");

            if (ins.Operand is MemberRef)
            {
                arch.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)ins.Operand).DeclaringType.ScopeType,Name = ((MemberRef)ins.Operand).Name}, ((MemberRef)ins.Operand).MethodSig)}");
            }
            else
            {
                arch.Append($"call {Utility.SafeMethodName((MethodDef)ins.Operand, ((MethodDef)ins.Operand).MethodSig)}");
            }
        }
    }
}
