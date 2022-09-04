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
        protected Pen selPen;
        public static System.Drawing.Size border;
        public bool IsAlive { get { return isAlive; } }

        public Entity()
        {

        }
        public void draw(Graphics graphics)
        {
            graphics.DrawRectangle(selPen, x, y, width, height);   
        }
        public abstract void update();
    }
}
