using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CS2ASM
{
    public static class Util
    {
        public static int SizeInStack(string Name)
        {
            if (
                   Name == "System.Byte" ||
                   Name == "System.SByte"
                   )
            {
                return 1;
            }
            else if (
                Name == "System.Char" ||
                Name == "System.Int16" ||
                Name == "System.UInt16"
                )
            {
                return 2;
            }
            else if (
               Name == "System.Int32" ||
               Name == "System.UInt32"
               )
            {
                return 4;
            }
            else
            {
                return 8;
            }
        }

        public static ulong IndexInStack(IList<FieldDef> defs,FieldDef def)
        {
            ulong Index = 0;
            for (int i = 0; i < defs.IndexOf(def); i++) 
            {
                Index += (ulong)SizeInStack(defs[i].FieldType.FullName);
            }
            return Index;
        }

        public static ulong SizeOfInStack(IList<FieldDef> defs)
        {
            ulong Size = 0;
            for (int i = 0; i < defs.Count; i++)
            {
                Size += (ulong)SizeInStack(defs[i].FieldType.FullName);
            }
            return Size;
        }

        public static void Start(string file, string args)
        {
            string currentd = Environment.CurrentDirectory;
            Environment.CurrentDirectory = new FileInfo(file).DirectoryName;
            var v = Process.Start(file, args);
            v.WaitForExit();
            Environment.CurrentDirectory = currentd;
        }

        public static void Start(string file, string workdir, string args)
        {
            string currentd = Environment.CurrentDirectory;
            Environment.CurrentDirectory = workdir;
            Console.WriteLine($"{new FileInfo(file).Name}:");
            var v = Process.Start(file, args);
            v.WaitForExit();
            Environment.CurrentDirectory = currentd;
        }
    }
}
