using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class Class_54
{
    public static async Task<string> method_325()
    {
        try
        {
            var path = "adb.exe";
            var path2 = "AdbWinApi.dll";
            var path3 = "AdbWinUsbApi.dll";
            var arg_ = Class_35.property_40;
            var arg_2 = Class_35.property_41;
            var arg_3 = Class_35.property_42;
            var text = Path.Combine(Path.GetTempPath(), "nvram");
            if (!Directory.Exists(text)) Directory.CreateDirectory(text);

            var tasks = new Task[3]
            {
                method_326(Path.Combine(text, path), arg_),
                method_326(Path.Combine(text, path2), arg_2),
                method_326(Path.Combine(text, path3), arg_3)
            };
            await Task.WhenAll(tasks);
            return text;
        }
        catch (Exception ex)
        {
            var ex2 = ex;
            throw new Exception(ex2.Message);
        }
    }

    [CompilerGenerated]
    internal static async Task method_326(string arg_01, byte[] arg_02)
    {
        if (!File.Exists(arg_01)) await Task.Run(() => { File.WriteAllBytes(arg_01, arg_02); });
    }
}