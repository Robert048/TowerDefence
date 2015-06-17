using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class Arrow : Projectile
    {
        public Arrow(Texture2D arrow, int damage, Enemy target, Vector2 startPosition, int range)
        {
            maxRange = range;
            texture = arrow;
            speed = 6;
            this.damage = damage;
            this.target = target;
            position = startPosition;
            projectileType = "arrow";
        }
    }
}
