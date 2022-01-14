﻿using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
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

        public int numberOfVariable 
        {
            get
            {
                if (ins.Operand is MemberRef)
                    return ((MemberRef)ins.Operand).MethodSig.Params.Count;
                else
                    return ((MethodDef)ins.Operand).MethodSig.Params.Count;
            }
        }

        public MethodSig methodSig 
        {
            get 
            {
                if (ins.Operand is MemberRef)
                    return ((MemberRef)ins.Operand).MethodSig;
                else
                    return ((MethodDef)ins.Operand).MethodSig;
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
