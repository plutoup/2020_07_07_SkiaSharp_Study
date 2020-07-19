using System;
using SkiaSharp;
using System.IO;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _2020_07_07_SkiaSharp_Study
{
    class Form1 : Form
    {
        PictureBox box = new PictureBox();
        public Form1() 
        {
            this.Size = new Size(500, 500);
            box.SizeMode = PictureBoxSizeMode.StretchImage;
            box.ClientSize = new Size(500, 500);
            this.Controls.Add(box);
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (SKSurface surface = SKSurface.Create(make_image(500, 500)))
            {
                SKCanvas canvas = surface.Canvas;

                canvas.Clear(SKColors.Red);

                using (SKPaint paint = new SKPaint())
                {
                    paint.Color = SKColors.Blue;
                    paint.IsAntialias = true;
                    paint.StrokeWidth = 15;
                    paint.Style = SKPaintStyle.Stroke;
                    canvas.DrawCircle(50, 50, 30, paint); //arguments are x position, y position, radius, and paint
                }

                using (SKImage image = surface.Snapshot())
                using (SKData data = image.Encode(SKEncodedImageFormat.Png, 500))
                using (MemoryStream mStream = new MemoryStream(data.ToArray()))
                {
                    Bitmap bm = new Bitmap(mStream, false);
                    box.Image = bm;
                }
            }
        }

        private SKImageInfo make_image(int width, int height)
        {
            SKImageInfo image_info = new SKImageInfo(width, height);
            return image_info;
        }
    }
}