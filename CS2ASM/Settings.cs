using System;
using System.Globalization;

namespace CS2ASM;

public enum Architecture { Amd64 }
public enum Format { Bin, Elf }
public enum ImageType { None, Iso }

public class Settings
{
    public string InputFile, OutputFile;
    public uint BaseAddress;
    public Architecture Architecture;
    public Format Format;
    public ImageType ImageType;
    
    public Settings(string[] args)
    {
        foreach (var arg in args)
        {
            if (arg[0] != '-')
            {
                InputFile = arg;
                continue;
            }

            var c = arg[1];
            switch (c)
            {
                case 'o':
                    OutputFile = arg[2..];
                    break;

                case 'a':
                    BaseAddress = arg.Contains("0x") ? uint.Parse(arg[4..], NumberStyles.HexNumber) : uint.Parse(arg[2..]);
                    break;

                case 'c':
                    Architecture = arg[2..].ToLowerInvariant() switch
                    {
                        "amd64" => Architecture.Amd64,
                        _ => throw new Exception("Unsupported architecture!")
                    };
                    break;

                case 'f':
                    Format = arg[2..].ToLowerInvariant() switch
                    {
                        "bin" => Format.Bin,
                        "elf" => Format.Elf,
                        _ => throw new Exception("Unsupported format!")
                    };
                    break;

                case 't':
                    ImageType = arg[2..].ToLowerInvariant() switch
                    {
                        "none" => ImageType.None,
                        "iso" => ImageType.Iso,
                        _ => throw new Exception("Unsupported image type!")
                    };
                    break;
            }
        }
    }
}