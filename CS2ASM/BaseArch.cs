using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CS2ASM;

public enum Methods
{
    ASM,
    Allocate,
    StringCtor,
    Dispose,
    ArrayCtor,
    Stackalloc,
    EntryPoint,
    Newobj
}

public abstract class BaseArch
{
    public readonly Dictionary<Methods, MethodDef> CompilerMethods;
    public readonly Dictionary<Code, MethodInfo> IlBridgeMethods;
    public readonly StringBuilder Text;
    public bool Debug;
    public int InstructionIndex, StackIndex;
        
    public abstract int PointerSize { get; }
    
    public abstract void JumpToEntryPoint();

    public abstract void Translate(MethodDef method);

    public abstract void InitializeStaticFields(TypeDef type);
    
    public abstract void InitializeStaticConstructor(MethodDef method);

    public abstract string Push(string register);

    public abstract string Pop(string register);

    public BaseArch(ref ModuleDefMD md)
    {
        CompilerMethods = new();
        IlBridgeMethods = new();
        Text = new();

        if (Utility.SizeOf(md, "System.Object") != 8) 
            throw new Exception("Invalid size for System.Object!");
        if (Utility.SizeOf(md, "System.Array") != 16)
            throw new Exception("Invalid size for System.Array!");
        if (Utility.SizeOf(md, "System.String") != 24)
            throw new Exception("Invalid size for System.String!");
    }

    public void ImportCompilerMethod(MethodDef method) 
    {
        foreach (var attribute in method.CustomAttributes) 
            if (attribute.TypeFullName == "System.Runtime.CompilerServices.CompilerMethodAttribute") 
            {
                if (!Enum.TryParse<Methods>(attribute.ConstructorArguments[0].Value.ToString(), true, out var result))
                    throw new Exception("Could not find method!");

                CompilerMethods.Add(result, method);
                break;
            }
    }

    public string GetCompilerMethod(Methods methods) => Utility.SafeMethodName(CompilerMethods[methods], CompilerMethods[methods].MethodSig);

    public void ImportTransformations(Type transformations)
    {
        foreach (var method in transformations.GetMethods())
        {
            var attribute = method.GetCustomAttribute<ILTransformationAttribute>(true);
            if (attribute != null)
                IlBridgeMethods.Add(attribute.Code, method);
        }
    }

    public void SkipNextInstruction() => InstructionIndex++;

    protected virtual void Append(string s) => Text.AppendLine(s);

    protected static IEnumerable<Instruction> GetAllBranches(MethodDef method)
    {
        foreach (var br in method.Body.Instructions)
            if (br.OpCode.OperandType is OperandType.InlineBrTarget or OperandType.ShortInlineBrTarget)
                yield return br;
    }
}