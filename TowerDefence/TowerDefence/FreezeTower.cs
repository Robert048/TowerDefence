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

        public FreezeTower(Texture2D freezeTower, Vector2 position)
        {
            damage = 10;
            attackSpeed = 1000;
            range = 100;
            ground = true;
            air = true;
            cost = 50;
            projectileList = new List<Projectile>();
            texture = freezeTower;
            freezePower = 10;
        }
    }
}
