using dnlib.DotNet;
using System;
using System.IO;

namespace IL2ASM
{
    public abstract unsafe class Arch
    {
        public const ulong ReservedStack = 1;
        public static StringWriter _Code = new StringWriter();
        public static delegate*<string, void> Writer = &Append;

        public static void Append(string s = "")
        {
            if (s.Length != 0 && s[0] == ';')
                Console.ForegroundColor = ConsoleColor.DarkGray;
            _Code.WriteLine(s);
            Console.WriteLine(s);
            if (s.Length != 0 && s[0] == ';') Console.ResetColor();
        }

        public abstract void Compile(MethodDef meth, bool isEntryPoint = false);

        public abstract void Setup();
    }
}
