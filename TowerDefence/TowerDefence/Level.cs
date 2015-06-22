using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Content;

namespace TowerDefense
{
    class Level
    {
        //textures for tiles
        private List<Texture2D> tileTextures = new List<Texture2D>();
        //the layout
        private Tile[,] tiles;
        //Waypoints for enemies
        private Queue<Vector2> waypoints;

        private Dictionary<Vector2, String> tileList;
        // first time the level is loaded
        private bool firstLoad = true;

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

        /// <summary>
        /// loading the level
        /// </summary>
        public void setLevel(int levelIndex)
        {
            waypoints = new Queue<Vector2>();
            tileList = new Dictionary<Vector2, String>();

            // Load the level.
            string levelPath = string.Format("Content/{0}.txt", levelIndex);
            Stream fileStream = TitleContainer.OpenStream(levelPath);

            LoadTiles(fileStream);
        }

        /// <summary>
        /// drawing the level
        /// </summary>
        public void Draw(SpriteBatch batch)
        {
            DrawTiles(batch);
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
                    tileList.Add(new Vector2(y, x), tileType.ToString());

                    tiles[x, y] = LoadTile(tileType, x, y);
                    //add waypoints for enemies
                    if (tileType == '1' || tileType == '2' || tileType == '3' || tileType == '4' || tileType == 'E')
                    {
                        waypoints.Enqueue(new Vector2(x, y) * 50);
                    }
                }
            }
            sortWaypoints();
        }

        //Sort the waypoints queue
        private void sortWaypoints()
        {
            Vector2 position = new Vector2(0, 250);
            Vector2[] array = waypoints.ToArray();
            waypoints.Clear();
            // loop through waypoints
            for (int i = 0; i < array.Length; i++)
            {
                Vector2 waypoint;
                if (i % 2 == 0)
                {
                    //first Y
                    waypoint = findY(array, position);
                }
                else
                {
                    //then X
                    waypoint = findX(array, position);
                }
                //enqueue waypoint
                waypoints.Enqueue(waypoint);
                //set position
                position = waypoint;
            }
        }

        private Vector2 findX(Vector2[] array, Vector2 position)
        {
            Vector2[] arrayX = new Vector2[4];
            //loop through array made of waypoints and puts same X in arrayX
            int j = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                float test = array[i].X;
                if (test == position.X)
                {
                    arrayX[j] = array[i];
                    j++;
                }
            }
            float minY = 0;
            minY = arrayX[0].Y;
            if (minY == position.Y)
            {
                minY = arrayX[1].Y;
            }
            for (int i = 0; i < arrayX.Length; i++)
            {
                if (minY > arrayX[i].X && arrayX[i].X > position.X)
                {
                    minY = arrayX[i].Y;
                }
            }
            return new Vector2(position.X, minY);
        }

        private Vector2 findY(Vector2[] array, Vector2 position)
        {
            Vector2[] arrayY = new Vector2[4];
            //loop through array made of waypoints and puts same Y in arrayY
            int j = 0;
            for (int i = 0; i < array.Count(); i++)
            {
                float test = array[i].Y;
                if (test == position.Y)
                {
                    arrayY[j] = array[i];
                    j++;
                }
            }
            float minX = 0;
            minX = arrayY[0].X;
            if (minX == position.X)
            {
                minX = arrayY[1].X;
            }
            for (int i = 0; i < arrayY.Length; i++)
            {
                if (minX > arrayY[i].X && arrayY[i].X > position.X)
                {
                    minX = arrayY[i].X;
                }
            }
            return new Vector2(minX, position.Y);
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
                case '0':
                    return new Tile(tileTextures[0], 0);

                //road
                case '|':
                    return new Tile(tileTextures[1], 0);
                case '-':
                    return new Tile(tileTextures[1], 90);

                //turn
                case '1':
                    return new Tile(tileTextures[2], 180);
                case '2':
                    return new Tile(tileTextures[2], 0);
                case '3':
                    return new Tile(tileTextures[2], 90);
                case '4':
                    return new Tile(tileTextures[2], 270);

                //end
                case 'E':
                    return new Tile(tileTextures[3], 0);

                // Unknown tile type character
                default:
                    throw new NotSupportedException(String.Format("Unsupported tile type character '{0}' at position {1}, {2}.", tileType, x, y));
            }
        }

        public Queue<Vector2> getWaypoints()
        {
            return waypoints;
        }

        /// <summary>
        /// Draws each tile in the level.
        /// </summary>
        private void DrawTiles(SpriteBatch batch)
        {
            // For each tile position
            for (int y = 0; y < Height; ++y)
            {
                for (int x = 0; x < Width; ++x)
                {
                    // If there is a visible tile in that position
                    Texture2D texture = tiles[x, y].Texture;
                    //check rotation
                    int rotation = tiles[x, y].rotation;
                    if (texture != null && rotation == 0)
                    {
                        // Draw it in screen space.
                        Vector2 position = new Vector2(x, y) * Tile.Size;
                        batch.Draw(texture, position, Color.White);
                    }
                    if (texture != null && rotation != 0)
                    {
                        // Draw it in screen space.
                        Vector2 position = new Vector2(x, y) * Tile.Size;
                        Vector2 vector = new Vector2(0, 0);
                        float rotate = 0;
                        if (rotation == 90)
                        {
                            rotate = ((float)Math.PI / 2.0f);
                            vector = new Vector2(0, 50);
                        }
                        else if (rotation == 180)
                        {
                            rotate = ((float)Math.PI);
                            vector = new Vector2(50, 50);
                        }
                        else if (rotation == 270)
                        {
                            rotate = ((float)Math.PI * 1.5f);
                            vector = new Vector2(50, 0);
                        }

                        batch.Draw(texture, new Rectangle(x * 50, y * 50, 50, 50), null, Color.White, rotate, vector, SpriteEffects.None, 0);
                    }
                }
            }
        }

        public String getTileType(Vector2 position)
        {
            foreach (var pair in tileList)
            {
                if (pair.Key == position)
                {
                    return pair.Value;
                }
            }
            return "1";
        }
    }
}
