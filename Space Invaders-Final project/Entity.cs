using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders_Final_project
{
    [Serializable]

    internal abstract class Entity
    {
        protected int x;
        protected int y;
        protected int height;
        protected int width;
        protected int speed;
        protected bool isAlive = true;
        protected Image image;
        public static System.Drawing.Size border;

        public bool IsAlive {
            set { isAlive=value; }
            get { return isAlive; } }

        public Entity()
        {

        }
        public void draw(Graphics graphics)
        {
            graphics.DrawImage(image, x, y, width, height);   
        }
        public abstract void update();

        protected bool checkCollision(Entity entity)
        {
            if (this.x+this.width<=entity.x)
            {
                return false;
            }
            if(this.y+this.height<=entity.y)
            {
                return false;
            }
            if(entity.x+entity.width<=this.x)
            {
                return false;
            }
            if(entity.y+entity.height<=this.y)
            {
                return false;
            }
            return true;
        }

        public abstract void isColied(List<Entity> list);
    }
}
