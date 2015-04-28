using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TowerDefence
{
    class Level
    {
        int[,] map = new int[,] 
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,4,4,4,3,0,0,0,0,},
            {0,2,4,4,3,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,},
            {0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,},
            {0,1,0,0,1,0,0,0,0,2,4,4,3,0,0,1,0,0,0,1,0,0,0,0,},
            {4,5,0,0,1,0,0,0,0,1,0,0,1,0,0,1,0,0,0,6,4,4,4,4,},
            {0,0,0,0,1,0,0,0,0,1,0,0,6,4,4,5,0,0,0,0,0,0,0,0,},
            {0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,6,4,4,4,4,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
        };
        private List<Texture2D> tileTextures = new List<Texture2D>();

        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }

        public int Width
        {
            get { return map.GetLength(1); }
        }
        public int Height
        {
            get { return map.GetLength(0); }
        }

        public void Draw(SpriteBatch batch)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int textureIndex = map[y, x];
                    if (textureIndex == -1)
                        continue;
                    if (textureIndex == 3)
                    {
                        Texture2D texture2 = tileTextures[2];
                        batch.Draw(texture2, new Rectangle(x * 50, y * 50, 50, 50), null, Color.White, ((float)Math.PI / 2.0f), new Vector2(0,50), SpriteEffects.None, 0);
                    }
                    else if (textureIndex == 4)
                    {
                        Texture2D texture2 = tileTextures[1];
                        batch.Draw(texture2, new Rectangle(x * 50, y * 50, 50, 50), null, Color.White, ((float)Math.PI / 2.0f), new Vector2(0, 50), SpriteEffects.None, 0);
                    }
                    else if (textureIndex == 5)
                    {
                        Texture2D texture2 = tileTextures[2];
                        batch.Draw(texture2, new Rectangle(x * 50, y * 50, 50, 50), null, Color.White, ((float)Math.PI), new Vector2(50, 50), SpriteEffects.None, 0);
                    }
                    else if (textureIndex == 6)
                    {
                        Texture2D texture2 = tileTextures[2];
                        batch.Draw(texture2, new Rectangle(x * 50, y * 50, 50, 50), null, Color.White, ((float)Math.PI * 1.5f), new Vector2(50, 0), SpriteEffects.None, 0);
                    }
                    else
                    {
                        Texture2D texture = tileTextures[textureIndex];
                        batch.Draw(texture, new Rectangle(x * 50, y * 50, 50, 50), Color.White);
                    }
                    
                }
            }
        }


    }
}
