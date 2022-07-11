/*
 * Reference: 
 * https://godbolt.org/
 * https://sharplab.io/
 * http://www.cs.albany.edu/~sdc/CSI500/Fal13/Readings/CSPPCh3.pdf
 * https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/x64-architecture
 * https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-6.0
*/

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Linq;

namespace CS2ASM.AMD64;

public class Amd64 : BaseArch
{
    public override int PointerSize => 8;
    
    protected override void Append(string str) => base.Append(str.Trim());

    public Amd64(ref ModuleDefMD md) : base(ref md) => base.Append("[bits 64]");

    public override void JumpToEntryPoint() => Append("call " + GetCompilerMethod(Methods.EntryPoint));

    public override void Translate(MethodDef def)
    {
        if (!def.HasBody)
            return;

        if (Debug)
            base.Append($";>>>>>{def}>>>>>");

        // Get all branches
        var brS = GetAllBranches(def).ToList();

        // Label
        base.Append(Utility.SafeMethodName(def, def.MethodSig) + ":");

        if (!IsAssemblyMethod(def))
        {
            var cnt = def.MethodSig.Params.Count + (def.MethodSig.HasThis ? 1 : 0);
            // Call.cs line 19
            base.Append("push rbp");
            base.Append("mov rbp,rsp");

            var rsv = (cnt + def.Body.Variables.Count) * 8;
            if (rsv != 0)
                base.Append("sub rsp," + rsv);

            //if (IsDebugMethod(def))
            if (cnt <= 6)
            {
                if (cnt >= 1)
                    base.Append($"mov [rbp-{cnt * 8}],rdi");
                if (cnt >= 2)
                    base.Append($"mov [rbp-{(cnt - 1) * 8}],rsi");
                if (cnt >= 3)
                    base.Append($"mov [rbp-{(cnt - 2) * 8}],rdx");
                if (cnt >= 4)
                    base.Append($"mov [rbp-{(cnt - 3) * 8}],rcx");
                if (cnt >= 5)
                    base.Append($"mov [rbp-{(cnt - 4) * 8}],r8");
                if (cnt == 6)
                    base.Append("mov [rbp-8],r9");
            }
            else
                throw new ArgumentOutOfRangeException(nameof(cnt), "Too much arguments!");
        }

        var ctx = new Context(Text, null, def, this)
        {
            StackOperationCount = 0
        };

        // Start parsing CIL code
        for (InstructionIndex = 0; InstructionIndex < def.Body.Instructions.Count; InstructionIndex++)
        {
            var ins = def.Body.Instructions[InstructionIndex];
            if (Debug)
                base.Append(";" + ins);

            // For branches
            foreach (var v in brS)
                if (((Instruction)v.Operand).Offset == ins.Offset)
                {
                    base.Append(Utility.BrLabelName(ins, def, true) + ":");
                    break;
                }

            ctx.ins = ins;

            // Compile CIL instructions
            IlBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] { ctx });
            if (Debug)
                base.Append(";stack op count;" + ctx.StackOperationCount);
        }

        if (!Debug)
            return;

        if (ctx.StackOperationCount != 0)
            base.Append(";Stack issue: " + ctx.StackOperationCount);
        base.Append($";<<<<<{def}<<<<<");
    }
    
    public override void InitializeStaticFields(TypeDef type)
    {
        foreach (var field in type.Fields)
        {
            if (!field.IsStatic)
                continue;

            // Ldsfld
            // Stsfld
            base.Append(Utility.SafeFieldName(type, field) + ":");
            base.Append("dq " + (field.HasConstant ? field.Constant.Value : 0));
        }
    }

    public override void InitializeStaticConstructor(MethodDef method) => base.Append("call " + Utility.SafeMethodName(method, method.MethodSig));

    public override string Push(string register)
    {
        /*StackIndex += PointerSize;
        var index = StackIndex;
        return $"mov qword [rbp+{index}],{register}";*/
        return "push " + register;
    }

    public override string Pop(string register)
    {
        /*var index = StackIndex;
        StackIndex -= PointerSize;
        return $"mov {register},qword [rbp+{index}]";*/
        return "pop " + register;
    }

    public static bool IsAssemblyMethod(MethodDef def)
    {
        foreach (var v in def.CustomAttributes)
            if (v.TypeFullName == "System.Runtime.CompilerServices.AssemblyMethodAttribute")
                return true;
        return false;
    }

    public static bool IsDebugMethod(MethodDef def)
    {
        foreach (var v in def.CustomAttributes)
            if (v.TypeFullName == "System.Runtime.CompilerServices.DebugAttribute")
                return true;
        return false;
    }
}