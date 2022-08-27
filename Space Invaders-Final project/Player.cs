using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    internal class Player :Entity
    {
        public Player()
        {
            this.x = 100;
            this.y = 100;
            this.height = 100;
            this.width = 100;
            this.speed = 5;
        }
    }
}
