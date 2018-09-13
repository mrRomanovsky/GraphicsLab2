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

        private Bitmap img;
        public Task3()
        {
            InitializeComponent();
        }
        public void DrawImage(Bitmap image)
        {
            float maxRGB = -1;
            float minRGB = 256;
            for (int i = 0; i < image.Width; ++i)
                for (int j = 0; j < image.Height; ++j)
                {
                    var pixel = image.GetPixel(i, j);
                    maxRGB = Math.Max(pixel.R / 255f, Math.Max(pixel.G / 255f, Math.Max(pixel.B / 255f, maxRGB)));
                    minRGB = Math.Min(pixel.R / 255f, Math.Min(pixel.G / 255f, Math.Min(pixel.B / 255f, minRGB)));
                    float delta = maxRGB - minRGB;
                    float H;
                    float S;
                    float V = maxRGB;
                    if (maxRGB == 0)
                        S = 0;
                    else
                        S = 1 - minRGB / maxRGB;
                    if (maxRGB == minRGB)
                        H = 0;
                    else
                    {
                        if(maxRGB == pixel.R / 255f && pixel.G / 255f >= pixel.B / 255f)
                            H = 60 * (pixel.G / 255f - pixel.B / 255f) / (maxRGB - minRGB);
                        else if(maxRGB == pixel.R / 255f && pixel.G / 255f < pixel.B / 255f)
                            H = 60 * (pixel.G / 255f - pixel.B / 255f) / (maxRGB - minRGB) + 360;
                        else if(maxRGB == pixel.G / 255f)
                            H = 60 * (pixel.B / 255f - pixel.R / 255f) / (maxRGB - minRGB) + 120;
                        else if (maxRGB == pixel.B / 255f)
                            H = 60 * (pixel.R / 255f - pixel.G / 255f) / (maxRGB - minRGB) + 240;
                    }
                }
            
            pictureBox1.Image = image;
            img = image;
            DrawImage(img);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawImage(img);
        }
    }
}
