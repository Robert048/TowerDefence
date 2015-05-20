using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class CanonTower : Tower
    {
        public CanonTower(Texture2D tower)
        {
            damage = 20;
            attackSpeed = 2;
            range = 150;
            ground = true;
            air = false;
            cost = 40;
            towertexture = tower;

        }
    }
}
