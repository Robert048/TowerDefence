using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class Wave
    {
        public List<Enemy> enemies;
        private int numberOfEnemies;
        private int waveNumber;
        private bool spawn;

        public Wave(int waveNumber, int numberOfEnemies)
        {
            this.numberOfEnemies = numberOfEnemies;
            this.waveNumber = waveNumber;
            enemies = new List<Enemy>();
            spawn = false;
        }

        //1 + 12, 2 + 14. 3 + 16
        public void Start()
        {
            AddEnemy();
            spawn = true;
        }

        private void AddEnemy()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                if (waveNumber < 3)
                {
                    //normal
                    Enemy normal = new NormalEnemy(new Vector2(10, 10), waveNumber);
                    enemies.Add(normal);

                }
                //alle 10e rondes
                else if (waveNumber % 10 == 0)
                {
                    Enemy boss = new BossEnemy(new Vector2(10, 10), waveNumber);
                    enemies.Add(boss);
                    //boss
                }
                //alle 5e rondes behalve de 10e rondes
                else if (waveNumber % 5 == 0)
                {
                    Enemy fast = new FastEnemy(new Vector2(10, 10), waveNumber);
                    enemies.Add(fast);
                    //fast
                }
                else
                {
                    Enemy fast = new FastEnemy(new Vector2(10, 10), waveNumber);
                    enemies.Add(fast);
                    // Random ofzo? 50/50 verdeeld?
                    //normal & flying TODO
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (spawn)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    Enemy enemy = enemies[i];
                    enemy.Update();
                    if (enemy.IsDead)
                    {
                        enemies.Remove(enemy);
                        i--;
                    }
                }
                spawn = false;
            }
        }

        public void Draw(SpriteBatch batch, ContentManager content)
        {
            //soort enemy
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(batch, getTextures(enemy, content));
            }
        }

        private Texture2D getTextures(Enemy enemy, ContentManager content)
        {
            if(enemy.GetType() == typeof(NormalEnemy))
            {
                return content.Load<Texture2D>("enemy");
            }
            else if (enemy.GetType() == typeof(FastEnemy))
            {
                return content.Load<Texture2D>("enemy");
            }
            else if (enemy.GetType() == typeof(BossEnemy))
            {
                return content.Load<Texture2D>("enemy");
            }
            else if (enemy.GetType() == typeof(FlyingEnemy))
            {
                return content.Load<Texture2D>("enemy");
            }
            else
            {
                return null;
            }
        }
    }
}
