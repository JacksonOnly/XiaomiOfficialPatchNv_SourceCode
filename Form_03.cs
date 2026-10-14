using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class Form_03 : Form
{
    private IContainer field_305;

    private Panel field_306;

    private ImageList field_307;

    private Button field_308;

    private UserControl_01 field_309;

    private UserControl_01 field_310;

    public Form_03()
    {
        property_50 = new Class_36.Class_37();
        property_49 = new Class_36.Class_38();
        property_48 = new Class_36();
        MinimumSize = new Size(336, 258);
        method_341();
    }

    [field: CompilerGenerated] public bool property_47 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated] private Class_36 property_48 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated]
    private Class_36.Class_38 property_49 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated]
    public Class_36.Class_37 property_50 { [CompilerGenerated] get; [CompilerGenerated] set; }

    private void method_336(object arg_01, EventArgs arg_02)
    {
    }

    private async void method_337(object arg_01, EventArgs arg_02)
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            if (!string.IsNullOrEmpty(field_309.Text) && !string.IsNullOrEmpty(field_310.Text))
            {
                property_50 = new Class_36.Class_37();
                property_50.Email = field_309.Text;
                property_50.Password = field_310.Text;
                property_49 = await property_48.method_237(property_50);
                if (!property_49.Success)
                {
                    MessageBox.Show(property_49.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }

                property_47 = true;
                Close();
            }
        }
        catch (Exception ex)
        {
            var ex2 = ex;
            MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void method_338(object arg_01, FormClosingEventArgs arg_02)
    {
        if (!property_47) Application.Exit();
    }

    private void method_339(object arg_01, FormClosedEventArgs arg_02)
    {
    }

    private void method_340(object arg_01, PaintEventArgs arg_02)
    {
    }

    protected override void Dispose(bool arg_01)
    {
        if (arg_01 && field_305 != null) field_305.Dispose();

        var var_02 = arg_01;
        base.Dispose(var_02);
    }

    private void method_341()
    {
        field_305 = new Container();
        var var_01 = new ComponentResourceManager(typeof(Form_03));
        field_306 = new Panel();
        field_308 = new Button();
        field_307 = new ImageList(field_305);
        field_310 = new UserControl_01();
        field_309 = new UserControl_01();
        field_306.SuspendLayout();
        SuspendLayout();
        field_306.BackColor = Color.White;
        field_306.Controls.Add(field_310);
        field_306.Controls.Add(field_309);
        field_306.Controls.Add(field_308);
        field_306.Dock = DockStyle.Fill;
        field_306.Location = new Point(0, 0);
        field_306.Name = "Pmain";
        field_306.Size = new Size(320, 219);
        field_306.TabIndex = 0;
        field_306.Paint += method_340;
        field_308.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_308.ForeColor = SystemColors.MenuHighlight;
        field_308.ImageAlign = ContentAlignment.TopCenter;
        field_308.ImageIndex = 2;
        field_308.ImageList = field_307;
        field_308.Location = new Point(18, 140);
        field_308.Name = "btnLogin";
        field_308.Size = new Size(56, 52);
        field_308.TabIndex = 2;
        field_308.Text = "Login";
        field_308.TextAlign = ContentAlignment.BottomCenter;
        field_308.UseVisualStyleBackColor = true;
        field_308.Click += method_337;
        field_307.ImageStream = (ImageListStreamer)var_01.GetObject("imageList1.ImageStream");
        field_307.TransparentColor = Color.Transparent;
        field_307.Images.SetKeyName(0, "download_8292031.png");
        field_307.Images.SetKeyName(1, "Request Service.ico");
        field_307.Images.SetKeyName(2, "lock_15367607.png");
        field_310.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_310.BackColor = Color.White;
        field_310.property_08 = Color.FromArgb(64, 64, 64);
        field_310.property_09 = 1;
        field_310.property_17 = Color.FromArgb(255, 128, 0);
        field_310.property_18 = new Font("Segoe UI", 11.25f);
        field_310.property_07 = "Password";
        field_310.Location = new Point(18, 91);
        field_310.property_20 = 32767;
        field_310.MinimumSize = new Size(150, 30);
        field_310.Name = "txtPassword";
        field_310.Padding = new Padding(5);
        field_310.property_14 = true;
        field_310.property_12 = Color.Gray;
        field_310.property_13 = new Font("Segoe UI", 10f);
        field_310.property_11 = "Enter your password";
        field_310.Size = new Size(284, 30);
        field_310.TabIndex = 8;
        field_310.property_15 = HorizontalAlignment.Left;
        field_310.property_16 = SystemColors.Highlight;
        field_310.property_10 = true;
        field_309.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_309.BackColor = Color.White;
        field_309.property_08 = Color.FromArgb(64, 64, 64);
        field_309.property_09 = 1;
        field_309.property_17 = Color.FromArgb(255, 128, 0);
        field_309.property_18 = new Font("Segoe UI", 11.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_309.property_07 = "Email";
        field_309.Location = new Point(18, 40);
        field_309.property_20 = 32767;
        field_309.MinimumSize = new Size(150, 30);
        field_309.Name = "txtEmail";
        field_309.Padding = new Padding(5);
        field_309.property_14 = false;
        field_309.property_12 = Color.Gray;
        field_309.property_13 = new Font("Segoe UI", 10f);
        field_309.property_11 = "Enter your email";
        field_309.Size = new Size(284, 30);
        field_309.TabIndex = 5;
        field_309.property_15 = HorizontalAlignment.Left;
        field_309.property_16 = SystemColors.Highlight;
        field_309.property_10 = true;
        AutoScaleDimensions = new SizeF(6f, 14f);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(320, 219);
        Controls.Add(field_306);
        Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        Icon = (Icon)var_01.GetObject("$this.Icon");
        Name = "Login";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Xiaomi Patch Nvram V2";
        FormClosing += method_338;
        FormClosed += method_339;
        Load += method_336;
        field_306.ResumeLayout(false);
        ResumeLayout(false);
    }
}