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
        public StringWriter _Code = new StringWriter();
        public bool DebugEnabled = true;

        public void Append(string s = "")
        {
            if (s.Length != 0 && s[0] == ';')
                Console.ForegroundColor = ConsoleColor.DarkGray;
            _Code.WriteLine(s);
            //Console.WriteLine(s);
            if (s.Length != 0 && s[0] == ';') Console.ResetColor();
        }

        public Dictionary<Code, MethodInfo> ILBridgeMethods = new Dictionary<Code, MethodInfo>();
        public abstract void Translate(MethodDef meth, bool isEntryPoint = false);
        public abstract void InitializeFields(TypeDef typ);
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
Br.OpCode.Code == Code.Br_S
)
                   select Br;
        }
        public abstract void Setup();
    }
}
