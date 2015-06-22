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
        //fields
        public List<Enemy> enemies;
        private int numberOfEnemies;
        private int waveNumber;
        private bool spawn;
        private Queue<Vector2> waypoints;
        private Player player;
        Random random = new Random();
        int BossNumber;

        /// <summary>
        /// constructor wave
        /// </summary>
        /// <param name="waveNumber">Het nummer van de wave</param>
        /// <param name="numberOfEnemies">Het aantal enemies in de wave</param>
        /// <param name="waypoints">De waypoints voor de enemies</param>
        /// <param name="player">De player</param>
        public Wave(int waveNumber, int numberOfEnemies, Queue<Vector2> waypoints, Player player)
        {
            this.numberOfEnemies = numberOfEnemies;
            this.waveNumber = waveNumber;
            this.waypoints = waypoints;
            enemies = new List<Enemy>();
            spawn = false;
            this.player = player;
            BossNumber = random.Next(0, 2);
        }
        
        /// <summary>
        /// start method om de wave te laten starten met spawnen.
        /// </summary>
        public void Start()
        {
            AddEnemy();
            spawn = true;
        }

        /// <summary>
        /// methode om enemy toe te voegen aan de wave
        /// </summary>
        private void AddEnemy()
        {
            int enemiesNR = numberOfEnemies;
            int halfWave = enemiesNR / 2;
            for (int i = 1; i < (numberOfEnemies + 1); i++)
            {
                if (waveNumber < 2)
                {
                    //normal
                    Enemy normal = new NormalEnemy(new Vector2((0 - (i * 50)), 250), waveNumber, waypoints);
                    enemies.Add(normal);

                }
                //alle 10e rondes
                else if ((waveNumber + 1) % 10 == 0)
                {
                    //Boss wave
                    Enemy boss = new BossEnemy(new Vector2((0 - (i * 50)), 250), waveNumber, waypoints);
                    enemies.Add(boss);
                    numberOfEnemies = 0;
                }
                //alle 5e rondes behalve de 10e rondes
                else if ((waveNumber + 1) % 5 == 0)
                {
                    //Fast enemy wave
                    Enemy fast = new FastEnemy(new Vector2((0 - (i * 50)), 250), waveNumber, waypoints);
                    enemies.Add(fast);
                }
                else
                {
                    //normal and flying enemies
                    Enemy enemy;
                    if (halfWave >= enemiesNR)
                    {
                        enemy = new NormalEnemy(new Vector2((0 - (i * 50)), 250), waveNumber, waypoints);
                        enemiesNR--;
                    }
                    else
                    {
                        enemy = new FlyingEnemy(new Vector2((0 - (i * 50)), 250), waveNumber, waypoints);
                        enemiesNR--;
                    }
                    enemies.Add(enemy);
                }
            }
        }

        /// <summary>
        /// monogame Update methode
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            if (spawn)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    Enemy enemy = enemies[i];
                    enemy.Update();
                    if (enemy.IsKilled())
                    {
                        player.score++;
                        player.money = player.money + enemy.bountyGiven;
                        enemies.Remove(enemy);
                        i--;
                    }
                    if (enemy.madeItToEnd())
                    {
                        if (enemy.GetType() == typeof(BossEnemy))
                        {
                            player.lives = player.lives - 5;
                        }
                        else
                        {
                            player.lives--;
                        }
                        enemies.Remove(enemy);
                        i--;
                    }
                }
            }
        }

        /// <summary>
        /// monogame Draw methode
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="content"></param>
        public void Draw(SpriteBatch batch, ContentManager content)
        {
            //soort enemy
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(batch, getTextures(enemy, content), content.Load<Texture2D>("BlankBar"));
            }
        }

        /// <summary>
        /// getter voor de textures van de enemies
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private Texture2D getTextures(Enemy enemy, ContentManager content)
        {
            if(enemy.GetType() == typeof(NormalEnemy))
            {
                return content.Load<Texture2D>("Enemies/normalEnemy");
            }
            else if (enemy.GetType() == typeof(FastEnemy))
            {
                return content.Load<Texture2D>("Enemies/fastEnemy");
            }
            else if (enemy.GetType() == typeof(BossEnemy))
            {
                if (BossNumber == 0)
                {
                    return content.Load<Texture2D>("Enemies/bossEnemy");
                }
                else
                {

                    return content.Load<Texture2D>("Enemies/boss2Enemy");
                }
            }
            else if (enemy.GetType() == typeof(FlyingEnemy))
            {
                return content.Load<Texture2D>("Enemies/flyingEnemy");
            }
            else
            {
                return null;
            }
        }
    }
}
