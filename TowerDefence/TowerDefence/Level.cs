using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace TowerDefence
{
    class Level
    {
        private List<Texture2D> tileTextures = new List<Texture2D>();

        public void AddTexture(Texture2D texture)
        {
            tileTextures.Add(texture);
        }

        /// <summary>
        /// Width of level measured in tiles.
        /// </summary>
        public int Width
        {
            get { return tiles.GetLength(0); }
        }

        /// <summary>
        /// Height of the level measured in tiles.
        /// </summary>
        public int Height
        {
            get { return tiles.GetLength(1); }
        }

        public void Draw(SpriteBatch batch)
        {
            // Load the level.
            string levelPath = string.Format("Content/{0}.txt", 0);
            Stream fileStream = TitleContainer.OpenStream(levelPath);

            LoadTiles(fileStream);
            DrawTiles(batch);
        }

        

        // de layout van het level
        private Tile[,] tiles;

        /// <summary>
        /// Draws each tile in the level.
        /// </summary>
        private void DrawTiles(SpriteBatch spriteBatch)
        {
            // For each tile position
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    // If there is a visible tile in that position
                    Texture2D texture = tiles[x, y].Texture;
                    if (texture != null)
                    {
                        // Draw it in screen space.
                        Vector2 position = new Vector2(x, y) * Tile.Size;
                        spriteBatch.Draw(texture, position, Color.White);
                    }
                }
            }
        }

        /// <summary>
        /// Laad de tiles uit de file
        /// </summary>
        /// <param name="filestream">
        /// filestream met level data
        /// </param>
        private void LoadTiles(Stream fileStream)
        {
            //Laad level en zorg dat alle regels even lang zijn
            int width;
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line = reader.ReadLine();
                width = line.Length;
                while (line != null)
                {
                    lines.Add(line);
                    if (line.Length != width)
                        throw new Exception(String.Format("The length of line {0} is different from all preceeding lines.", lines.Count));
                    line = reader.ReadLine();
                }
            }

            // Allocate the tile grid.
            tiles = new Tile[width, lines.Count];

            // Loop over every tile position,
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    // to load each tile.
                    char tileType = lines[y][x];
                    tiles[x, y] = LoadTile(tileType, x, y);
                }
            }
        }

        /// <summary>
        /// Loads an individual tile's appearance and behavior.
        /// </summary>
        /// <param name="tileType">
        /// The character loaded from the structure file which
        /// indicates what should be loaded.
        /// </param>
        /// <param name="x">
        /// The X location of this tile in tile space.
        /// </param>
        /// <param name="y">
        /// The Y location of this tile in tile space.
        /// </param>
        /// <returns>The loaded tile.</returns>
        private Tile LoadTile(char tileType, int x, int y)
        {
            switch (tileType)
            {
                //grass
                case '.':
                    return new Tile(tileTextures[0]);

                //road
                case '|':
                    return new Tile(tileTextures[1]);

                //turn
                case '┌':
                    return new Tile(tileTextures[2]);

                //turn
                case '┐':
                    return new Tile(tileTextures[2]);

                //road
                case '-':
                    return new Tile(tileTextures[1]);

                //Lucht
                case '┘':
                    return new Tile(tileTextures[2]);

                //Lucht
                case '└':
                    return new Tile(tileTextures[2]);

                // Unknown tile type character
                default:
                    throw new NotSupportedException(String.Format("Unsupported tile type character '{0}' at position {1}, {2}.", tileType, x, y));
            }
        }
    }
}
