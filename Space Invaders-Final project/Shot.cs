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
            this.x = x;
            this.y = y;
            this.height = 10;
            this.width = 5;
            this.speed = 10;
        }
        public override void update()
        {
            this.y -= this.speed;
        }
    }
}
