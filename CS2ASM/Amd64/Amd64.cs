/*
 * Reference: 
 * http://www.cs.albany.edu/~sdc/CSI500/Fal13/Readings/CSPPCh3.pdf
 * 
 * https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/x64-architecture
 * https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-6.0
*/

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CS2ASM
{
    public unsafe class Amd64 : BaseArch
    {
        public override void Setup(ModuleDefMD def)
        {
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
                        this.Append($"call {Amd64.SafeMethodName(M)}");
                    }
                }

            this.Append($"call {Amd64.SafeMethodName(def.EntryPoint)}");
            this.Append();
        }

        public override void Translate(MethodDef def)
        {
            this.Append($";{new string('>', 20)}{def}{new string('>', 20)}");

            //Get All Branches
            var BrS = GetAllBranches(def);

            //Label
            this.Append($"{Amd64.SafeMethodName(def)}:");

            //Call.cs Line 19
            this.Append($"push rbp");
            this.Append($"mov rbp,rsp");

            //For Variables
            //pop at Ret.cs
            this.Append($"sub rsp,{def.Body.Variables.Count * 8}");
            
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
                        this.Append($"{Amd64.BrLabelName(ins, def, true)}:");
                    }
                }

                //Compile IL Instructions
                ILBridgeMethods[ins.OpCode.Code].Invoke(null, new object[] { this, ins, def });
            }

            this.Append($";{new string('<', 20)}{def}{new string('<', 20)}");
            this.Append();
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
                        this.Append($"{Amd64.SafeFieldName(typ, v)}:");
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


        public static string SafeMethodName(MethodDef meth)
        {
            return $"{Amd64.SafeTypeName(meth.DeclaringType)}.{meth.Name}";
        }

        public static string SafeTypeName(TypeDef def)
        {
            return $"{def.Namespace}.{def.Name}";
        }

        public static string SafeFieldName(TypeDef type, FieldDef field)
        {
            return $"{type.Namespace}.{field.Name}";
        }

        public static string BrLabelName(Instruction ins, MethodDef def, bool Create = false)
        {
            return $"{Amd64.SafeMethodName(def)}.IL.{(Create ? ins.Offset : (((Instruction)(ins.Operand)).Offset)):X4}";
        }
    }
}
