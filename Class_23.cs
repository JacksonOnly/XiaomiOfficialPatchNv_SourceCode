using System;
using System.Linq;

public class Class_23
{
    private static string method_174(string arg_01)
    {
        if (arg_01.Length != 14) throw new ArgumentException("IMEI base must be 14 digits long.");

        var var_01 = 0;
        for (var i = 0; i < arg_01.Length; i++)
        {
            var var_4 = arg_01[i] - 48;
            if (i % 2 == 1)
            {
                var_4 *= 2;
                if (var_4 > 9) var_4 -= 9;
            }

            var_01 += var_4;
        }

        return ((10 - var_01 % 10) % 10).ToString();
    }

    public static string method_175()
    {
        var var_02 = "8628440599";
        var field_113 = new Random();
        var var_3 = string.Concat(from arg_01 in Enumerable.Range(0, 4)
            select field_113.Next(0, 10).ToString());
        var var_4 = var_02 + var_3;
        var var_5 = method_174(var_4);
        return var_4 + var_5;
    }
}