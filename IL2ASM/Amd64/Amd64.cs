/*
 * Reference: 
 * https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/x64-architecture
 * https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-6.0
*/

using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Diagnostics;

namespace IL2ASM
{
    public unsafe class Amd64 : Arch
    {
        public const ulong RsvdStack = 1;

        public override void Setup()
        {
            Append($"[bits 64]");
        }

        public override void Compile(MethodDef meth, bool isEntryPoint = false)
        {
            Append($"{meth.SafeName()}:");
            Append($"xor rax,rax");

            //for call
            Append($"sub rbp,8");

            //for variables
            for (ulong i = 0; i < (ulong)meth.Body.Variables.Count + ReservedStack; i++)
            {
                Append($"push rax");
            }

            for (int i = 0; i < meth.Body.Instructions.Count; i++)
            {
                var ins = meth.Body.Instructions[i];

                Append($";{ins}");

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
                        Append($"add rbp,8");
                        Append($"push qword [rbp-8]");
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
                   ins.Is("Stloc")
                   )
                {
                    ulong Index = ILParser.Stloc(ins) + 1;
                    Index += RsvdStack;
                    Append($"pop rax");
                    Append($"mov [rbp-{Index * 8}],rax");
                }

                else if (
                  ins.Is("Ldloc")
                  )
                {
                    ulong Index = ILParser.Ldloc(ins) + 1;
                    Index += RsvdStack;
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
            }
        }
    }
}
