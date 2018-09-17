﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
	public partial class Form1 : Form
	{
		{
			InitializeComponent();
		}
        static public void BuildHistogram(int[] histogramValues, int maxValue, ref Bitmap picture, ref PictureBox pictureBox)
        {
            picture = new Bitmap(pictureBox.Width, pictureBox.Height);
            pictureBox.Image = picture;
            Graphics g = Graphics.FromImage(pictureBox.Image);
            for (var i = 0; i < 256; ++i)
            {
                int height = histogramValues[i] * pictureBox.Height / maxValue;
                var r = new Rectangle(2 * i, pictureBox.Height - height, 2, height);
                g.DrawRectangle(new Pen(Color.DarkGray, .5f), r);
            }
        }
        static public void BuildHistogram(int[] histogramValues, int maxValue, ref Bitmap picture)
        {
            Graphics g = Graphics.FromImage(picture);
            for (var i = 0; i < 256; ++i)
            {
                int height = histogramValues[i] * picture.Height / maxValue;
                var r = new Rectangle(2 * i, picture.Height - height, 2, height);
                g.DrawRectangle(new Pen(Color.DarkGray, .5f), r);
            }
        }
        private void button1_Click(object sender, EventArgs e)
		{
			Bitmap image = (Bitmap) Bitmap.FromFile(textBox1.Text);
		    Bitmap image2 = (Bitmap)image.Clone();
		    Bitmap image3 = (Bitmap)image.Clone();
		    int[] brightnessHistogram = new int[256]; //normalized brightness of images difference
            int maxDiff = 1;
            for (int i = 0; i < image.Width; ++i)
				for (int j = 0; j < image.Height; ++j) {
					var pixel = image.GetPixel(i, j);
					var greyScaleEqual = (pixel.R + pixel.G + pixel.B) / 3;
				    int greyScaleWeighted = (int)(0.2126 * pixel.R + 0.7152 * pixel.G + 0.0722 * pixel.B); //HDTV
				    int greyScaleDiff = greyScaleEqual - greyScaleWeighted;
				    if (greyScaleDiff > maxDiff)
				        maxDiff = greyScaleDiff;
				    greyScaleDiff = greyScaleDiff >= 0 ? greyScaleDiff : 0;
					image.SetPixel(i, j, Color.FromArgb(255, greyScaleEqual, greyScaleEqual, greyScaleEqual));
				    image2.SetPixel(i, j, Color.FromArgb(255, greyScaleWeighted, greyScaleWeighted, greyScaleWeighted));
				    image3.SetPixel(i, j, Color.FromArgb(255, greyScaleDiff, greyScaleDiff, greyScaleDiff));
                }

		    int histMax = 1;
            for (int i = 0; i < image.Width; ++i)
                for (int j = 0; j < image.Height; ++j)
                {
                    int newDiff = 255/maxDiff * image3.GetPixel(i, j).R;
                    brightnessHistogram[newDiff]++;
                    if (histMax < brightnessHistogram[newDiff])
                        histMax = brightnessHistogram[newDiff];
                    image3.SetPixel(i, j, Color.FromArgb(255, newDiff, newDiff, newDiff));
                }
		    int histHeight = 301;
		    int histBarWidth = 301 / 255;
		    Bitmap histImage = new Bitmap(392, histHeight);
            BuildHistogram(brightnessHistogram, histMax, ref histImage);
            task1EqualGrey = new Task1Form();
		    task1EqualGrey.DrawImage(image);
            task1EqualGrey.ShowDialog();
		    task1WeightedGrey = new Task1Form();
            task1WeightedGrey.DrawImage(image2);
            task1WeightedGrey.ShowDialog();
		    task1DiffGrey = new Task1Form();
            task1DiffGrey.DrawImage(image3);
            task1DiffGrey.ShowDialog();
		    task1Histogram = new Task1Form();
		    task1Histogram.DrawImage(histImage);
		    task1Histogram.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image = (Bitmap)Bitmap.FromFile(textBox1.Text);
            var task3 = new Task3();
            task3.DrawImage(image);
            task3.ShowDialog();
        }
    }
}
