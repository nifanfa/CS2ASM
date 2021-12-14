using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CS2ASM
{
    public static class Util
    {
        public static int SizeOfShallow(string Name)
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

        public static ulong SizeOfOrIndex(TypeDef type, FieldDef def)
        {
            List<IList<FieldDef>> fields = new List<IList<FieldDef>>();
            TypeDef td = type;
            do
            {
                fields.Insert(0, td.Fields);
                //Here is for struct
                if (td.IsValueType) break;
            } while ((td = (TypeDef)td.BaseType) != null);

            ulong Index = 0;
            foreach (var v1 in fields)
            {
                foreach (var v2 in v1)
                {
                    if (v2 == def) break;
                    Index += (ulong)SizeOfShallow(v2.FieldType.FullName);
                }
            }
            return Index;
        }

        public static ulong SizeOf(ModuleDef module, string FullName)
        {
            foreach (var v in module.Types)
            {
                if (v.FullName == FullName)
                {
                    return SizeOfOrIndex(v, null);
                }
            }
            throw new KeyNotFoundException();
        }

        public static string SafeMethodName(MethodDef meth)
        {
            string result = $"{Util.SafeTypeName(meth.DeclaringType)}.{meth.Name}";
            bool dotP = false;
            for (int i = 0; i < meth.Parameters.Count; i++)
            {
                if (meth.Parameters[i].Name != string.Empty)
                {
                    if (!dotP)
                    {
                        result += ".";
                        dotP = true;
                    }
                    result += meth.Parameters[i].Type.TypeName.Replace("*", "");
                    if (i != meth.Parameters.Count - 1)
                        result += ".";
                }
            }
            return result;
        }

        public static string SafeTypeName(TypeDef def)
        {
            return $"{def.Namespace}.{def.Name}";
        }

        public static string SafeFieldName(TypeDef type, FieldDef field)
        {
            return $"{type.Namespace}.{field.Name}";
        }

        public static string BrLabelName(Instruction ins, MethodDef def, bool Create = false)
        {
            return $"{Util.SafeMethodName(def)}.IL.{(Create ? ins.Offset : (((Instruction)(ins.Operand)).Offset)):X4}";
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
