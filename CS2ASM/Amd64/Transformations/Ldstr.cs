using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Text;

namespace CS2ASM
{
    public static unsafe partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldstr)]
        public static void Ldstr(BaseArch arch, Instruction ins, MethodDef def)
        {
            var nextIns = def.Body.Instructions[def.Body.Instructions.IndexOf(ins) + 1];
            if (nextIns.IsStloc())
            {
                var bytes = Encoding.Unicode.GetBytes((string)ins.Operand);
                var text = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    text += bytes[i] + (i + 1 == bytes.Length ? "" : ",");
                }
                ulong Index = OperandParser.Stloc(nextIns) + 1;

                arch.Append($"push qword {bytes.Length + (sizeof(ulong) * 2)}");
                arch.Append($"call System.Runtime.Allocator.malloc");
                arch.Append($"pop rbp");
                arch.Append($"add rsp,8");
                arch.Append($"mov [rbp-{Index * 8}],rax");

                arch.Append($"mov rcx,rax");
                arch.Append($"add rcx,16");
                arch.Append($"mov qword [rax],{((string)ins.Operand).Length}");
                arch.Append($"mov [rax+8],rcx");

                arch.Append($"jmp {Amd64.SafeMethodName(def)}.{ins.Offset:X4}");
                arch.Append($"{Amd64.SafeMethodName(def)}.{ins.Offset:X4}.String:");
                arch.Append($"db {text}");
                arch.Append($"{Amd64.SafeMethodName(def)}.{ins.Offset:X4}:");
                arch.Append($"mov qword rdi,[rbp-{Index * 8}]");
                arch.Append($"add rdi,16");
                arch.Append($"mov rsi,{Amd64.SafeMethodName(def)}.{ins.Offset:X4}.String");
                arch.Append($"mov rcx,{bytes.Length}");
                arch.Append($"rep movsb");
                arch.SkipNextInstruction();
            }
            else
            {
                if (nextIns.OpCode.Code == Code.Call && ((MethodDef)nextIns.Operand).FullName == "System.Void System.Runtime.Intrinsic::asm(System.String)")
                {
                    string comment = (string)ins.Operand;
                    int paramCount = def.Parameters.Count;

                    string cpy = comment;
                    if (cpy.IndexOf("{") != -1 && cpy.IndexOf("}") != -1)
                    {
                        cpy = cpy.Substring(cpy.IndexOf("{") + 1);
                        cpy = cpy.Substring(0, cpy.IndexOf("}"));

                        foreach (var v in def.Parameters)
                        {
                            if (v.Name == cpy)
                            {
                                //ldarg
                                comment = comment.Replace($"{{{cpy}}}", $"[rbp+{(paramCount + 1 - v.Index) * 8}]");
                                goto End;
                            }
                        }

                        foreach (var v in def.Body.Variables)
                        {
                            if (v.Name == cpy)
                            {
                                //ldloc
                                comment = comment.Replace($"{{{cpy}}}", $"[rbp-{(v.Index + 1) * 8}]");
                                goto End;
                            }
                        }

                        if (comment == (string)ins.Operand)
                        {
                            throw new Exception($"\"{cpy}\" is not a valid variable of the context");
                        }
                    }
                End:
                    arch.Append($"{comment}");
                    arch.SkipNextInstruction();

                    //Debugger.Break();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
