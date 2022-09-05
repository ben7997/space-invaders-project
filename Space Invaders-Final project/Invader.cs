using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    [Serializable]
    class Invader : Spaceship
    {
        static public int enemyCount = 0;
        private int direction = 1;
        public Invader()
        {
            enemyCount++;
            this.x = 0;
            this.y = 25;
            this.height = 25;
            this.width = 25;
            this.speed = 5;
            this.image = Image.FromFile("C:\\Users\\Neomi\\Desktop\\space invaders\\space-invaders-project\\Space Invaders-Final project\\assets\\invader.png");
        }

        public override void shoot(List<Entity> entities)
        { 
            entities.Add(new Shot(this.x + width/2, this.y + height));
        }
        public override void update()
        {
            this.x += speed * direction;

            if (this.x + width > border.Width || this.x < 0)
            {
                direction *= -1;
                y += height * 2;
            }
        }
        public override void isColied(List<Entity> entitys)
        {
           foreach(Entity entity in entitys)
            {
                if (entity is Shot && this.checkCollision(entity))
                {
                    this.isAlive = false;
                    entity.IsAlive = false;
                    enemyCount--;
                }
            }
        }
    }
}
