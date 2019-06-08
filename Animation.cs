using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калейдоскоп
{
    class Animation : MonoBehavior
    {
        const int TriangleWidth = 300;

        TriangleBuilder t = new TriangleBuilder(TriangleWidth);
        Particle[] m = new Particle[100];
        float angle;
        float startX, startY, dx, dy, bs;
        int countX, countY;

        public Animation(int w, int h)
        {
            for (int i = 0; i < m.Length; i++)
                m[i] = new Particle(rnd.Next() % TriangleWidth, rnd.Next() % TriangleWidth,
                    rnd.Next() % 25 + 5,
                    Color.FromArgb(250, rnd.Next() % 256, rnd.Next() % 256, rnd.Next() % 256),
                    new Rectangle(0, 0, 300, 300)
                    );

            float cx = w / 2;
            float cy = h / 2;
            dx = TriangleWidth / 2;
            dy = (float)(TriangleWidth * Math.Sin(Math.PI / 3));
            bs = dy / 6;

            startX = (float)(cx - (Math.Truncate(cx / dx) * dx));
            countX = (int)Math.Truncate((w - startX) / dx) + 3;
            startX -= dx;

            startY = (float)((cy + bs) - (Math.Truncate((cy + bs) / dy) * dy));
            countY = (int)Math.Truncate((h - startY) / dy) + 2;
        }

        public override void Update(float delta)
        {
            for (int i = 0; i < m.Length; i++)
                m[i].Update(delta);

            angle += delta * 10;
        }

        public override void Paint(Graphics g)
        {
            t.Clear(Color.White);
            for (int i = 0; i < m.Length; i++)
                t.Draw(m[i]);

            Triangle tr0 = t.GetResultImage();
            Triangle tr1 = tr0.MirrorY();

            for (int x = 0; x < countX; x++)
            {
                for (int y = 0; y < countY; y++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        int da = y % 2 == 0 ? ((x / 2) % 3) : (((x + 3) / 2) % 3);
                        g.DrawTriangle(tr0, startX + dx * x, startY + dy * y - bs, da * 240);
                    }
                    else
                    {
                        int da = y % 2 == 0 ? ((x / 2) % 3) : (((x + 3) / 2) % 3);
                        g.DrawTriangle(tr1, startX + dx * x, startY + dy * y + bs, da * 120 + 60);
                    }
                }
            }
        }
    }
}
