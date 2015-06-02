using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class Wave
    {
        public List<Enemy> Enemies;
        private int numberOfEnemies;
        private int waveNumber;

        public Wave(int waveNumber, int numberOfEnemies)
        {
            this.numberOfEnemies = numberOfEnemies;
            this.waveNumber = waveNumber;
            Enemies = new List<Enemy>();
        }

        public void IncrementWave()
        {
            waveNumber++;
        }
        //1 + 12, 2 + 14. 3 + 16


        public void Start()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                if(waveNumber < 3)
                {
                    //normal
                    Enemy normal = new NormalEnemy(new Vector2(10, 10), waveNumber);
                    Enemies.Add(normal);
                    
                }
                //alle 10e rondes
                else if(waveNumber % 10 == 0)
                {
                    Enemy boss = new BossEnemy(new Vector2(10, 10), waveNumber);
                    Enemies.Add(boss);
                    //boss
                }
                //alle 5e rondes behalve de 10e rondes
                else if (waveNumber % 5 == 0)
                {
                    Enemy fast = new FastEnemy(new Vector2(10, 10), waveNumber);
                    Enemies.Add(fast);
                    //fast
                }
                else
                {
                    Enemy fast = new FastEnemy(new Vector2(10, 10), waveNumber);
                    Enemies.Add(fast);
                    // Random ofzo? 50/50 verdeeld?
                    //normal & flying TODO
                }
            }
        }
    }
}
