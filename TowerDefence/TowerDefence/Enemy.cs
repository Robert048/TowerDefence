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
                if (position.Y > waypoint.Y) position.Y = position.Y - 5;
                if (position.Y < waypoint.Y) position.Y = position.Y + 5;
            }
            else if (position.Y == waypoint.Y)
            {
                position.X = position.X + 5;
            }
            if (position.X > 1200)
            {
                madeIt = true;
            }
            //levens
            if(currentHealth <= 0) alive = false;
        }

        public void Draw(SpriteBatch batch, Texture2D texture)
        {
            if(alive)
            {
                float healthPercentage = currentHealth / startHealth;
                Color color = new Color(new Vector3(1 - healthPercentage, 1 - healthPercentage, 1 - healthPercentage));
                batch.Draw(texture, new Rectangle(Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 50, 50), Color.White);
                //batch.Draw(texture, new Rectangle(Convert.ToInt32(position.X), (Convert.ToInt32(position.Y) - 10), 10, 10), color);
            }
        }
    }
}
