using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CS2ASM.AMD64
{
    public static class CStage
    {
        public static unsafe void CompileC(ModuleDefMD def, BaseArch arch, string fileNameNoExtensionNameAndPath)
        {
            if (!File.Exists(@"C:\mingw64\bin\gcc.exe"))
            {
                Utility.Start(@"Amd64\mingw64.exe", "-o\"C:\\\" -y");
            }
            Utility.Start(@"C:\mingw64\bin\gcc.exe", new FileInfo(def.Location).DirectoryName, @$"gcc -fno-asynchronous-unwind-tables -O2 -s -c -o {fileNameNoExtensionNameAndPath}.o {fileNameNoExtensionNameAndPath}.c");
            File.Move(new FileInfo(def.Location).DirectoryName + @$"\{fileNameNoExtensionNameAndPath}.o", @$"Amd64\{fileNameNoExtensionNameAndPath}.o", true);
            Utility.Start(@"Amd64\objconv-x64.exe", $"-fnasm {fileNameNoExtensionNameAndPath}.o");
            StreamReader str = new StreamReader(@$"Amd64\{fileNameNoExtensionNameAndPath}.asm");
            string line = string.Empty;
            while ((line = str.ReadLine()) != null)
            {
                if (line.IndexOf("global") != 0)
                {
                    arch._Code.WriteLine(line);
                }
            }
        }
    }
}
