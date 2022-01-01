using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Newobj)]
        public static void Newobj(BaseArch arch, Instruction ins, MethodDef def)
        {
            Sizeof(arch, new Instruction() { Operand = ins.Operand is MemberRef ? ((MemberRef)ins.Operand).DeclaringType.ScopeType : ((MethodDef)ins.Operand).DeclaringType }, def);
            arch.Append($"call System.GC.Allocate.UInt64");
            arch.Append($"pop rax");
            arch.Append($"push rax");
            arch.Append($"mov r15,rax");

            if (ins.Operand is MemberRef)
                arch.Append($"call {Utility.SafeMethodName(new MethodDefUser() { DeclaringType = (TypeDef)((MemberRef)ins.Operand).DeclaringType.ScopeType,Name = ((MemberRef)ins.Operand).Name}, ((MemberRef)ins.Operand).MethodSig)}");
            else
                arch.Append($"call {Utility.SafeMethodName((MethodDef)ins.Operand, ((MethodDef)ins.Operand).MethodSig)}");

            Sizeof(arch, new Instruction() { Operand = ins.Operand is MemberRef ? ((MemberRef)ins.Operand).DeclaringType.ScopeType : ((MethodDef)ins.Operand).DeclaringType }, def);

            //Object.Size
            arch.Append($"xor rdx,rdx");
            arch.Append($"pop rdx");
            arch.Append($"push r15");
            arch.Append($"add [r15],rdx");
        }
    }
}
