using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    internal class Player : Entity
    {
        public Player()
        {
            this.x = 202;
            this.y = 200;
            this.height = 25;
            this.width = 25;
            this.speed = 5;
        }
        public void moveLeft()
        {
            this.x -= this.speed;
        }
        public void moveRight()
        {
            this.x += this.speed;
        }

        public override void update()
        {

        }
    }
}
