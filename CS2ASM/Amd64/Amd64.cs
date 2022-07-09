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
using System.Collections.Generic;
using System.Diagnostics;

namespace CS2ASM.AMD64
{
    public class Amd64 : BaseArch
    {
        public override int PointerSize => 8;

        public Amd64(ModuleDefMD md) : base(md) {}

        public override void Before(ModuleDefMD def)
        {
            Append($"[bits 64]");
        }

        public override void Translate(MethodDef def)
        {
            if (!def.HasBody) return;
            if (Debug)
                this.Append($";{new string('>', 20)}{def}{new string('>', 20)}");

            //Get All Branches
            var BrS = GetAllBranches(def);

            //Label
            this.Append($"{Utility.SafeMethodName(def, def.MethodSig)}:");

            if (!Amd64.IsAssemblyMethod(def))
            {
                int cnt = def.MethodSig.Params.Count + (def.MethodSig.HasThis ? 1 : 0);
                //Call.cs Line 19
                this.Append($"push rbp");
                this.Append($"mov rbp,rsp");

                int rsv = (cnt + def.Body.Variables.Count) * 8;
                if(rsv!=0)
                    this.Append($"sub rsp,{rsv}");

                //if (IsDebugMethod(def))
                if (cnt <= 6)
                {
                    if (cnt >= 1)
                    {
                        this.Append($"mov [rbp-{(cnt - 0) * 8}],rdi");
                    }
                    if (cnt >= 2)
                    {
                        this.Append($"mov [rbp-{(cnt - 1) * 8}],rsi");
                    }
                    if (cnt >= 3)
                    {
                        this.Append($"mov [rbp-{(cnt - 2) * 8}],rdx");
                    }
                    if (cnt >= 4)
                    {
                        this.Append($"mov [rbp-{(cnt - 3) * 8}],rcx");
                    }
                    if (cnt >= 5)
                    {
                        this.Append($"mov [rbp-{(cnt - 4) * 8}],r8");
                    }
                    if (cnt >= 6)
                    {
                        this.Append($"mov [rbp-{(cnt - 5) * 8}],r9");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Too much argument");
                }
            }

            if(def == CompilerMethods[Methods.InitialiseStatics])
            {
                this.InitializeStaticConstructor((ModuleDefMD)def.Module);
            }

            Context ctx = new Context(this.text, null, def, this);
            ctx.StackOperationCount = 0;

            //Start Parse IL Code
            for (InstructionIndex = 0; InstructionIndex < def.Body.Instructions.Count; InstructionIndex++)
            {
                var ins = def.Body.Instructions[InstructionIndex];

                if (Debug)
                    this.Append($";{ins}");

                //For Branches
                foreach (var v in BrS)
                {
                    if (((Instruction)v.Operand).Offset == ins.Offset)
                    {
                        this.Append($"{Utility.BrLabelName(ins, def, true)}:");
                    }
                }

                ctx.ins = ins;

                //Compile IL Instructions
                ILBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] { ctx });
                this.Append($";stack op count;{ctx.StackOperationCount}");
            }

            if (ctx.StackOperationCount != 0)
                this.Append($";Stack issue: {ctx.StackOperationCount}");

            if (Debug)
                this.Append($";{new string('<', 20)}{def}{new string('<', 20)}");
        }

        public static bool IsAssemblyMethod(MethodDef def)
        {
            foreach (var v in def.CustomAttributes)
            {
                if (v.TypeFullName == "System.Runtime.CompilerServices.AssemblyMethodAttribute")
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsDebugMethod(MethodDef def)
        {
            foreach (var v in def.CustomAttributes)
            {
                if (v.TypeFullName == "System.Runtime.CompilerServices.DebugAttribute")
                {
                    return true;
                }
            }
            return false;
        }

        public override void InitializeStaticFields(TypeDef typ)
        {
            foreach (var v in typ.Fields)
            {
                //Ldsfld
                //Stsfld
                if (v.IsStatic)
                {
                    this.Append($"{Utility.SafeFieldName(typ, v)}:");
                    this.Append($"dq {(v.HasConstant ? v.Constant.Value : 0)}");
                }
            }
        }

        public override void Append(string s = "")
        {
            s = s.Trim();

            base.Append(s);
        }

        internal override void After(ModuleDefMD def)
        {
        }

        public override void InitializeStaticConstructor(ModuleDefMD def)
        {
            foreach (var T in def.Types)
                foreach (var M in T.Methods)
                {
                    if (M.IsStaticConstructor)
                    {
                        this.Append($"call {Utility.SafeMethodName(M, M.MethodSig)}");
                    }
                }
        }

        public override void JumpToEntry(ModuleDefMD def)
        {
            this.Append($"call {GetCompilerMethod(Methods.EntryPoint)}");
            this.Append($"jmp $");
        }
    }
}
