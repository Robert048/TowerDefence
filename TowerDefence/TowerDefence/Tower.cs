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
        protected Texture2D projectileTexture;
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
        protected Enemy target;
        protected int attackTime;
        
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
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
            spritebatch.Draw(texture, rectangle, Color.White);
        }

        public void getClosest(Wave_manager manager)
        {
            float smallestRange = range;
            target = null;
            List<Enemy> enemies = manager.enemies;
            foreach (Enemy enemy in enemies)
            {
                if (Vector2.Distance(position, enemy.getPosition()) < smallestRange)
                {
                    smallestRange = Vector2.Distance(position, enemy.getPosition());
                    target = enemy;
                }
            }
            //return target;
        }

        public bool targetInRange()
        {
            if (Vector2.Distance(position, target.getPosition()) < range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void shoot(GameTime gameTime)
        {
            attackTime += Convert.ToInt32(gameTime.ElapsedGameTime.TotalMilliseconds);
            if (target != null)
            {
                if (targetInRange() && attackTime >= attackSpeed)
                {
                    attackTime = 0;
                    target.currentHealth = target.currentHealth - damage;
                    Arrow projectile = new Arrow(projectileTexture);
                    projectile.shoot(target, position);
                    projectile.Draw();

                }
            }
        }
    }
}
