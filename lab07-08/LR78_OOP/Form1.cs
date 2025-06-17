using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace LR78_OOP
{
    public partial class Form1 : Form
    {
        Storage<Shape> sto = new Storage<Shape>();
        Tree tree;

        public Form1()
        {

            InitializeComponent();
            (pictureBox1 as Control).KeyPress += new KeyPressEventHandler(PressEventHandler);
            tree = new Tree(sto, treeView1);
            sto.AddObserver(tree);
            treeView1.CheckBoxes = true;

        }


        public void PressEventHandler(object sender, KeyPressEventArgs e)
        {
            if (sto.size() != 0)
            {
                if (e.KeyChar == 119) sto.get().OffsetXY(0, -1);
                if (e.KeyChar == 115) sto.get().OffsetXY(0, 1);
                if (e.KeyChar == 97) sto.get().OffsetXY(-1, 0);
                if (e.KeyChar == 100) sto.get().OffsetXY(1, 0);
                if (e.KeyChar == 98) sto.get().Grow(1);
                if (e.KeyChar == 118) sto.get().Grow(-1);
                if (e.KeyChar == 110)
                {
                    if (sto.get() is Polygon) ((Polygon)sto.get()).growN(1);
                    if (sto.get() is Star) ((Star)sto.get()).growN(1);
                }
                if (e.KeyChar == 109)
                {
                    if (sto.get() is Polygon) ((Polygon)sto.get()).growN(-1);
                    if (sto.get() is Star) ((Star)sto.get()).growN(-1);
                }
                if (e.KeyChar == 46)
                {
                    sto.get().Rotate(2);
                }
                if (e.KeyChar == 44)
                {
                    sto.get().Rotate(-2);
                }
                if (e.KeyChar == 122) sto.prevCur();
                if (e.KeyChar == 120) sto.nextCur();
                if (e.KeyChar == 99) sto.del();
                if (e.KeyChar == 107)
                {

                    if (colorDialog1.ShowDialog() == DialogResult.OK) sto.get().SetColor(colorDialog1.Color);
                }

                Random rnd = new Random();
                int obj = rnd.Next(1, 3);
                if (e.KeyChar == 49)
                {
                    int rad = rnd.Next(10, 100);
                    sto.add(new Circle(rnd.Next(4, pictureBox1.Width - 50), rnd.Next(4, pictureBox1.Height - 50), rad, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width - 50, pictureBox1.Height - 50));
                }
                if (e.KeyChar == 51)
                {
                    int rad = rnd.Next(10, 100);
                    sto.add(new Polygon(rnd.Next(4, pictureBox1.Width - 50), rnd.Next(4, pictureBox1.Height - 50), rad, rnd.Next(3, 9), Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width - 50, pictureBox1.Height - 50));
                    ((Polygon)sto.get()).Rotate(rnd.Next(0, 180));
                }
                if (e.KeyChar == 50)
                {
                    int rad = rnd.Next(10, 100);
                    sto.add(new Star(rnd.Next(4, pictureBox1.Width - 50), rnd.Next(4, pictureBox1.Height - 50), rad, rnd.Next(5, 9), Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width - 50, pictureBox1.Height - 50));
                    ((Star)sto.get()).Rotate(rnd.Next(0, 180));
                }

            }
            tree.Print();
            pictureBox1.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sto.size() != 0 && !(sto.get() is SGroup))
            {
                sto.get().sticky = checkBox1.Checked;
                if (checkBox1.Checked == true) sto.get().AddStorage(sto);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                StreamWriter stream = new StreamWriter(f);
                stream.WriteLine(sto.size());
                if (sto.size() != 0)
                {
                    sto.toFirst();
                    for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Save(stream);
                }
                stream.Close();
                f.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sto.size() != 0)
            {
                SGroup group = new SGroup(pictureBox1.Width, pictureBox1.Height);
                sto.toFirst();
                int cnt = 0;
                for (int i = 0; i < sto.size(); i++, sto.next()) //считаем количество отмеченных элементов
                    if (sto.isChecked() == true) cnt++;
                while (cnt != 0)
                {
                    if (sto.isChecked() == true)
                    {
                        group.Add(sto.getIterator());
                        sto.delIterator();
                        cnt--;
                    }
                    if (sto.size() != 0) sto.next();
                }
                sto.add(group);
            }
            pictureBox1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (sto.size() != 0) sto.del();
            pictureBox1.Invalidate();
        }



        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            bool isFinded = false;
            if (sto.size() != 0)
            {
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next())
                {
                    if (sto.getIterator().Find(e.X, e.Y) == true && e.Button == MouseButtons.Left)
                    {
                        isFinded = true;
                        sto.setCurPTR();
                        break;
                    }
                    if (sto.getIterator().Find(e.X, e.Y) == true && e.Button == MouseButtons.Right)
                    {
                        isFinded = true;
                        sto.check();
                        break;
                    }
                }
            }
            if (isFinded == false)
            {
                if (radioButton3.Checked == true)
                {
                    Random rnd = new Random();
                    int rad = rnd.Next(10, 100);
                    sto.add(new Circle(e.X, e.Y, rad, Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width, pictureBox1.Height));
                }
                else
                if (radioButton2.Checked == true)
                {
                    Random rnd = new Random();
                    int rad = rnd.Next(10, 100);
                    sto.add(new Polygon(e.X, e.Y, rad, rnd.Next(3, 9), Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width, pictureBox1.Height));
                    ((Polygon)sto.get()).Rotate(rnd.Next(0, 180));
                }
                else
                if (radioButton1.Checked == true)
                {
                    Random rnd = new Random();
                    int rad = rnd.Next(10, 100);
                    sto.add(new Star(e.X, e.Y, rad, rnd.Next(5, 9), Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), pictureBox1.Width, pictureBox1.Height));
                    ((Star)sto.get()).Rotate(rnd.Next(0, 180));
                }
                if (checkBox1.Checked)
                {
                    sto.get().sticky = true;
                    sto.get().AddStorage(sto);
                }
            }
            if (isFinded == true && sto.get().sticky == true) checkBox1.Checked = true; else checkBox1.Checked = false;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (sto.size() != 0)
            {
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next())
                {
                    sto.getIterator().DrawObj(e.Graphics);
                    if (sto.isChecked() == true) sto.getIterator().DrawRectangle(e.Graphics, new Pen(Color.Gray, 2));
                }
                sto.get().DrawRectangle(e.Graphics, new Pen(Color.Red, 1));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (sto.size() != 0 && sto.get() is SGroup)
            {
                while (((SGroup)sto.get()).size() != 0)
                {
                    sto.addAfter(((SGroup)sto.get()).Out());
                    sto.prevCur();
                }
                sto.del();
            }
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream f = new FileStream(openFileDialog1.FileName, FileMode.Open);
                StreamReader stream = new StreamReader(f);
                int i = Convert.ToInt32(stream.ReadLine());
                Factory shapeFactory = new ShapeFactory();  //фабрика КОНКРЕТНЫХ объектов
                for (; i > 0; i--)
                {
                    string tmp = stream.ReadLine();
                    sto.add(shapeFactory.createShape(tmp));
                    sto.get().Load(stream);
                }
                stream.Close();
                f.Close();
            }
            pictureBox1.Invalidate();
            tree.Print();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {


            if ((e.Action == TreeViewAction.ByKeyboard || e.Action == TreeViewAction.ByMouse) && e.Node.Text != "Фигуры")
            {


                TreeNode tmp = e.Node;

                while (tmp.Parent.Text != "Фигуры") tmp = tmp.Parent;
                treeView1.SelectedNode = tmp;
                sto.toFirst();
                sto.setCurPTR();
                for (int i = 0; i < tmp.Index; i++)
                {

                    sto.nextCur();
                }
                sto.setCurPTR();
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox1.Focus();
        }



        private void Button6_Click(object sender, EventArgs e)
        {
            if (sto.size() != 0)
                sto.del();
            pictureBox1.Invalidate();

        }


        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tmp = e.Node;

            if (e.Button == MouseButtons.Right)
            {
                sto.toFirst();
                sto.setCurPTR();

                for (int i = 0; i < tmp.Index; i++)
                {
                    sto.nextCur();
                }
                if (sto.size() != 0 && sto.get() is SGroup)
                {
                    while (((SGroup)sto.get()).size() != 0)
                    {
                        sto.addAfter(((SGroup)sto.get()).Out());
                        sto.prevCur();
                    }
                    sto.del();
                }
            }
            if (e.Button == MouseButtons.Left)
            {

                treeView1.SelectedNode = tmp;

                sto.toFirst();
                for (int i = 0; i <= treeView1.SelectedNode.Index; i++)
                {
                    sto.next();
                }
                sto.check();

            }
            pictureBox1.Invalidate();


        }


        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode tmp = e.Node;
            treeView1.SelectedNode = tmp;

            sto.toFirst();

            for (int i = 0; i < treeView1.SelectedNode.Index; i++)
            {
                sto.next();
            }
            sto.setCurPTR();
            sto.del();


            pictureBox1.Invalidate();

        }
    }
}
public abstract class Shape : ObjObserved
{
    public string name; //имена для всех объектов и групп
    protected Rectangle rect; //область объекта для его отрисовки и выделения
    protected int x, y, width, height; //x, y для позиции объектов и групп, w и h для учитывания границ отрисовки
    public bool sticky = false;
    abstract public void Resize();
    abstract public void SetXY(int _x, int _y);
    abstract public void OffsetXY(int _x, int _y);
    abstract public void SetColor(Color c);
    abstract public void Grow(int gr);
    abstract public void Rotate(int gr);
    abstract public void DrawObj(System.Drawing.Graphics e);
    abstract public void DrawRectangle(System.Drawing.Graphics e, Pen pen);
    abstract public bool Find(int _x, int _y);
    abstract public bool Find(Shape obj);
    abstract public void Clone(); //потом сделаю мб
    abstract public Rectangle GetRectangle();  //получить границы фигуры для контроля выхода за пределы
    abstract public void Save(StreamWriter stream);
    abstract public void Load(StreamReader stream);
    abstract public string GetInfo();
}

public abstract class Factory
{
    public abstract Shape createShape(string name);
}

public class ShapeFactory : Factory
{
    public override Shape createShape(string name)
    {
        Shape shape;
        switch (name)
        {
            case "Circle":
                shape = new Circle();
                break;
            case "Group":
                shape = new SGroup();
                break;
            case "Polygon":
                shape = new Polygon();
                break;
            case "Star":
                shape = new Star();
                break;
            default:
                shape = null;
                break;
        }
        return shape;
    }
}


public class SGroup : Shape
{
    public Storage<Shape> sto;

    public SGroup()
    {
        sto = new Storage<Shape>();
        name = "Group";
    }

    public SGroup(int Width, int Height)
    {
        width = Width;
        height = Height;
        sto = new Storage<Shape>();
        name = "Group";
    }

    public void Add(Shape s)
    {
        sto.add(s);
        sto.get().sticky = false;
        if (sto.size() == 1) rect = new Rectangle(s.GetRectangle().X, s.GetRectangle().Y, s.GetRectangle().Width, s.GetRectangle().Height);
        else
        {
            if (s.GetRectangle().Left < rect.Left)
            {
                int tmp = rect.Right;
                rect.X = s.GetRectangle().Left;
                rect.Width = tmp - rect.X;
            }
            if (s.GetRectangle().Right > rect.Right) rect.Width = s.GetRectangle().Right - rect.X;
            if (s.GetRectangle().Top < rect.Top)
            {
                int tmp = rect.Bottom;
                rect.Y = s.GetRectangle().Top;
                rect.Height = tmp - rect.Y;
            }
            if (s.GetRectangle().Bottom > rect.Bottom) rect.Height = s.GetRectangle().Bottom - rect.Y;
        }
    }

    public Shape Out()
    {
        if (sto.size() != 0)
        {
            Shape tmp = sto.get();
            sto.del();
            Resize();
            return tmp;
        }
        return null;
    }

    public int size()
    {
        return sto.size();
    }

    public override void Resize()
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            rect = sto.getIterator().GetRectangle();
            for (int i = 0; i < sto.size(); i++, sto.next())
            {
                if (sto.getIterator().GetRectangle().Left < rect.Left)
                {
                    int tmp = rect.Right;
                    rect.X = sto.getIterator().GetRectangle().Left;
                    rect.Width = tmp - rect.X;
                }
                if (sto.getIterator().GetRectangle().Right > rect.Right) rect.Width = sto.getIterator().GetRectangle().Right - rect.X;
                if (sto.getIterator().GetRectangle().Top < rect.Top)
                {
                    int tmp = rect.Bottom;
                    rect.Y = sto.getIterator().GetRectangle().Top;
                    rect.Height = tmp - rect.Y;
                }
                if (sto.getIterator().GetRectangle().Bottom > rect.Bottom) rect.Height = sto.getIterator().GetRectangle().Bottom - rect.Y;
            }
        }
    }

    public override void Clone()
    {
        throw new NotImplementedException();
    }

    public override void DrawObj(Graphics e)
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().DrawObj(e);
        }
    }

    public override void Grow(int gr)
    {
        if (sto.size() != 0)
        {
            if (gr > 0 && rect.X + gr > 1 && gr + rect.Right < width - 1 && rect.Y + gr > 1 && gr + rect.Bottom < height - 1)
            {
                rect.X -= gr;
                rect.Y -= gr;
                rect.Width += 2 * gr;
                rect.Height += 2 * gr;
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Grow(gr);
            }
            if (gr < 0)
            {
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Grow(gr);
                if (gr < 0) Resize();
            }
        }
    }

    public override void OffsetXY(int _x, int _y)
    {
        if (sto.size() != 0)
        {
            if (rect.X + _x > 0 && _x + rect.Right < width)
            {
                rect.X += _x;
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().OffsetXY(_x, 0);
            }
            if (rect.Y + _y > 0 && _y + rect.Bottom < height)
            {
                rect.Y += _y;
                sto.toFirst();
                for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().OffsetXY(0, _y);
            }
        }
    }

    public override void SetColor(Color c)
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().SetColor(c);
        }
    }

    public override void SetXY(int _x, int _y)
    {
        throw new NotImplementedException();
    }

    public override Rectangle GetRectangle()
    {
        return rect;
    }

    public override bool Find(int _x, int _y)
    {
        if (rect.X < _x && _x < rect.Right && rect.Y < _y && _y < rect.Bottom) return true; else return false;
    }

    public override void DrawRectangle(Graphics e, Pen pen)
    {
        e.DrawRectangle(pen, rect);
    }

    public override void Save(StreamWriter stream)
    {
        stream.WriteLine("Group");
        stream.WriteLine(sto.size() + " " + width + " " + height);
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Save(stream);
        }
    }

    public override void Load(StreamReader stream)
    {
        ShapeFactory factory = new ShapeFactory();
        string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int i = Convert.ToInt32(data[0]);
        width = Convert.ToInt32(data[1]);
        height = Convert.ToInt32(data[2]);
        for (; i > 0; i--)
        {
            Shape tmp = factory.createShape(stream.ReadLine());
            tmp.Load(stream);
            Add(tmp);
        }
    }

    public override string GetInfo()
    {
        return name + "    Size : " + sto.size().ToString();
    }

    public override void Rotate(int gr)
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) sto.getIterator().Rotate(gr);
        }
    }

    public override bool Find(Shape obj)
    {
        if (sto.size() != 0)
        {
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next()) if (sto.getIterator().Find(obj) == true) return true;
        }
        return false;
    }
}

public class Circle : Shape
{
    protected int radius;
    protected Color col;
    public Circle()
    {
        x = 0;
        y = 0;
        radius = 0;
        name = "Circle";
    }
    public Circle(int x, int y, int r, Color c, int Width, int Height)
    {
        width = Width;
        height = Height;
        name = "Circle";
        this.x = x;
        this.y = y;
        col = c;
        //контроль выхода за границы при инициализации
        if (r > x) r = x;
        if (x + r > width) r = width - x;
        if (r > y) r = y;
        if (y + r > height) r = height - y;
        radius = r;
        rect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
    }

    public override void DrawObj(Graphics e)
    {
        e.DrawEllipse(new Pen(Color.Black, 2), rect);
        e.FillEllipse(new SolidBrush(col), rect);
    }

    public override void DrawRectangle(Graphics e, Pen pen)
    {
        e.DrawRectangle(pen, rect);
    }

    public override void OffsetXY(int _x, int _y)
    {
        if (storage != null && storage.size() != 0 && sticky == true)
        {
            storage.toFirst();
            for (int i = 0; i < storage.size(); i++, storage.next())
            {
                if (Find(storage.getIterator()) == true && storage.getIterator() != this)
                {
                    if (storage.getIterator().sticky == false)
                        storage.getIterator().OffsetXY(_x, _y);
                }
            }
        }
        if (x + _x > radius && x + _x + radius < width) x += _x;
        if (y + _y > radius && y + _y + radius < height) y += _y;
        Resize();
    }

    public override void Resize()
    {
        rect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
    }

    public override void Grow(int gr)
    {
        if (radius + gr < x && x + radius + gr < width && radius + gr < y && y + radius + gr < height && radius + gr > 0) radius += gr;
        Resize();
    }

    public override void SetColor(Color c)
    {
        col = c;
    }

    public override void SetXY(int _x, int _y)
    {
        throw new NotImplementedException();
    }

    public override void Clone()
    {
        throw new NotImplementedException();
    }

    public override Rectangle GetRectangle()
    {
        return rect;
    }

    public override bool Find(int _x, int _y)
    {
        if (Math.Pow(x - _x, 2) + Math.Pow(y - _y, 2) <= radius * radius) return true; else return false;
    }

    public override void Save(StreamWriter stream)
    {
        stream.WriteLine("Circle");
        stream.WriteLine((rect.X + radius) + " " + (rect.Y + radius) + " " + radius + " " + col.R + " " + col.G + " " + col.B + " " + width + " " + height);
    }

    public override void Load(StreamReader stream)
    {
        string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        x = Convert.ToInt32(data[0]);
        y = Convert.ToInt32(data[1]);
        radius = Convert.ToInt32(data[2]);
        col = Color.FromArgb(Convert.ToInt32(data[3]), Convert.ToInt32(data[4]), Convert.ToInt32(data[5]));
        width = Convert.ToInt32(data[6]);
        height = Convert.ToInt32(data[7]);
        Resize();
    }

    public override string GetInfo()
    {
        return name + "  X: " + x + " Y: " + y + " Rad: " + radius + " " + col.ToString();
    }

    public override void Rotate(int gr)
    {

    }

    public override bool Find(Shape obj)
    {
        string[] data = obj.GetInfo().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (data[0] != "Group")
        {
            int _x = Convert.ToInt32(data[2]);
            int _y = Convert.ToInt32(data[4]);
            int _rad = Convert.ToInt32(data[6]);
            if (Math.Pow(x - _x, 2) + Math.Pow(y - _y, 2) <= Math.Pow(radius + _rad, 2)) return true;
        }
        else return obj.Find(this); //просим группу поискать нас
        return false;
    }
}

public class Polygon : Circle
{
    private int n, rotate = 0;
    List<PointF> lst;
    public Polygon() : base()
    {
        name = "Polygon";
    }

    public Polygon(int x, int y, int r, int n, Color c, int Width, int Height) : base(x, y, r, c, Width, Height)
    {
        this.n = n;
        //контроль выхода за границы при инициализации
        if (r > x) r = x;
        if (x + r > width) r = width - x;
        if (r > y) r = y;
        if (y + r > height) r = height - y;
        Resize();
        name = "Polygon";
    }

    public override void Clone()
    {
        throw new NotImplementedException();
    }

    public override void DrawObj(Graphics e)
    {
        e.DrawPolygon(new Pen(Color.Black, 2), lst.ToArray());
        e.FillPolygon(new SolidBrush(col), lst.ToArray());
    }

    public override void DrawRectangle(Graphics e, Pen pen)
    {
        e.DrawRectangle(pen, rect);
    }

    public override bool Find(int _x, int _y)
    {
        if (rect.X < _x && _x < rect.Right && rect.Y < _y && _y < rect.Bottom) return true; else return false;
    }

    public override Rectangle GetRectangle()
    {
        return rect;
    }

    public override void Grow(int gr)
    {
        if (radius + gr < x && x + radius + gr < width && radius + gr < y && y + radius + gr < height && radius + gr > 0) radius += gr;
        Resize();
    }

    public override void Load(StreamReader stream)
    {
        string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        x = Convert.ToInt32(data[0]);
        y = Convert.ToInt32(data[1]);
        radius = Convert.ToInt32(data[2]);
        n = Convert.ToInt32(data[3]);
        rotate = Convert.ToInt32(data[4]);
        col = Color.FromArgb(Convert.ToInt32(data[5]), Convert.ToInt32(data[6]), Convert.ToInt32(data[7]));
        width = Convert.ToInt32(data[8]);
        height = Convert.ToInt32(data[9]);
        Resize();
    }

    public override void OffsetXY(int _x, int _y)
    {
        if (storage != null && storage.size() != 0 && sticky == true)
        {
            storage.toFirst();
            for (int i = 0; i < storage.size(); i++, storage.next())
            {
                if (Find(storage.getIterator()) == true && storage.getIterator() != this)
                {
                    if (storage.getIterator().sticky == false)
                        storage.getIterator().OffsetXY(_x, _y);
                }
            }
        }
        if (x + _x > radius && x + _x + radius < width) x += _x;
        if (y + _y > radius && y + _y + radius < height) y += _y;
        Resize();
    }

    public override void Resize()
    {
        lst = null;
        lst = new List<PointF>();
        for (int i = rotate; i < rotate + 360; i += 360 / n)
        {
            double radiani = (double)(i * 3.14) / 180;
            float xx = x + (int)(radius * Math.Cos(radiani));
            float yy = y + (int)(radius * Math.Sin(radiani));
            lst.Add(new PointF(xx, yy));
        }
        rect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
    }

    public override void Save(StreamWriter stream)
    {
        stream.WriteLine("Polygon");
        stream.WriteLine(x + " " + y + " " + radius + " " + n + " " + rotate + " " + col.R + " " + col.G + " " + col.B + " " + width + " " + height);
    }

    public override void SetColor(Color c)
    {
        col = c;
    }

    public override void SetXY(int _x, int _y)
    {

    }

    public override string GetInfo()
    {
        return name + "  X: " + x + " Y: " + y + " Rad: " + radius + " N: " + n + " " + col.ToString();
    }

    public override void Rotate(int gr)
    {
        rotate += gr;
        Resize();
    }

    public void growN(int gr)
    {
        if (n + gr > 2) n += gr;
        Resize();
    }
}

public class Star : Circle
{
    private int n, rotate = 0;
    List<PointF> lst;
    public Star() : base()
    {
        name = "Star";
    }

    public Star(int x, int y, int r, int n, Color c, int Width, int Height) : base(x, y, r, c, Width, Height)
    {
        this.n = n;
        //контроль выхода за границы при инициализации
        if (r > x) r = x;
        if (x + r > width) r = width - x;
        if (r > y) r = y;
        if (y + r > height) r = height - y;
        Resize();
        name = "Star";
    }

    public override void Clone()
    {
        throw new NotImplementedException();
    }

    public override void DrawObj(Graphics e)
    {
        e.DrawPolygon(new Pen(Color.Black, 2), lst.ToArray());
        e.FillPolygon(new SolidBrush(col), lst.ToArray());
    }

    public override void DrawRectangle(Graphics e, Pen pen)
    {
        e.DrawRectangle(pen, rect);
    }

    public override bool Find(int _x, int _y)
    {
        if (rect.X < _x && _x < rect.Right && rect.Y < _y && _y < rect.Bottom) return true; else return false;
    }

    public override Rectangle GetRectangle()
    {
        return rect;
    }

    public override void Grow(int gr)
    {
        if (radius + gr < x && x + radius + gr < width && radius + gr < y && y + radius + gr < height && radius + gr > 0) radius += gr;
        Resize();
    }

    public override void Load(StreamReader stream)
    {
        string[] data = stream.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        x = Convert.ToInt32(data[0]);
        y = Convert.ToInt32(data[1]);
        radius = Convert.ToInt32(data[2]);
        n = Convert.ToInt32(data[3]);
        rotate = Convert.ToInt32(data[4]);
        col = Color.FromArgb(Convert.ToInt32(data[5]), Convert.ToInt32(data[6]), Convert.ToInt32(data[7]));
        width = Convert.ToInt32(data[8]);
        height = Convert.ToInt32(data[9]);
        Resize();
    }

    public override void Rotate(int gr)
    {
        rotate += gr;
        Resize();
    }

    public override void OffsetXY(int _x, int _y)
    {
        if (storage != null && storage.size() != 0 && sticky == true)
        {
            storage.toFirst();
            for (int i = 0; i < storage.size(); i++, storage.next())
            {
                if (Find(storage.getIterator()) == true && storage.getIterator() != this)
                {
                    if (storage.getIterator().sticky == false)
                        storage.getIterator().OffsetXY(_x, _y);
                }
            }
        }
        if (x + _x > radius && x + _x + radius < width) x += _x;
        if (y + _y > radius && y + _y + radius < height) y += _y;
        Resize();
    }

    public override void Resize()
    {
        lst = null;
        lst = new List<PointF>();
        double a = rotate * Math.PI / 180, da = Math.PI / n, l;
        for (int k = 0; k < 2 * n + 1; k++)
        {
            l = k % 2 == 0 ? radius : radius / 2;
            lst.Add(new PointF((float)(x + l * Math.Cos(a)), (float)(y + l * Math.Sin(a))));
            a += da;
        }
        rect = new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius);
    }

    public override void Save(StreamWriter stream)
    {
        stream.WriteLine("Star");
        stream.WriteLine(x + " " + y + " " + radius + " " + n + " " + rotate + " " + col.R + " " + col.G + " " + col.B + " " + width + " " + height);
    }

    public override void SetColor(Color c)
    {
        col = c;
    }

    public override void SetXY(int _x, int _y)
    {

    }

    public override string GetInfo()
    {
        return name + "  X: " + x + " Y: " + y + " Rad: " + radius + " N: " + n + " " + col.ToString();
    }

    public void growN(int gr)
    {
        if (n + gr > 3) n += gr;
        Resize();
    }
}

class DPanel : Panel
{
    public DPanel()
    {
        this.DoubleBuffered = true;
        this.ResizeRedraw = true;
    }
}

public class Observer
{
    public virtual void SubjectChanged() { return; }
}

class Tree : Observer
{
    private Storage<Shape> sto;
    private TreeView tree;
    public Tree(Storage<Shape> sto, TreeView tree)
    {
        this.sto = sto;
        this.tree = tree;
    }

    public void Print()
    {
        tree.Nodes.Clear();
        if (sto.size() != 0)
        {
            int SelectedIndex = 0;
            TreeNode start = new TreeNode("Фигуры");
            sto.toFirst();
            for (int i = 0; i < sto.size(); i++, sto.next())
            {
                if (sto.getCurPTR() == sto.getIteratorPTR()) SelectedIndex = i;
                PrintNode(start, sto.getIterator());
            }
            tree.Nodes.Add(start);

            for (int i = 0; i < sto.size(); i++)
            {
                sto.next();
                tree.SelectedNode = tree.Nodes[0].Nodes[i];
                if (sto.isChecked() == true)
                    tree.SelectedNode.ForeColor = Color.Red;
                else tree.SelectedNode.ForeColor = Color.Black;
            }
        }
        tree.ExpandAll();

    }

    private void PrintNode(TreeNode node, Shape shape)
    {
        if (shape is SGroup)
        {
            TreeNode tn = new TreeNode(shape.GetInfo());
            if (((SGroup)shape).sto.size() != 0)
            {
                ((SGroup)shape).sto.toFirst();
                for (int i = 0; i < ((SGroup)shape).sto.size(); i++, ((SGroup)shape).sto.next())
                    PrintNode(tn, ((SGroup)shape).sto.getIterator());
            }
            node.Nodes.Add(tn);
        }
        else
        {

            node.Nodes.Add(shape.GetInfo());
        }
    }

    public override void SubjectChanged()
    {
        Print();
    }
}

public class ObjObserved
{
    public Storage<Shape> storage;
    public void AddStorage(Storage<Shape> sto)
    {
        storage = sto;
    }
}

public class Observed
{
    private List<Observer> observers;
    public Observed()
    {
        observers = new List<Observer>();
    }
    public void AddObserver(Observer o)
    {
        observers.Add(o);
    }
    public void Notify()
    {
        foreach (Observer observer in observers) observer.SubjectChanged();
    }
}

public class Storage<T> : Observed
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
        Notify();
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
        Notify();
    }
    public void prevCur()
    {
        current = current.left;
        Notify();
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
        Notify();
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
        Notify();
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
    public void setCurPTR()
    {
        current = iterator;
        Notify();
    }
    public bool isChecked()
    {
        if (iterator.isChecked == true) return true; else return false;
    }
    public void check()
    {
        iterator.isChecked = !iterator.isChecked;
        Notify();
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
