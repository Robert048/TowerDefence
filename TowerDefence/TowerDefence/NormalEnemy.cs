using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class NormalEnemy : Enemy
    {
        private float speed = 0.5f;
        private int bountyGiven;

        public NormalEnemy(Texture2D texture, Vector2 position, float health, int bountyGiven, float speed)
            : base()
        {
            this.startHealth = health;
            this.currentHealth = startHealth;
            this.bountyGiven = bountyGiven;
            this.speed = speed;
        }


    }
}
