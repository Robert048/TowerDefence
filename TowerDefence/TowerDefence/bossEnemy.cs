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
        //boss enemy met alle info over de bos
        public BossEnemy(Vector2 position, int waveNumber, Queue<Vector2> waypoints)
            : base()
        {
            startHealth = 1000 + (waveNumber * 50); //het aantal leven dat de enemy heeft aan het begin van de wave dit wordt per wave moeijlijker
            currentHealth = startHealth; //de huidige leven van enemy
            bountyGiven = 10 + (waveNumber * 4); // het aantal gold dat de enemy geeft
            speed = 1.0f; // de snelheid van de enemy
            this.waypoints = waypoints; // waar de enemy heen moet
            this.position = position; // waar de enemy is
            waypoint = position; // waar de enemy heen moet
        }
    }
}
