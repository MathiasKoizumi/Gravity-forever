using System;
using System.Drawing;
using System.Reflection;

namespace GravityLivesOn1._0
{
	internal class Ding
	{
		public Image image;

		public double størrelse = 45.0;

		public int masse;

		public float particles;

		public Color farve;

		public float positionX;

		public float positionY;

		public float positionZ;

		public float hastighedX = 5f;

		public float hastighedY = 5f;

		public float hastighedZ = 5f;

		public int alder;

		public int vinkel;

		public Random rand = new Random();

		public Ding(int speed, int massen, int color, int size, Form1 form1)
		{
			størrelse = (double)size;
			hastighedX = (float)rand.Next(speed);
			hastighedY = (float)rand.Next(speed);
			hastighedZ = (float)rand.Next(speed);
			positionX = (float)rand.Next(1200);
			positionY = (float)rand.Next(400);
			positionZ = (float)rand.Next(500);
			Assembly.GetExecutingAssembly();
			if (rand.Next(2) == 0)
			{
				masse = massen;
			}
			particles = (float)((double)massen * størrelse + (double)masse * størrelse);
			alder = 0;
			vinkel = rand.Next(1, 360);
			farve = Color.FromArgb(rand.Next(color), rand.Next(color), rand.Next(color), rand.Next(color));
		}

		public Ding()
		{
		}
	}
}
