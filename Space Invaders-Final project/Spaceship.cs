using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders_Final_project
{
    [Serializable]
    internal abstract class Spaceship : Entity
    {
        protected int hitPoints;
        public abstract void shoot(List<Entity> entities);
    }
}
