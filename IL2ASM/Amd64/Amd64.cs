/*
 * Reference: https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/x64-architecture
 * Reference: https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection.emit.opcodes?view=net-6.0
*/

using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace IL2ASM
{
    public unsafe class Amd64 : Arch
    {
        public const ulong RsvdStack = 1;

        public override void Setup()
        {
            Append($"[bits 64]");
        }

        public override void Compile(MethodDef meth)
        {
            string nam = meth.FullName.Split(' ')[1];
            nam = nam.Substring(0, nam.IndexOf("("));
            nam = nam.SafeName();

            Append($"{nam}:");
            Append($"xor rax,rax");
            for (ulong i = 0; i < (ulong)meth.Body.Variables.Count + ReservedStack; i++)
            {
                Append($"push rax");
            }
            Append();

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
                  ins.Is("Ret")
                  )
                {
                    if (meth.Module.EntryPoint != meth)
                    {
                        Append($"ret");
                    }
                }

                else if (
                   ins.Is("Ldc")
                   )
                {
                    Append($"push {ILParser.ldc(ins)}");
                }

                else if (
                   ins.Is("Stloc")
                   )
                {
                    ulong Index = ILParser.stloc(ins) + 1;
                    Index += RsvdStack;
                    Append($"pop rax");
                    Append($"mov [rbp-{Index * 8}],rax");
                }

                else if (
                  ins.Is("Ldloc")
                  )
                {
                    ulong Index = ILParser.ldloc(ins) + 1;
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

                Append();
            }
        }
    }
}
