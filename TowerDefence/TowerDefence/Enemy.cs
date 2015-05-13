using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    class Enemy
    {
        private bool alive = true;
        protected int startHealth;

        public int currentHealth { get; set; }
        public int bountyGiven { get; set; }

        

        public bool IsDead
        {
            get { return currentHealth <= 0; }
        }

    }
}
