using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class FreezeBullet : Projectile
    {
        public FreezeBullet(Texture2D freeze, int damage, Enemy target, Vector2 startPosition, int range, int freezePower)
        {
            this.freezePower = freezePower;
            maxRange = range;
            texture = freeze;
            speed = 2;
            this.damage = damage;
            this.target = target;
            position = startPosition;
            projectileType = "freeze";
        }
    }
}
