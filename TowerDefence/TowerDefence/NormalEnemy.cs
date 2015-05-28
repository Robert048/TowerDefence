using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class NormalEnemy : Enemy
    {
        private float speed = 0.5f;

        public NormalEnemy(Texture2D texture, Vector2 position, int health, int bountyGiven, float speed)
            : base()
        {
            this.startHealth = health;
            this.currentHealth = startHealth;
            this.bountyGiven = bountyGiven;
            this.speed = speed;
        }


    }
}
