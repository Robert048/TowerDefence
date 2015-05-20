using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class ArrowTower : Tower
    {

        public ArrowTower()
        {
            damage = 10;
            attackSpeed = 1;
            range = 100;
            ground = true;
            air = true;
            cost = 20;
            

        }
    }
}
