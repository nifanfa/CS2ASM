using CS2ASM.AMD64;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.IO;
using System.Text;

namespace CS2ASM
{
    public static partial class Amd64Transformation
    {
        [ILTransformation(Code.Ldstr)]
        public static void Ldstr(Context context)
        {
            if (context.nextInstruction.Operand is MethodDef && ((MethodDef)context.nextInstruction.Operand) == context.arch.CompilerMethods[Methods.ASM])
            {
                if (!InlineAssembly.NewMethod(context))
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                var bytes = Encoding.Unicode.GetBytes((string)context.operand);
                var text = "";
                for (int i = 0; i < bytes.Length; i++)
                {
                    text += bytes[i] + (i + 1 == bytes.Length ? "" : ",");
                }
                //Every object has its unique hash code this is why i use it

                //Instance
                /*
                context.Append($"mov rdi,LB_{bytes.GetHashCode():X2}");
                context.Append($"mov rsi,{((string)context.operand).Length}");
                context.Append($"call {context.arch.GetCompilerMethod(Methods.StringCtor)}");
                context.Push($"rax");
                context.StackOperationCount += 1;
                context.Append($"jmp LB_{context.nextInstruction.GetHashCode():X2}");
                context.Append($"LB_{bytes.GetHashCode():X2}:");
                context.Append($"db {text}");
                context.Append($"LB_{context.nextInstruction.GetHashCode():X2}:");
                */
                //Static
                context.Push($"LB_{bytes.GetHashCode():X2}");
                context.StackOperationCount += 1;
                context.Append($"jmp LB_{context.nextInstruction.GetHashCode():X2}");
                context.Append($"LB_{bytes.GetHashCode():X2}:");
                if(Utility.SizeOf(context.def.Module, "System.String")!= 24) 
                {
                    throw new InvalidDataException("Do not modify the structure of Object or String");
                }
                context.Append($"dq {Utility.SizeOf(context.def.Module,"System.String")+ (ulong)(((string)context.operand).Length*2)}"); //object.Size
                context.Append($"dq {((string)context.operand).Length}"); //string.Length
                context.Append($"dq LB_{bytes.GetHashCode():X2}+24"); //string.Value
                context.Append($"db {text}");
                context.Append($"LB_{context.nextInstruction.GetHashCode():X2}:");
            }
        }
    }
}
