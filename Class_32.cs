using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class Class_32
{
    [field: CompilerGenerated] private static string property_36 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated] private static string property_37 { [CompilerGenerated] get; [CompilerGenerated] set; }

    private static void method_228()
    {
        var var_01 =
            new DirectoryInfo(Path.Combine(Path.GetTempPath(), "Nvram")).GetFiles("adb.exe",
                SearchOption.AllDirectories);
        if (var_01.Count() == 0) throw new FileNotFoundException("adb.exe executable not found at the provided path.");

        property_36 = var_01[0].FullName;
        property_37 = Path.GetDirectoryName(var_01[0].FullName);
    }

    public static async Task<string> method_229(string arg_01, int arg_02 = 10000)
    {
        try
        {
            method_228();
            var field_129 = new Process();
            try
            {
                var process = field_129;
                var processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;
                var var_09 = property_36;
                processStartInfo.FileName = var_09;
                var var_10 = property_37;
                processStartInfo.WorkingDirectory = var_10;
                processStartInfo.Arguments = arg_01;
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                process.StartInfo = processStartInfo;
                field_129.Start();
                var task = field_129.StandardOutput.ReadToEndAsync();
                var task2 = field_129.StandardError.ReadToEndAsync();
                if (await Task.WhenAny(Task.Run(() => { field_129.WaitForExit(); }), Task.Delay(arg_02)) ==
                    Task.Delay(arg_02))
                {
                    field_129.Kill();
                    return "Error: Fastboot command timed out.";
                }

                return await task + await task2;
            }
            finally
            {
                if (field_129 != null) ((IDisposable)field_129).Dispose();
            }
        }
        catch (Exception ex)
        {
            var ex2 = ex;
            return "Exception: " + ex2.Message;
        }
    }
}