using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CS2ASM.AMD64
{
    public static class CStage
    {
        public static unsafe void ImportLib(ModuleDefMD def, BaseArch arch, string fileNameNoExtensionNameAndPath,string ModuleName)
        {
            Utility.Start(@"Amd64\7z.exe", $@"e {new DirectoryInfo(Environment.CurrentDirectory).Parent}\{fileNameNoExtensionNameAndPath}.lib -o{Environment.CurrentDirectory}\Amd64\ *.obj -r -y");
            Utility.Start(@"Amd64\objconv-x64.exe", $"-fnasm {ModuleName}.obj");
            StreamReader str = new StreamReader(@$"Amd64\{ModuleName}.asm");
            string line = string.Empty;
            while ((line = str.ReadLine()) != null)
            {
                if (
                    line.IndexOf("global") == -1 &&
                    line.IndexOf("__CheckForDebuggerJustMyCode") == -1
                    )
                {
                    arch._Code.WriteLine(line);
                }
            }
        }
    }
}
