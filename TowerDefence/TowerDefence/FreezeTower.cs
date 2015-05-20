using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class FreezeTower : Tower
    {
        protected int freezePower;

        public FreezeTower(Texture2D freezeTower)
        {
            damage = 10;
            attackSpeed = 1;
            range = 100;
            ground = true;
            air = true;
            cost = 50;
            projectileList = new List<Projectile>();
            towertexture = freezeTower;
            freezePower = 20;
        }
    }
}
