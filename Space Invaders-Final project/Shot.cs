using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    class Shot: Entity
    {
        public Shot(int x, int y)
        {
            this.height = 5;
            this.width = 10;
            this.x = x-this.height;
            this.y = y;
            this.speed = 12;
        }
        public override void update()
        {
            this.y -= this.speed;
            if (this.y < 0)
            {
                isAlive = false;
            }
        }
    }
}
