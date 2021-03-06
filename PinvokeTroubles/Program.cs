﻿using System;
using System.Runtime.InteropServices;
[StructLayout(LayoutKind.Sequential)]
struct MyFlags
{
 public ushort mBits;
 private IntPtr defCtor;
};

[StructLayout(LayoutKind.Sequential)]
struct MyFlags2
{
 public ushort mBits;
};

class Program
{
    [DllImport("NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern void testmf(MyFlags val);
    [DllImport("NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern void testmf2( MyFlags2 val);
    [DllImport("NativeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern void testmf3( MyFlags val);

    static void Main(string[] args)
    {
        testmf2(new MyFlags2(){mBits = 42});
        testmf3(new MyFlags(){mBits = 42});
        testmf(new MyFlags(){mBits = 42}); //mem read acccess violation
        Console.ReadKey();
    }
}
