using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TowerDefense
{
    class BossEnemy : Enemy
    {
       private float speed;

        public BossEnemy(Vector2 position, int waveNumber)
            : base()
        {
            startHealth = 10 * waveNumber;
            currentHealth = startHealth;
            bountyGiven = 10 * waveNumber;
            speed = 0.5f;
        }


        /// <summary>
        /// LoadContent, to load the sprite for the enemy
        /// all of your content.
        /// </summary>
        public static void LoadContent(ContentManager content)
        {
            Texture2D texture = content.Load<Texture2D>("enemy");
        }
    }
}
