using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;
using System.IO;

namespace IL2ASM
{
    public static class Util
    {
        public static string SafeName(this MethodDef meth)
        {
            return $"{meth.DeclaringType.Namespace}_{meth.DeclaringType.Name}_{meth.Name}";
        }

        public static bool Is(this Instruction ins, string s)
        {
            return ins.OpCode.Code.ToString().IndexOf(s) == 0;
        }

        public static void Start(string file, string args)
        {
            string currentd = Environment.CurrentDirectory;
            Environment.CurrentDirectory = new FileInfo(file).DirectoryName;
            Console.WriteLine($"{new FileInfo(file).Name}:");
            var v = Process.Start(file, args);
            v.WaitForExit();
            Environment.CurrentDirectory = currentd;
        }
    }
}
