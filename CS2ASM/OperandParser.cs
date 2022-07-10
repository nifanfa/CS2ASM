using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;

namespace CS2ASM;

public static class OperandParser
{
    public static object Ldc(Instruction ins)
    {
        if (ins.Operand is Local local) ins.Operand = local.Index;
        return ins.OpCode.Code switch
        {
            Code.Ldc_I4 => ins.Operand,
            Code.Ldc_I4_S => ins.Operand,
            Code.Ldc_I8 => ins.Operand,

            Code.Ldc_I4_M1 => -1, //-1
            Code.Ldc_I4_0 => 0,
            Code.Ldc_I4_1 => 1,
            Code.Ldc_I4_2 => 2,
            Code.Ldc_I4_3 => 3,
            Code.Ldc_I4_4 => 4,
            Code.Ldc_I4_5 => 5,
            Code.Ldc_I4_6 => 6,
            Code.Ldc_I4_7 => 7,
            Code.Ldc_I4_8 => 8,
        };
    }

    public static ulong Stloc(Instruction ins)
    {
        if (ins.Operand is Local local) ins.Operand = local.Index;
        return ins.OpCode.Code switch
        {
            Code.Stloc => Convert.ToUInt64(ins.Operand),
            Code.Stloc_S => Convert.ToUInt64(ins.Operand),

            Code.Stloc_0 => 0,
            Code.Stloc_1 => 1,
            Code.Stloc_2 => 2,
            Code.Stloc_3 => 3,
        };
    }

    public static ulong Ldloc(Instruction ins)
    {
        if (ins.Operand is Local local) ins.Operand = local.Index;
        return ins.OpCode.Code switch
        {
            Code.Ldloc => Convert.ToUInt64(ins.Operand),
            Code.Ldloc_S => Convert.ToUInt64(ins.Operand),    
            Code.Ldloca => Convert.ToUInt64(ins.Operand),    
            Code.Ldloca_S => Convert.ToUInt64(ins.Operand),    

            Code.Ldloc_0 => 0,
            Code.Ldloc_1 => 1,
            Code.Ldloc_2 => 2,
            Code.Ldloc_3 => 3,
        };
    }

    public static ulong Ldarg(Instruction ins)
    {
        if (ins.Operand is Local local) ins.Operand = local.Index;
        if (ins.Operand is Parameter parameter) ins.Operand = parameter.Index;
        return ins.OpCode.Code switch
        {
            Code.Ldarg => Convert.ToUInt64(ins.Operand),
            Code.Ldarg_S => Convert.ToUInt64(ins.Operand),
            Code.Ldarga => Convert.ToUInt64(ins.Operand),
            Code.Ldarga_S => Convert.ToUInt64(ins.Operand),

            Code.Ldarg_0 => 0,
            Code.Ldarg_1 => 1,
            Code.Ldarg_2 => 2,
            Code.Ldarg_3 => 3,
        };
    }

    public static ulong Starg(Instruction ins)
    {
        if (ins.Operand is Local local) ins.Operand = local.Index;
        return ins.OpCode.Code switch
        {
            Code.Starg => Convert.ToUInt64(((Parameter)ins.Operand).Index),
            Code.Starg_S => Convert.ToUInt64(((Parameter)ins.Operand).Index),
        };
    }
}