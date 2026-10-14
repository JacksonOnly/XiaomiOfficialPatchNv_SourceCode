using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class Form_05 : Form
{
    private IContainer field_504;

    private Panel field_505;

    private UserControl_01 field_506;

    private ImageList field_507;

    private Button field_508;

    private Button field_509;

    public Form_05()
    {
        property_58 = false;
        method_380();
    }

    [field: CompilerGenerated] public bool property_58 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated] public string property_59 { [CompilerGenerated] get; [CompilerGenerated] set; }

    private void method_377(object arg_01, EventArgs arg_02)
    {
        Icon = SystemIcons.Question;
    }

    private void method_378(object arg_01, EventArgs arg_02)
    {
        Close();
    }

    private void method_379(object arg_01, EventArgs arg_02)
    {
        if (!string.IsNullOrEmpty(field_506.Text))
        {
            property_59 = field_506.Text;
            property_58 = true;
            Close();
        }
    }

    protected override void Dispose(bool arg_01)
    {
        if (arg_01 && field_504 != null) field_504.Dispose();

        var var_02 = arg_01;
        base.Dispose(var_02);
    }

    private void method_380()
    {
        field_504 = new Container();
        var var_01 = new ComponentResourceManager(typeof(Form_05));
        field_505 = new Panel();
        field_506 = new UserControl_01();
        field_507 = new ImageList(field_504);
        field_508 = new Button();
        field_509 = new Button();
        field_505.SuspendLayout();
        SuspendLayout();
        field_505.Controls.Add(field_509);
        field_505.Controls.Add(field_508);
        field_505.Controls.Add(field_506);
        field_505.Dock = DockStyle.Fill;
        field_505.Location = new Point(0, 0);
        field_505.Name = "panel1";
        field_505.Size = new Size(290, 93);
        field_505.TabIndex = 0;
        field_506.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_506.BackColor = Color.White;
        field_506.property_08 = Color.FromArgb(224, 224, 224);
        field_506.property_09 = 1;
        field_506.property_17 = Color.FromArgb(255, 128, 0);
        field_506.property_18 = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_506.property_07 = "SN:";
        field_506.Location = new Point(7, 14);
        field_506.property_20 = 32767;
        field_506.MinimumSize = new Size(150, 30);
        field_506.Name = "txtSN";
        field_506.Padding = new Padding(5);
        field_506.property_14 = false;
        field_506.property_12 = Color.Gray;
        field_506.property_13 = new Font("Segoe UI", 10f);
        field_506.property_11 = "Enter your SN";
        field_506.Size = new Size(275, 30);
        field_506.TabIndex = 6;
        field_506.property_15 = HorizontalAlignment.Left;
        field_506.property_16 = SystemColors.Highlight;
        field_506.property_10 = true;
        field_507.ImageStream = (ImageListStreamer)var_01.GetObject("imageList1.ImageStream");
        field_507.TransparentColor = Color.Transparent;
        field_507.Images.SetKeyName(0, "download_8292031.png");
        field_507.Images.SetKeyName(1, "Request Service.ico");
        field_507.Images.SetKeyName(2, "Clear Symbol.ico");
        field_508.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_508.ForeColor = SystemColors.MenuHighlight;
        field_508.ImageAlign = ContentAlignment.MiddleLeft;
        field_508.ImageIndex = 1;
        field_508.ImageList = field_507;
        field_508.Location = new Point(6, 52);
        field_508.Name = "btnComfirm";
        field_508.Size = new Size(83, 31);
        field_508.TabIndex = 7;
        field_508.Text = "CONFIRM";
        field_508.TextAlign = ContentAlignment.MiddleRight;
        field_508.UseVisualStyleBackColor = true;
        field_508.Click += method_379;
        field_509.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_509.ForeColor = Color.FromArgb(255, 128, 128);
        field_509.ImageAlign = ContentAlignment.MiddleLeft;
        field_509.ImageIndex = 2;
        field_509.ImageList = field_507;
        field_509.Location = new Point(108, 52);
        field_509.Name = "btnNope";
        field_509.Size = new Size(74, 31);
        field_509.TabIndex = 8;
        field_509.Text = "NOPE !";
        field_509.TextAlign = ContentAlignment.MiddleRight;
        field_509.UseVisualStyleBackColor = true;
        field_509.Click += method_378;
        AutoScaleDimensions = new SizeF(6f, 13f);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(290, 93);
        Controls.Add(field_505);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "WriteSN";
        StartPosition = FormStartPosition.CenterParent;
        Text = "WriteSN ?";
        Load += method_377;
        field_505.ResumeLayout(false);
        ResumeLayout(false);
    }
}