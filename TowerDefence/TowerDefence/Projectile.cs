using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class Projectile
    {
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected Vector2 position = new Vector2();
        protected Vector2 tPos = new Vector2();
        protected float speed;
        protected int damage;
        protected bool madeIt = false;
        protected bool inRange = true;
        protected int maxRange;
        protected Enemy target;
        protected String projectileType;
        private Vector2 direction;
        float rotation;
        //private Vector2 vector;

        public bool madeIT()
        {
            return madeIt;
        }

        public bool isInRange()
        {
            return inRange;
        }

        private bool stillInRange()
        {
            if (Vector2.Distance(position, target.getPosition()) < maxRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(GameTime gametime)
        {
            tPos = target.getPosition();
            direction = tPos - position;
            rotation = (float)Math.Atan2(direction.Y + 15, direction.X + 20);

            if (target.IsKilled())
            {
                madeIt = true;
            }
            if (!stillInRange())
            {
                inRange = false;
            }
            if ((int)position.X > tPos.X + 26)
            {
                position.X -= speed;
            }
            if ((int)position.X < tPos.X + 26)
            {
                position.X += speed;
            }
            if ((int)position.Y > tPos.Y + 26)
            {
                position.Y -= speed;
            }
            if ((int)position.Y < tPos.Y + 26)
            {
                position.Y += speed;
            }
            if (((int)position.X >= (tPos.X) && (int)position.X <= (tPos.X + 40)) && (position.Y >= (tPos.Y) && position.Y <= (tPos.Y + 30)))
            {
                target.currentHealth = target.currentHealth - damage;
                madeIt = true;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (projectileType == "arrow")
            {
                rectangle = new Rectangle((int)position.X + 25, (int)position.Y + 25, 30, 10);
            }
            else if (projectileType == "freeze")
            {
                rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            }
            else if (projectileType == "canon")
            {
                rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            }

            //batch.Draw(texture, rectangle, Color.White);
            Vector2 orgin = new Vector2(15, 5);
            //batch.Draw(texture, position, rectangle, Color.White, angle, orgin, 1.0f, SpriteEffects.None, 0);
            batch.Draw(texture, rectangle, null, Color.White, rotation, new Vector2(15, 5), SpriteEffects.None, 0);
        }
    }
}
