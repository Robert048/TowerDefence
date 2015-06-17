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

        public ArrowTower(Texture2D arrowTower, Texture2D arrow, Vector2 position)
        {
            this.position = position;
            damage = 5;
            attackSpeed = 1000;
            range = 200;
            ground = true;
            air = true;
            cost = 20;
            projectileList = new List<Projectile>();
            texture = arrowTower;
            projectileTexture = arrow;
            towerString = "arrowTower";
        }      
    
    }
}
