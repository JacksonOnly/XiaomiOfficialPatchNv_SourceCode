using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Class_30
{
    private static byte[] method_189(byte[] arg_01)
    {
        using var var_01 = MD5.Create();
        var var_2 = var_01.ComputeHash(arg_01);
        var var_3 = new byte[8];
        for (var i = 0; i < 8; i++) var_3[i] = (byte)(var_2[i] ^ var_2[i + 8]);

        return var_3;
    }

    public static byte[] method_190(string arg_01)
    {
        if (string.IsNullOrEmpty(arg_01)) throw new ArgumentNullException("meid");

        arg_01 = arg_01.Trim().Replace(" ", "");
        if (arg_01.Length != 14) arg_01 = "00000000000000";

        var var_01 = new byte[7];
        for (var i = 0; i < 7; i++) var_01[i] = Convert.ToByte(arg_01.Substring(i * 2, 2), 16);

        var var_2 = new byte[7]
        {
            var_01[6],
            var_01[5],
            var_01[4],
            var_01[3],
            var_01[2],
            var_01[1],
            var_01[0]
        };
        var var_3 = new byte[8];
        for (var j = 0; j < 8; j++) var_3[j] = 242;

        var var_4 = method_189(var_3);
        var var_5 = new byte[1] { 2 };
        Array.Copy(var_5, 0, var_4, 0, var_5.Length);
        var var_6 = new List<byte>();
        var_6.AddRange(var_4);
        var_6.AddRange(var_2);
        var_6.Add(242);
        var var_7 = method_189(var_6.ToArray());
        var_6.AddRange(var_7);
        return var_6.ToArray();
    }
}