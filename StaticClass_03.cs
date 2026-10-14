using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BismillahAdb;

public static class StaticClass_03
{
    private static readonly string field_233 = "(error|fail|not found)";

    public static string method_313(this string arg_01)
    {
        try
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(arg_01));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static DirectoryInfo[] method_314(this DirectoryInfo arg_01, string arg_02)
    {
        try
        {
            return arg_01.GetDirectories(arg_02, SearchOption.AllDirectories);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static FileInfo[] method_315(this DirectoryInfo arg_01, string arg_02)
    {
        try
        {
            return arg_01.GetFiles(arg_02, SearchOption.AllDirectories);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public static async Task<string[]> method_316(this AdbClient arg_01, string arg_02)
    {
        return await Task.Run(() => arg_01.ExecuteCommand(arg_02));
    }

    public static async Task<string> method_317(this AdbClient arg_01, string arg_02)
    {
        return await Task.Run(() => arg_01.ExecuteCommand(arg_02)[0]);
    }

    public static async Task method_318(this AdbClient arg_01, string arg_02, string arg_03)
    {
        await Task.Run(() => { arg_01.DownloadFile(arg_02, arg_03); });
    }

    public static async Task method_319(this AdbClient arg_01, byte[] arg_02, string arg_03)
    {
        await Task.Run(() => { arg_01.UploadData(arg_02, arg_03); });
    }

    public static async Task<string> method_320(this AdbClient arg_01)
    {
        var list = new List<string> { "getprop ro.boot.chipid", "getprop ro.boot.cpuid" };
        foreach (var item in list)
        {
            var text = await arg_01.method_317(item);
            if (string.IsNullOrWhiteSpace(text) || Regex.IsMatch(text, field_233, RegexOptions.IgnoreCase)) continue;

            return text;
        }

        return null;
    }
}