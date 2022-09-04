﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    [Serializable]
    internal class Player : Spaceship
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
            if (this.isLeftPress && x > 0)
            {
                this.x -= this.speed;
            }
            if (this.isRightPress && x + this.width < border.Width)
            {
                this.x += this.speed;
            }

        }
        public override void shoot(List<Entity> entities)
        {
            entities.Add(new Shot(this.Xposition, this.Yposition));
        }
        public override void isColied(List<Entity> entitys)
        {
            foreach (Entity entity in entitys)
            {
                if (entity is Invader && this.checkCollision(entity))
                {
                    this.hitPoints-=1;
                }
            }
        }

    }
}
