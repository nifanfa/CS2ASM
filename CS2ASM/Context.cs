using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CS2ASM
{
    public class Context
    {
        public StringBuilder text;
        public Instruction ins;
        public MethodDef def;
        public BaseArch arch;

        public volatile int StackOperationCount = 0;
         
        public bool hasReturn 
        {
            get 
            {
                return methodSig.RetType.ElementType != ElementType.Void;
            }
        }

        public bool hasThis
        {
            get
            {
                return methodSig.HasThis;
            }
        }

        public IList<Instruction> instructions 
        {
            get 
            {
                return def.Body.Instructions;
            }
        }

        public int currentInstructionIndex 
        {
            get 
            {
                return instructions.IndexOf(ins);
            }
        }

        public object operand 
        {
            get 
            {
                return ins.Operand;
            }
        }

        public int numberOfParams 
        {
            get
            {
                return methodSig.Params.Count + (methodSig.HasThis ? 1 : 0);
            }
        }

        public MethodSig methodSig 
        {
            get 
            {
                if (ins.Operand is MemberRef)
                    return ((MemberRef)ins.Operand).MethodSig;
                if (ins.Operand is MethodDef)
                    return ((MethodDef)ins.Operand).MethodSig;
                if (ins.Operand is MethodSig)
                    return ((MethodSig)ins.Operand);
                return null;
            }
        }

        public Instruction prevInstruction 
        {
            get
            {
                return def.Body.Instructions[def.Body.Instructions.IndexOf(ins) - 1];
            }
        }

        public Instruction nextInstruction
        {
            get
            {
                return def.Body.Instructions[def.Body.Instructions.IndexOf(ins) + 1];
            }
        }

        public Context(StringBuilder sb,Instruction ins, MethodDef def,BaseArch arch)
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
    }
}
