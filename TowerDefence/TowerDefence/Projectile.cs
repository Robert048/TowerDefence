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
        protected bool madeIt = false;

        public void setPosition(Vector2 position)
        {
            this.position = position;
        }

        public void Update(GameTime gametime, Enemy target)
        {
            tPos = target.getPosition();

            if ((int)position.X > tPos.X)
            {
                position.X = position.X - speed;
            }
            if ((int)position.X < tPos.X)
            {
                position.X = position.X + speed;
            }
            if ((int)position.Y > tPos.Y)
            {
                position.Y -= speed;
            }
            if ((int)position.Y < tPos.Y)
            {
                position.Y += speed;
            }

            if ((int)position.X == tPos.X && position.Y == tPos.Y)
            {
                madeIt = true;
            }

        }

        protected bool madeIT()
        {
            return madeIt;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 10);
            spritebatch.Draw(texture, rectangle, Color.White);
        }
    }
}
