using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR6_OOP
{
    public partial class Form1 : Form
    {

        Storage<Circle> sto = new Storage<Circle>();
        private int x, y, xi, yi;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left))
            {
                sto.toLast();
                bool isFinded = false;
                for (int i = sto.size(); i > 0; i--, sto.prev())
                    if (Math.Pow(sto.getIterator().getX() - e.X, 2) + Math.Pow(sto.getIterator().getY() - e.Y, 2) <= sto.getIterator().getRad() * sto.getIterator().getRad())
                    {
                        sto.setCurPTR(sto.getIteratorPTR());
                        update();
                        isFinded = true;
                        break;
                    }
                if (isFinded == false)
                {
                    if (rad_cir.Checked == true)
                    {
                        Random rnd = new Random();
                        int rad = rnd.Next(10, 100);
                        if (rad > e.X) rad = e.X;
                        if (rad > e.Y) rad = e.Y;
                        if (e.X + rad > pictureBox1.Width) rad = pictureBox1.Width - e.X;
                        if (e.Y + rad > pictureBox1.Height) rad = pictureBox1.Height - e.Y;
                        sto.add(new Circle(e.X, e.Y, rad, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256))));
                        update();
                    }
                    else
                    if (rad_sqar.Checked == true)
                    {
                        Random rnd = new Random();
                        int rad = rnd.Next(10, 100);
                        if (rad > e.X) rad = e.X;
                        if (rad > e.Y) rad = e.Y;
                        if (e.X + rad > pictureBox1.Width) rad = pictureBox1.Width - e.X;
                        if (e.Y + rad > pictureBox1.Height) rad = pictureBox1.Height - e.Y;
                        sto.add(new Polygon(e.X, e.Y, rad, rnd.Next(3, 9), 0, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256))));
                        ((Polygon)sto.get()).Rotate(rnd.Next(0, 180));
                        update();
                    }
                    else
                    if (rad_star.Checked == true)
                    {
                        Random rnd = new Random();
                        int rad = rnd.Next(10, 100);
                        if (rad > e.X) rad = e.X;
                        if (rad > e.Y) rad = e.Y;
                        if (e.X + rad > pictureBox1.Width) rad = pictureBox1.Width - e.X;
                        if (e.Y + rad > pictureBox1.Height) rad = pictureBox1.Height - e.Y;
                        sto.add(new Star(e.X, e.Y, rad, rnd.Next(5, 9), 0, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256))));
                        ((Star)sto.get()).Rotate(rnd.Next(0, 180));
                        update();
                    }
                }
                pictureBox1.Invalidate();
            }
            if ((e.Button == MouseButtons.Right))
            {
                sto.toLast();
                if (sto.size() != 0 && Math.Pow(sto.get().getX() - e.X, 2) + Math.Pow(sto.get().getY() - e.Y, 2) <= sto.get().getRad() * sto.get().getRad()) sto.del();
                else
                    for (int i = sto.size(); i > 0; i--, sto.prev())
                        if (Math.Pow(sto.getIterator().getX() - e.X, 2) + Math.Pow(sto.getIterator().getY() - e.Y, 2) <= sto.getIterator().getRad() * sto.getIterator().getRad())
                        {
                            sto.setCurPTR(sto.getIteratorPTR());
                            break;
                        }
                if (sto.size() != 0) update();
                pictureBox1.Invalidate();
            }
            if (sto.size() != 0)
            {
                xi = sto.get().getX();
                yi = sto.get().getY();
            }
            x = e.X;
            y = e.Y;
        }
        private void update()
        {

            if (sto.size() != 0)
            {
                pictureBox1.Refresh();
                colorDialog1.Color = sto.get().GetColor();
                but_col.BackColor = colorDialog1.Color;
                if (sto.get() is Polygon)
                {
                    textb_A.Enabled = true;
                    textb_X.Text = sto.get().getX().ToString();
                    textb_Y.Text = sto.get().getY().ToString();
                    textb_N.Text = ((Polygon)sto.get()).getN().ToString();
                    textb_R.Text = sto.get().getRad().ToString();
                    textb_A.Text = ((Polygon)sto.get()).getRotate().ToString();
                    rad_sqar.Checked = true;
                    trackBar1.Enabled = true;
                    trackBar1.Value = ((Polygon)sto.get()).getRotate();
                    trackBar3.Enabled = true;
                    trackBar3.Value = sto.get().getRad();

                    return;
                }
                if (sto.get() is Star)
                {
                    textb_A.Enabled = true;
                    textb_X.Text = sto.get().getX().ToString();
                    textb_Y.Text = sto.get().getY().ToString();
                    textb_N.Text = ((Star)sto.get()).getN().ToString();
                    textb_R.Text = sto.get().getRad().ToString();
                    textb_A.Text = ((Star)sto.get()).getRotate().ToString();
                    rad_star.Checked = true;
                    trackBar1.Enabled = true;
                    trackBar3.Enabled = true;
                    trackBar1.Value = ((Star)sto.get()).getRotate();
                    trackBar3.Value = sto.get().getRad();
                    return;
                }
                if (sto.get() is Circle)
                {
                    textb_X.Text = sto.get().getX().ToString();
                    textb_Y.Text = sto.get().getY().ToString();
                    textb_A.Text = "Unavailable";
                    textb_A.Enabled = false;
                    textb_R.Text = sto.get().getRad().ToString();
                    rad_cir.Checked = true;
                    trackBar1.Enabled = false;
                    trackBar3.Enabled = true;
                    trackBar3.Value = sto.get().getRad();

                    return;
                }
            }
        }

        private void but_col_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK && sto.getCurPTR() != null)
            {
                but_col.BackColor = colorDialog1.Color;
                sto.get().SetColor(colorDialog1.Color);
                pictureBox1.Invalidate();
            }
        }

        private void bot_bcol_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                but_bcol.BackColor = colorDialog2.Color;
                pictureBox1.BackColor = colorDialog2.Color;
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
            if (e.Button == MouseButtons.Left && sto.size() != 0)
            {

                this.Cursor = Cursors.Hand;
                if (xi + (e.X - x) > sto.get().getRad() && yi + (e.Y - y) > sto.get().getRad() && xi + (e.X - x) + sto.get().getRad() < pictureBox1.Size.Width && yi + (e.Y - y) + sto.get().getRad() < pictureBox1.Size.Height) sto.get().SetXY(xi + (e.X - x), yi + (e.Y - y));
                pictureBox1.Invalidate();
                update();
            }
        }

        private void textb_X_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (sto.size() != 0 && Int32.TryParse(textb_X.Text, out value) && sto.get().getRad() < value && sto.get().getRad() + value < pictureBox1.Width) sto.get().SetXY(value, sto.get().getY());
            pictureBox1.Invalidate();
        }

        private void textb_Y_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (sto.size() != 0 && Int32.TryParse(textb_Y.Text, out value) && sto.get().getRad() < value && sto.get().getRad() + value < pictureBox1.Width) sto.get().SetXY(sto.get().getX(), value);
            pictureBox1.Invalidate();
        }

        private void textb_N_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (sto.size() != 0 && Int32.TryParse(textb_N.Text, out value) && value > 1)
            {
                if (sto.get() is Polygon) ((Polygon)sto.get()).setN(value);
                if (sto.get() is Star) ((Star)sto.get()).setN(value);
            }
            pictureBox1.Invalidate();
        }

        private void textb_R_TextChanged(object sender, EventArgs e)
        {
            int value;
            int a = pictureBox1.Height - 10;
            int b = pictureBox1.Width - 10;
            if (trackBar3.Value < sto.get().getRad() && Int32.TryParse(textb_R.Text, out value)) sto.get().setRad(value);
            if (sto.size() != 0 && Int32.TryParse(textb_R.Text, out value) && (sto.get().getRad() < sto.get().getY() && sto.get().getRad() + sto.get().getY() < a && sto.get().getRad() < sto.get().getX() + 1 && sto.get().getRad() + sto.get().getX() + 1 < b)) sto.get().setRad(value);
            pictureBox1.Invalidate();
        }

        private void textb_A_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (sto.size() != 0 && Int32.TryParse(textb_A.Text, out value))
            {
                if (sto.get() is Polygon) ((Polygon)sto.get()).Rotate(value);
                if (sto.get() is Star) ((Star)sto.get()).Rotate(value);
            }
            pictureBox1.Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            textb_A.Text = trackBar1.Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (sto.size() != 0) sto.del();
            pictureBox1.Invalidate();
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sto.size() != 0) sto.prevCur();
            pictureBox1.Invalidate();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (sto.size() != 0) sto.nextCur();
            pictureBox1.Invalidate();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

            textb_R.Text = trackBar3.Value.ToString();
        }

        public Form1()
        {
            InitializeComponent();
            (pictureBox1 as Control).KeyPress += new KeyPressEventHandler(PressEventHandler);
        }
        public void PressEventHandler(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 51 && sto.size() != 0)
            {

                pictureBox1.Invalidate();
                rad_star.Checked = true;
                sto.toLast();
                Random rnd = new Random();
                int rad = rnd.Next(10, 100);
                int e_X = rnd.Next(10, pictureBox1.Width - 10);
                int e_Y = rnd.Next(50, pictureBox1.Height - 10);
                for (int i = sto.size(); i > 0; i--, sto.prev())
                    if (Math.Pow(sto.getIterator().getX() - e_X, 2) + Math.Pow(sto.getIterator().getY() - e_Y, 2) <= sto.getIterator().getRad() * sto.getIterator().getRad())
                    {
                        sto.setCurPTR(sto.getIteratorPTR());
                        update();
                        break;
                    }
                if (rad > e_X) rad = e_X;
                if (rad > e_Y) rad = e_Y;
                if (e_X + rad > pictureBox1.Width) rad = pictureBox1.Width - e_X;
                if (e_Y + rad > pictureBox1.Height) rad = pictureBox1.Height - e_Y;
                sto.add(new Circle(e_X, e_Y, rad, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256))));
                update();
                pictureBox1.Invalidate();
                if (sto.size() != 0)
                {
                    xi = sto.get().getX();
                    yi = sto.get().getY();
                }
                x = e_X;
                y = e_Y;

            }
            if (e.KeyChar == 49 && sto.size() != 0)
            {
                pictureBox1.Invalidate();
                rad_star.Checked = true;
                sto.toLast();
                Random rnd = new Random();
                int rad = rnd.Next(10, 100);
                int e_X = rnd.Next(10, pictureBox1.Width - 10);
                int e_Y = rnd.Next(50, pictureBox1.Height - 10);
                for (int i = sto.size(); i > 0; i--, sto.prev())
                    if (Math.Pow(sto.getIterator().getX() - e_X, 2) + Math.Pow(sto.getIterator().getY() - e_Y, 2) <= sto.getIterator().getRad() * sto.getIterator().getRad())
                    {
                        sto.setCurPTR(sto.getIteratorPTR());
                        update();
                        break;
                    }
                if (rad > e_X) rad = e_X;
                if (rad > e_Y) rad = e_Y;
                if (e_X + rad > pictureBox1.Width) rad = pictureBox1.Width - e_X;
                if (e_Y + rad > pictureBox1.Height) rad = pictureBox1.Height - e_Y;
                sto.add(new Star(e_X, e_Y, rad, rnd.Next(5, 9), 0, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256))));
                ((Star)sto.get()).Rotate(rnd.Next(0, 180));
                update();
                pictureBox1.Invalidate();
                if (sto.size() != 0)
                {
                    xi = sto.get().getX();
                    yi = sto.get().getY();
                }
                x = e_X;
                y = e_Y;
            }

            if (e.KeyChar == 50 && sto.size() != 0)
            {

                rad_sqar.Checked = true;
                sto.toLast();
                Random rnd = new Random();
                int rad = rnd.Next(10, 100);
                int e_X = rnd.Next(10, pictureBox1.Width - 10);
                int e_Y = rnd.Next(50, pictureBox1.Height - 10);
                for (int i = sto.size(); i > 0; i--, sto.prev())
                    if (Math.Pow(sto.getIterator().getX() - e_X, 2) + Math.Pow(sto.getIterator().getY() - e_Y, 2) <= sto.getIterator().getRad() * sto.getIterator().getRad())
                    {
                        sto.setCurPTR(sto.getIteratorPTR());
                        update();
                        break;
                    }

                if (rad > e_X) rad = e_X;
                if (rad > e_X) rad = e_X;
                if (e_X + rad > pictureBox1.Width) rad = pictureBox1.Width - e_X;
                if (e_Y + rad > pictureBox1.Height) rad = pictureBox1.Height - e_Y;
                sto.add(new Polygon(e_X, e_Y, rad, rnd.Next(3, 9), 0, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256))));
                ((Polygon)sto.get()).Rotate(rnd.Next(0, 180));
                update();
                pictureBox1.Invalidate();
                if (sto.size() != 0)
                {
                    xi = sto.get().getX();
                    yi = sto.get().getY();
                }
                x = e_X;
                y = e_Y;

            }
            if (e.KeyChar == 119 && sto.size() != 0 && sto.get().getRad() < sto.get().getY()) sto.get().SetXY(sto.get().getX(), sto.get().getY() - 1);
            if (e.KeyChar == 115 && sto.size() != 0 && sto.get().getRad() + sto.get().getY() < pictureBox1.Width) sto.get().SetXY(sto.get().getX(), sto.get().getY() + 1);
            if (e.KeyChar == 97 && sto.size() != 0 && sto.get().getRad() < sto.get().getX() + 1) sto.get().SetXY(sto.get().getX() - 1, sto.get().getY());
            if (e.KeyChar == 100 && sto.size() != 0 && sto.get().getRad() + sto.get().getX() + 1 < pictureBox1.Width) sto.get().SetXY(sto.get().getX() + 1, sto.get().getY());
            if (e.KeyChar == 46 && sto.size() != 0)
            {
                if (sto.get() is Polygon) ((Polygon)sto.get()).Rotate(((Polygon)sto.get()).getRotate() + 1);
                if (sto.get() is Star) ((Star)sto.get()).Rotate(((Star)sto.get()).getRotate() + 1);
            }
            if (e.KeyChar == 44 && sto.size() != 0)
            {
                if (sto.get() is Polygon) ((Polygon)sto.get()).Rotate(((Polygon)sto.get()).getRotate() - 1);
                if (sto.get() is Star) ((Star)sto.get()).Rotate(((Star)sto.get()).getRotate() - 1);
            }
            if (e.KeyChar == 122 && sto.size() != 0) sto.prevCur();
            if (e.KeyChar == 120 && sto.size() != 0) sto.nextCur();
            if (e.KeyChar == 99 && sto.size() != 0) sto.del();
            if (e.KeyChar == 110 && sto.size() != 0)
            {
                if (sto.get() is Polygon) ((Polygon)sto.get()).setN(((Polygon)sto.get()).getN() + 1);
                if (sto.get() is Star) ((Star)sto.get()).setN(((Star)sto.get()).getN() + 1);
            }
            if (e.KeyChar == 109 && sto.size() != 0)
            {
                if (sto.get() is Polygon && ((Polygon)sto.get()).getN() > 3) ((Polygon)sto.get()).setN(((Polygon)sto.get()).getN() - 1);
                if (sto.get() is Star && ((Star)sto.get()).getN() > 3) ((Star)sto.get()).setN(((Star)sto.get()).getN() - 1);
            }
            int a = pictureBox1.Height - 10;
            int b = pictureBox1.Width - 10;
            if (e.KeyChar == 98 && sto.size() != 0 && sto.get().getRad() < sto.get().getY() && sto.get().getRad() + sto.get().getY() < a && sto.get().getRad() < sto.get().getX() + 1 && sto.get().getRad() + sto.get().getX() + 1 < b) sto.get().setRad(sto.get().getRad() + 1);
            if (e.KeyChar == 118 && sto.size() != 0 && sto.get().getRad() >= 2) sto.get().setRad(sto.get().getRad() - 1);
            update();
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (sto.size() != 0)
            {
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next())
                {
                    if (sto.getIterator() is Polygon)   //если многоугольник
                    {
                        e.Graphics.DrawPolygon(Pens.Black, ((Polygon)sto.getIterator()).GetPoints());
                        e.Graphics.FillPolygon(new SolidBrush(sto.getIterator().GetColor()), ((Polygon)sto.getIterator()).GetPoints());

                    }
                    else
                    if (sto.getIterator() is Star)   //если звезда
                    {
                        e.Graphics.DrawPolygon(Pens.Black, ((Star)sto.getIterator()).GetPoints());
                        e.Graphics.FillPolygon(new SolidBrush(sto.getIterator().GetColor()), ((Star)sto.getIterator()).GetPoints());
                    }
                    else //если круг
                    {
                        Rectangle tmp = new Rectangle(sto.getIterator().getX() - sto.getIterator().getRad(), sto.getIterator().getY() - sto.getIterator().getRad(), 2 * sto.getIterator().getRad(), 2 * sto.getIterator().getRad());
                        e.Graphics.DrawEllipse(Pens.Black, tmp);
                        e.Graphics.FillEllipse(new SolidBrush(sto.getIterator().GetColor()), tmp);

                    }
                }
                e.Graphics.DrawEllipse(new Pen(Color.Gray, 3), sto.get().getX() - sto.get().getRad() - 2, sto.get().getY() - sto.get().getRad() - 2, 2 * sto.get().getRad() + 4, 2 * sto.get().getRad() + 4);
            }

        }
    }
}
public class point
{
    protected int x { get; set; }
    protected int y { get; set; }
    public Color col = SystemColors.Window;
    public point()
    {
        x = 0; y = 0;
    }
    public point(int x, int y, Color c)
    {
        this.x = x;
        this.y = y;
        col = c;
    }
    public point(point p)
    {
        x = p.x;
        y = p.y;
        col = p.col;
    }
    public int getX()
    {
        return x;
    }
    public int getY()
    {
        return y;
    }
    virtual protected void Resize() { }
    virtual public void SetXY(int x, int y)
    {
        this.x = x;
        this.y = y;
        Resize();
    }
    public void SetColor(Color c)
    {
        col = c;
    }
    public Color GetColor()
    {
        return col;
    }
}

public class Circle : point
{
    protected int rad;
    public Circle()
    {
        rad = 10;
    }
    public Circle(int x, int y, int r, Color c) : base(x, y, c)
    {
        rad = r;
    }
    public override void SetXY(int x, int y)
    {
        base.SetXY(x, y);
    }
    public void setRad(int rr)
    {
        rad = rr;
        Resize();
    }
    public int getRad()
    {
        return rad;
    }
    override protected void Resize()
    {
    }
}

public class Star : Circle
{
    private int n, rotate;
    List<PointF> lst;
    override protected void Resize()
    {
        lst = null;
        lst = new List<PointF>();
        double a = rotate * Math.PI / 180, da = Math.PI / n, l;
        for (int k = 0; k < 2 * n + 1; k++)
        {
            l = k % 2 == 0 ? rad : rad / 2;
            lst.Add(new PointF((float)(x + l * Math.Cos(a)), (float)(y + l * Math.Sin(a))));
            a += da;
        }
    }
    public Star(int x, int y, int r, int n, int rot, Color c) : base(x, y, r, c)
    {
        rotate = rot;
        this.n = n;
        Resize();
    }
    public void setN(int nn)
    {
        n = nn;
        Resize();
    }
    public void Rotate(int rr)
    {
        rotate = rr;
        Resize();
    }
    public int getN()
    {
        return n;
    }
    public int getRotate()
    {
        return rotate;
    }
    public PointF[] GetPoints()
    {
        return lst.ToArray<PointF>();
    }
}


public class Polygon : Circle
{
    private int n, rotate;
    List<PointF> lst;

    override protected void Resize()
    {
        lst = null;
        lst = new List<PointF>();
        for (int i = rotate; i < rotate + 360; i += 360 / n)
        {
            double radiani = (double)(i * 3.14) / 180;
            float xx = x + (int)(rad * Math.Cos(radiani));
            float yy = y + (int)(rad * Math.Sin(radiani));
            lst.Add(new PointF(xx, yy));
        }
    }
    public Polygon(int x, int y, int r, int n, int rot, Color c) : base(x, y, r, c)
    {
        rotate = rot;
        this.n = n;
        Resize();
    }
    public void setN(int nn)
    {
        n = nn;
        Resize();
    }
    public void Rotate(int rr)
    {
        rotate = rr;
        Resize();
    }
    public int getN()
    {
        return n;
    }
    public int getRotate()
    {
        return rotate;
    }
    public PointF[] GetPoints()
    {
        return lst.ToArray<PointF>();
    }
}

public class Storage<T>
{
    public class list
    {
        public T data { get; set; }
        public list right { get; set; }
        public list left { get; set; }
        public bool isChecked = false;
    };
    private list first;
    private list last;
    private list current;
    private list iterator;

    private int rate;
    public Storage()
    {
        first = null;
        rate = 0;
    }
    public void add(T obj)
    {
        list tmp = new list();
        tmp.data = obj;
        if (first != null)
        {
            tmp.left = last;
            last.right = tmp;
            last = tmp;
        }
        else
        {
            first = tmp;
            last = first;
            current = first;
        }
        last.right = first;  //можно зациклить список
        current = tmp;
        first.left = last;
        rate++;
    }
    public void addBefore(T obj)
    {
        list tmp = new list();
        tmp.data = obj;
        if (first != null)
        {
            tmp.left = (current.left);
            (current.left).right = tmp;
            current.left = tmp;
            tmp.right = current;
            if (current == first) first = current.left;
        }
        else
        {
            first = tmp;
            last = first;
            current = first;
            first.right = first;
            first.left = first;
        }
        current = tmp;
        rate++;
    }
    public void addAfter(T obj)
    {
        list tmp = new list();
        tmp.data = obj;
        if (first != null)
        {
            tmp.left = current;
            tmp.right = current.right;
            (current.right).left = tmp;
            current.right = tmp;
            if (current == last) last = current.right;
        }
        else
        {
            first = tmp;
            last = first;
            current = first;
            first.right = first;
            first.left = first;
        }
        current = tmp;
        rate++;
    }
    public void toFirst()
    {
        iterator = first;
    }
    public void toLast()
    {
        iterator = last;
    }
    public void next()
    {
        iterator = iterator.right;
    }
    public void prev()
    {
        iterator = iterator.left;
    }
    public void nextCur()
    {
        current = current.right;
    }
    public void prevCur()
    {
        current = current.left;
    }
    public void del()
    {
        if (rate == 1)
        {
            first = null;
            last = null;
            current = null;
        }
        else
        {
            (current.left).right = current.right;
            (current.right).left = current.left;
            list tmp = current;
            if (current == last)
            {
                current = current.left;
                last = current;
            }
            else
            {
                if (current == first) first = current.right;
                current = current.right;
            }
        }
        rate--;
    }
    public void delIterator()
    {
        if (rate == 1)
        {
            first = null;
            last = null;
            iterator = null;
        }
        else
        {
            (iterator.left).right = iterator.right;
            (iterator.right).left = iterator.left;
            if (iterator == last)
            {
                iterator = iterator.left;
                last = iterator;
            }
            else
            {
                if (iterator == first) first = iterator.right;
                iterator = iterator.left;
            }
        }
        rate--;
    }
    public int size()
    {
        return rate;
    }
    public list getIteratorPTR()
    {
        return iterator;
    }
    public list getCurPTR()
    {
        return current;
    }
    public void setCurPTR(list it)
    {
        current = it;
    }
    public bool isChecked()
    {
        if (iterator.isChecked == true) return true; else return false;
    }
    public void check()
    {
        iterator.isChecked = !iterator.isChecked;
    }
    public T getIterator()
    {
        return (iterator.data);
    }
    public T get()
    {
        return (current.data);
    }
};

