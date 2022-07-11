/*
 * Reference: 
 * https://sharplab.io/
 */

using CS2ASM.AMD64;
using dnlib.DotNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using DiscUtils.Iso9660;

namespace CS2ASM;

internal class Program
{
    public static string NasmPath = "nasm";
    public static string LldPath = "ld.lld";

    public static void Main(string[] args)
    {
        if (args.Length < 6) 
        {
            if (Debugger.IsAttached) 
            {
                args = "CS2ASM -a0x100000 -camd64 -felf -tiso -ooutput.iso ConsoleApp1.dll".Split(" ");
                goto DebugStart;
            }

            Console.WriteLine("Usage: CS2ASM -a<address> -c<amd64> -f<bin,elf> -t<none,iso> -o<output> <input>");
            Environment.Exit(1);
        }
        DebugStart:

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            NasmPath = "Tools/" + NasmPath;
            LldPath = "cmd";
        }

        var settings = new Settings(args);
        var def = ModuleDefMD.Load(settings.InputFile);
        var stopwatch = new Stopwatch();
        var bin = Path.ChangeExtension(settings.OutputFile, "bin");
        var elf = Path.ChangeExtension(settings.OutputFile, "elf");

        Console.WriteLine("Compiling...");
        stopwatch.Start();

        BaseArch arch;
        switch (settings.Architecture)
        {
            case Architecture.Amd64:
                arch = new Amd64(ref def);
                arch.Debug = false; // Disable this to improve compiler performance
                arch.ImportTransformations(typeof(Amd64Transformation));
                break;
            default: return;
        }

        // TODO: Improve speed by merging the loops

        foreach (var type in def.Types)
            foreach (var method in type.Methods)
            {
                if (method.IsStaticConstructor)
                {
                    arch.InitializeStaticConstructor(method);
                    continue;
                }
                arch.ImportCompilerMethod(method);
            }

        arch.JumpToEntryPoint();
        foreach (var type in def.Types)
        {
            foreach (var method in type.Methods)
                arch.Translate(method);
            arch.InitializeStaticFields(type);
        }

        stopwatch.Stop();
        Console.WriteLine($"Finished compiling! Took {stopwatch.ElapsedMilliseconds} ms.\nAssembling...");
        stopwatch.Restart();

        var format = "bin";
        if (settings.Format == Format.Elf)
            format = settings.Architecture == Architecture.Amd64 ? "elf64" : "elf32";

        File.WriteAllText("Tools/Kernel.asm", arch.Text.ToString());
        Utility.Start(NasmPath, $"-f{format} Tools/EntryPoint.asm -o {bin}");

        // You need to have LLD on your PATH!
        if (settings.Format != Format.Bin)
            Utility.Start(LldPath, $"{(LldPath == "cmd" ? "/c ld.lld " : string.Empty)}-Ttext={settings.BaseAddress} -melf_x86_64 -o {elf} {bin}");

        stopwatch.Stop();
        Console.WriteLine($"Finished assembling! Took {stopwatch.ElapsedMilliseconds} ms.");

        switch (settings.ImageType)
        {
            case ImageType.None: return;
            case ImageType.Iso:
            {
                if (settings.Format == Format.Bin)
                    throw new Exception("Cannot create an ISO image with a kernel of bin format!");
                
                Console.WriteLine("Generating ISO image...");
                stopwatch.Restart();

                using var cd = File.OpenRead("Tools/limine/limine-cd.bin");
                using var sys = File.OpenRead("Tools/limine/limine.sys");
                using var kernel = File.OpenRead(elf);

                var iso = new CDBuilder
                {
                    UseJoliet = true,
                    VolumeIdentifier = def.Assembly.Name,
                    UpdateIsolinuxBootTable = true
                };
                var name = Path.GetFileName(elf);
                iso.AddFile("limine.sys", sys);
                iso.AddFile("limine.cfg", Encoding.ASCII.GetBytes($"TIMEOUT=0\n:{def.Assembly.Name}\nPROTOCOL=multiboot1\nKERNEL_PATH=boot:///{name}"));
                iso.AddFile(name, kernel);
                iso.SetBootImage(cd, BootDeviceEmulation.NoEmulation, 0);
                iso.Build(settings.OutputFile);

                Utility.Start("Tools/limine/limine-deploy", "--force-mbr " + settings.OutputFile);

                stopwatch.Stop();
                Console.WriteLine($"Finished ISO image generation! Took {stopwatch.ElapsedMilliseconds} ms.");
                break;
            }
            default: return;
        }
    }
}