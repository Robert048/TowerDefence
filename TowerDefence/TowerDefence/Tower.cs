using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense
{
    class Tower
    {
        protected Texture2D texture;        
        protected Rectangle rectangle;
        protected Vector2 position;
        protected int damage;
        protected int attackSpeed;
        protected int range;
        protected Boolean ground;
        protected Boolean air;
        protected int cost;
        protected List<Projectile> projectileList;   
        
        public int getCost()
        {
            return cost;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, rectangle, Color.White);
        }


    }
}
