using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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

		private NumericUpDown antalObjekter;

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

		public Form1()
		{
			rand = new Random();
			InitializeComponent();
			designObjekter((int)antalObjekter.Value, (int)speed.Value);
			g = panel1.CreateGraphics();
			bitmap = new Bitmap(panel1.Width, panel1.Height, PixelFormat.Format32bppArgb);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.Clear(Color.Beige);
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
				graphics.FillEllipse(new SolidBrush(objekter[i].farve), objekter[i].positionX, objekter[i].positionY, (float)(int)objekter[i].størrelse, (float)(int)objekter[i].størrelse);
			}
			graphics.Save();
			g.DrawImage(image, 0, 0);
			animate();
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
			for (int i = 0; (decimal)i < rounds.Value; i++)
			{
				DrawPaintMe();
			}
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
			panel1 = new Panel();
			numericUpDown1 = new NumericUpDown();
			label1 = new Label();
			button1 = new Button();
			checkBox1 = new CheckBox();
			checkBox2 = new CheckBox();
			numericUpDown2 = new NumericUpDown();
			antalObjekter = new NumericUpDown();
			label2 = new Label();
			checkBox4 = new CheckBox();
			numericUpDown4 = new NumericUpDown();
			sizeDrops = new NumericUpDown();
			label3 = new Label();
			checkBox5 = new CheckBox();
			label4 = new Label();
			spredningStørrelse = new NumericUpDown();
			button2 = new Button();
			rounds = new NumericUpDown();
			label5 = new Label();
			speed = new NumericUpDown();
			label6 = new Label();
			((ISupportInitialize)numericUpDown1).BeginInit();
			((ISupportInitialize)numericUpDown2).BeginInit();
			((ISupportInitialize)antalObjekter).BeginInit();
			((ISupportInitialize)numericUpDown4).BeginInit();
			((ISupportInitialize)sizeDrops).BeginInit();
			((ISupportInitialize)spredningStørrelse).BeginInit();
			((ISupportInitialize)rounds).BeginInit();
			((ISupportInitialize)speed).BeginInit();
			base.SuspendLayout();
			panel1.Location = new Point(2, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(1266, 591);
			panel1.TabIndex = 0;
			panel1.Paint += panel1_Paint;
			numericUpDown1.Location = new Point(22, 624);
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new Size(44, 20);
			numericUpDown1.TabIndex = 1;
			numericUpDown1.Value = new decimal(new int[4]
			{
				50,
				0,
				0,
				0
			});
			label1.AutoSize = true;
			label1.Location = new Point(72, 626);
			label1.Name = "label1";
			label1.Size = new Size(40, 13);
			label1.TabIndex = 2;
			label1.Text = "Gravity";
			button1.Location = new Point(193, 664);
			button1.Name = "button1";
			button1.Size = new Size(109, 23);
			button1.TabIndex = 3;
			button1.Text = "Create Magneto";
			button1.UseVisualStyleBackColor = true;
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(193, 606);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(96, 17);
			checkBox1.TabIndex = 4;
			checkBox1.Text = "Affect particles";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox2.AutoSize = true;
			checkBox2.Location = new Point(193, 630);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new Size(88, 17);
			checkBox2.TabIndex = 5;
			checkBox2.Text = "Particle mass";
			checkBox2.UseVisualStyleBackColor = true;
			numericUpDown2.Location = new Point(287, 627);
			numericUpDown2.Name = "numericUpDown2";
			numericUpDown2.Size = new Size(61, 20);
			numericUpDown2.TabIndex = 6;
			numericUpDown2.Value = new decimal(new int[4]
			{
				100,
				0,
				0,
				0
			});
			antalObjekter.Location = new Point(1134, 608);
			antalObjekter.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			antalObjekter.Name = "antalObjekter";
			antalObjekter.Size = new Size(47, 20);
			antalObjekter.TabIndex = 7;
			antalObjekter.Value = new decimal(new int[4]
			{
				20,
				0,
				0,
				0
			});
			antalObjekter.ValueChanged += antalObjekter_ValueChanged;
			label2.AutoSize = true;
			label2.Location = new Point(1047, 610);
			label2.Name = "label2";
			label2.Size = new Size(81, 13);
			label2.TabIndex = 8;
			label2.Text = "Number objects";
			checkBox4.AutoSize = true;
			checkBox4.Location = new Point(761, 631);
			checkBox4.Name = "checkBox4";
			checkBox4.Size = new Size(55, 17);
			checkBox4.TabIndex = 10;
			checkBox4.Text = "Shield";
			checkBox4.UseVisualStyleBackColor = true;
			numericUpDown4.Location = new Point(822, 630);
			numericUpDown4.Name = "numericUpDown4";
			numericUpDown4.Size = new Size(57, 20);
			numericUpDown4.TabIndex = 11;
			sizeDrops.Location = new Point(914, 630);
			sizeDrops.Maximum = new decimal(new int[4]
			{
				200,
				0,
				0,
				0
			});
			sizeDrops.Name = "sizeDrops";
			sizeDrops.Size = new Size(40, 20);
			sizeDrops.TabIndex = 12;
			sizeDrops.Value = new decimal(new int[4]
			{
				50,
				0,
				0,
				0
			});
			sizeDrops.ValueChanged += sizeDrops_ValueChanged;
			label3.AutoSize = true;
			label3.Location = new Point(960, 632);
			label3.Name = "label3";
			label3.Size = new Size(64, 13);
			label3.TabIndex = 13;
			label3.Text = "Size objects";
			checkBox5.AutoSize = true;
			checkBox5.Location = new Point(1188, 645);
			checkBox5.Name = "checkBox5";
			checkBox5.Size = new Size(68, 17);
			checkBox5.TabIndex = 16;
			checkBox5.Text = "Pico size";
			checkBox5.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Location = new Point(1047, 645);
			label4.Name = "label4";
			label4.Size = new Size(68, 13);
			label4.TabIndex = 15;
			label4.Text = "Size diversity";
			spredningStørrelse.Location = new Point(1134, 643);
			spredningStørrelse.Maximum = new decimal(new int[4]
			{
				255,
				0,
				0,
				0
			});
			spredningStørrelse.Name = "spredningStørrelse";
			spredningStørrelse.Size = new Size(47, 20);
			spredningStørrelse.TabIndex = 14;
			spredningStørrelse.Value = new decimal(new int[4]
			{
				1,
				0,
				0,
				0
			});
			spredningStørrelse.ValueChanged += spredningStørrelse_ValueChanged;
			button2.Location = new Point(363, 600);
			button2.Name = "button2";
			button2.Size = new Size(118, 44);
			button2.TabIndex = 17;
			button2.Text = "Start";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			rounds.Location = new Point(22, 651);
			rounds.Maximum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				0
			});
			rounds.Name = "rounds";
			rounds.Size = new Size(44, 20);
			rounds.TabIndex = 18;
			rounds.Value = new decimal(new int[4]
			{
				50,
				0,
				0,
				0
			});
			label5.AutoSize = true;
			label5.Location = new Point(72, 653);
			label5.Name = "label5";
			label5.Size = new Size(44, 13);
			label5.TabIndex = 19;
			label5.Text = "Rounds";
			speed.Location = new Point(515, 606);
			speed.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			speed.Name = "speed";
			speed.Size = new Size(63, 20);
			speed.TabIndex = 20;
			speed.Value = new decimal(new int[4]
			{
				25,
				0,
				0,
				0
			});
			speed.ValueChanged += numericUpDown3_ValueChanged;
			label6.AutoSize = true;
			label6.Location = new Point(584, 610);
			label6.Name = "label6";
			label6.Size = new Size(38, 13);
			label6.TabIndex = 21;
			label6.Text = "Speed";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(1266, 711);
			base.Controls.Add(label6);
			base.Controls.Add(speed);
			base.Controls.Add(label5);
			base.Controls.Add(rounds);
			base.Controls.Add(button2);
			base.Controls.Add(checkBox5);
			base.Controls.Add(label4);
			base.Controls.Add(spredningStørrelse);
			base.Controls.Add(label3);
			base.Controls.Add(sizeDrops);
			base.Controls.Add(numericUpDown4);
			base.Controls.Add(checkBox4);
			base.Controls.Add(label2);
			base.Controls.Add(antalObjekter);
			base.Controls.Add(numericUpDown2);
			base.Controls.Add(checkBox2);
			base.Controls.Add(checkBox1);
			base.Controls.Add(button1);
			base.Controls.Add(label1);
			base.Controls.Add(numericUpDown1);
			base.Controls.Add(panel1);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Name = "Form1";
			Text = "Gravity v2.0";
			((ISupportInitialize)numericUpDown1).EndInit();
			((ISupportInitialize)numericUpDown2).EndInit();
			((ISupportInitialize)antalObjekter).EndInit();
			((ISupportInitialize)numericUpDown4).EndInit();
			((ISupportInitialize)sizeDrops).EndInit();
			((ISupportInitialize)spredningStørrelse).EndInit();
			((ISupportInitialize)rounds).EndInit();
			((ISupportInitialize)speed).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
