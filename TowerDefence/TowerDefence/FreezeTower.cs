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
        public FreezeTower(Texture2D freezeTower, Texture2D freeze, Vector2 position)
        {
            this.position = position;
            damage = 2;
            attackSpeed = 1500;
            range = 100;
            ground = true;
            air = true;
            cost = 50;
            projectileList = new List<Projectile>();
            texture = freezeTower;
            this.freezePower = 2;
            projectileTexture = freeze;
            towerString = "freezeTower";
        }
    }
}
