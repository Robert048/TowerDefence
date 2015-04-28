using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefence
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Texture2D BG;

        //Levels
        Level level = new Level();

        //buttons
        //Button button = new Button(Texture2D, );


        //gameStates for the different states the game has
        enum GameState
        {
            MainMenu, Credits, Settings, LevelSelect, Playing, EndGame, Pause
        }
        GameState CurrentGameState = GameState.Playing;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = level.Width * 50;
            graphics.PreferredBackBufferHeight = (level.Height * 50) + 200;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Initialize before game starts to run
        /// Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D road = Content.Load<Texture2D>("road");
            Texture2D turn = Content.Load<Texture2D>("turn");

            font = Content.Load<SpriteFont>("font");
            BG = Content.Load<Texture2D>("BG_ingame");

            level.AddTexture(grass);
            level.AddTexture(road);
            level.AddTexture(turn);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //gamestates
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    break;
                case GameState.Settings:
                    break;
                case GameState.Credits:
                    break;
                case GameState.LevelSelect:
                    break;
                case GameState.Playing:
                    break;
                case GameState.Pause:
                    break;
                case GameState.EndGame:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Begin the drawing
            spriteBatch.Begin();
            
            //gamestates
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    //draw buttons

                    break;
                case GameState.Settings:
                    break;
                case GameState.Credits:
                    break;
                case GameState.LevelSelect:
                    break;
                case GameState.Playing:
                    level.Draw(spriteBatch);
                    //onderste gedeelte
                    spriteBatch.Draw(BG, new Rectangle(0, 550, 1200, 200), Color.White);
                    spriteBatch.DrawString(font, "Lives: ", new Vector2(level.Width, level.Height + 550 ), Color.Black);
                    
                    break;
                case GameState.Pause:
                    break;
                case GameState.EndGame:
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
