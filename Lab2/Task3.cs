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
    public partial class Task3 : Form
    {
        private float EPS = 0.0001f;
        private Bitmap img;
        public Task3()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public void DrawImage(Bitmap image)
        {
            float maxRGB = -1;
            float minRGB = 256;
            for (int i = 0; i < image.Width; ++i)
                for (int j = 0; j < image.Height; ++j)
                {
                    var pixel = image.GetPixel(i, j);
                    float pixelR = pixel.R / 255f;
                    float pixelG = pixel.G / 255f;
                    float pixelB = pixel.B / 255f;
                    maxRGB = Math.Max(pixelR, Math.Max(pixelG, Math.Max(pixelB, maxRGB)));
                    minRGB = Math.Min(pixelR, Math.Min(pixelG, Math.Min(pixelB, minRGB)));
                    float delta = maxRGB - minRGB;
                    //RGB -> HSV
                    float H = 0;
                    float S = 0;
                    float V = maxRGB;
                    if (maxRGB == 0)
                        S = 0;
                    else
                        S = 1 - minRGB / maxRGB;
                    if (maxRGB - minRGB < EPS)
                        H = 0;
                    else
                    {
                        if((maxRGB - pixelR) < EPS && pixelG >= pixelB)
                            H = 60 * (pixelG - pixelB) / (maxRGB - minRGB);
                        else if((maxRGB - pixelR) < EPS && pixelG < pixelB)
                            H = 60 * (pixelG - pixelB) / (maxRGB - minRGB) + 360;
                        else if((maxRGB - pixelG) < EPS)
                            H = 60 * (pixelB - pixelR) / (maxRGB - minRGB) + 120;
                        else if ((maxRGB - pixelB) < EPS)
                            H = 60 * (pixelR - pixelG) / (maxRGB - minRGB) + 240;
                    }
                    //HSV -> RGB
                    H += int.Parse(textBox1.Text);
                    if (H > 360)
                        H = H % 360;
                    S *= 100 ;
                    S += int.Parse(textBox2.Text);
                    if (S > 100)
                        S = S % 100;
                    V *= 100;
                    V += int.Parse(textBox3.Text);
                    if (V > 100)
                        V = V % 100;
                    int Hi = (int)(Math.Floor(H / 60) % 6);
                    var Vmin = (100 - S) * V / 100;
                    var a = (V - Vmin) * (H % 60) / 60;
                    var Vinc = Vmin + a;
                    var Vdec = V - a;
                    float R = 0, G = 0, B = 0;
                    switch (Hi)
                    {
                        case 0:
                            R = V;
                            G = Vinc;
                            B = Vmin;
                            break;
                        case 1:
                            R = Vdec;
                            G = V;
                            B = Vmin;
                            break;
                        case 2:
                            R = Vmin;
                            G = V;
                            B = Vinc;
                            break;
                        case 3:
                            R = Vmin;
                            G = Vdec;
                            B = V;
                            break;
                        case 4:
                            R = Vinc;
                            G = Vmin;
                            B = V;
                            break;
                        case 5:
                            R = V;
                            G = Vmin;
                            B = Vdec;
                            break;
                    }
                    image.SetPixel(i, j, Color.FromArgb((int)(R * 255/100), (int)(G * 255 / 100), (int)(B * 255 / 100)));
                    maxRGB = -1;
                    minRGB = 255;
                }
            
            pictureBox1.Image = image;
            img = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawImage(img);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            img.Save("d:\\myImg.jpg");
        }
    }
}
