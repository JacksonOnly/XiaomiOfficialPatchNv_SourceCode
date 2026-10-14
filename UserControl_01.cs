using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

[DesignerCategory("Code")]
public class UserControl_01 : UserControl
{
    private readonly Label field_78;

    private readonly TextBox field_79;

    private Color field_80 = Color.MediumSlateBlue;

    private int field_81 = 1;

    private bool field_82 = true;

    private string field_83 = "Enter Text";

    private Color field_84 = Color.Gray;

    private Font field_85 = new("Segoe UI", 10f);

    private bool field_86;

    private string field_87 = "Info";

    private Color field_88 = Color.Black;

    private Font field_89;

    private bool field_90;

    public UserControl_01()
    {
        var label = new Label();
        label.AutoSize = false;
        label.TextAlign = ContentAlignment.MiddleLeft;
        label.Width = 80;
        label.Dock = DockStyle.Left;
        var var_01 = field_87;
        label.Text = var_01;
        field_78 = label;
        var textBox = new TextBox();
        textBox.BorderStyle = BorderStyle.None;
        object var_2 = new Font("Segoe UI", 10f);
        textBox.Font = (Font)var_2;
        var var_3 = Color.Black;
        textBox.ForeColor = var_3;
        var var_4 = Color.White;
        textBox.BackColor = var_4;
        textBox.Dock = DockStyle.Fill;
        var var_5 = new Padding(5, 0, 0, 0);
        textBox.Margin = var_5;
        field_79 = textBox;
        field_89 = field_79.Font;
        field_88 = field_79.ForeColor;
        BackColor = Color.White;
        Padding = new Padding(5);
        Size = new Size(300, 35);
        MinimumSize = new Size(150, 30);
        Controls.Add(field_79);
        Controls.Add(field_78);
        field_79.Enter += (arg_01, arg_02) => { method_120(); };
        field_79.Leave += (arg_01, arg_02) => { method_119(); };
        method_119();
    }

    [Category("Custom")]
    public string property_07
    {
        get => field_87;
        set
        {
            field_87 = value;
            field_78.Text = value;
        }
    }

    [Category("Custom")]
    public Color property_08
    {
        get => field_80;
        set
        {
            field_80 = value;
            Invalidate();
        }
    }

    [Category("Custom")]
    public int property_09
    {
        get => field_81;
        set
        {
            if (value >= 1)
            {
                field_81 = value;
                Invalidate();
            }
        }
    }

    [Category("Custom")]
    public bool property_10
    {
        get => field_82;
        set
        {
            field_82 = value;
            Invalidate();
        }
    }

    [Category("Custom")]
    public string property_11
    {
        get => field_83;
        set
        {
            field_83 = value;
            if (field_86) field_79.Text = field_83;
        }
    }

    [Category("Custom")]
    public Color property_12
    {
        get => field_84;
        set
        {
            field_84 = value;
            if (field_86) field_79.ForeColor = value;
        }
    }

    [Category("Custom")]
    public Font property_13
    {
        get => field_85;
        set
        {
            field_85 = value;
            if (field_86) field_79.Font = value;
        }
    }

    [Category("Custom")]
    public bool property_14
    {
        get => field_90;
        set
        {
            field_90 = value;
            if (!field_86)
            {
                var textBox = field_79;
                var var_02 = value;
                textBox.UseSystemPasswordChar = var_02;
            }
            else
            {
                field_79.UseSystemPasswordChar = false;
            }
        }
    }

    [Category("Custom")]
    public HorizontalAlignment property_15
    {
        get => field_79.TextAlign;
        set => field_79.TextAlign = value;
    }

    [Category("Custom")]
    public override Font Font
    {
        get => field_79.Font;
        set
        {
            field_89 = value;
            if (!field_86) field_79.Font = value;
        }
    }

    [Category("Custom")]
    public Color property_16
    {
        get => field_88;
        set
        {
            field_88 = value;
            if (!field_86) field_79.ForeColor = value;
        }
    }

    public override string Text
    {
        get => field_86 ? "" : field_79.Text;
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                field_86 = false;
                field_79.ForeColor = field_88;
                field_79.Font = field_89;
                field_79.Text = value;
                if (property_14) field_79.UseSystemPasswordChar = true;
            }
            else
            {
                method_119();
            }
        }
    }

    [Category("Custom")]
    public Color property_17
    {
        get => field_78.ForeColor;
        set => field_78.ForeColor = value;
    }

    [Category("Custom")]
    public Font property_18
    {
        get => field_78.Font;
        set => field_78.Font = value;
    }

    [Category("Behavior")]
    public int property_20
    {
        get => field_79.MaxLength;
        set => field_79.MaxLength = value;
    }

    public event KeyPressEventHandler event_01
    {
        add => field_79.KeyPress += value;
        remove => field_79.KeyPress -= value;
    }

    protected override void OnPaint(PaintEventArgs arg_01)
    {
        base.OnPaint(arg_01);
        var color = field_80;
        float var_07 = field_81;
        var var_8 = color;
        using var var_9 = new Pen(var_8, var_07);
        var_9.Alignment = PenAlignment.Inset;
        if (field_82)
        {
            arg_01.Graphics.DrawLine(var_9, 0, Height - 1, Width, Height - 1);
            return;
        }

        var graphics = arg_01.Graphics;
        _ = 0;
        _ = 0;
        var num = Width - 1;
        var var_10 = Height - 1;
        var var_11 = num;
        var var_12 = var_9;
        graphics.DrawRectangle(var_12, 0, 0, var_11, var_10);
    }

    private void method_119()
    {
        if (string.IsNullOrWhiteSpace(field_79.Text))
        {
            field_86 = true;
            field_79.Text = field_83;
            field_79.ForeColor = field_84;
            field_79.Font = field_85;
            field_79.UseSystemPasswordChar = false;
        }
    }

    private void method_120()
    {
        if (field_86)
        {
            field_86 = false;
            field_79.Text = "";
            field_79.ForeColor = field_88;
            field_79.Font = field_89;
            if (field_90) field_79.UseSystemPasswordChar = true;
        }
    }
}