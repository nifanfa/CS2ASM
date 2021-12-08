using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CS2ASM
{
    public static class Utility
    {
        public static int SizeInStack(FieldDef def)
        {
            if (
                   ((FieldDef)def).FieldType.FullName == "System.Byte" ||
                   ((FieldDef)def).FieldType.FullName == "System.SByte"
                   )
            {
                return 1;
            }
            else if (
                ((FieldDef)def).FieldType.FullName == "System.Char" ||
                ((FieldDef)def).FieldType.FullName == "System.Int16" ||
                ((FieldDef)def).FieldType.FullName == "System.UInt16"
                )
            {
                return 2;
            }
            else if (
               ((FieldDef)def).FieldType.FullName == "System.Int32" ||
               ((FieldDef)def).FieldType.FullName == "System.UInt32"
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
                Index += (ulong)SizeInStack(defs[i]);
            }
            return Index;
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
