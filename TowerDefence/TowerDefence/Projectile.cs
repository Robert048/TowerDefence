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
        protected Enemy target;
        protected String projectileType;
        //private Vector2 vector;
        private float rotation;
        

        public bool madeIT()
        {
            return madeIt;
        }

        public void Update(GameTime gametime)
        {
            tPos = target.getPosition();
            tPos.X += 25;
            tPos.Y += 25;
            
            if(target.IsKilled())
            {
                madeIt = true;
            }
            if ((int)position.X > tPos.X)
            {
                position.X -= speed;
            }
            if ((int)position.X < tPos.X)
            {
                position.X += speed;
            }
            if ((int)position.Y > tPos.Y)
            {
                position.Y -= speed;
            }
            if ((int)position.Y < tPos.Y)
            {
                position.Y += speed;
            }
            if ((int)position.X == tPos.X + 25 && position.Y == tPos.Y + 25)
            {
                target.currentHealth = target.currentHealth - damage;
                madeIt = true;
            }
            rotation = (float)Math.Atan2((double)tPos.Y, (double)tPos.X);

        }

        public void Draw(SpriteBatch batch)
        {
            if(projectileType == "arrow")
            {
                rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 10);
            }
            else if(projectileType == "freeze")
            {
                rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            }
            else if(projectileType == "canon")
            {
                rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 30);
            }
            
            //batch.Draw(texture, rectangle, Color.White);
            batch.Draw(texture, rectangle, null, Color.White, rotation, new Vector2(15, 5), SpriteEffects.None, 0);
        }
    }
}
