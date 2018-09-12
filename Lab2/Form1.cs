using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
	public partial class Form1 : Form
	{
		//Task1EqualGrey task1EqualGrey;

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
		/*	Bitmap image = (Bitmap) Bitmap.FromFile(textBox1.Text);
			for (int i = 0; i < image.Width; ++i)
				for (int j = 0; j < image.Height; ++j) {
					var pixel = image.GetPixel(i, j);
					var grayScale = (pixel.R + pixel.G + pixel.B) / 3;
					image.SetPixel(i, j, Color.FromArgb(255, grayScale, grayScale, grayScale));
				}
			task1EqualGrey = new Task1EqualGrey();
			task1EqualGrey.ShowImage(image);
			task1EqualGrey.ShowDialog();*/
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

        private void button3_Click(object sender, EventArgs e)
        {
            Task3 task3 = new Task3();
            task3.ShowDialog();
        }
    }
}
