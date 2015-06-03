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
        private Queue<Vector2> waypoints;

        public Wave(int waveNumber, int numberOfEnemies, Queue<Vector2> waypoints)
        {
            this.numberOfEnemies = numberOfEnemies;
            this.waveNumber = waveNumber;
            this.waypoints = waypoints;
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
            numberOfEnemies = 1;
            waypoints.Enqueue(new Vector2(1200, 50));
            for (int i = 0; i < numberOfEnemies; i++)
            {
                if (waveNumber < 3)
                {
                    //normal
                    Enemy normal = new NormalEnemy(new Vector2(0, 250), waveNumber, waypoints);
                    enemies.Add(normal);

                }
                //alle 10e rondes
                else if (waveNumber % 10 == 0)
                {
                    //Boss wave
                    Enemy boss = new BossEnemy(new Vector2(10, 10), waveNumber, waypoints);
                    enemies.Add(boss);
                }
                //alle 5e rondes behalve de 10e rondes
                else if (waveNumber % 5 == 0)
                {
                    //Fast enemy wave
                    Enemy fast = new FastEnemy(new Vector2(10, 10), waveNumber, waypoints);
                    enemies.Add(fast);
                }
                else
                {
                    //normal and flying enemies
                    int halfWave = numberOfEnemies / 2;
                    Enemy enemy;
                    if (halfWave >= numberOfEnemies)
                    {
                        enemy = new NormalEnemy(new Vector2(0, 250), waveNumber, waypoints);
                    }
                    else
                    {
                        enemy = new FlyingEnemy(new Vector2(10, 10), waveNumber, waypoints);
                    }
                    enemies.Add(enemy);
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
                //spawn = false;
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
                return content.Load<Texture2D>("normalEnemy");
            }
            else if (enemy.GetType() == typeof(FastEnemy))
            {
                return content.Load<Texture2D>("fastEnemy");
            }
            else if (enemy.GetType() == typeof(BossEnemy))
            {
                //TODO random bossEnemy of boss2Enemy
                return content.Load<Texture2D>("bossEnemy");
            }
            else if (enemy.GetType() == typeof(FlyingEnemy))
            {
                return content.Load<Texture2D>("flyingEnemy");
            }
            else
            {
                return null;
            }
        }
    }
}
