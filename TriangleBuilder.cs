using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Калейдоскоп
{
    class TriangleBuilder
    {
        Bitmap buf0, buf1, buf2, rslt;
        Graphics g0, g1, g2, gr;
        PointF center;
        public TriangleBuilder(int width)
        {
            float height = (float)(width * Math.Sin(Math.PI / 3));
            buf0 = new Bitmap(width, (int)height);
            buf1 = new Bitmap(width, (int)height);
            buf2 = new Bitmap(width, (int)height);
            rslt = new Bitmap(width, (int)height);

            g0 = Graphics.FromImage(buf0);
            g1 = Graphics.FromImage(buf1);
            g2 = Graphics.FromImage(buf2);
            gr = Graphics.FromImage(rslt);

            center = new PointF(((float)width) / 2, height / 3);

            g1.TranslateTransform(center.X, center.Y);
            g1.RotateTransform(120);
            g1.TranslateTransform(-center.X, -center.Y);
            g2.TranslateTransform(center.X, center.Y);
            g2.RotateTransform(120);
            g2.TranslateTransform(-center.X, -center.Y);
            gr.TranslateTransform(center.X, center.Y);
            gr.RotateTransform(120);
            gr.TranslateTransform(-center.X, -center.Y);
        }

        public void Draw(MonoBehavior obj)
        {
            obj.Paint(g0);
        }

        public void Clear(Color color)
        {
            g0.Clear(color);
        }

        public Triangle GetResultImage()
        {
            //Обрезать картинку
            g1.DrawImage(buf0, 0, 0);
            g2.DrawImage(buf1, 0, 0);
            gr.DrawImage(buf2, 0, 0);

            return new Triangle(rslt);
        }
    }
}
