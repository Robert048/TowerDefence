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
        private int numberOfWaves;
        private float timeSinceLastWave;
        private bool waveFinished;
        public Wave CurrentWave { get { return waves.Peek(); } }
        public List<Enemy> enemies { get { return CurrentWave.enemies; } }

        public Wave_manager(Queue<Vector2> waypoints, int levelIndex)
        {
            numberOfWaves = 10 + levelIndex;


            for (int i = 0; i < numberOfWaves; i++)
            {
                int initialNumberOfEnemies = 10;
                int numberModifier = i * 2;
                Wave wave = new Wave(i, initialNumberOfEnemies + numberModifier, waypoints);
                waves.Enqueue(wave);
            }

            StartNextWave();
        }

        

        private void StartNextWave()
        {
            if(waves.Count > 0)
            {
                waves.Peek().Start();
                timeSinceLastWave = 0;
                waveFinished = false;
            }
        }
        public void Update(GameTime gametime)
        {
            CurrentWave.Update(gametime);
        }

        public void Draw(SpriteBatch batch, ContentManager content)
        {
            CurrentWave.Draw(batch, content);
        }
    }
}
