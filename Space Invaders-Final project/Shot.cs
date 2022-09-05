using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    [Serializable]
    class Shot: Entity
    {
        public Shot(int x, int y)
        {
            this.height = 10;
            this.width = 5;
            this.x = x;
            this.y = y;
            this.speed = 12;
            this.image = Image.FromFile("C:\\Users\\Neomi\\Desktop\\space invaders\\space-invaders-project\\Space Invaders-Final project\\assets\\shot.png");
        }
        public override void update()
        {
            this.y -= this.speed;
            if (this.y < 0)
            {
                isAlive = false;
            }
        }

        public override void isColied(List<Entity> entitys)
        {
            return;
            foreach (Entity entity in entitys)
            {
                if (entity is Invader && this.checkCollision(entity))
                {
                    this.isAlive=false;
                }
            }
        }
    }
}
