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

namespace CS2ASM.AMD64
{
    public class Amd64 : BaseArch
    {
        public override int PointerSize => 8;

        public Amd64(ModuleDefMD md) : base(md) {}

        public override void Before(ModuleDefMD def)
        {
            Append("[bits 64]");
        }

        public override void Translate(MethodDef def)
        {
            if (!def.HasBody)
                return;

            if (Debug)
                Append($";>>>>>{def}>>>>>");

            // Get All Branches
            var brS = GetAllBranches(def).ToArray();

            // Label
            Append(Utility.SafeMethodName(def, def.MethodSig) + ":");

            if (!IsAssemblyMethod(def))
            {
                var cnt = def.MethodSig.Params.Count + (def.MethodSig.HasThis ? 1 : 0);
                // Call.cs Line 19
                Append("push rbp");
                Append("mov rbp,rsp");

                var rsv = (cnt + def.Body.Variables.Count) * 8;
                if (rsv != 0)
                    Append("sub rsp," + rsv);

                //if (IsDebugMethod(def))
                if (cnt <= 6)
                {
                    if (cnt >= 1)
                        Append($"mov [rbp-{cnt * 8}],rdi");
                    if (cnt >= 2)
                        Append($"mov [rbp-{(cnt - 1) * 8}],rsi");
                    if (cnt >= 3)
                        Append($"mov [rbp-{(cnt - 2) * 8}],rdx");
                    if (cnt >= 4)
                        Append($"mov [rbp-{(cnt - 3) * 8}],rcx");
                    if (cnt >= 5)
                        Append($"mov [rbp-{(cnt - 4) * 8}],r8");
                    if (cnt == 6)
                        Append("mov [rbp-8],r9");
                }
                else
                    throw new ArgumentOutOfRangeException(nameof(cnt), "Too much arguments!");
            }

            if (def == CompilerMethods[Methods.InitialiseStatics])
                InitializeStaticConstructor((ModuleDefMD)def.Module);

            var ctx = new Context(text, null, def, this)
            {
                StackOperationCount = 0
            };

            // Start parsing CIL code
            for (InstructionIndex = 0; InstructionIndex < def.Body.Instructions.Count; InstructionIndex++)
            {
                var ins = def.Body.Instructions[InstructionIndex];

                if (Debug)
                    Append(";" + ins);

                // For branches
                foreach (var v in brS)
                    if (((Instruction)v.Operand).Offset == ins.Offset)
                        Append(Utility.BrLabelName(ins, def, true) + ":");

                ctx.ins = ins;

                // Compile CIL instructions
                IlBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] { ctx });
                Append(";stack op count;" + ctx.StackOperationCount);
            }

            if (ctx.StackOperationCount != 0)
                Append(";Stack issue: " + ctx.StackOperationCount);

            if (Debug)
                Append($";<<<<<{def}<<<<<");
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

        public override void InitializeStaticFields(TypeDef typ)
        {
            foreach (var v in typ.Fields)
            {
                if (!v.IsStatic)
                    continue;

                // Ldsfld
                // Stsfld
                Append(Utility.SafeFieldName(typ, v) + ":");
                Append("dq " + (v.HasConstant ? v.Constant.Value : 0));
            }
        }

        public override void Append(string str)
        {
            base.Append(str.Trim());
        }

        internal override void After(ModuleDefMD def) {}

        public override void InitializeStaticConstructor(ModuleDefMD def)
        {
            foreach (var t in def.Types)
                foreach (var m in t.Methods)
                    if (m.IsStaticConstructor)
                        Append("call " + Utility.SafeMethodName(m, m.MethodSig));
        }

        public override void JumpToEntry(ModuleDefMD def)
        {
            Append("call " + GetCompilerMethod(Methods.EntryPoint));
        }
    }
}
