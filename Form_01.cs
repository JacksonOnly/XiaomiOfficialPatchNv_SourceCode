using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class Form_01 : Form
{
    private readonly IContainer field_206 = null;

    private Panel field_207;

    private ColumnHeader field_208;

    private ColumnHeader field_209;

    private ColumnHeader field_210;

    public ListView field_211;

    public Form_01()
    {
        property_43 = false;
        method_297();
    }

    [field: CompilerGenerated] public bool property_43 { [CompilerGenerated] get; [CompilerGenerated] set; }

    private void method_295(object arg_01, EventArgs arg_02)
    {
        property_43 = true;
        Icon = SystemIcons.Information;
    }

    private void method_296(object arg_01, FormClosingEventArgs arg_02)
    {
        property_43 = false;
    }

    protected override void Dispose(bool arg_01)
    {
        if (arg_01 && field_206 != null) field_206.Dispose();

        var var_02 = arg_01;
        base.Dispose(var_02);
    }

    private void method_297()
    {
        var var_01 = new ComponentResourceManager(typeof(Form_01));
        field_207 = new Panel();
        field_211 = new ListView();
        field_208 = new ColumnHeader();
        field_209 = new ColumnHeader();
        field_210 = new ColumnHeader();
        field_207.SuspendLayout();
        SuspendLayout();
        field_207.Controls.Add(field_211);
        field_207.Dock = DockStyle.Fill;
        field_207.Location = new Point(0, 0);
        field_207.Name = "panel1";
        field_207.Size = new Size(426, 178);
        field_207.TabIndex = 0;
        field_211.BackColor = Color.White;
        field_211.BorderStyle = BorderStyle.FixedSingle;
        field_211.Columns.AddRange(new ColumnHeader[3] { field_208, field_209, field_210 });
        field_211.Dock = DockStyle.Fill;
        field_211.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_211.GridLines = true;
        field_211.HideSelection = false;
        field_211.HoverSelection = true;
        field_211.LabelEdit = true;
        field_211.Location = new Point(0, 0);
        field_211.Name = "listView1";
        field_211.Size = new Size(426, 178);
        field_211.TabIndex = 0;
        field_211.UseCompatibleStateImageBehavior = false;
        field_211.View = View.Details;
        field_208.Text = "Ways";
        field_208.Width = 49;
        field_209.Text = "Mode";
        field_209.Width = 71;
        field_210.Text = "Commands";
        field_210.Width = 421;
        AutoScaleDimensions = new SizeF(6f, 13f);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(426, 178);
        Controls.Add(field_207);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)var_01.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "Guide";
        Text = "Guide";
        FormClosing += method_296;
        Load += method_295;
        field_207.ResumeLayout(false);
        ResumeLayout(false);
    }
}