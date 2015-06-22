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
        //stats van de player
        public int lives { get; set; } //levens
        public int money { get; set; } //geld
        public int score { get; set; } //score

        /// <summary>
        /// constructor voor Player
        /// </summary>
        public Player()
        {
            //initialize de player stats
            score = 0;
            lives = 20;
            money = 51;
        }
    }
}
