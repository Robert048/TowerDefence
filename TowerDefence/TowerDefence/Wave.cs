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
                }
                //alle 10e rondes
                else if(waveNumber % 10 == 0)
                {
                    //boss
                }
                //alle 5e rondes behalve de 10e rondes
                else if (waveNumber % 5 == 0)
                {
                    //fast
                }
                else
                {
                    //normal & flying
                }
            }
        }
    }
}
