#define DEBUG
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

public sealed class Class_04 : IDisposable
{
    private static readonly string[] field_10 = new string[69]
    {
        "httpdebugger", "fiddler", "wireshark", "charles", "dnspy", "dnspy-x86", "x64dbg", "x32dbg", "ollydbg", "ida",
        "ida64", "ida32", "processhacker", "procmon", "processexplorer", "immunitydebugger", "windbg", "dbgview",
        "ghidra", "radare2",
        "cutter", "de4dot", "ilspy", "ilspycmd", "reflector", "justdecompile", "dotpeek", "dotnetpeek",
        "confuserex-unpacker", "netunpack",
        "simpleassemblyexplorer", "megadumper", "sharpod", "koi", "netguard", "smartassembly", "phoenixprotector",
        "cryptoobfuscator", "agile.net", "eazfuscator",
        "spices.net", "cheatengine", "scylla", "scylla_x64", "scylla_x86", "reclass", "peid", "pe-bear", "exeinfope",
        "lordpe",
        "cfr", "fernflower", "jd-gui", "recaf", "apktool", "jadx", "httpanalyzer", "burp", "proxifier", "tcpview",
        "netcheat", "networkminer", "vmtoolsd", "vboxservice", "qemu-ga", "sandboxie", "procmon64", "regmon",
        "apimonitor"
    };

    private readonly ConcurrentDictionary<int, DateTime> field_11 = new();

    private readonly CancellationTokenSource field_12 = new();

    private readonly Task field_13;

    private readonly int field_14;

    private readonly bool field_15;

    private volatile bool field_16;

    public Class_04(int arg_01 = 3000, bool arg_02 = true)
    {
        if (arg_01 < 500)
            throw new ArgumentOutOfRangeException("scanIntervalMs", "Scan interval must be at least 500ms");

        field_14 = arg_01;
        field_15 = arg_02;
        if (field_15 && !method_29()) throw new SecurityException("Administrator privileges are required");

        field_13 = Task.Run((Func<Task>)method_25);
    }

    public void Dispose()
    {
        if (!field_16)
        {
            field_16 = true;
            field_12.Cancel();
            try
            {
                field_13.Wait(1500);
            }
            catch (AggregateException)
            {
            }

            field_12.Dispose();
        }
    }

    public void method_24()
    {
        method_28();
        var var_01 = Process.GetProcesses();
        foreach (var var_3 in var_01)
            try
            {
                if (method_26(var_3)) method_27(var_3);
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is NotSupportedException)
            {
            }
    }

    private async Task method_25()
    {
        while (!field_12.IsCancellationRequested)
            try
            {
                method_24();
                await Task.Delay(field_14, field_12.Token);
            }
            catch (TaskCanceledException)
            {
                break;
            }
            catch (Exception ex2)
            {
                Debug.WriteLine("[ProcessProtector] Monitoring error: " + ex2.Message);
                await Task.Delay(1000, field_12.Token);
            }
    }

    private bool method_26(Process arg_01)
    {
        try
        {
            var field_26 = arg_01.ProcessName.ToLowerInvariant();
            return field_10.Any(value => field_26.Contains(value) && !field_11.ContainsKey(arg_01.Id));
        }
        catch
        {
            return false;
        }
    }

    private void method_27(Process arg_01)
    {
        try
        {
            arg_01.Kill();
            if (arg_01.WaitForExit(1500))
            {
                field_11.TryAdd(arg_01.Id, DateTime.UtcNow);
                Debug.WriteLine($"[ProcessProtector] Killed: {arg_01.ProcessName} (PID: {arg_01.Id})");
            }
            else
            {
                Debug.WriteLine("[ProcessProtector] Failed to kill: " + arg_01.ProcessName);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("[ProcessProtector] Error killing " + arg_01.ProcessName + ": " + ex.Message);
        }
        finally
        {
            arg_01.Dispose();
        }
    }

    private void method_28()
    {
        if (field_16) throw new ObjectDisposedException("ProcessProtector");
    }

    private static bool method_29()
    {
        return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }
}