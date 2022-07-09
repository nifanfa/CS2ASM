using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace CS2ASM
{
    public static class Utility
    {
        public static int SizeOfShallow(IType type)
        {
            if (type.FullName.Contains("e__FixedBuffer")) 
            {
                return (int)((TypeDef)type.ScopeType).ClassSize;
            }
            string Name = type.FullName;
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

        public static ulong SizeOfOrIndex(TypeDef type, string name)
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
                    if (v2.Name == name) break;
                    if (v2.IsStatic) break;
                    Index += (ulong)SizeOfShallow(v2.FieldType);
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

        public static string SafeMethodName(MethodDef meth, MethodSig msig)
        {
            string result = $"{Utility.SafeTypeName(meth.DeclaringType)}.{meth.Name}";
            bool dotP = false;
            for (int i = 0; i < msig.Params.Count; i++)
            {
                if (!dotP)
                {
                    result += "_";
                    dotP = true;
                }
                result += msig.Params[i].TypeName.Replace("*", "");
                if (i != msig.Params.Count - 1)
                    result += "_";
            }
            result = result.Replace("`", "");
            result = result.Replace("[", "");
            result = result.Replace("]", "");
            return result;
        }

        public static string SafeTypeName(TypeDef def)
        {
            return $"{def.Namespace}.{def.Name}";
        }

        public static string SafeFieldName(TypeDef type, FieldDef field)
        {
            return $"{type.Namespace}.{type.Name}.{field.Name}";
        }

        public static string BrLabelName(Instruction ins, MethodDef def, bool Create = false)
        {
            //Every object has its unique hash code this is why i use it
            return $"LB_{def.GetHashCode():X4}{(Create ? ins.Offset : ((Instruction)(ins.Operand)).Offset):X4}";
        }

        public static void Start(string file, string args, string dir)
        {
            var currentd = Environment.CurrentDirectory;
            Environment.CurrentDirectory = dir;
            Start(file, args);
            Environment.CurrentDirectory = currentd;
        }
        
        public static void Start(string file, string args)
        {
            var psi = new ProcessStartInfo
            {
                FileName = file,
                Arguments = args,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false
            };
            var v = Process.Start(psi);
            v?.WaitForExit();
        }
    }
}
