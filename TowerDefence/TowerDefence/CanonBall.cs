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
        //canonball class met alle informatie van de getekende canonoball
        public CanonBall(Texture2D canon, int damage, Enemy target, Vector2 startPosition, int range)
        {
            maxRange = range;//maximum afstand dat de projectile reist
            texture = canon;// hoe de projectile er uit ziet
            speed = 2; //de snelheid waarmee de projectile beweegt
            this.damage = damage; // de hoeveelheid schade de projectile doet wanneer die zijn doel raakt
            this.target = target;// de doelwit van de projectile
            position = startPosition;// vanaf welke toren de projectile wordt afgeschoten
            projectileType = "canon";//de type van de projectile
        }
    }
}
