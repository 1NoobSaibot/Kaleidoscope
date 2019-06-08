using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калейдоскоп
{
    struct Vector
    {
        public float x, y;
        public double abs { get => Math.Sqrt(x * x + y * y); }
        public Vector(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector operator +(Vector l, Vector r)
        {
            return new Vector(l.x + r.x, l.y + r.y);
        }
        public static Vector operator -(Vector l, Vector r)
        {
            return new Vector(l.x - r.x, l.y - r.y);
        }
        public static Vector operator *(Vector l, float r)
        {
            return new Vector(l.x * r, l.y * r);
        }
        public static Vector operator *(float l, Vector r)
        {
            return new Vector(l * r.x, l * r.y);
        }
    }
}
