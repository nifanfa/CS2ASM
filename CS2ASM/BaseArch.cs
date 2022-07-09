using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CS2ASM
{
    public enum Methods
    {
        ASM,
        Allocate,
        StringCtor,
        Dispose,
        ArrayCtor,
        Stackalloc,
        InitialiseStatics,
        EntryPoint,
        Newobj
    }

    public abstract class BaseArch
    {
        public readonly Dictionary<Methods, MethodDef> CompilerMethods;
        public readonly Dictionary<Code, MethodInfo> IlBridgeMethods;
        public readonly StringBuilder text;
        public readonly ModuleDefMD module;
        public bool Debug;
        public int InstructionIndex;
        
        public abstract int PointerSize { get; }

        public BaseArch(ModuleDefMD md)
        {
            CompilerMethods = new();
            IlBridgeMethods = new();
            text = new();
            module = md;

            if (Utility.SizeOf(module, "System.Object") != 8) 
                throw new Exception("Invalid size for System.Object!");
            if (Utility.SizeOf(module, "System.Array") != 16)
                throw new Exception("Invalid size for System.Array!");
            if (Utility.SizeOf(module, "System.String") != 24)
                throw new Exception("Invalid size for System.String!");
        }

        public void ImportCompilerMethods(ModuleDef def) 
        {
            foreach(var t in def.Types) 
                foreach(var m in t.Methods) 
                    foreach(var a in m.CustomAttributes) 
                        if (a.TypeFullName == "System.Runtime.CompilerServices.CompilerMethodAttribute") 
                        {
                            var defined = Enum.TryParse<Methods>(a.ConstructorArguments[0].Value.ToString(), true, out var result);
                            if (!defined)
                                throw new KeyNotFoundException("Could not find method!");

                            CompilerMethods.Add(result, m);
                        }

            if (CompilerMethods.Count != Enum.GetNames(typeof(Methods)).Length) 
                throw new KeyNotFoundException("Number of methods don't match!");
        }

        public string GetCompilerMethod(Methods methods) 
        {
            return Utility.SafeMethodName(CompilerMethods[methods], CompilerMethods[methods].MethodSig);
        }

        public void ImportTransformations(Type transformations)
        {
            foreach (var method in transformations.GetMethods())
            {
                var attribute = method.GetCustomAttribute<ILTransformationAttribute>(true);
                if (attribute != null)
                    IlBridgeMethods.Add(attribute.code, method);
            }
        }

        public void SkipNextInstruction()
        {
            InstructionIndex++;
        }

        public virtual void Append(string s)
        {
            text.AppendLine(s);
        }

        public abstract void Translate(MethodDef meth);

        public abstract void InitializeStaticFields(TypeDef typ);

        public static IEnumerable<Instruction> GetAllBranches(MethodDef def)
        {
            return from br in def.Body.Instructions
                   where
(
br.OpCode.Code == Code.Br ||
br.OpCode.Code == Code.Brfalse ||
br.OpCode.Code == Code.Brfalse_S ||
br.OpCode.Code == Code.Brtrue ||
br.OpCode.Code == Code.Brtrue_S ||
br.OpCode.Code == Code.Br_S ||
br.OpCode.Code == Code. Bne_Un ||
br.OpCode.Code == Code. Bne_Un_S ||
br.OpCode.Code == Code. Beq ||
br.OpCode.Code == Code. Beq_S ||
br.OpCode.Code == Code. Ble ||
br.OpCode.Code == Code. Blt ||
br.OpCode.Code == Code. Blt_S ||
br.OpCode.Code == Code. Blt_Un ||
br.OpCode.Code == Code. Blt_Un_S ||
br.OpCode.Code == Code. Ble_S ||
br.OpCode.Code == Code. Ble_Un ||
br.OpCode.Code == Code. Ble_Un_S ||
br.OpCode.Code == Code. Bge ||
br.OpCode.Code == Code. Bge_Un ||
br.OpCode.Code == Code. Bge_S ||
br.OpCode.Code == Code. Bge_Un_S ||
br.OpCode.Code == Code. Bgt ||
br.OpCode.Code == Code. Bgt_S ||
br.OpCode.Code == Code. Bgt_Un ||
br.OpCode.Code == Code. Bgt_Un_S
)
                   select br;
        }

        public abstract void InitializeStaticConstructor(ModuleDefMD def);

        public abstract void JumpToEntry(ModuleDefMD def);

        internal abstract void After(ModuleDefMD def);

        public abstract void Before(ModuleDefMD def);
    }
}
