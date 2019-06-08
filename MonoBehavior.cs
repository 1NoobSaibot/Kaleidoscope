using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Калейдоскоп
{
    abstract class MonoBehavior
    {
        public static Random rnd = new Random();
        public abstract void Update(float delta);
        public abstract void Paint(Graphics g);
    }
}
