using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace IL2ASM
{
    public abstract unsafe class Arch
    {
        public StringWriter _Code = new StringWriter();

        public void Append(string s = "")
        {
            if (s.Length != 0 && s[0] == ';')
                Console.ForegroundColor = ConsoleColor.DarkGray;
            _Code.WriteLine(s);
            Console.WriteLine(s);
            if (s.Length != 0 && s[0] == ';') Console.ResetColor();
        }

        public Dictionary<Code, MethodInfo> ILBridgeMethods = new Dictionary<Code, MethodInfo>();
        public abstract void Compile(MethodDef meth, bool isEntryPoint = false);
        public abstract void Setup();
    }
}
