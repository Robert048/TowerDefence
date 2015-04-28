using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefence
{
    class Player
    {
        private int lives { get; set; }
        private int money { get; set; }
        public int score { get; set; }

        public Player()
        {
            score = 0;
            lives = 30;
            money = 100;
        }
    }
}
