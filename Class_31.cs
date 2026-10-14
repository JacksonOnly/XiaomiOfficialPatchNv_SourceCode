using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

public class Class_31
{
    private static readonly int field_125 = 131072;

    private static byte[] field_126;

    public Class_31(string arg_01, string arg_02)
    {
        property_35 = method_218(arg_01);
        field_126 = File.ReadAllBytes(arg_02);
    }

    [field: CompilerGenerated] public Class_22 property_35 { [CompilerGenerated] get; [CompilerGenerated] set; }

    public byte[] method_198()
    {
        var var_01 = BitConverter.ToInt32(field_126, 4);
        var var_2 = method_221(field_126, Class_29.field_119);
        var var_3 = method_221(field_126, Class_29.field_120);
        var var_4 = method_221(field_126, Class_29.field_118);
        var var_5 = method_220(field_126, Class_29.field_122);
        var var_6 = method_220(field_126, Class_29.field_123);
        if (var_4 < 0) throw new Exception("Cannot find  file in NVRAM image.");

        if (var_2 < 0) throw new Exception("Cannot find  file in NVRAM image.");

        if (var_5 < 0) throw new Exception("Cannot find WIFI file in NVRAM image.");

        var var_7 = BitConverter.ToInt32(field_126, var_5 - 4);
        var var_8 = field_125 + BitConverter.ToInt32(field_126, var_5 - 8);
        if (var_6 < 0) throw new Exception("Cannot find BT_Addr file in NVRAM image.");

        var var_9 = BitConverter.ToInt32(field_126, var_6 - 4);
        var var_10 = field_125 + BitConverter.ToInt32(field_126, var_6 - 8);
        var var_11 = Path.GetTempFileName();
        File.WriteAllBytes(var_11, field_126);
        var var_12 = method_209();
        var var_13 = method_199();
        using (var var_20 = new FileStream(var_11, FileMode.Open, FileAccess.ReadWrite))
        {
            using var var_21 = new BinaryWriter(var_20);
            using var var_22 = new BinaryReader(var_20);
            if (var_2.HasValue)
            {
                var_20.Seek(var_2.Value + 12, SeekOrigin.Begin);
                var_21.Write((byte)10);
                var_20.Seek(var_2.Value + 64, SeekOrigin.Begin);
                var_21.Write(var_12);
            }

            if (var_4.HasValue)
            {
                var_20.Seek(var_4.Value + 64, SeekOrigin.Begin);
                var_21.Write(var_13);
            }

            if (var_3.HasValue)
                try
                {
                    var var_29 = Class_30.method_190(property_35.property_25);
                    var_20.Seek(var_3.Value + 64, SeekOrigin.Begin);
                    var_21.Write(var_29);
                }
                catch
                {
                }

            var_20.Seek(var_8 + 4, SeekOrigin.Begin);
            var_21.Write(method_222(property_35.property_26));
            var_20.Seek(var_8, SeekOrigin.Begin);
            var var_30 = var_22.ReadBytes(var_7 - 2);
            var_21.Write(method_214(var_30));
            var_20.Seek(var_10, SeekOrigin.Begin);
            var_21.Write(method_222(property_35.property_27));
            var_20.Seek(var_10, SeekOrigin.Begin);
            var var_31 = var_22.ReadBytes(var_9 - 2);
            var_21.Write(method_214(var_31));
            var_20.Seek(field_125, SeekOrigin.Begin);
            var var_32 = var_22.ReadBytes(var_01);
            var_20.Seek(12L, SeekOrigin.Begin);
            var_21.Write(method_213(var_32));
        }

        var var_33 = File.ReadAllBytes(var_11);
        File.Delete(var_11);
        return var_33;
    }

    private byte[] method_199()
    {
        var var_01 = "devPubKeyModulus:" + property_35.property_28 + "\\ndevPubKeyExponent:" +
                     property_35.property_29 + "\\ndevPubKeySign:" + property_35.property_30 + "\\ncriticalData:" +
                     property_35.property_31 + "\\ncrticalDataSign:" + property_35.property_32;
        var var_2 = Encoding.ASCII.GetBytes(var_01);
        var var_3 = new byte[4096];
        Array.Copy(var_2, var_3, Math.Min(var_2.Length, var_3.Length));
        var var_4 = method_202(var_3);
        var var_5 = new byte[4104];
        Array.Copy(var_3, 0, var_5, 0, 4096);
        Array.Copy(var_4, 0, var_5, 4096, 8);
        return var_5;
    }

    public static byte[] method_200(string arg_01)
    {
        arg_01 += "F0000";
        var var_01 = arg_01.ToCharArray();
        for (var i = 0; i < var_01.Length - 1; i += 2)
        {
            var var_5 = var_01[i];
            var_01[i] = var_01[i + 1];
            var_01[i + 1] = var_5;
        }

        var var_6 = new string(var_01);
        var var_7 = new byte[var_6.Length / 2];
        for (var j = 0; j < var_7.Length; j++) var_7[j] = Convert.ToByte(var_6.Substring(j * 2, 2), 16);

        return var_7;
    }

    private static byte[] method_202(byte[] arg_01)
    {
        using var var_01 = MD5.Create();
        var var_2 = var_01.ComputeHash(arg_01);
        var var_3 = new byte[8];
        for (var i = 0; i < 8; i++) var_3[i] = (byte)(var_2[i] ^ var_2[i + 8]);

        return var_3;
    }

    private byte[] method_209()
    {
        var var_01 = new Dictionary<string, string>
        {
            { "imei_1", property_35.property_23 },
            { "imei_2", property_35.property_24 }
        };
        var var_2 = new List<byte>();
        for (var i = 1; i <= 10; i++)
        {
            byte[] var_11;
            if (var_01.TryGetValue($"imei_{i}", out var var_10) && var_10 != "000000000000000" && (i == 1 || i == 2))
            {
                var_11 = method_200(var_10);
            }
            else
            {
                var_11 = new byte[10];
                for (var j = 0; j < 10; j++) var_11[j] = byte.MaxValue;
            }

            var var_12 = method_202(var_11);
            var var_13 = new byte[32];
            Array.Copy(var_11, 0, var_13, 0, var_11.Length);
            Array.Copy(var_12, 0, var_13, var_11.Length, var_12.Length);
            var_2.AddRange(var_13);
        }

        var var_14 = new byte[32]
        {
            143, 156, 97, 81, 220, 134, 185, 22, 58, 55,
            80, 109, 157, 255, 119, 83, 70, 75, 167, 62,
            94, 222, 243, 98, 91, 161, 141, 72, 18, 53,
            128, 91
        };
        var var_15 = new byte[32]
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
            11, 12, 13, 14, 15, 16, 17, 18, 11, 20,
            21, 22, 23, 24, 25, 26, 27, 28, 0, 0,
            0, 0
        };
        var var_16 = new byte[32]
        {
            53, 35, 50, 83, 66, 69, 84, 36, 67, 134,
            104, 52, 120, 86, 52, 18, 120, 86, 52, 18,
            67, 134, 104, 52, 66, 69, 84, 36, 53, 35,
            50, 83
        };
        var var_17 = new byte[16]
        {
            190, 65, 12, 103, 57, 77, 152, 1, 114, 86,
            170, 60, 143, 33, 187, 66
        };
        method_216(ref var_15, ref var_16, var_14);
        var var_18 = method_210(var_17, var_16, method_217(var_15, 0, 16), 256, CipherMode.CBC);
        return method_210(var_2.ToArray(), var_18, new byte[16], 128, CipherMode.ECB);
    }

    private static byte[] method_210(byte[] arg_01, byte[] arg_02, byte[] arg_03, int arg_04, CipherMode arg_05)
    {
        using var var_01 = Aes.Create();
        var_01.Mode = arg_05;
        var_01.KeySize = arg_04;
        var_01.Padding = PaddingMode.None;
        var_01.Key = arg_02;
        var_01.IV = arg_03;
        using var var_2 = var_01.CreateEncryptor();
        return var_2.TransformFinalBlock(arg_01, 0, arg_01.Length);
    }

    private static int method_212(int arg_01)
    {
        var var_01 = (uint)(arg_01 & -1);
        if ((var_01 & 0x80000000u) != 0) return (int)(0 - ((~var_01 & 0xFFFFFFFFu) + 1));

        return (int)var_01;
    }

    private static byte[] method_213(byte[] arg_01)
    {
        var var_01 = 0;
        var var_2 = 0;
        var var_3 = arg_01.Length;
        for (var i = 0; i < var_3; i += 4)
        {
            var var_5 = new byte[4];
            var var_6 = Math.Min(4, var_3 - i);
            Array.Copy(arg_01, i, var_5, 0, var_6);
            var var_7 = BitConverter.ToInt32(var_5, 0);
            if (var_6 < 4)
            {
                var_2 = var_7;
                break;
            }

            var_01 = i / 4 % 2 != 0 ? var_01 + var_7 : var_01 ^ var_7;
        }

        return BitConverter.GetBytes(method_212(var_01 + var_2) ^ var_3);
    }

    private static byte[] method_214(byte[] arg_01)
    {
        var var_01 = 0;
        var var_2 = arg_01.Length;
        for (var i = 0; i < var_2; i++)
        {
            var var_4 = arg_01[i];
            var_01 = i % 2 != 0 ? var_01 ^ var_4 : var_01 + var_4;
        }

        return new byte[2]
        {
            170,
            (byte)var_01
        };
    }

    private static void method_215(ref byte[] arg_01)
    {
        for (var var_01 = 0; var_01 < arg_01.Length - 1; var_01 += 2)
        {
            var var_2 = arg_01[var_01];
            arg_01[var_01] = arg_01[var_01 + 1];
            arg_01[var_01 + 1] = var_2;
        }
    }

    private static void method_216(ref byte[] arg_01, ref byte[] arg_02, byte[] arg_03)
    {
        method_215(ref arg_01);
        method_215(ref arg_02);
        for (var var_01 = 0; var_01 < arg_01.Length; var_01++)
        {
            arg_01[var_01] ^= arg_03[var_01];
            arg_02[var_01] ^= arg_01[var_01];
        }
    }

    private static byte[] method_217(byte[] arg_01, int arg_02, int arg_03)
    {
        var var_01 = new byte[arg_03];
        Array.Copy(arg_01, arg_02, var_01, 0, arg_03);
        return var_01;
    }

    private Class_22 method_218(string arg_01)
    {
        var var_01 = new Class_22();
        var var_2 = arg_01.Replace("\\n", "\n").Split('\n');
        var var_3 = new Dictionary<string, string>();
        var var_11 = var_2;
        foreach (var var_13 in var_11)
        {
            var var_14 = var_13.IndexOf(':');
            if (var_14 != -1)
            {
                var var_16 = var_13.Substring(0, var_14).Trim();
                var var_17 = var_13.Substring(var_14 + 1).Trim();
                var_3[var_16] = var_17;
            }
        }

        if (!var_3.TryGetValue("devPubKeyModulus", out var var_18) ||
            !var_3.TryGetValue("devPubKeyExponent", out var var_19) ||
            !var_3.TryGetValue("devPubKeySign", out var var_20) || !var_3.TryGetValue("criticalData", out var var_21) ||
            !var_3.TryGetValue("crticalDataSign", out var var_22))
            throw new Exception("One or more fields are missing.");

        var_01.property_28 = var_18;
        var_01.property_29 = var_19;
        var_01.property_30 = var_20;
        var_01.property_31 = var_21;
        var_01.property_32 = var_22;
        var var_23 = var_21.Substring(8);
        var var_24 = 0;
        while (var_24 + 4 <= var_23.Length)
        {
            var var_25 = var_23.Substring(var_24, 2);
            var_24 += 2;
            var var_26 = Convert.ToInt32(var_23.Substring(var_24, 2), 16);
            var_24 += 2;
            var var_27 = var_26 * 2;
            if (var_24 + var_27 > var_23.Length) break;

            var var_28 = var_23.Substring(var_24, var_27);
            var_24 += var_27;
            switch (var_25)
            {
                case "01":
                    var_01.property_22 = method_219(var_28);
                    break;
                case "02":
                    var_01.property_23 = method_219(var_28);
                    break;
                case "03":
                    var_01.property_24 = method_219(var_28);
                    break;
                case "04":
                    var_01.property_25 = method_219(var_28);
                    break;
                case "05":
                    var_01.property_26 = method_219(var_28);
                    break;
                case "06":
                    var_01.property_27 = method_219(var_28);
                    break;
            }
        }

        return var_01;
    }

    private string method_219(string arg_01)
    {
        var var_01 = new StringBuilder();
        for (var i = 0; i < arg_01.Length; i += 2)
        {
            var var_3 = arg_01.Substring(i, 2);
            var var_6 = (char)Convert.ToByte(var_3, 16);
            var_01.Append(var_6);
        }

        return var_01.ToString();
    }

    private static int method_220(byte[] arg_01, string arg_02)
    {
        var var_01 = Encoding.ASCII.GetBytes(arg_02);
        for (var i = 0; i <= arg_01.Length - var_01.Length; i++)
        {
            var var_3 = true;
            for (var j = 0; j < var_01.Length; j++)
                if (arg_01[i + j] != var_01[j])
                {
                    var_3 = false;
                    break;
                }

            if (var_3) return i;
        }

        return -1;
    }

    private static int? method_221(byte[] arg_01, string arg_02)
    {
        var var_01 = method_220(arg_01, arg_02);
        if (var_01 == -1) return null;

        var var_2 = BitConverter.ToInt32(arg_01, var_01 - 8);
        return field_125 + var_2;
    }

    public static byte[] method_222(string arg_01)
    {
        arg_01 = arg_01.Replace(":", "").Replace("-", "").Replace(" ", "");
        var var_01 = arg_01.Length;
        var var_2 = new byte[var_01 / 2];
        for (var i = 0; i < var_01; i += 2) var_2[i / 2] = Convert.ToByte(arg_01.Substring(i, 2), 16);

        return var_2;
    }
}