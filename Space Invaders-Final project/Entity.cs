using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    internal abstract class Entity
    {
        protected int x;
        protected int y;
        protected int height;
        protected int width;
        protected int speed;
        protected bool isAlive = true;
        public bool IsAlive { get { return isAlive; } }
        public void draw(Graphics graphics)
        {
            Pen selPen = new Pen(Color.Blue);
            graphics.DrawRectangle(selPen, x, y, height, width);   
        }
        public abstract void update();
    }
}
