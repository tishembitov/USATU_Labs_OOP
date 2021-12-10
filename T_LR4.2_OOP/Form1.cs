using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_LR4._2_OOP
{
    public partial class Form1 : Form
    {
        Model model;
        public Form1()
        {
            InitializeComponent();
            model = new Model();
            model.observerA += new System.EventHandler(this.UpdateFromModel);
            model.observerB += new System.EventHandler(this.UpdateFromModel);
            model.observerC += new System.EventHandler(this.UpdateFromModel);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            model.SetValueA(Convert.ToInt32(textBox1.Text));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            model.SetValueA(Decimal.ToInt32(numericUpDown1.Value));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            model.SetValueA(Convert.ToInt32(trackBar1.Value));
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            model.SetValueB(Convert.ToInt32(textBox2.Text));
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            model.SetValueB(Decimal.ToInt32(numericUpDown2.Value));
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            model.SetValueB(Convert.ToInt32(trackBar2.Value));
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            model.SetValueC(Convert.ToInt32(textBox3.Text));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            model.SetValueC(Decimal.ToInt32(numericUpDown3.Value));
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            model.SetValueC(Convert.ToInt32(trackBar3.Value));
        }


        private void UpdateFromModel(object sender, EventArgs e)
        {
            textBox1.Text = model.GetValueA().ToString();
            numericUpDown1.Value = model.GetValueA();
            trackBar1.Value = model.GetValueA();
            textBox2.Text = model.GetValueB().ToString();
            numericUpDown2.Value = model.GetValueB();
            trackBar2.Value = model.GetValueB();
            textBox3.Text = model.GetValueC().ToString();
            numericUpDown3.Value = model.GetValueC();
            trackBar3.Value = model.GetValueC();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.textBox1 = textBox1.Text;
            Properties.Settings.Default.textBox2 = textBox2.Text;
            Properties.Settings.Default.textBox3 = textBox3.Text;
            Properties.Settings.Default.numericUpDown1 = numericUpDown1.Value;
            Properties.Settings.Default.numericUpDown2 = numericUpDown2.Value;
            Properties.Settings.Default.numericUpDown3 = numericUpDown3.Value;
            Properties.Settings.Default.trackBar1 = trackBar1.Value;
            Properties.Settings.Default.trackBar2 = trackBar2.Value;
            Properties.Settings.Default.trackBar3 = trackBar3.Value;
            Properties.Settings.Default.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.textBox1;
            textBox2.Text = Properties.Settings.Default.textBox2;
            textBox3.Text = Properties.Settings.Default.textBox3;
            numericUpDown1.Value = Properties.Settings.Default.numericUpDown1;
            numericUpDown2.Value = Properties.Settings.Default.numericUpDown2;
            numericUpDown3.Value = Properties.Settings.Default.numericUpDown3;
            trackBar1.Value = Properties.Settings.Default.trackBar1;
            trackBar2.Value = Properties.Settings.Default.trackBar2;
            trackBar3.Value = Properties.Settings.Default.trackBar3;
        }
    }

    public class Model
    {
        public System.EventHandler observerA;
        public System.EventHandler observerB;
        public System.EventHandler observerC;
        private int valueA = 0;
        private int valueB = 0;
        private int valueC = 0;
        public void SetValueA(int value)
        {
            if (value >= 0 && valueC <= 100)
            {
                valueA = value;
                if (valueA > valueB && valueA <= 98)
                {
                    valueB = valueA + 1;
                    valueC = valueB + 1;
                }

                else if (valueA > valueB && valueA > 98)
                    valueC = valueB = valueA;
                observerA.Invoke(this, null);
                observerB.Invoke(this, null);
                observerC.Invoke(this, null);
            }
        }
        public void SetValueB(int value)
        {
            if (value >= 0 && value <= 100)
            {
                if (valueA <= value && value <= valueC)
                    valueB = value;
                observerB.Invoke(this, null);
            }
            observerB.Invoke(this, null);
        }

        public void SetValueC(int value)
        {
            if (value >= 0 && valueC <= 100)
            {
                valueC = value;
                if (valueC < valueB && valueC >= 2)
                {
                    valueB = valueC - 1;
                    valueA = valueB - 1;
                }

                else if (valueC < valueB && valueC < 2)
                    valueA = valueB = valueC;
                observerA.Invoke(this, null);
                observerB.Invoke(this, null);
                observerC.Invoke(this, null);
            }
        }
        public int GetValueA()
        {
            return valueA;
        }

        public int GetValueB()
        {
            return valueB;
        }
        public int GetValueC()
        {
            return valueC;
        }
    }
}
