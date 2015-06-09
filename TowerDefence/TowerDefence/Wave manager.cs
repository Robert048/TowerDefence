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
        private readonly Queue<Wave> waves = new Queue<Wave>();
        public int numberOfWaves;
        private bool levelFinished = false;
            
        public List<Enemy> enemies { get { return CurrentWave().enemies; } }

        public Wave_manager(Queue<Vector2> waypoints, int levelIndex, Player player)
        {
            numberOfWaves = 10 + levelIndex;
            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumberOfEnemies = 10;
                int numberModifier = i * 2;
                Wave wave = new Wave(i, initialNumberOfEnemies + numberModifier, waypoints, player);
                waves.Enqueue(wave);
            }
            StartNextWave();
        }

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

        public bool isFinished()
        {
            return levelFinished;
        }

        private void StartNextWave()
        {
            if(waves.Count > 0)
            {
                waves.Peek().Start();
            }
        }

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
                    waves.Dequeue();
                    CurrentWave().Start();
                }
            }
        }

        public void Draw(SpriteBatch batch, ContentManager content)
        {
            CurrentWave().Draw(batch, content);
        }
    }
}
