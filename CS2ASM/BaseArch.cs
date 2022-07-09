using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CS2ASM
{
    public enum Methods
    {
        ASM,
        Allocate,
        StringCtor,
        Dispose,
        ArrayCtor,
        Stackalloc,
        InitialiseStatics,
        EntryPoint,
        Newobj
    }

    public abstract class BaseArch
    {
        public Dictionary<Methods, MethodDef> CompilerMethods = new();
        public ModuleDefMD module;

        public BaseArch(ModuleDefMD md)
        {
            module = md;
            if (Utility.SizeOf(module, "System.Object") != 8) 
            {
                throw new Exception("Invalid Structure Of System.Object");
            }
            if (Utility.SizeOf(module, "System.Array") != 16)
            {
                throw new Exception("Invalid Structure Of System.Array");
            }
            if (Utility.SizeOf(module, "System.String") != 24)
            {
                throw new Exception("Invalid Structure Of System.String");
            }
        }

        public void ImportCompilerMethods(ModuleDef def) 
        {
            foreach(var t in def.Types) 
            {
                foreach(var m in t.Methods) 
                {
                    foreach(var a in m.CustomAttributes) 
                    {
                        if (a.TypeFullName == "System.Runtime.CompilerServices.CompilerMethodAttribute") 
                        {
                            var v = a.ConstructorArguments[0].Value;
                            if (Enum.IsDefined(typeof(Methods), v)) 
                            {
                                CompilerMethods.Add((Methods)v, m);
                            }
                            else 
                            {
                                throw new KeyNotFoundException();
                            }
                        }
                    }
                }
            }
            if (CompilerMethods.Count != Enum.GetNames(typeof(Methods)).Length) 
            {
                throw new KeyNotFoundException();
            }
        }

        public string GetCompilerMethod(Methods methods) 
        {
            return Utility.SafeMethodName(CompilerMethods[methods], CompilerMethods[methods].MethodSig);
        }

        public void ImportTransformations(Type transformations)
        {
            var methodInfos = from M in transformations.GetMethods()
                              where M.GetCustomAttribute(typeof(ILTransformationAttribute), true) != null
                              select M;
            foreach (var v in methodInfos)
            {
                ILBridgeMethods.Add(v.GetCustomAttributes(true).OfType<ILTransformationAttribute>().First().code, v);
            }
        }

        public bool Debug = true;
        public StringBuilder text = new();

        public int InstructionIndex;

        public abstract int PointerSize { get; }

        public void SkipNextInstruction()
        {
            InstructionIndex++;
        }

        public virtual void Append(string s = "")
        {
            text.AppendLine(s);
        }

        public Dictionary<Code, MethodInfo> ILBridgeMethods = new();
        
        public abstract void Translate(MethodDef meth);
        public abstract void InitializeStaticFields(TypeDef typ);
        public IEnumerable<Instruction> GetAllBranches(MethodDef def)
        {
            return from Br in def.Body.Instructions
                   where
(
Br.OpCode.Code == Code.Br ||
Br.OpCode.Code == Code.Brfalse ||
Br.OpCode.Code == Code.Brfalse_S ||
Br.OpCode.Code == Code.Brtrue ||
Br.OpCode.Code == Code.Brtrue_S ||
Br.OpCode.Code == Code.Br_S ||
Br.OpCode.Code == Code. Bne_Un ||
Br.OpCode.Code == Code. Bne_Un_S ||
Br.OpCode.Code == Code. Beq ||
Br.OpCode.Code == Code. Beq_S ||
Br.OpCode.Code == Code. Ble ||
Br.OpCode.Code == Code. Blt ||
Br.OpCode.Code == Code. Blt_S ||
Br.OpCode.Code == Code. Blt_Un ||
Br.OpCode.Code == Code. Blt_Un_S ||
Br.OpCode.Code == Code. Ble_S ||
Br.OpCode.Code == Code. Ble_Un ||
Br.OpCode.Code == Code. Ble_Un_S ||
Br.OpCode.Code == Code. Bge ||
Br.OpCode.Code == Code. Bge_Un ||
Br.OpCode.Code == Code. Bge_S ||
Br.OpCode.Code == Code. Bge_Un_S ||
Br.OpCode.Code == Code. Bgt ||
Br.OpCode.Code == Code. Bgt_S ||
Br.OpCode.Code == Code. Bgt_Un ||
Br.OpCode.Code == Code. Bgt_Un_S
)
                   select Br;
        }

        public abstract void InitializeStaticConstructor(ModuleDefMD def);
        public abstract void JumpToEntry(ModuleDefMD def);
        internal abstract void After(ModuleDefMD def);
        public abstract void Before(ModuleDefMD def);
    }
}
