using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[CompilerGenerated]
[DebuggerNonUserCode]
internal class Class_35
{
    private static ResourceManager field_145;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager property_38
    {
        get
        {
            if (field_145 == null) field_145 = new ResourceManager("CC2A3F3D", typeof(Class_35).Assembly);

            return field_145;
        }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo property_39 { get; set; }

    internal static byte[] property_40 => (byte[])property_38.GetObject("adb", property_39);

    internal static byte[] property_41 => (byte[])property_38.GetObject("AdbWinApi", property_39);

    internal static byte[] property_42 => (byte[])property_38.GetObject("AdbWinUsbApi", property_39);
}