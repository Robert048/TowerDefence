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
            startHealth = 6 + (waveNumber * 5); //het aantal leven dat de enemy heeft aan het begin van de wave dit wordt per wave moeijlijker
            currentHealth = startHealth; //de huidige leven van enemy
            bountyGiven = 2 + (waveNumber * 1);// het aantal gold dat de enemy geeft
            speed = 1.25f;// de snelheid van de enemy
            this.waypoints = waypoints;// waar de enemy heen moet
            this.position = position;// waar de enemy is
            waypoint = position;// waar de enemy heen moet
            flying = true; // de enemy vliegt
        }

    }
}
