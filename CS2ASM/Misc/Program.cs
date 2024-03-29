﻿using dnlib.DotNet.Emit;
using System;
using System.IO;

namespace CS2ASM.Misc
{
    class Program
    {
        public const string NameSpaceName = "CS2ASM";
        public const string ClassName = "Amd64Bridge";

        static unsafe void Main(string[] args)
        {
            string Sample = File.ReadAllText(@"Generator\Sample.cs");

            string[] Names = Enum.GetNames(typeof(Code));
            if (Directory.Exists(@"Output\"))
                Directory.Delete(@"Output\", true);
            Directory.CreateDirectory(@"Output\");
            foreach (var Name in Names)
            {
                string Vari = Sample;
                Vari = Vari.Replace("$NAMESPACE$", NameSpaceName);
                Vari = Vari.Replace("$CLASSNAME$", ClassName);
                Vari = Vari.Replace("$EXCEPTION$", $"throw new NotImplementedException(\"{Name} is not implemented\");");
                Vari = Vari.Replace("$OPCODENAME$", Name);
                File.WriteAllText(@$"Output\{Name}.cs", Vari);

            }
        }
    }
}
