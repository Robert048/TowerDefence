using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TowerDefense
{
    class Enemy
    {
        protected bool alive = true;
        protected bool madeIt = false;
        protected int startHealth;
        protected Queue<Vector2> waypoints = new Queue<Vector2>();
        protected Vector2 position = new Vector2();
        protected Vector2 waypoint = new Vector2();
        private int nr = 0;
        protected float speed;

        public int currentHealth { get; set; }
        public int bountyGiven { get; set; }

        public bool IsKilled()
        {
            return (alive == false);
        }

        public bool madeItToEnd()
        {
            return madeIt;
        }

        public void Update()
        {
            //waypoints
            if (position == waypoint)
            {
                waypoint = waypoints.ElementAt(nr);
                nr++;
            }
            else if (position.X == waypoint.X)
            {
                if (position.Y > waypoint.Y) position.Y = position.Y - speed;
                if (position.Y < waypoint.Y) position.Y = position.Y + speed;
            }
            else if (position.Y == waypoint.Y)
            {
                position.X = position.X + speed;
            }
            if (position.X > 1150)
            {
                madeIt = true;
            }
            //levens
            if(currentHealth <= 0) alive = false;
        }

        public void Draw(SpriteBatch batch, Texture2D texture, Texture2D healthBar)
        {
            if(alive)
            {
                float healthPercentage = (((float)currentHealth / (float)startHealth) * 100);
                Debug.WriteLine(currentHealth);
                Debug.WriteLine(startHealth);
                Debug.WriteLine(healthPercentage);
                byte test = Convert.ToByte(255 - ((255f / 100f) * healthPercentage));
                byte test2 = Convert.ToByte(0 + ((255f / 100f) * healthPercentage));
                Color color = new Color(test, test2, 0);
                Debug.WriteLine("next");
                batch.Draw(texture, new Rectangle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 50, 50), Color.White);
                batch.Draw(healthBar, new Rectangle(Convert.ToInt32(position.X), (Convert.ToInt32(position.Y) - 10), 50, 10), color);
            }
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public bool getAlive()
        {
            return alive;
        }
    }
}
