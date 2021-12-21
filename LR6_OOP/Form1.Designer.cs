
namespace LR6_OOP
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rad_star = new System.Windows.Forms.RadioButton();
            this.rad_sqar = new System.Windows.Forms.RadioButton();
            this.rad_cir = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.textb_R = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textb_A = new System.Windows.Forms.TextBox();
            this.textb_N = new System.Windows.Forms.TextBox();
            this.textb_Y = new System.Windows.Forms.TextBox();
            this.textb_X = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.but_bcol = new System.Windows.Forms.Button();
            this.but_col = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.colorDialog3 = new System.Windows.Forms.ColorDialog();
            this.but_Del = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(968, 709);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBox1_PreviewKeyDown);
            // 
            // rad_star
            // 
            this.rad_star.AutoSize = true;
            this.rad_star.Location = new System.Drawing.Point(13, 3);
            this.rad_star.Name = "rad_star";
            this.rad_star.Size = new System.Drawing.Size(76, 21);
            this.rad_star.TabIndex = 1;
            this.rad_star.TabStop = true;
            this.rad_star.Text = "Звезда";
            this.rad_star.UseVisualStyleBackColor = true;
            // 
            // rad_sqar
            // 
            this.rad_sqar.AutoSize = true;
            this.rad_sqar.Location = new System.Drawing.Point(13, 30);
            this.rad_sqar.Name = "rad_sqar";
            this.rad_sqar.Size = new System.Drawing.Size(127, 21);
            this.rad_sqar.TabIndex = 2;
            this.rad_sqar.TabStop = true;
            this.rad_sqar.Text = "Многоугольник";
            this.rad_sqar.UseVisualStyleBackColor = true;
            // 
            // rad_cir
            // 
            this.rad_cir.AutoSize = true;
            this.rad_cir.Location = new System.Drawing.Point(13, 57);
            this.rad_cir.Name = "rad_cir";
            this.rad_cir.Size = new System.Drawing.Size(108, 21);
            this.rad_cir.TabIndex = 3;
            this.rad_cir.TabStop = true;
            this.rad_cir.Text = "Окружность";
            this.rad_cir.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.rad_star);
            this.panel1.Controls.Add(this.rad_cir);
            this.panel1.Controls.Add(this.rad_sqar);
            this.panel1.Location = new System.Drawing.Point(1001, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 87);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.trackBar3);
            this.panel2.Controls.Add(this.textb_R);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.textb_A);
            this.panel2.Controls.Add(this.textb_N);
            this.panel2.Controls.Add(this.textb_Y);
            this.panel2.Controls.Add(this.textb_X);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1001, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 220);
            this.panel2.TabIndex = 5;
            // 
            // trackBar3
            // 
            this.trackBar3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar3.Location = new System.Drawing.Point(3, 176);
            this.trackBar3.Maximum = 500;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(204, 56);
            this.trackBar3.TabIndex = 8;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // textb_R
            // 
            this.textb_R.Location = new System.Drawing.Point(74, 145);
            this.textb_R.Name = "textb_R";
            this.textb_R.Size = new System.Drawing.Size(93, 22);
            this.textb_R.TabIndex = 10;
            this.textb_R.TextChanged += new System.EventHandler(this.textb_R_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Size  :";
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBar1.Location = new System.Drawing.Point(3, 113);
            this.trackBar1.Maximum = 360;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar1.Size = new System.Drawing.Size(208, 56);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // textb_A
            // 
            this.textb_A.Location = new System.Drawing.Point(74, 87);
            this.textb_A.Name = "textb_A";
            this.textb_A.Size = new System.Drawing.Size(93, 22);
            this.textb_A.TabIndex = 7;
            this.textb_A.TextChanged += new System.EventHandler(this.textb_A_TextChanged);
            // 
            // textb_N
            // 
            this.textb_N.Location = new System.Drawing.Point(48, 53);
            this.textb_N.Name = "textb_N";
            this.textb_N.Size = new System.Drawing.Size(57, 22);
            this.textb_N.TabIndex = 6;
            this.textb_N.TextChanged += new System.EventHandler(this.textb_N_TextChanged);
            // 
            // textb_Y
            // 
            this.textb_Y.Location = new System.Drawing.Point(159, 19);
            this.textb_Y.Name = "textb_Y";
            this.textb_Y.Size = new System.Drawing.Size(48, 22);
            this.textb_Y.TabIndex = 5;
            this.textb_Y.TextChanged += new System.EventHandler(this.textb_Y_TextChanged);
            // 
            // textb_X
            // 
            this.textb_X.Location = new System.Drawing.Point(48, 19);
            this.textb_X.Name = "textb_X";
            this.textb_X.Size = new System.Drawing.Size(57, 22);
            this.textb_X.TabIndex = 4;
            this.textb_X.TextChanged += new System.EventHandler(this.textb_X_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Angle :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "N  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y  :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "X  :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.but_bcol);
            this.panel3.Controls.Add(this.but_col);
            this.panel3.Location = new System.Drawing.Point(1001, 341);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(228, 80);
            this.panel3.TabIndex = 6;
            // 
            // but_bcol
            // 
            this.but_bcol.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_bcol.Location = new System.Drawing.Point(13, 39);
            this.but_bcol.Name = "but_bcol";
            this.but_bcol.Size = new System.Drawing.Size(194, 34);
            this.but_bcol.TabIndex = 1;
            this.but_bcol.Text = "Цвет фона";
            this.but_bcol.UseVisualStyleBackColor = false;
            this.but_bcol.Click += new System.EventHandler(this.bot_bcol_Click);
            // 
            // but_col
            // 
            this.but_col.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_col.Location = new System.Drawing.Point(13, 3);
            this.but_col.Name = "but_col";
            this.but_col.Size = new System.Drawing.Size(195, 30);
            this.but_col.TabIndex = 0;
            this.but_col.Text = "Цвет фигуры";
            this.but_col.UseVisualStyleBackColor = false;
            this.but_col.Click += new System.EventHandler(this.but_col_Click);
            // 
            // but_Del
            // 
            this.but_Del.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.but_Del.Location = new System.Drawing.Point(15, 3);
            this.but_Del.Name = "but_Del";
            this.but_Del.Size = new System.Drawing.Size(192, 26);
            this.but_Del.TabIndex = 7;
            this.but_Del.Text = "Очисть поле";
            this.but_Del.UseVisualStyleBackColor = false;
            this.but_Del.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1001, 416);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Controls.Add(this.label12);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(1001, 515);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(228, 206);
            this.panel4.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 177);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(170, 17);
            this.label15.TabIndex = 8;
            this.label15.Text = "W,A,S,D - перемещение ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 156);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "Z - предыдущая фирура";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "X - следующая фигура";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 118);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "\"<\" \">\" - вращать";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "V - уменшить размер";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "B - увеличить размер ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "M - уменьшить N";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "N - увеличить N";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "C - удалить фигуру";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(132, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "------->";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Location = new System.Drawing.Point(15, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "<-------";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.but_Del);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Location = new System.Drawing.Point(1001, 427);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(228, 82);
            this.panel5.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 725);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "LAB6_OOP";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton rad_star;
        private System.Windows.Forms.RadioButton rad_sqar;
        private System.Windows.Forms.RadioButton rad_cir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textb_X;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textb_A;
        private System.Windows.Forms.TextBox textb_N;
        private System.Windows.Forms.TextBox textb_Y;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textb_R;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button but_bcol;
        private System.Windows.Forms.Button but_col;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ColorDialog colorDialog3;
        private System.Windows.Forms.Button but_Del;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TrackBar trackBar3;
    }
}

