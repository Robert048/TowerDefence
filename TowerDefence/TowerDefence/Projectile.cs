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
        protected Vector2 position;
        protected Vector2 tPos;
        protected float speed;

        public Projectile()
        {

        }
        public void shoot(Enemy target, Vector2 position)
        {
            this.position = position;
            tPos = target.getPosition();
            
        }

        public void Draw(SpriteBatch spritebatch)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 30, 10);
            spritebatch.Draw(texture, rectangle, Color.White);
        }
    }
}
