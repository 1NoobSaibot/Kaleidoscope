using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калейдоскоп
{
    class Particle : MonoBehavior
    {
        Rectangle limiter;
        Vector position, speed, accelerate;
        Brush brush;
        float r;

        public Particle(float x, float y, float r, Color c, Rectangle limiter)
        {
            position = new Vector(x, y);
            this.r = r;
            brush = new SolidBrush(c);
            this.limiter = limiter;
        }

        public override void Update(float delta)
        {
            position += speed * delta;
            if (position.y < limiter.Top)
            {
                position.y = limiter.Top;
                if (speed.y < 0) speed.y *= -1;
            }
            else if (position.y > limiter.Bottom)
            {
                position.y = limiter.Bottom;
                if (speed.y > 0) speed.y *= -1;
            }

            if (position.x < limiter.Left)
            {
                position.x = limiter.Left;
                if (speed.x < 0) speed.x *= -1;
            }
            else if (position.x > limiter.Right)
            {
                position.x = limiter.Right;
                if (speed.x > 0) speed.x *= -1;
            }
            speed += new Vector((float)((rnd.NextDouble() - 0.5) * delta), (float)((rnd.NextDouble() - 0.5) * delta)) * 30;
        }

        public override void Paint(Graphics g)
        {
            g.FillCircle(brush, position.x, position.y, r);
        }
    }
}
