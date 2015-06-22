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
        //de variabelen van elke tower
        protected Texture2D projectileTexture;
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected Vector2 position;
        protected int damage;
        protected int attackSpeed;
        protected int range;
        protected Boolean air;
        protected int cost;
        protected List<Projectile> projectileList;
        protected Enemy target;
        protected int attackTime;
        protected String towerString;
        protected int freezePower = 0;

        /// <summary>
        /// returned de kosten van de toren
        /// </summary>
        public int getCost()
        {
            return cost;
        }

        /// <summary>
        /// returned de postitie van de toren
        /// </summary>
        public Vector2 getPosition()
        {
            return position;
        }

        /// <summary>
        /// returned de target waar de toren op schiet
        /// </summary>
        /// <param name="manager">de huidige wave</param>
        public Enemy getTarget(Wave_manager manager)
        {
            //targeting
            float smallestRange = range;
            target = null;
            List<Enemy> enemies = manager.enemies;
            foreach (Enemy enemy in enemies)
            {
                if (Vector2.Distance(position, enemy.getPosition()) < smallestRange)
                {
                    if (enemy.getFlying() && air == false)
                    {

                    }
                    else
                    {
                        smallestRange = Vector2.Distance(position, enemy.getPosition());
                        target = enemy;
                    }
                    
                }
            }
            return target;
        }

        /// <summary>
        /// update de game
        /// </summary>
        public void Update(GameTime gameTime, Wave_manager manager)
        {
            getTarget(manager);
            attackTime += Convert.ToInt32(gameTime.ElapsedGameTime.TotalMilliseconds);
            if (target != null)
            {
                if (attackTime >= attackSpeed)
                {
                    attackTime = 0;
                    if (towerString == "arrowTower")
                    {
                        Arrow projectile = new Arrow(projectileTexture, damage, target, position, range);
                        projectileList.Add(projectile);
                    }
                    else if (towerString == "canonTower")
                    {
                        CanonBall projectile = new CanonBall(projectileTexture, damage, target, position, range);
                        projectileList.Add(projectile);
                    }
                    else if (towerString == "freezeTower")
                    {
                        FreezeBullet projectile = new FreezeBullet(projectileTexture, damage, target, position, range, freezePower);
                        projectileList.Add(projectile);
                    }
                }
            }
            for (int i = 0; i < projectileList.Count; i++)
            {
                Projectile projectile = projectileList[i];
                projectile.Update(gameTime);

                if (projectile.madeIT() || !projectile.isInRange())
                {
                    projectileList.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// tekend de toren
        /// </summary>
        public void Draw(SpriteBatch spritebatch)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
            spritebatch.Draw(texture, rectangle, Color.White);

            foreach (var projectile in projectileList)
            {
                projectile.Draw(spritebatch);
            }
        }

        /// <summary>
        /// returned de schade dat de toren doet
        /// </summary>
        public int getDamage()
        {
            return damage;
        }

        /// <summary>
        /// returned de 
        /// </summary>
        public int getRange()
        {
            return range;
        }

        /// <summary>
        /// returned de aanval snelheid
        /// </summary>
        public int getAttackSpeed()
        {
            return attackSpeed;
        }
    }
}
