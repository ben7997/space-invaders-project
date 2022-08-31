using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    internal class Player : Entity
    {
        private bool isLeftPress = false;
        private bool isRightPress = false;
        public bool LeftPress {
            set { isLeftPress = value; }
            get { return isLeftPress; }
        }

        public bool RightPress { 
            set { isRightPress = value; }
            get { return isRightPress; }
        }
        public int Xposition
        {
            get { return x+(width/2); }
        }
        public int Yposition
        {
            get { return y; }
        }
        public Player()
        {
            this.x = 202;
            this.y = 200;
            this.height = 25;
            this.width = 25;
            this.speed = 10;
        }
        public override void update()
        {
            if(this.isLeftPress)
            {
                this.x -= this.speed;
            }
            if(this.isRightPress)
            {
                this.x += this.speed;
            }
        }
    }
}
