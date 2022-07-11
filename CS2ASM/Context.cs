using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Collections.Generic;
using System.Text;

namespace CS2ASM
{
    public class Context
    {
        public StringBuilder text { get; }

        public Instruction ins { get; set; }

        public MethodDef def { get; }

        public BaseArch arch { get; }

        public int StackOperationCount { get; set; }
         
        public bool hasReturn => methodSig.RetType.ElementType != ElementType.Void;

        public bool HasThis => methodSig.HasThis;

        public IList<Instruction> instructions => def.Body.Instructions;

        public int CurrentInstructionIndex => instructions.IndexOf(ins);

        public object operand => ins.Operand;

        public int numberOfParams => methodSig.Params.Count + (methodSig.HasThis ? 1 : 0);
        
        public Instruction prevInstruction => def.Body.Instructions[def.Body.Instructions.IndexOf(ins) - 1];

        public Instruction nextInstruction => def.Body.Instructions[def.Body.Instructions.IndexOf(ins) + 1];

        public MethodSig methodSig 
        {
            get 
            {
                return ins.Operand switch
                {
                    MemberRef @ref => @ref.MethodSig,
                    MethodDef methodDef => methodDef.MethodSig,
                    MethodSig sig => sig,
                    _ => null
                };
            }
        }

        public Context(StringBuilder sb, Instruction ins, MethodDef def, BaseArch arch)
        {
            text = sb;
            this.ins = ins;
            this.def = def;
            this.arch = arch;
        }

        internal void Append(string v)
        {
            text.AppendLine(v);
        }

        internal void Push(string v)
        {
            text.AppendLine(arch.Push(v));
        }

        internal void Pop(string v)
        {
            text.AppendLine(arch.Pop(v));
        }
    }
}
