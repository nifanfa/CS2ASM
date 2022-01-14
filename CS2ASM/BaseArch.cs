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
        Stackalloc
    }

    public abstract unsafe class BaseArch
    {
        public Dictionary<Methods, MethodDef> CompilerMethods = new Dictionary<Methods, MethodDef>();

        public virtual void ImportCompilerMethods(ModuleDef def) 
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
        }

        public string GetCompilerMethod(Methods methods) 
        {
            return Utility.SafeMethodName(CompilerMethods[methods], CompilerMethods[methods].MethodSig);
        }

        public virtual void ImportTransformations(Type transformations)
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
        public StringBuilder text = new StringBuilder();

        public int InstructionIndex = 0;

        public int PointerSize = 8;

        public void SkipNextInstruction()
        {
            InstructionIndex++;
        }

        public virtual void Append(string s = "")
        {
            text.AppendLine(s);
        }

        public Dictionary<Code, MethodInfo> ILBridgeMethods = new Dictionary<Code, MethodInfo>();
        
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
Br.OpCode.Code == Code. Ble_S ||
Br.OpCode.Code == Code. Ble_Un ||
Br.OpCode.Code == Code. Ble_Un ||
Br.OpCode.Code == Code. Bge ||
Br.OpCode.Code == Code. Bge_Un ||
Br.OpCode.Code == Code. Bge_S ||
Br.OpCode.Code == Code. Bge_Un_S
)
                   select Br;
        }

        public abstract void InitializeStaticConstructor(ModuleDefMD def);
        public abstract void JumpToEntry(ModuleDefMD def);
        internal abstract void After(ModuleDefMD def);
        public abstract void Before(ModuleDefMD def);
    }
}
