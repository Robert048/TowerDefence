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
        public BossEnemy(Vector2 position, int waveNumber, Queue<Vector2> waypoints)
            : base()
        {
            startHealth = 50 + (waveNumber * 10);
            currentHealth = startHealth;
            bountyGiven = 10 + (waveNumber * 4);
            speed = 1.0f;
            this.waypoints = waypoints;
            this.position = position;
            waypoint = position;
        }
    }
}
