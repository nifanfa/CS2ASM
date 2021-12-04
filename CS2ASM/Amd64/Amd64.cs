/*
 * Reference: 
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
using System.Text;

namespace CS2ASM
{
    public unsafe class Amd64 : BaseArch
    {
        public override void Setup()
        {
            var methodInfos = from M in typeof(Amd64Transformation).GetMethods()
                              where M.GetCustomAttribute(typeof(ILTransformationAttribute), true) != null
                              select M;
            foreach (var v in methodInfos)
            {
                ILBridgeMethods.Add(v.GetCustomAttributes(true).OfType<ILTransformationAttribute>().First().code, v);
            }

            this.Append($"[bits 64]");
        }

        public override void Translate(MethodDef def, bool isEntryPoint = false)
        {
            //Get All Branches
            var BrS = GetAllBranches(def);

            //Label
            this.Append($"{Amd64.SafeMethodName(def)}:");

            //Call.cs Line 19
            if (!isEntryPoint)
            {
                this.Append($"pop rcx");
                this.Append($"push rbp"); //Save rbp register
                this.Append($"push rcx"); //For ret instruction
            }

            this.Append($"mov rbp,rsp");

            //For Variables
            //pop at Ret.cs
            this.Append($"sub rsp,{def.Body.Variables.Count * 8}");

            //Start Parse IL Code
            for (int i = 0; i < def.Body.Instructions.Count; i++)
            {
                var ins = def.Body.Instructions[i];

                if (DebugEnabled)
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
        }

        public override void InitializeFields(IList<TypeDef> types)
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
                    else
                    {
                        throw new NotImplementedException("Only static fields were supported for now!");
                    }
                }
            }
        }

        public override void CreateTypeDefs(IList<TypeDef> types)
        {
            foreach (var typ in types)
            {
                if (typ.Name == "<Module>") continue;
                string name = SafeTypeName(typ);
                byte[] nameB = Encoding.Unicode.GetBytes(name);
                this.Append($"{name}:");
                this.Append($"dq {nameB.Length}");

                string s = string.Empty;
                for (int i = 0; i < nameB.Length; i++)
                {
                    s += $"{nameB[i]}{(i + 1 == nameB.Length ? "" : ",")}";
                }
                this.Append($"db {s}");
            }
        }

        public override void Append(string s = "")
        {
            s = s.Trim();

            base.Append(s);
        }


        public static string SafeMethodName(MethodDef meth)
        {
            return $"{Amd64.SafeTypeName(meth.DeclaringType)}_{meth.Name}";
        }

        public static string SafeTypeName(TypeDef def)
        {
            return $"{def.Namespace}_{def.Name}";
        }

        public static string SafeFieldName(TypeDef type, FieldDef field)
        {
            return $"{type.Namespace}_{field.Name}";
        }

        public static string BrLabelName(Instruction ins, MethodDef def, bool Create = false)
        {
            return $"{Amd64.SafeMethodName(def)}_IL_{(Create ? ins.Offset : (((Instruction)(ins.Operand)).Offset)):X4}";
        }
    }
}
