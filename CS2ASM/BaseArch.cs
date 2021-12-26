using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CS2ASM
{
    public abstract unsafe class BaseArch
    {
        public virtual void ImportTransformations(Type transformations)
        {
            ILBridgeMethods = new Dictionary<Code, MethodInfo>();
            var methodInfos = from M in transformations.GetMethods()
                              where M.GetCustomAttribute(typeof(ILTransformationAttribute), true) != null
                              select M;
            foreach (var v in methodInfos)
            {
                ILBridgeMethods.Add(v.GetCustomAttributes(true).OfType<ILTransformationAttribute>().First().code, v);
            }
        }

        public bool Debug = true;
        public StringWriter _Code = new StringWriter();

        public int InstructionIndex = 0;

        public int PointerSize = 8;

        public void SkipNextInstruction()
        {
            InstructionIndex++;
        }

        public virtual void Append(string s = "")
        {
            _Code.WriteLine(s);
        }

        public Dictionary<Code, MethodInfo> ILBridgeMethods = null;
        public abstract void Translate(MethodDef meth);
        public abstract void InitializeStaticFields(IList<TypeDef> types);
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
Br.OpCode.Code == Code. Beq_S
)
                   select Br;
        }

        public abstract void InitializeStaticConstructor(ModuleDefMD def);
        public abstract void JumpToEntry(ModuleDefMD def);
        internal abstract void After(ModuleDefMD def);
        public abstract void Before(ModuleDefMD def);
    }
}
