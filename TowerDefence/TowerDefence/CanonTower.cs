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
        // de CanonTower class waarin alle informatie van de CanonTower staat
        public CanonTower(Texture2D tower, Texture2D canon, Vector2 position)
        {
            this.position = position; //de positie waar de tower staat
            damage = 15;  //de schade dat de tower doet met elk projectiel
            attackSpeed = 2500; //de snelheid waarmee de tower schiet in ms
            range = 200; //de afstand waarin de toren kan schieten
            air = false; //kan de toren luchtdoelen schieten
            cost = 50; // hoeveel de toren kost om te plaatsen
            projectileList = new List<Projectile>(); //lijst van geschoten projectielen
            texture = tower; //hoe de toren er uit ziet
            projectileTexture = canon; //hoe de projectiel er uit ziet
            towerString = "canonTower"; //de toren
        }
    }
}
