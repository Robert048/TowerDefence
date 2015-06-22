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
    class Wave_manager
    {
        //fields
        private readonly Queue<Wave> waves = new Queue<Wave>();
        public int numberOfWaves;
        private bool levelFinished = false;
        public int currentWave = 1;
            
        //lijst met enemies
        public List<Enemy> enemies { get { return CurrentWave().enemies; } }

        /// <summary>
        /// wave manager constructor
        /// </summary>
        /// <param name="waypoints">Waypoints voor de enemies</param>
        /// <param name="levelIndex">Het level nummer</param>
        /// <param name="player">De Player</param>
        public Wave_manager(Queue<Vector2> waypoints, int levelIndex, Player player)
        {
            numberOfWaves = 10 + (levelIndex * 5);
            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumberOfEnemies = 10;
                int numberModifier = i * 2;
                Wave wave = new Wave(i, initialNumberOfEnemies + numberModifier, waypoints, player);
                waves.Enqueue(wave);
            }
            StartNextWave();
        }

        /// <summary>
        /// getter voor de currentWave
        /// </summary>
        /// <returns>De currentwave</returns>
        public Wave CurrentWave()
        { 
            if(waves.Count > 0)
            {
                return waves.Peek();
            }
            else
            {
                // WIN
                levelFinished = true;

                // Dummywave
                return new Wave(15, 20, new Queue<Vector2>(), new Player());
            }
        }

        /// <summary>
        /// getter voor levelFinished
        /// </summary>
        /// <returns>LevelFinished</returns>
        public bool isFinished()
        {
            return levelFinished;
        }

        /// <summary>
        /// start de volgende wave
        /// </summary>
        private void StartNextWave()
        {
            if(waves.Count > 0)
            {
                waves.Peek().Start();
            }
        }

        /// <summary>
        /// monogame Update method
        /// </summary>
        /// <param name="gametime"></param>
        public void Update(GameTime gametime)
        {
            if(levelFinished)
            {

            }
            else
            {
                CurrentWave().Update(gametime);
                if (CurrentWave().enemies.Count <= 0)
                {
                    currentWave++;
                    waves.Dequeue();
                    CurrentWave().Start();
                }
            }
        }

        /// <summary>
        /// monogame Draw method
        /// </summary>
        /// <param name="batch"></param>
        /// <param name="content"></param>
        public void Draw(SpriteBatch batch, ContentManager content)
        {
            CurrentWave().Draw(batch, content);
        }
    }
}
