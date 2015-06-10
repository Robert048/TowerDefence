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
        public FlyingEnemy(Vector2 position, int waveNumber, Queue<Vector2> waypoints)
            : base()
        {
            startHealth = 6 + (waveNumber * 2);
            currentHealth = startHealth;
            bountyGiven = 2 + (waveNumber * 3);
            speed = 1.25f;
            this.waypoints = waypoints;
            this.position = position;
            waypoint = position;
        }

    }
}
