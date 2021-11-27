﻿using dnlib.DotNet.Emit;
using System;
using System.Diagnostics;
using System.IO;

namespace IL2ASM
{
    public static class Util
    {
        public static string SafeName(this string s)
        {
            s = s.Replace(".", "_");
            s = s.Replace(":", "_");
            return s;
        }

        public static bool Is(this Instruction ins, string s)
        {
            return ins.OpCode.Code.ToString().IndexOf(s) == 0;
        }

        public static void Start(string file, string args)
        {
            string currentd = Environment.CurrentDirectory;
            Environment.CurrentDirectory = new FileInfo(file).DirectoryName;
            var v = Process.Start(file, args);
            v.WaitForExit();
            Environment.CurrentDirectory = currentd;
        }
    }
}
