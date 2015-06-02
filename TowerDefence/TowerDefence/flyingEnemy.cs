using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class FlyingEnemy : Enemy
    {
        private float speed;

        public FlyingEnemy(Vector2 position, int waveNumber, Queue<Vector2> waypoints)
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
