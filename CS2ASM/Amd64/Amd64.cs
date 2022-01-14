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
using System.Collections.Generic;

namespace CS2ASM.AMD64
{
    public unsafe class Amd64 : BaseArch
    {
        public override void Before(ModuleDefMD def)
        {
            this.PointerSize = 8;

            this.Append($"[bits 64]");
        }

        public override void Translate(MethodDef def)
        {
            if (Debug)
                this.Append($";{new string('>', 20)}{def}{new string('>', 20)}");

            //Get All Branches
            var BrS = GetAllBranches(def);

            //Label
            this.Append($"{Utility.SafeMethodName(def, def.MethodSig)}:");

            if (!Amd64.IsAssemblyMethod(def))
            {
                //Call.cs Line 19
                this.Append($"mov rbx,rbp");
                this.Append($"mov rbp,rsp");

                //For Variables
                //pop at Ret.cs
                this.Append($"sub rsp,{def.Body.Variables.Count * 8}");
                this.Append($"push rbx");
            }

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

                //Compile IL Instructions
                ILBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] {new Context(this.text,ins,def,this)
                });
            }

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
            this.Append($"call {Utility.SafeMethodName(def.EntryPoint, def.EntryPoint.MethodSig)}");
            this.Append($"jmp die");
        }
    }
}
