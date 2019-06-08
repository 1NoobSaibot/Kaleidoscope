using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калейдоскоп
{
    static class GraphicsExtension
    {
        public static void DrawCircle(this Graphics g, Pen pen, float x, float y, float r)
        {
            g.DrawEllipse(pen, x - r, y - r, r * 2, r * 2);
        }

        public static void FillCircle(this Graphics g, Brush brush, float x, float y, float r)
        {
            g.FillEllipse(brush, x - r, y - r, r * 2, r * 2);
        }

        public static void DrawTriangle(this Graphics g, Triangle t, float x, float y, float angle)
        {
            g.TranslateTransform(x, y);
            g.RotateTransform(angle);
            t.DrawImage(g);
            g.ResetTransform();
        }
    }
}
