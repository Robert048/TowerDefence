using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class ArrowTower : Tower
    {

        public ArrowTower(Texture2D arrowTower)
        {
            damage = 10;
            attackSpeed = 1;
            range = 100;
            ground = true;
            air = true;
            cost = 20;
            projectileList = new List<Projectile>();
            towertexture = arrowTower;
        }
    }
}
