using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_LR4._1_OOP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Container<Circle> sto = new Container<Circle>();



        private void Paint_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sto.toLast();
                bool isFinded = false;
                for (int i = sto.size(); i > 0; i--, sto.prev())
                {
                    if (Math.Pow(sto.getIterator().x + 20 - e.X, 2) + Math.Pow(sto.getIterator().y + 20 - e.Y, 2) <= sto.getIterator().r * sto.getIterator().r)
                    {
                        sto.setCurPTR(sto.getIteratorPTR());
                        isFinded = true;
                        break;
                    }
                }
                if (isFinded == false)
                {
                    sto.add(new Circle(20, e.X - 20, e.Y - 20));
                }
            }
            else
            {
                bool isFinded = false;
                sto.toLast();
                for (int i = sto.size(); i > 0; i--, sto.prev())
                {
                    if (Math.Pow(sto.getIterator().x + 20 - e.X, 2) + Math.Pow(sto.getIterator().y + 20 - e.Y, 2) <= sto.getIterator().r * sto.getIterator().r)
                    {
                        sto.check();
                        isFinded = true;
                        break;
                    }
                }
                if (isFinded == false)
                {
                    sto.toFirst();
                    int kol = 0;
                    for (int i = 0; i < sto.size(); i++, sto.next())
                        if (sto.isChecked() == true) kol++;
                    sto.toFirst();
                    if (kol == 0 && sto.size() != 0) sto.del();
                    while (kol != 0)
                    {
                        if (sto.isChecked() == true)
                        {
                            if (sto.getIteratorPTR() == sto.getCurPTR()) sto.prevCur();
                            sto.delIterator();
                            kol--;
                        }
                        if (sto.size() != 0) sto.next();
                    }
                }
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next())
            {
                RectangleF tmp = new RectangleF((float)sto.getIterator().x, (float)sto.getIterator().y, (float)(2 * sto.getIterator().r), (float)(2 * sto.getIterator().r));
                e.Graphics.DrawEllipse(Pens.Black, tmp);
                if (sto.isChecked() == true)
                {
                    if (sto.getCurPTR() == sto.getIteratorPTR())
                    {
                        e.Graphics.DrawEllipse(new Pen(Color.Purple, 5), tmp);
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(new Pen(Color.Orange, 5), tmp);
                    }
                }
                else
                {
                    if (sto.getCurPTR() == sto.getIteratorPTR())
                    {
                        e.Graphics.DrawEllipse(new Pen(Color.Red, 5), tmp);
                    }
                    else
                    {
                        e.Graphics.DrawEllipse(new Pen(Color.Black, 1), tmp);
                    }
                }
                e.Graphics.FillEllipse(Brushes.Gray, tmp);
            }

        }
    }
}


public class Circle
{
    public int x;
    public int y;
    public int r;
    public Circle(int r, int x, int y)
    {
        this.x = x;
        this.y = y;
        this.r = r;
    }
}

public class Container<T>
{
    public class list
    {
        public T Data { get; set; }
        public list Right { get; set; }
        public list Left { get; set; }
        public bool IsChecked = false;
    };
    private list First;
    private list Last;
    private list Current;
    private list Iterator;

    private int rate;
    public Container()
    {
        First = null;
        rate = 0;
    }
    public void add(T obj)
    {
        list tmp = new list();
        tmp.Data = obj;
        if (First != null)
        {
            tmp.Left = Last;
            Last.Right = tmp;
            Last = tmp;
        }
        else
        {
            First = tmp;
            Last = First;
            Current = First;
        }
        Last.Right = First;  //можно зациклить список
        Current = tmp;
        First.Left = Last;
        rate++;
    }
    public void addBefore(T obj)
    {
        list tmp = new list();
        tmp.Data = obj;
        if (First != null)
        {
            tmp.Left = (Current.Left);
            (Current.Left).Right = tmp;
            Current.Left = tmp;
            tmp.Right = Current;
            if (Current == First) First = Current.Left;
        }
        else
        {
            First = tmp;
            Last = First;
            Current = First;
            First.Right = First;
            First.Left = First;
        }
        Current = tmp;
        rate++;
    }
    public void addAfter(T obj)
    {
        list tmp = new list();
        tmp.Data = obj;
        if (First != null)
        {
            tmp.Left = Current;
            tmp.Right = Current.Right;
            (Current.Right).Left = tmp;
            Current.Right = tmp;
            if (Current == Last) Last = Current.Right;
        }
        else
        {
            First = tmp;
            Last = First;
            Current = First;
            First.Right = First;
            First.Left = First;
        }
        Current = tmp;
        rate++;
    }
    public void toFirst()
    {
        Iterator = First;
    }
    public void toLast()
    {
        Iterator = Last;
    }
    public void next()
    {
        Iterator = Iterator.Right;
    }
    public void prev()
    {
        Iterator = Iterator.Left;
    }
    public void nextCur()
    {
        Current = Current.Right;
    }
    public void prevCur()
    {
        Current = Current.Left;
    }
    public void del()
    {
        if (rate == 1)
        {
            First = null;
            Last = null;
            Current = null;
        }
        else
        {
            (Current.Left).Right = Current.Right;
            (Current.Right).Left = Current.Left;
            list tmp = Current;
            if (Current == Last)
            {
                Current = Current.Left;
                Last = Current;
            }
            else
            {
                if (Current == First) First = Current.Right;
                Current = Current.Right;
            }
        }
        rate--;
    }
    public void delIterator()
    {
        if (rate == 1)
        {
            First = null;
            Last = null;
            Iterator = null;
        }
        else
        {
            (Iterator.Left).Right = Iterator.Right;
            (Iterator.Right).Left = Iterator.Left;
            if (Iterator == Last)
            {
                Iterator = Iterator.Left;
                Last = Iterator;
            }
            else
            {
                if (Iterator == First) First = Iterator.Right;
                Iterator = Iterator.Left;
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
        return Iterator;
    }
    public list getCurPTR()
    {
        return Current;
    }
    public void setCurPTR(list it)
    {
        Current = it;
    }
    public bool isChecked()
    {
        if (Iterator.IsChecked == true) return true; else return false;
    }
    public void check()
    {
        Iterator.IsChecked = !Iterator.IsChecked;
    }
    public T getIterator()
    {
        return (Iterator.Data);
    }
    public T get()
    {
        return (Current.Data);
    }
};
