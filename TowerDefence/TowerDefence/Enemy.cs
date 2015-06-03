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
        protected int startHealth;
        protected Queue<Vector2> waypoints = new Queue<Vector2>();
        protected Vector2 position = new Vector2();
        protected Vector2 waypoint = new Vector2();

        public int currentHealth { get; set; }
        public int bountyGiven { get; set; }

        public bool IsDead
        {
            get { return (alive == false); }
        }

        public void Update()
        {
            //waypoints
            if (position == waypoint)
            {
                waypoint = waypoints.Dequeue();
            }
            else if (position.X == waypoint.X)
            {
                if (position.Y > waypoint.Y) position.Y--;
                if (position.Y < waypoint.Y) position.Y++;
            }
            else if (position.Y == waypoint.Y)
            {
                position.X++;
                Debug.WriteLine("x++");
            }
            if (position.X > 1200) alive = false;
            Debug.WriteLine(position + " en " + waypoint);

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
            }
        }
    }
}
