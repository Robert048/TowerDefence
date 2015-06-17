using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class CanonBall : Projectile
    {
        public CanonBall(Texture2D canon, int damage, Enemy target, Vector2 startPosition, int range)
        {
            maxRange = range;
            texture = canon;
            speed = 2;
            this.damage = damage;
            this.target = target;
            position = startPosition;
            projectileType = "canon";
        }
    }
}
