using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калейдоскоп
{
    class Triangle
    {
        Bitmap image;
        PointF center;

        public Triangle(Bitmap image)
        {
            this.image = image;
            float x = image.Width / 2f;
            float y = (float)(image.Width * Math.Sin(Math.PI / 3)) / 3f;
            center = new PointF(x, y);
        }

        public void DrawImage(Graphics g)
        {
            g.DrawImage(image, -center.X, -center.Y);
        }

        public Triangle MirrorY()
        {
            Bitmap newImg = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(newImg);
            g.TranslateTransform(center.X, 0);
            g.ScaleTransform(-1, 1);
            g.DrawImage(image, -center.X, 0);
            
            return new Triangle(newImg);
        }
    }
}
