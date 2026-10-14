using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class Form_02 : Form
{
    private readonly List<string[]> field_215 = new()
    {
        new string[3] { "1", "Adb", "adb shell getprop ro.product.device" },
        new string[3] { "2", "Fastboot", "fastboot getvar product" }
    };

    private readonly List<string[]> field_216 = new()
    {
        new string[3] { "1", "Adb", "adb shell getprop ro.boot.chipid" },
        new string[3] { "2", "Adb", "adb shell getprop ro.boot.cpuid" },
        new string[3] { "3", "Adb", "adb shell getprop | findstr \"chipid\"" },
        new string[3] { "4", "Adb", "adb shell getprop | findstr \"cpuid\"" },
        new string[3] { "5", "Fastboot", "fastboot getvar cpuid" },
        new string[3] { "6", "Fastboot", "fastboot getvar chipid" }
    };

    private IContainer field_217;

    private Panel field_218;

    private ImageList field_219;

    private Button field_220;

    private UserControl_01 field_221;

    private UserControl_01 field_222;

    private UserControl_01 field_223;

    private UserControl_01 field_224;

    private UserControl_01 field_225;

    private UserControl_01 field_226;

    private UserControl_01 field_227;

    private Button field_228;

    private ImageList field_229;

    private Button field_230;

    private Button field_231;

    private Button field_232;

    public Form_02()
    {
        property_46 = new Form_01();
        property_45 = false;
        property_44 = new Class_21();
        method_312();
    }

    [field: CompilerGenerated] public Class_21 property_44 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated] public bool property_45 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated] private Form_01 property_46 { [CompilerGenerated] get; [CompilerGenerated] set; }

    private void method_304(object arg_01, EventArgs arg_02)
    {
        field_225.event_01 += method_305;
        field_224.event_01 += method_305;
        field_223.event_01 += method_305;
        field_225.property_20 = 15;
        field_224.property_20 = 15;
        field_223.property_20 = 14;
        field_222.property_20 = 12;
        field_221.property_20 = 12;
        field_227.Text = property_44.Product;
        field_226.Text = property_44.ChipId;
        if (!string.IsNullOrEmpty(property_44.ChipId) && property_44.ChipId.Length > 34)
            field_226.Text = property_44.ChipId.Remove(34);

        field_225.Text = Class_23.method_175();
        field_224.Text = property_44.Imei2;
        field_223.Text = property_44.Meid;
        var var_01 = new Class_27().method_183();
        field_222.Text = var_01.property_33;
        field_221.Text = var_01.property_34;
    }

    private void method_305(object arg_01, KeyPressEventArgs arg_02)
    {
        var var_02 = arg_02.KeyChar;
        if (!char.IsControl(var_02))
        {
            var var_3 = arg_02.KeyChar;
            if (!char.IsDigit(var_3)) arg_02.Handled = true;
        }
    }

    private void method_306(object arg_01, EventArgs arg_02)
    {
        if (!string.IsNullOrEmpty(field_227.Text) && !string.IsNullOrEmpty(field_226.Text) &&
            field_224.Text.Length == 15 && field_225.Text.Length == 15)
        {
            property_44.ChipId = field_226.Text;
            property_44.RealCpuId = field_226.Text;
            if (field_226.Text.Length > 34)
            {
                property_44.ChipId = field_226.Text.Remove(34);
                property_44.RealCpuId = field_226.Text.Remove(34);
            }

            property_44.Product = field_227.Text;
            property_44.Imei1 = field_225.Text;
            property_44.Imei2 = field_224.Text;
            property_44.Meid = field_223.Text;
            property_44.WifiMac = field_222.Text;
            property_44.BtMac = field_221.Text;
            property_45 = true;
            Close();
        }
    }

    private void method_307(object arg_01, EventArgs arg_02)
    {
        field_225.Text = Class_23.method_175();
    }

    private void method_308(object arg_01, EventArgs arg_02)
    {
        if (property_46.property_43) property_46.Close();

        property_46 = new Form_01();
        foreach (var item in field_215)
        {
            var var_6 = new ListViewItem(item);
            property_46.field_211.Items.Add(var_6);
        }

        property_46.Text = "Get Product Name";
        property_46.StartPosition = FormStartPosition.Manual;
        var var_7 = field_230.PointToScreen(Point.Empty);
        var num = var_7.X + field_230.Width;
        var var_16 = var_7.Y;
        var var_17 = num;
        var var_18 = new Point(var_17, var_16);
        var var_19 = Screen.FromControl(field_230);
        if (var_18.X + property_46.Width > var_19.WorkingArea.Right)
        {
            var var_21 = var_19.WorkingArea.Right - property_46.Width;
            var_18.X = var_21;
        }

        if (var_18.Y + property_46.Height > var_19.WorkingArea.Bottom)
        {
            var var_25 = var_19.WorkingArea.Bottom - property_46.Height;
            var_18.Y = var_25;
        }

        var form_ = property_46;
        var var_26 = var_18;
        form_.Location = var_26;
        property_46.Show();
    }

    private void method_309(object arg_01, EventArgs arg_02)
    {
        if (property_46.property_43) property_46.Close();

        property_46 = new Form_01();
        foreach (var item in field_216)
        {
            var var_6 = new ListViewItem(item);
            property_46.field_211.Items.Add(var_6);
        }

        property_46.Text = "Get Cpuid ";
        property_46.StartPosition = FormStartPosition.Manual;
        var var_7 = field_231.PointToScreen(Point.Empty);
        var num = var_7.X + field_231.Width;
        var var_16 = var_7.Y;
        var var_17 = num;
        var var_18 = new Point(var_17, var_16);
        var var_19 = Screen.FromControl(field_231);
        if (var_18.X + property_46.Width > var_19.WorkingArea.Right)
        {
            var var_21 = var_19.WorkingArea.Right - property_46.Width;
            var_18.X = var_21;
        }

        if (var_18.Y + property_46.Height > var_19.WorkingArea.Bottom)
        {
            var var_25 = var_19.WorkingArea.Bottom - property_46.Height;
            var_18.Y = var_25;
        }

        var form_ = property_46;
        var var_26 = var_18;
        form_.Location = var_26;
        property_46.Show();
    }

    private void method_310(object arg_01, FormClosingEventArgs arg_02)
    {
        if (property_46.property_43) property_46.Close();
    }

    private void method_311(object arg_01, EventArgs arg_02)
    {
        field_224.Text = Class_23.method_175();
    }

    protected override void Dispose(bool arg_01)
    {
        if (arg_01 && field_217 != null) field_217.Dispose();

        var var_02 = arg_01;
        base.Dispose(var_02);
    }

    private void method_312()
    {
        field_217 = new Container();
        var var_01 = new ComponentResourceManager(typeof(Form_02));
        field_218 = new Panel();
        field_232 = new Button();
        field_229 = new ImageList(field_217);
        field_230 = new Button();
        field_231 = new Button();
        field_228 = new Button();
        field_221 = new UserControl_01();
        field_222 = new UserControl_01();
        field_223 = new UserControl_01();
        field_224 = new UserControl_01();
        field_225 = new UserControl_01();
        field_226 = new UserControl_01();
        field_227 = new UserControl_01();
        field_220 = new Button();
        field_219 = new ImageList(field_217);
        field_218.SuspendLayout();
        SuspendLayout();
        field_218.BackColor = Color.White;
        field_218.Controls.Add(field_232);
        field_218.Controls.Add(field_230);
        field_218.Controls.Add(field_231);
        field_218.Controls.Add(field_228);
        field_218.Controls.Add(field_221);
        field_218.Controls.Add(field_222);
        field_218.Controls.Add(field_223);
        field_218.Controls.Add(field_224);
        field_218.Controls.Add(field_225);
        field_218.Controls.Add(field_226);
        field_218.Controls.Add(field_227);
        field_218.Controls.Add(field_220);
        field_218.Dock = DockStyle.Fill;
        field_218.Location = new Point(0, 0);
        field_218.Name = "PMain";
        field_218.Size = new Size(370, 348);
        field_218.TabIndex = 0;
        field_232.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        field_232.ImageIndex = 0;
        field_232.ImageList = field_229;
        field_232.Location = new Point(334, 126);
        field_232.Name = "btnImei2";
        field_232.Size = new Size(24, 23);
        field_232.TabIndex = 11;
        field_232.UseVisualStyleBackColor = true;
        field_232.Click += method_311;
        field_229.ImageStream = (ImageListStreamer)var_01.GetObject("imageList2.ImageStream");
        field_229.TransparentColor = Color.Transparent;
        field_229.Images.SetKeyName(0, "Refresh.ico");
        field_229.Images.SetKeyName(1, "mobile_16623507.png");
        field_229.Images.SetKeyName(2, "mobile_16729619.png");
        field_229.Images.SetKeyName(3, "information.png");
        field_230.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        field_230.ImageIndex = 3;
        field_230.ImageList = field_229;
        field_230.Location = new Point(334, 20);
        field_230.Name = "btnProduct";
        field_230.Size = new Size(24, 24);
        field_230.TabIndex = 10;
        field_230.UseVisualStyleBackColor = true;
        field_230.Click += method_308;
        field_231.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        field_231.ImageIndex = 3;
        field_231.ImageList = field_229;
        field_231.Location = new Point(334, 56);
        field_231.Name = "btnChipid";
        field_231.Size = new Size(24, 24);
        field_231.TabIndex = 9;
        field_231.UseVisualStyleBackColor = true;
        field_231.Click += method_309;
        field_228.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        field_228.ImageIndex = 0;
        field_228.ImageList = field_229;
        field_228.Location = new Point(334, 92);
        field_228.Name = "btnGenerateImei1";
        field_228.Size = new Size(24, 23);
        field_228.TabIndex = 8;
        field_228.UseVisualStyleBackColor = true;
        field_228.Click += method_307;
        field_221.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_221.BackColor = Color.White;
        field_221.property_08 = Color.FromArgb(224, 224, 224);
        field_221.property_09 = 1;
        field_221.property_17 = Color.FromArgb(255, 128, 0);
        field_221.property_18 = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_221.property_07 = "BTMAC";
        field_221.Location = new Point(12, 233);
        field_221.property_20 = 32767;
        field_221.MinimumSize = new Size(150, 30);
        field_221.Name = "btTextBox";
        field_221.Padding = new Padding(5);
        field_221.property_14 = false;
        field_221.property_12 = Color.Gray;
        field_221.property_13 = new Font("Segoe UI", 10f);
        field_221.property_11 = "Enter btmac";
        field_221.Size = new Size(346, 30);
        field_221.TabIndex = 7;
        field_221.property_15 = HorizontalAlignment.Left;
        field_221.property_16 = SystemColors.Highlight;
        field_221.property_10 = true;
        field_222.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_222.BackColor = Color.White;
        field_222.property_08 = Color.FromArgb(224, 224, 224);
        field_222.property_09 = 1;
        field_222.property_17 = Color.FromArgb(255, 128, 0);
        field_222.property_18 = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_222.property_07 = "WIFIMAC";
        field_222.Location = new Point(12, 198);
        field_222.property_20 = 32767;
        field_222.MinimumSize = new Size(150, 30);
        field_222.Name = "wifiTextBox";
        field_222.Padding = new Padding(5);
        field_222.property_14 = false;
        field_222.property_12 = Color.Gray;
        field_222.property_13 = new Font("Segoe UI", 10f);
        field_222.property_11 = "Enter wifimac";
        field_222.Size = new Size(346, 30);
        field_222.TabIndex = 6;
        field_222.property_15 = HorizontalAlignment.Left;
        field_222.property_16 = SystemColors.Highlight;
        field_222.property_10 = true;
        field_223.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_223.BackColor = Color.White;
        field_223.property_08 = Color.FromArgb(224, 224, 224);
        field_223.property_09 = 1;
        field_223.property_17 = Color.FromArgb(255, 128, 0);
        field_223.property_18 = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_223.property_07 = "MEID";
        field_223.Location = new Point(12, 162);
        field_223.property_20 = 32767;
        field_223.MinimumSize = new Size(150, 30);
        field_223.Name = "meidTextBox";
        field_223.Padding = new Padding(5);
        field_223.property_14 = false;
        field_223.property_12 = Color.Gray;
        field_223.property_13 = new Font("Segoe UI", 10f);
        field_223.property_11 = "Enter meid";
        field_223.Size = new Size(346, 30);
        field_223.TabIndex = 5;
        field_223.property_15 = HorizontalAlignment.Left;
        field_223.property_16 = SystemColors.Highlight;
        field_223.property_10 = true;
        field_224.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_224.BackColor = Color.White;
        field_224.property_08 = Color.FromArgb(224, 224, 224);
        field_224.property_09 = 1;
        field_224.property_17 = Color.FromArgb(255, 128, 0);
        field_224.property_18 = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_224.property_07 = "IMEI2";
        field_224.Location = new Point(12, 126);
        field_224.property_20 = 32767;
        field_224.MinimumSize = new Size(150, 30);
        field_224.Name = "imei2TextBox";
        field_224.Padding = new Padding(5);
        field_224.property_14 = false;
        field_224.property_12 = Color.Gray;
        field_224.property_13 = new Font("Segoe UI", 10f);
        field_224.property_11 = "Enter imei2";
        field_224.Size = new Size(346, 30);
        field_224.TabIndex = 4;
        field_224.property_15 = HorizontalAlignment.Left;
        field_224.property_16 = SystemColors.Highlight;
        field_224.property_10 = true;
        field_225.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_225.BackColor = Color.White;
        field_225.property_08 = Color.FromArgb(224, 224, 224);
        field_225.property_09 = 1;
        field_225.Enabled = false;
        field_225.property_17 = Color.FromArgb(255, 128, 0);
        field_225.property_18 = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_225.property_07 = "IMEI1";
        field_225.Location = new Point(12, 90);
        field_225.property_20 = 32767;
        field_225.MinimumSize = new Size(150, 30);
        field_225.Name = "imei1TextBox";
        field_225.Padding = new Padding(5);
        field_225.property_14 = false;
        field_225.property_12 = Color.Gray;
        field_225.property_13 = new Font("Segoe UI", 10f);
        field_225.property_11 = "Enter imei1";
        field_225.Size = new Size(346, 30);
        field_225.TabIndex = 3;
        field_225.property_15 = HorizontalAlignment.Left;
        field_225.property_16 = SystemColors.Highlight;
        field_225.property_10 = true;
        field_226.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_226.BackColor = Color.White;
        field_226.property_08 = Color.FromArgb(224, 224, 224);
        field_226.property_09 = 1;
        field_226.property_17 = Color.FromArgb(255, 128, 0);
        field_226.property_18 = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_226.property_07 = "CHIPID";
        field_226.Location = new Point(12, 56);
        field_226.property_20 = 32767;
        field_226.MinimumSize = new Size(150, 30);
        field_226.Name = "chipidTextBox";
        field_226.Padding = new Padding(5);
        field_226.property_14 = false;
        field_226.property_12 = Color.Gray;
        field_226.property_13 = new Font("Segoe UI", 10f);
        field_226.property_11 = "Enter chip id";
        field_226.Size = new Size(346, 30);
        field_226.TabIndex = 2;
        field_226.property_15 = HorizontalAlignment.Left;
        field_226.property_16 = SystemColors.Highlight;
        field_226.property_10 = true;
        field_227.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_227.BackColor = Color.White;
        field_227.property_08 = Color.FromArgb(224, 224, 224);
        field_227.property_09 = 1;
        field_227.property_17 = Color.FromArgb(255, 128, 0);
        field_227.property_18 = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_227.property_07 = "PRODUCT";
        field_227.Location = new Point(12, 20);
        field_227.property_20 = 32767;
        field_227.MinimumSize = new Size(150, 30);
        field_227.Name = "productTextBox";
        field_227.Padding = new Padding(5);
        field_227.property_14 = false;
        field_227.property_12 = Color.Gray;
        field_227.property_13 = new Font("Segoe UI", 10f);
        field_227.property_11 = "Enter product name";
        field_227.Size = new Size(346, 30);
        field_227.TabIndex = 1;
        field_227.property_15 = HorizontalAlignment.Left;
        field_227.property_16 = SystemColors.Highlight;
        field_227.property_10 = true;
        field_220.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_220.ForeColor = SystemColors.MenuHighlight;
        field_220.ImageAlign = ContentAlignment.TopCenter;
        field_220.ImageIndex = 1;
        field_220.ImageList = field_219;
        field_220.Location = new Point(12, 286);
        field_220.Name = "btnComfirm";
        field_220.Size = new Size(61, 51);
        field_220.TabIndex = 0;
        field_220.Text = "CONFIRM";
        field_220.TextAlign = ContentAlignment.BottomCenter;
        field_220.UseVisualStyleBackColor = true;
        field_220.Click += method_306;
        field_219.ImageStream = (ImageListStreamer)var_01.GetObject("imageList1.ImageStream");
        field_219.TransparentColor = Color.Transparent;
        field_219.Images.SetKeyName(0, "download_8292031.png");
        field_219.Images.SetKeyName(1, "Request Service.ico");
        AutoScaleDimensions = new SizeF(6f, 13f);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(370, 348);
        Controls.Add(field_218);
        Icon = (Icon)var_01.GetObject("$this.Icon");
        Name = "CriticalForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Critical data.";
        FormClosing += method_310;
        Load += method_304;
        field_218.ResumeLayout(false);
        ResumeLayout(false);
    }
}