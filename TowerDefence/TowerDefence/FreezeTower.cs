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
        // de FreezeTower class waarin alle informatie van de FreezeTower staat
        public FreezeTower(Texture2D freezeTower, Texture2D freeze, Vector2 position)
        {
            this.position = position; //de positie waar de tower staat
            damage = 2;//de schade dat de tower doet met elk projectiel
            attackSpeed = 1500;//de snelheid waarmee de tower schiet in ms
            range = 100;//de afstand waarin de toren kan schieten
            air = true;//kan de toren luchtdoelen schieten
            cost = 50;// hoeveel de toren kost om te plaatsen
            projectileList = new List<Projectile>();//lijst van geschoten projectielen
            texture = freezeTower;//hoe de toren er uit ziet
            this.freezePower = 2; // hoe de toren freezed
            projectileTexture = freeze;//hoe de projectiel er uit ziet
            towerString = "freezeTower";//de toren
        }
    }
}
