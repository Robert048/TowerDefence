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
        //arrow class met alle informatie van de getekende arrow
        public Arrow(Texture2D arrow, int damage, Enemy target, Vector2 startPosition, int range)
        {
            maxRange = range; //maximum afstand dat de arrow reist
            texture = arrow; //hoe de arrow er uit ziet
            speed = 6; // de snelheid waarmee de arrow beweegt
            this.damage = damage; // de hoeveelheid schade de arrow doet wanneer die zijn doel raakt
            this.target = target; // de doelwit van de arrow
            position = startPosition; // vanaf welke toren de arow wordt afgeschoten
            projectileType = "arrow"; //de type van de projectile
        }
    }
}
