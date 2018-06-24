using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace GravityLivesOn1._0
{
	public class Form1 : Form
	{
		private Random rand;
        private Ding[] objekter;
        private Graphics g;
        private Bitmap bitmap;
        private IContainer components;
        private Panel panel1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Button button1;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private NumericUpDown numericUpDown2;
        private Label label2;
        private CheckBox checkBox4;
        private NumericUpDown numericUpDown4;
        private NumericUpDown sizeDrops;
        private Label label3;
        private CheckBox checkBox5;
        private Label label4;
        private NumericUpDown spredningStørrelse;
        private Button button2;
        private NumericUpDown rounds;
        private Label label5;
        private NumericUpDown speed;
        private Label label6;
        private TrackBar antalObjekter;
        private Button button3;
        private bool drawing;


        public Form1()
		{

            drawing = false;
            rand = new Random();
			InitializeComponent();
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
			g = panel1.CreateGraphics();
			bitmap = new Bitmap(SystemInformation.VirtualScreen.Width,
                               SystemInformation.VirtualScreen.Height,
                               PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.Beige);
			}
            
		}

        private void Go()
        {

            while(true)
            {
                if (!drawing)
                    return;
                DrawPaintMe();
            }


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void DrawPaintMe()
		{
			Bitmap image = new Bitmap(bitmap.Width, bitmap.Height);
			Graphics graphics = Graphics.FromImage(image);
			graphics = Graphics.FromImage(image);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(bitmap, 0, 0);
			for (int i = 0; i < objekter.Length; i++)
			{
                try
                {
                    graphics.FillEllipse(new SolidBrush(objekter[i].farve), objekter[i].positionX, objekter[i].positionY, (int)objekter[i].størrelse, (int)objekter[i].størrelse);

                }
                catch { }

            }
			graphics.Save();
			g.DrawImage(image, 0, 0);
            try
            {
                animate();
            }
            catch { }
		}

		private void animate()
		{
			for (int i = 0; i < objekter.Length; i++)
			{
				objekter[i].positionX = objekter[i].positionX + objekter[i].hastighedX;
				objekter[i].positionY = objekter[i].positionY + objekter[i].hastighedY;
				objekter[i].positionZ = objekter[i].positionZ + objekter[i].hastighedZ;
				switch (rand.Next(2))
				{
				case 0:
					objekter[i].hastighedX = (float)rand.Next((int)speed.Value);
					objekter[i].hastighedY = (float)rand.Next((int)speed.Value);
					objekter[i].hastighedZ = (float)rand.Next((int)speed.Value);
					break;
				case 1:
					objekter[i].hastighedX = (float)(-rand.Next((int)speed.Value));
					objekter[i].hastighedY = (float)(-rand.Next((int)speed.Value));
					objekter[i].hastighedZ = (float)(-rand.Next((int)speed.Value));
					break;
				}
				switch (rand.Next(2))
				{
				case 0:
					objekter[i].størrelse = objekter[i].størrelse + (double)rand.Next((int)spredningStørrelse.Value);
					break;
				case 1:
					if (objekter[i].størrelse > (double)(int)spredningStørrelse.Value)
					{
						objekter[i].størrelse = objekter[i].størrelse - (double)rand.Next((int)spredningStørrelse.Value);
					}
					break;
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

            if (drawing)
                drawing = false;
            else
                drawing = true;

            Thread thread = new Thread(new ThreadStart(Go));
            thread.Start();
		}

		private void designObjekter(int number, int speed)
		{
			objekter = new Ding[number];
			for (int i = 0; i < number; i++)
			{
				Ding ding = new Ding(rand.Next(speed), rand.Next(100), rand.Next(200), (int)sizeDrops.Value, this);
				objekter[i] = ding;
			}
		}

		private void antalObjekter_ValueChanged(object sender, EventArgs e)
		{
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
		}

		private void sizeDrops_ValueChanged(object sender, EventArgs e)
		{
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
		}

		private void spredningStørrelse_ValueChanged(object sender, EventArgs e)
		{
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
		}

		private void numericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
		}

		private void button3_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.sizeDrops = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.spredningStørrelse = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.rounds = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.antalObjekter = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeDrops)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spredningStørrelse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rounds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antalObjekter)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.antalObjekter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1298, 761);
            this.panel1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(22, 624);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 626);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gravity";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create Magneto";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(193, 606);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Affect particles";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(193, 630);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(88, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Particle mass";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(287, 627);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(61, 20);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1047, 610);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Number objects";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(761, 631);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(55, 17);
            this.checkBox4.TabIndex = 10;
            this.checkBox4.Text = "Shield";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(822, 630);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown4.TabIndex = 11;
            // 
            // sizeDrops
            // 
            this.sizeDrops.Location = new System.Drawing.Point(914, 630);
            this.sizeDrops.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.sizeDrops.Name = "sizeDrops";
            this.sizeDrops.Size = new System.Drawing.Size(40, 20);
            this.sizeDrops.TabIndex = 12;
            this.sizeDrops.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.sizeDrops.ValueChanged += new System.EventHandler(this.sizeDrops_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(960, 632);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Size objects";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(1188, 645);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(68, 17);
            this.checkBox5.TabIndex = 16;
            this.checkBox5.Text = "Pico size";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1047, 645);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Size diversity";
            // 
            // spredningStørrelse
            // 
            this.spredningStørrelse.Location = new System.Drawing.Point(1134, 643);
            this.spredningStørrelse.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.spredningStørrelse.Name = "spredningStørrelse";
            this.spredningStørrelse.Size = new System.Drawing.Size(47, 20);
            this.spredningStørrelse.TabIndex = 14;
            this.spredningStørrelse.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(363, 600);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 44);
            this.button2.TabIndex = 17;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rounds
            // 
            this.rounds.Location = new System.Drawing.Point(22, 651);
            this.rounds.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.rounds.Name = "rounds";
            this.rounds.Size = new System.Drawing.Size(44, 20);
            this.rounds.TabIndex = 18;
            this.rounds.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 653);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Rounds";
            // 
            // speed
            // 
            this.speed.Location = new System.Drawing.Point(515, 606);
            this.speed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(63, 20);
            this.speed.TabIndex = 20;
            this.speed.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 610);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Speed";
            // 
            // antalObjekter
            // 
            this.antalObjekter.LargeChange = 50;
            this.antalObjekter.Location = new System.Drawing.Point(1134, 592);
            this.antalObjekter.Maximum = 100000;
            this.antalObjekter.Minimum = 1;
            this.antalObjekter.Name = "antalObjekter";
            this.antalObjekter.Size = new System.Drawing.Size(142, 45);
            this.antalObjekter.TabIndex = 8;
            this.antalObjekter.TickFrequency = 1000;
            this.antalObjekter.Value = 500;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(384, 664);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Reset";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 761);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rounds);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.spredningStørrelse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sizeDrops);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Gravity v2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeDrops)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spredningStørrelse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rounds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antalObjekter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            designObjekter((int)antalObjekter.Value, (int)speed.Value);
        }
    }
}
