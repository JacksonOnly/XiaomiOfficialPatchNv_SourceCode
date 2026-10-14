using System;
using System.Drawing;
using System.Windows.Forms;

public static class StaticClass_04
{
    public static void method_363(this RichTextBox arg_01, string arg_02, Color arg_03 = default,
        bool arg_04 = false, bool arg_05 = false)
    {
        var richTextBox = arg_01;
        if (richTextBox == null) return;

        object var_02 = (MethodInvoker)(() =>
        {
            arg_01.ScrollToCaret();
            arg_01.SelectionColor = arg_01.ForeColor;
            arg_01.SelectionFont = arg_01.Font;
            arg_01.SelectionStart = arg_01.TextLength;
            arg_01.SelectionLength = 0;
            if (arg_04) arg_01.SelectionFont = new Font(arg_01.Font, FontStyle.Bold);

            if (arg_05) arg_01.SelectionFont = new Font(arg_01.Font, FontStyle.Underline);

            var color = arg_03;
            Color method_366var_06 = default;
            var method_366var_7 = color;
            if (method_366var_7 == method_366var_06)
                arg_01.SelectionColor = arg_01.ForeColor;
            else
                arg_01.SelectionColor = arg_03;

            arg_01.AppendText($"{arg_02} ");
            arg_01.ScrollToCaret();
        });
        richTextBox.Invoke((Delegate)var_02);
    }

    public static void method_364(this RichTextBox arg_01, string arg_02, Color arg_03 = default,
        bool arg_04 = false, bool arg_05 = false)
    {
        var richTextBox = arg_01;
        if (richTextBox == null) return;

        object var_02 = (MethodInvoker)(() =>
        {
            arg_01.ScrollToCaret();
            arg_01.SelectionStart = arg_01.TextLength;
            arg_01.SelectionLength = 0;
            if (arg_04) arg_01.SelectionFont = new Font(arg_01.Font, FontStyle.Bold);

            if (arg_05) arg_01.SelectionFont = new Font(arg_01.Font, FontStyle.Underline);

            var color = arg_03;
            Color method_367var_06 = default;
            var method_367var_7 = color;
            if (method_367var_7 == method_367var_06)
                arg_01.SelectionColor = Color.Green;
            else
                arg_01.SelectionColor = arg_03;

            arg_01.AppendText($"{arg_02} ");
            arg_01.AppendText("\n");
            arg_01.SelectionColor = arg_01.ForeColor;
            arg_01.SelectionFont = arg_01.Font;
            arg_01.ScrollToCaret();
        });
        richTextBox.Invoke((Delegate)var_02);
    }

    public static void method_365(this RichTextBox arg_01, string arg_02, bool arg_03 = false, bool arg_04 = false)
    {
        var richTextBox = arg_01;
        if (richTextBox == null) return;

        object var_02 = (MethodInvoker)(() =>
        {
            arg_01.ScrollToCaret();
            arg_01.SelectionStart = arg_01.TextLength;
            arg_01.SelectionLength = 0;
            if (arg_03) arg_01.SelectionFont = new Font(arg_01.Font, FontStyle.Bold);

            if (arg_04) arg_01.SelectionFont = new Font(arg_01.Font, FontStyle.Underline);

            arg_01.SelectionColor = Color.Red;
            arg_01.AppendText(arg_02);
            arg_01.AppendText("\n");
            arg_01.SelectionColor = arg_01.ForeColor;
            arg_01.SelectionFont = arg_01.Font;
            arg_01.ScrollToCaret();
        });
        richTextBox.Invoke((Delegate)var_02);
    }
}