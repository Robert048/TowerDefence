using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class Enemy
    {
        protected bool alive = true; // is de enemy in leven
        protected bool madeIt = false; //heeft de enmey het einde van de level gehaald
        protected int startHealth; // de statr leven van de enemy
        protected Queue<Vector2> waypoints = new Queue<Vector2>(); //de pad dat de enemy moet afleggen
        protected Vector2 position = new Vector2(); //de positie van de enemy
        protected Vector2 waypoint = new Vector2(); // waar de enemy naar toe gaat
        protected bool flying = false; //vliegt de enemy
        private int nr = 0; // welke nr de enemy is
        protected float speed; //de snelheid van de enemy
        private float rotation; //de rotatie wanner de enemy een bocht bereikt
        private Vector2 vector; //lopen van de enemy
        private int counter = 0; // counter
        private bool slowed = false; // wordt de enemy vertraagd
        private float startSpeed; // de start snelheid van de enemy

        public int currentHealth { get; set; } //de huidige health van de enemy
        public int bountyGiven { get; set; } //de hoeveelheid gold dat de enemy geeft

        //doorgeven wanneer een enemy is gekilled
        public bool IsKilled()
        {
            return (alive == false);
        }

        //doorgeven wanneer een enemy het einde heeft bereikt
        public bool madeItToEnd()
        {
            return madeIt;
        }

        public void Update()
        {
            //waypoints de pad die de enemy moet aflegen afleggen
            if (position == waypoint)
            {
                waypoint = waypoints.ElementAt(nr);
                nr++;
            }
            else if (position.X == waypoint.X)
            {
                if (position.Y > waypoint.Y)
                {
                    position.Y = position.Y - speed;
                    rotation = 0;
                    vector = new Vector2(0, 0);
                }
                if (position.Y < waypoint.Y)
                {
                    position.Y = position.Y + speed;
                    rotation = ((float)Math.PI);
                    vector = new Vector2(50, 50);
                }
            }
            else if (position.Y == waypoint.Y)
            {
                position.X = position.X + speed;
                rotation = ((float)Math.PI / 2.0f);
                vector = new Vector2(0, 50);
            }
            if (position.X > 1150)
            {
                madeIt = true;
            }
            //slowed
            if (slowed && counter < 100)
            {
                counter++;
            }
            if (slowed && counter >= 100 && (position - waypoint).X % startSpeed == 0 && (position - waypoint).Y % startSpeed == 0)
            {
                slowed = false;
                counter = 0;
                speed = startSpeed;
            }

            //levens
            if(currentHealth <= 0) alive = false;
        }

        //tekenen van de enemy
        public void Draw(SpriteBatch batch, Texture2D texture, Texture2D healthBar)
        {
            if (alive)
            {
                float healthPercentage = (((float)currentHealth / (float)startHealth) * 100);
                if (healthPercentage > 1)
                {
                    byte test = Convert.ToByte(255 - ((255f / 100f) * healthPercentage));
                    byte test2 = Convert.ToByte(0 + ((255f / 100f) * healthPercentage));
                    Color color = new Color(test, test2, 0);
                    batch.Draw(texture, new Rectangle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 50, 50), null, Color.White, rotation, vector, SpriteEffects.None, 0);
                    batch.Draw(healthBar, new Rectangle(Convert.ToInt32(position.X), (Convert.ToInt32(position.Y) - 10), Convert.ToInt32(healthPercentage / 2), 10), color);
                }
            }
        }

        //returnd de locatie van de enemy
        public Vector2 getPosition()
        {
            return position;
        }

        //de enemy vertragen
        public void setSlowed(int freezePower)
        {
            slowed = true;
            startSpeed = speed;
            speed = speed / freezePower;
        }
        // returned of de enemy is vertraagd
        public bool getSlowed()
        {
           return slowed;
        }

        //returned of de enemy vliegt
        public bool getFlying()
        {
            return flying;
        }

    }
}
