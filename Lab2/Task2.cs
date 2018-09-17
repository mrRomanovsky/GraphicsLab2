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
    public partial class Task2 : Form
    {
        private Bitmap original;
        private Bitmap bitmapMainPicture;
        private Bitmap red;
        private Bitmap green;
        private Bitmap blue;
        private Bitmap bitmapHistogram;
        private Bitmap redHistogram;
        private Bitmap greenHistogram;
        private Bitmap blueHistogram;

        public Task2(string link)
        {
            InitializeComponent();

            original = (Bitmap)Bitmap.FromFile(link);
            pictureBox1.Image = original;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bitmapMainPicture = original;
            pictureBox1.Image = original;
            pictureBox2.Image = null;
            bitmapHistogram = null;
            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (red != null)
            {
                pictureBox1.Image = red;
                bitmapMainPicture = red;
                pictureBox1.Refresh();
                pictureBox2.Image = redHistogram;
                bitmapHistogram = redHistogram;
                return;
            }
            red = new Bitmap(original.Width, original.Height);
            int max = int.MinValue;
            int[] histogram = new int[256];
            for (int i = 0; i < original.Width; ++i)
                for (int j = 0; j < original.Height; ++j)
                {
                    var pixel = original.GetPixel(i, j);
                    histogram[pixel.R]++;
                    if (histogram[pixel.R] > max)
                        max = histogram[pixel.R];
                    red.SetPixel(i, j, Color.FromArgb(255, pixel.R, 0, 0));
                }
            bitmapMainPicture = red;
            pictureBox1.Image = red;
            pictureBox1.Invalidate();
            if (redHistogram == null)
            {
                Form1.BuildHistogram(histogram, max, ref redHistogram, ref pictureBox2);
                bitmapHistogram = redHistogram;
            }
            else
                pictureBox2.Image = redHistogram;
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (green != null)
            {
                pictureBox1.Image = green;
                bitmapMainPicture = green;
                pictureBox1.Refresh();
                pictureBox2.Image = greenHistogram;
                bitmapHistogram = greenHistogram;
                return;
            }
            green = new Bitmap(original.Width, original.Height);
            int max = int.MinValue;
            int[] histogram = new int[256];
            for (int i = 0; i < original.Width; ++i)
                for (int j = 0; j < original.Height; ++j)
                {
                    var pixel = original.GetPixel(i, j);
                    histogram[pixel.G]++;
                    if (histogram[pixel.G] > max)
                        max = histogram[pixel.G];
                    green.SetPixel(i, j, Color.FromArgb(255, 0, pixel.G, 0));
                }
            pictureBox1.Invalidate();
            bitmapMainPicture = green;
            pictureBox1.Image = green;
            if (greenHistogram == null)
            {
                Form1.BuildHistogram(histogram, max, ref greenHistogram, ref pictureBox2);
                bitmapHistogram = greenHistogram;
            }
            else
                pictureBox2.Image = greenHistogram;
            pictureBox1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (blue != null)
            {
                pictureBox1.Image = blue;
                bitmapMainPicture = blue;
                pictureBox1.Refresh();
                pictureBox2.Image = blueHistogram;
                bitmapHistogram = blueHistogram;
                return;
            }
            blue = new Bitmap(original.Width, original.Height);
            pictureBox1.Image = blue;
            int max = int.MinValue;
            int[] histogram = new int[256];
            for (int i = 0; i < original.Width; ++i)
                for (int j = 0; j < original.Height; ++j)
                {
                    var pixel = original.GetPixel(i, j);
                    histogram[pixel.B]++;
                    if (histogram[pixel.B] > max)
                        max = histogram[pixel.B];
                    blue.SetPixel(i, j, Color.FromArgb(255, 0, 0, pixel.B));
                }
            bitmapMainPicture = blue;
            if (blueHistogram == null)
            {
                Form1.BuildHistogram(histogram, max, ref blueHistogram, ref pictureBox2);
                bitmapHistogram = blueHistogram;
            }
            else
                pictureBox2.Image = blueHistogram;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (bitmapMainPicture != null)
                pictureBox1.Image = bitmapMainPicture;
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            if (bitmapHistogram != null)
                pictureBox2.Image = bitmapHistogram;
        }
    }
}
