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
        protected bool alive = true;
        protected bool madeIt = false;
        protected int startHealth;
        protected Queue<Vector2> waypoints = new Queue<Vector2>();
        protected Vector2 position = new Vector2();
        protected Vector2 waypoint = new Vector2();
        private int nr = 0;
        protected float speed;
        private float rotation;
        private Vector2 vector;

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
            //levens
            if(currentHealth <= 0) alive = false;
        }

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
