using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class Player
    {
        public int lives { get; set; }
        public int money { get; set; }
        public int score { get; set; }

        public Player()
        {
            score = 0;
            lives = 20;
            money = 50;
        }
    }
}
