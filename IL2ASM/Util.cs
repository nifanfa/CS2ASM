using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;
using System.IO;

namespace IL2ASM
{
    public static class Util
    {
        public static string SafeMethodName(this MethodDef meth)
        {
            return $"{meth.DeclaringType.Namespace}_{meth.DeclaringType.Name}_{meth.Name}";
        }

        public static string BrLabelName(Instruction ins, MethodDef def, bool Create = false)
        {
            return $"{def.SafeMethodName()}_IL_{(Create ? ins.Offset : (((Instruction)(ins.Operand)).Offset)):X4}";
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
