using System;
using System.Linq;
using System.Security.Cryptography;

public class Class_27
{
    private readonly RandomNumberGenerator field_117;

    public Class_27()
    {
        field_117 = RandomNumberGenerator.Create();
    }

    public Class_26 method_183(string arg_01 = "F0:2C:7B")
    {
        var var_01 = (from value in arg_01.Split(':')
            select Convert.ToByte(value, 16)).ToArray();
        var_01[0] |= 2;
        var var_2 = new byte[3];
        field_117.GetBytes(var_2);
        var var_3 = new byte[6];
        Array.Copy(var_01, var_3, 3);
        Array.Copy(var_2, 0, var_3, 3, 3);
        var var_4 = method_185(method_184(var_3) + 1);
        return new Class_26
        {
            property_33 = method_186(var_3),
            property_34 = method_186(var_4)
        };
    }

    private static ulong method_184(byte[] arg_01)
    {
        if (arg_01.Length != 6) throw new ArgumentException("MAC address must be 6 bytes.");

        var var_01 = new byte[8];
        Array.Copy(arg_01, 0, var_01, 2, 6);
        if (BitConverter.IsLittleEndian) Array.Reverse(var_01);

        return BitConverter.ToUInt64(var_01, 0);
    }

    private static byte[] method_185(ulong arg_01)
    {
        var var_01 = BitConverter.GetBytes(arg_01);
        if (BitConverter.IsLittleEndian) Array.Reverse(var_01);

        return var_01.Skip(2).ToArray();
    }

    private static string method_186(byte[] arg_01)
    {
        var var_02 = arg_01.Select(b =>
        {
            var method_188var_02 = "X2";
            return b.ToString(method_188var_02);
        });
        return string.Join("", var_02);
    }
}