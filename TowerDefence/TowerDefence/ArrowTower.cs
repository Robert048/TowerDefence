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
        // de arrowtower class waarin alle informatie van de arrowrtower staat
        public ArrowTower(Texture2D arrowTower, Texture2D arrow, Vector2 position)
        {
            this.position = position; //de positie waar de tower staat
            damage = 5; //de schade dat de tower doet met elk projectiel
            attackSpeed = 1000; //de snelheid waarmee de tower schiet in ms
            range = 200; //de afstand waarin de toren kan schieten
            air = true; //kan de toren luchtdoelen schieten
            cost = 20; // hoeveel de toren kost om te plaatsen
            projectileList = new List<Projectile>(); //lijst van geschoten projectielen
            texture = arrowTower; //hoe de toren er uit ziet
            projectileTexture = arrow; //hoe de projectiel er uit ziet
            towerString = "arrowTower"; //de toren
        }      
    
    }
}
