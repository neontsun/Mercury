using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ScrollBar : System.Windows.Forms.Control
{
    public ScrollBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        Size = new Size(9, 237);
        ThumbColor = Color.White;
        BorderColor = Color.FromArgb(30, 30, 30);
        Orientation = ScrollOrientation.VerticalScroll;
        ThumbHeight = 35;
    }

    private int VALUE;
    private int MAX = 100;
    private ScrollOrientation ORIENTATION;
    public event ScrollEventHandler SCROLL;

    public Int32 Value
    {
        get { return VALUE; }
        set
        {
            bool flag = VALUE == value;
            if (!flag)
            {
                VALUE = value;
                OnScroll(ScrollEventType.ThumbPosition);

                Invalidate();
            }
        }
    }
    public Int32 Maximum
    {
        get { return MAX; }
        set
        {
            MAX = value;
            Invalidate();
        }
    }

    [Category("Appearance"), Description("Цвет ползунка")]
    public Color ThumbColor
    {
        get;
        set;
    }

    [Category("Appearance"), Description("Высота ползунка")]
    public Int32 ThumbHeight
    {
        get;
        set;
    }

    [Category("Appearance"), Description("Цвет обводки")]
    public Color BorderColor
    {
        get;
        set;
    }

    [Category("Appearance"), Description("Вид контролла")]
    public ScrollOrientation Orientation
    {
        get { return ORIENTATION; }
        set
        {
            ORIENTATION = value;

            Invalidate();
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) MouseScroll(e);

        base.OnMouseDown(e);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left) MouseScroll(e);

        base.OnMouseMove(e);
    }
    private void MouseScroll(MouseEventArgs e)
    {
        int V = 0;
        ScrollOrientation orientation = Orientation;
        if (orientation != ScrollOrientation.HorizontalScroll)
        {
            if (orientation == ScrollOrientation.VerticalScroll)
            {
                V = Maximum * (e.Y - ThumbHeight / 2) / (Height - ThumbHeight);
            }
        }
        else
        {
            V = Maximum * (e.X - ThumbHeight / 2) / (Width - ThumbHeight);
        }

        switch (Orientation)
        {
            case ScrollOrientation.HorizontalScroll: break;
            case ScrollOrientation.VerticalScroll: break;
        }

        Value = Math.Max(0, Math.Min(Maximum, V));
    }
    public virtual void OnScroll(ScrollEventType Type = ScrollEventType.ThumbPosition)
    {
        SCROLL?.Invoke(this, new ScrollEventArgs(Type, Value, Orientation));
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        if (Maximum > 0)
        {
            Rectangle THUMBRECT = Rectangle.Empty;

            switch (Orientation)
            {
                case ScrollOrientation.HorizontalScroll:
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(10, Height / 2), new Point(Width - 10, Height / 2));
                    THUMBRECT = new Rectangle(VALUE * (Width - ThumbHeight) / Maximum, 2, ThumbHeight, Height - 4);
                    break;

                case ScrollOrientation.VerticalScroll:
                    e.Graphics.DrawLine(new Pen(Color.FromArgb(40, 40, 40)), new Point(Width / 2, 10), new Point(Width / 2, Height - 10));
                    THUMBRECT = new Rectangle(2, VALUE * (Height - ThumbHeight) / Maximum, Width - 4, ThumbHeight);
                    break;
            }

            e.Graphics.FillRectangle(new SolidBrush(ThumbColor), THUMBRECT);
            e.Graphics.DrawRectangle(new Pen(BorderColor), new Rectangle(0, 0, Width - 1, Height - 1));
        }
    }
}