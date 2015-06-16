﻿using System;
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
                    smallestRange = Vector2.Distance(position, enemy.getPosition());
                    target = enemy;
                }
            }
            return target;
        }

        //public bool targetInRange()
        //{
        //    if (Vector2.Distance(position, target.getPosition()) < range)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public void Update(GameTime gameTime, Wave_manager manager)
        {
            getTarget(manager);
            attackTime += Convert.ToInt32(gameTime.ElapsedGameTime.TotalMilliseconds);
            if (target != null)
            {
                if (attackTime >= attackSpeed)
                {
                    attackTime = 0;
                    // TODO CHECK WELKE TOWER HET IS EN MAAK ER EEN BIJBEHORENDE PROJECTILE VAN
                    Arrow projectile = new Arrow(projectileTexture, damage, target, position);

                    projectileList.Add(projectile);
                }
            }
            for (int i = 0; i < projectileList.Count; i++)
            {
                Projectile projectile = projectileList[i];
                projectile.Update(gameTime);

                if (projectile.madeIT())
                {
                    projectileList.RemoveAt(i);
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, 50, 50);
            spritebatch.Draw(texture, rectangle, Color.White);

            foreach (var projectile in projectileList)
            {
                projectile.Draw(spritebatch);
            }
        }

        public int getDamage()
        {
            return damage;
        }

        public int getRange()
        {
            return range;
        }

        public int getAttackSpeed()
        {
            return attackSpeed;
        }
    }
}
