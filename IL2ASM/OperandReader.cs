using dnlib.DotNet.Emit;
using System;

namespace IL2ASM
{
    public static unsafe class OperandReader
    {
        public static ulong Ldc(Instruction ins)
        {
            unchecked
            {
                return ins.OpCode.Code switch
                {
                    Code.Ldc_I4 => (ulong)((int)ins.Operand),
                    Code.Ldc_I4_S => (ulong)((sbyte)ins.Operand),

                    Code.Ldc_I4_M1 => (ulong)-1,
                    Code.Ldc_I4_0 => 0,
                    Code.Ldc_I4_1 => 1,
                    Code.Ldc_I4_2 => 2,
                    Code.Ldc_I4_3 => 3,
                    Code.Ldc_I4_4 => 4,
                    Code.Ldc_I4_5 => 5,
                    Code.Ldc_I4_6 => 6,
                    Code.Ldc_I4_7 => 7,
                    Code.Ldc_I4_8 => 8,

                    Code.Ldc_I8 => Convert.ToUInt64(ins.Operand),
                    Code.Ldc_R4 => (ulong)(ins.Operand),
                    Code.Ldc_R8 => (ulong)(ins.Operand)
                };
            }
        }

        public static ulong Stloc(Instruction ins)
        {
            unchecked
            {
                return ins.OpCode.Code switch
                {
                    Code.Stloc => (ulong)((int)ins.Operand),
                    Code.Stloc_S => (ulong)((sbyte)ins.Operand),

                    Code.Stloc_0 => 0,
                    Code.Stloc_1 => 1,
                    Code.Stloc_2 => 2,
                    Code.Stloc_3 => 3,
                };
            }
        }

        public static ulong Ldloc(Instruction ins)
        {
            unchecked
            {
                return ins.OpCode.Code switch
                {
                    Code.Ldloc => (ulong)((int)ins.Operand),
                    Code.Ldloc_S => (ulong)((sbyte)ins.Operand),

                    Code.Ldloc_0 => 0,
                    Code.Ldloc_1 => 1,
                    Code.Ldloc_2 => 2,
                    Code.Ldloc_3 => 3,
                };
            }
        }

        public static ulong Ldarg(Instruction ins)
        {
            unchecked
            {
                return ins.OpCode.Code switch
                {
                    Code.Ldarg => (ulong)((int)ins.Operand),
                    Code.Ldarg_S => (ulong)((sbyte)ins.Operand),

                    Code.Ldarg_0 => 0,
                    Code.Ldarg_1 => 1,
                    Code.Ldarg_2 => 2,
                    Code.Ldarg_3 => 3,
                };
            }
        }
    }
}
