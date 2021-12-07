using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.IO;

namespace CS2ASM.AMD64
{
    public static class LibStage
    {
        public static unsafe void ImportLib(ModuleDefMD def, BaseArch arch, string fileNameNoPath)
        {
            Utility.Start(@"Amd64\7z.exe", $@"e {new DirectoryInfo(Environment.CurrentDirectory).Parent}\{fileNameNoPath} -o{Environment.CurrentDirectory}\Amd64\ *.obj -r -y");
            foreach (var v in new DirectoryInfo(@"Amd64\").GetFiles())
            {
                if (v.Extension != ".obj" || v.Name.Contains("asm")) continue;
                string ModuleName = v.Name.Substring(0, v.Name.Length - v.Extension.Length);
                Utility.Start(@"Amd64\objconv-x64.exe", $"-fnasm {ModuleName}.obj");

                List<string> vs = new List<string>();
                StreamReader str = new StreamReader(@$"Amd64\{ModuleName}.asm");
                string line = string.Empty;
                while ((line = str.ReadLine()) != null)
                {
                    if (
                        !line.Contains("global") &&
                        !line.Contains("extern") &&
                        !line.Contains("__CheckForDebuggerJustMyCode") 
                        )
                    {
                        if (!vs.Contains(line))
                            arch._Code.WriteLine(line);

                        //Preventing label redefined
                        if (line.Contains(":"))
                        {
                            vs.Add(line);
                        }
                    }
                }
                v.Delete();
            }
        }
    }
}
