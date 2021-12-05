using System;
using System.Diagnostics;
using System.IO;

namespace CS2ASM
{
    public static class Utility
    {
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
