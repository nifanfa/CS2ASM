/*
 * Reference: 
 * https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/x64-architecture
 * https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-6.0
*/

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace IL2ASM
{
    public unsafe class Amd64 : Arch
    {
        public override void Setup()
        {
            Append($"[bits 64]");
        }

        public override void Compile(MethodDef meth, bool isEntryPoint = false)
        {
            //Get All Branches
            List<Instruction> BrS = new List<Instruction>();
            foreach (var ins in meth.Body.Instructions)
            {
                if (
                    ins.OpCode == OpCodes.Br ||
                    ins.OpCode == OpCodes.Brfalse ||
                    ins.OpCode == OpCodes.Brfalse_S ||
                    ins.OpCode == OpCodes.Brtrue ||
                    ins.OpCode == OpCodes.Brtrue_S ||
                    ins.OpCode == OpCodes.Br_S
                    )
                {
                    BrS.Add(ins);
                }
            }

            //Starts
            Append($"{meth.SafeName()}:");
            Append($"xor rax,rax");

            //for call
            if (!isEntryPoint)
            {
                //dangerous
                Append($"pop rax");
                Append($"mov [rbp+8],rax");
            }

            //for variables
            for (ulong i = 0; i < (ulong)meth.Body.Variables.Count + ReservedStack; i++)
            {
                Append($"push rax");
            }

            for (int i = 0; i < meth.Body.Instructions.Count; i++)
            {
                var ins = meth.Body.Instructions[i];

                Append($";{ins}");
                foreach(var v in BrS)
                {
                    if(((Instruction)v.Operand).Offset == ins.Offset)
                    Append($"{meth.SafeName()}_IL_{ins.Offset:X4}:");
                }

                if (
                    ins.OpCode.Code == Code.Nop ||
                    ins.Is("Conv")
                    )
                {
                }

                else if (
                   ins.OpCode.Code == Code.Call
                   )
                {
                    Append($"call {((MethodDef)ins.Operand).SafeName()}");
                }

                else if (
                  ins.Is("Ret")
                  )
                {
                    if (!isEntryPoint)
                    {
                        //recover
                        Append($"push qword [rbp+8]");
                        Append($"ret");
                    }
                    else
                    {
                        Append($"jmp die");
                    }
                }

                else if (
                   ins.Is("Ldc")
                   )
                {
                    Append($"push {ILParser.Ldc(ins)}");
                }

                else if (
                   ins.OpCode.Code == Code.Br ||
                   ins.OpCode.Code == Code.Br_S
                   )
                {
                    Append($"jmp {meth.SafeName()}_IL_{((Instruction)(ins.Operand)).Offset:X4}");
                }

                else if (
                   ins.Is("Stloc")
                   )
                {
                    ulong Index = ILParser.Stloc(ins) + 1;
                    Append($"pop rax");
                    Append($"mov [rbp-{Index * 8}],rax");
                }

                else if (
                  ins.Is("Ldloc")
                  )
                {
                    ulong Index = ILParser.Ldloc(ins) + 1;
                    Append($"push qword [rbp-{Index * 8}]");
                }

                else if (
                  ins.Is("Stind")
                  )
                {
                    Append($"pop rdx");
                    Append($"pop rax");
                    if (ins.OpCode.Code == Code.Stind_I1)
                    {
                        Append($"mov [rax],dl");
                    }
                    if (ins.OpCode.Code == Code.Stind_I2)
                    {
                        Append($"mov [rax],dx");
                    }
                    if (ins.OpCode.Code == Code.Stind_I)
                    {
                        Append($"mov [rax],edx");
                    }
                    if (ins.OpCode.Code == Code.Stind_I4)
                    {
                        Append($"mov [rax],edx");
                    }
                    if (ins.OpCode.Code == Code.Stind_R4)
                    {
                        Append($"mov [rax],edx");
                    }
                    if (ins.OpCode.Code == Code.Stind_I8)
                    {
                        Append($"mov [rax],rdx");
                    }
                    if (ins.OpCode.Code == Code.Stind_R8)
                    {
                        Append($"mov [rax],rdx");
                    }
                    if (ins.OpCode.Code == Code.Stind_Ref)
                    {
                        Append($"mov [rax],rdx");
                    }
                }

                else if (
                  ins.Is("Add")
                 )
                {
                    Append($"pop rdx");
                    Append($"pop rax");
                    Append($"add rax,rdx");
                    Append($"push rax");
                }

                else
                {
                    Append($"unresolved {ins}");
                }

                Append();
            }
        }
    }
}
