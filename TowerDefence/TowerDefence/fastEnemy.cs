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
    class FastEnemy : Enemy
    {
        private float speed;

        public FastEnemy(Vector2 position, int waveNumber, Queue<Vector2> waypoints)
            : base()
        {
            startHealth = 10 * waveNumber;
            currentHealth = startHealth;
            bountyGiven = 10 * waveNumber;
            speed = 0.5f;
            this.waypoints = waypoints;
        }
    }
}
