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
        //class van de freeze projectiel
        public FreezeBullet(Texture2D freeze, int damage, Enemy target, Vector2 startPosition, int range, int freezePower)
        {
            this.freezePower = freezePower; //projectile doet freeze
            maxRange = range;//maximum afstand dat de projectile reist
            texture = freeze;// hoe de projectile er uit ziet
            speed = 2;//de snelheid waarmee de projectile beweegt
            this.damage = damage;// de hoeveelheid schade de projectile doet wanneer die zijn doel raakt
            this.target = target;// de doelwit van de projectile
            position = startPosition;// vanaf welke toren de projectile wordt afgeschoten
            projectileType = "freeze";//de type van de projectile
        }
    }
}
