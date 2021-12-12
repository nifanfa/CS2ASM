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
using System.Linq;
using System.Reflection;

namespace CS2ASM.AMD64
{
    public unsafe class Amd64 : BaseArch
    {
        public override void Before(ModuleDefMD def)
        {
            this.PointerSize = 8;

            var methodInfos = from M in typeof(Amd64Transformation).GetMethods()
                              where M.GetCustomAttribute(typeof(ILTransformationAttribute), true) != null
                              select M;
            foreach (var v in methodInfos)
            {
                ILBridgeMethods.Add(v.GetCustomAttributes(true).OfType<ILTransformationAttribute>().First().code, v);
            }

            this.Append($"[bits 64]");
            
            foreach(var T in def.Types) 
                foreach(var M in T.Methods)
                {
                    if (M.IsStaticConstructor)
                    {
                        this.Append($"call {Util.SafeMethodName(M)}");
                    }
                }

            this.Append($"call {Util.SafeMethodName(def.EntryPoint)}");
            this.Append($"jmp die");

            //For IDT
            this.Append($"%macro procirq 1");
            this.Append($"push rax");
            this.Append($"push rcx");
            this.Append($"push rdx");
            this.Append($"push rbx");
            this.Append($"push rsp");
            this.Append($"push rbp");
            this.Append($"push rsi");
            this.Append($"push rdi");
            this.Append($"push r8");
            this.Append($"push r9");
            this.Append($"push r10");
            this.Append($"push r11");
            this.Append($"push r12");
            this.Append($"push r13");
            this.Append($"push r14");
            this.Append($"push r15");
            this.Append($"push %1"); //This will be cleared automatically after call System.Platform.Amd64.IDT.OnInterrupt
            this.Append($"call System.Platform.Amd64.IDT.OnInterrupt.irq");
            this.Append($"pop r15");
            this.Append($"pop r14");
            this.Append($"pop r13");
            this.Append($"pop r12");
            this.Append($"pop r11");
            this.Append($"pop r10");
            this.Append($"pop r9");
            this.Append($"pop r8");
            this.Append($"pop rdi");
            this.Append($"pop rsi");
            this.Append($"pop rbp");
            this.Append($"pop rsp");
            this.Append($"pop rbx");
            this.Append($"pop rdx");
            this.Append($"pop rcx");
            this.Append($"pop rax");
            this.Append($"iretq");
            this.Append($"%endmacro");
        }

        public override void Translate(MethodDef def)
        {
            this.Append($";{new string('>', 20)}{def}{new string('>', 20)}");

            //Get All Branches
            var BrS = GetAllBranches(def);

            //Label
            this.Append($"{Util.SafeMethodName(def)}:");

            if (!Amd64.IsEmptyMethod(def))
            {
                //Call.cs Line 19
                this.Append($"mov r8,rbp");
                this.Append($"mov rbp,rsp");

                //For Variables
                //pop at Ret.cs
                this.Append($"sub rsp,{def.Body.Variables.Count * 8}");
                this.Append($"push r8");
            }
            
            //Start Parse IL Code
            for (InstructionIndex = 0; InstructionIndex < def.Body.Instructions.Count; InstructionIndex++)
            {
                var ins = def.Body.Instructions[InstructionIndex];

                this.Append($";{ins}");

                //For Branches
                foreach (var v in BrS)
                {
                    if (((Instruction)v.Operand).Offset == ins.Offset)
                    {
                        this.Append($"{Util.BrLabelName(ins, def, true)}:");
                    }
                }

                //Compile IL Instructions
                ILBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] { this, ins, def });
            }

            this.Append($";{new string('<', 20)}{def}{new string('<', 20)}");
            this.Append();
        }

        public static bool IsEmptyMethod(MethodDef def)
        {
            foreach(var v in def.CustomAttributes) 
            {
                if(v.TypeFullName == "System.Runtime.CompilerServices.EmptyMethodAttribute") 
                {
                    return true;
                }
            }
            return false;
        }

        public override void InitializeStaticFields(IList<TypeDef> types)
        {
            foreach (var typ in types)
            {
                foreach (var v in typ.Fields)
                {
                    //Ldsfld
                    //Stsfld
                    if (v.IsStatic)
                    {
                        this.Append($";{v}");
                        this.Append($"{Util.SafeFieldName(typ, v)}:");
                        this.Append($"dq {(v.HasConstant ? v.Constant.Value : 0)}");
                    }
                }
            }
        }

        public override void Append(string s = "")
        {
            s = s.Trim();

            base.Append(s);
        }

        internal override void After()
        {
        }
    }
}
