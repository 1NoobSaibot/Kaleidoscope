using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калейдоскоп
{
    public partial class Form1 : Form
    {

        Animation animation = new Animation(1920, 1080);
        Graphics g;
        DateTime last;

        public Form1()
        {
            InitializeComponent();
            last = DateTime.Now;
            canvas.Image = new Bitmap(1920, 1080);
            g = Graphics.FromImage(canvas.Image);
            looper.Start();
        }

        private void onTick(object sender, EventArgs e)
        {
            animation.Paint(g);
            Matrix m = new Matrix();

            DateTime current = DateTime.Now;
            TimeSpan span = current - last;
            float delta = (float)span.TotalSeconds;
            animation.Update(delta);
            last = current;
            canvas.Refresh();
        }
    }
}
