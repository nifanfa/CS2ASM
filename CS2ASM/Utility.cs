using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS2ASM;

public static class Utility
{
    public static int SizeOfShallow(IType type)
    {
        if (type.FullName.Contains("e__FixedBuffer")) 
            return (int)((TypeDef)type.ScopeType).ClassSize;

        switch (type.FullName)
        {
            case "System.Byte":
            case "System.SByte":
                return 1;
            case "System.Char":
            case "System.Int16":
            case "System.UInt16":
                return 2;
            case "System.Int32":
            case "System.UInt32":
                return 4;
            default:
                return 8;
        }
    }

    public static ulong SizeOfOrIndex(TypeDef type, string name)
    {
        var fields = new List<IList<FieldDef>>();
        var td = type;

        do
        {
            fields.Insert(0, td.Fields);
            if (td.IsValueType) // For structures
                break;
        } while ((td = (TypeDef)td.BaseType) != null);

        ulong index = 0;
        foreach (var v1 in fields)
            foreach (var v2 in v1)
            {
                if (v2.Name == name || v2.IsStatic)
                    break;
                index += (ulong)SizeOfShallow(v2.FieldType);
            }

        return index;
    }

    public static ulong SizeOf(ModuleDef module, string fullName)
    {
        foreach (var v in module.Types)
            if (v.FullName == fullName)
                return SizeOfOrIndex(v, null);
        throw new Exception("Could not find type for sizeof: " + fullName);
    }

    public static string SafeMethodName(MethodDef meth, MethodSig msig)
    {
        var result = $"{SafeTypeName(meth.DeclaringType)}.{meth.Name}";
        var dotP = false;

        for (var i = 0; i < msig.Params.Count; i++)
        {
            if (!dotP)
            {
                result += "_";
                dotP = true;
            }

            result += msig.Params[i].TypeName.Replace("*", string.Empty);
            if (i != msig.Params.Count - 1)
                result += "_";
        }
        
        return result
            .Replace("`", string.Empty)
            .Replace("[", string.Empty)
            .Replace("]", string.Empty);
    }

    public static string SafeTypeName(TypeDef def) => $"{def.Namespace}.{def.Name}";

    public static string SafeFieldName(TypeDef type, FieldDef field) => $"{type.Namespace}.{type.Name}.{field.Name}";

    // Every object has its own unique hash code, this is why I use it
    public static string BrLabelName(Instruction ins, MethodDef def, bool create = false) => $"LB_{def.GetHashCode():X4}{(create ? ins.Offset : ((Instruction)ins.Operand).Offset):X4}";

    public static void Start(string file, string args)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = file,
            Arguments = args,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            UseShellExecute = false
        })?.WaitForExit();
    }
}