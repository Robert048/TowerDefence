using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense
{
    /// <summary>
    /// This is the main game class
    /// </summary>
    public class TowerDefense : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch batch;
        private SpriteFont font;
        private Texture2D BG;

        //Objecten
        private Player player = new Player();
        private Level level = new Level();
        private Wave_manager manager = new Wave_manager();

        //buttons
        private Button btnMenuPlay;


        //gameStates for the different states the game has
        enum GameState
        {
            MainMenu, Credits, Settings, LevelSelect, Playing, EndGame, Pause
        }
        GameState CurrentGameState = GameState.MainMenu;

        public TowerDefense()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            batch = new SpriteBatch(GraphicsDevice);

            //load level sprites
            Texture2D grass = Content.Load<Texture2D>("grass");
            Texture2D road = Content.Load<Texture2D>("road");
            Texture2D turn = Content.Load<Texture2D>("turn");
            //add sprites for tiles to level
            level.AddTexture(grass);
            level.AddTexture(road);
            level.AddTexture(turn);

            //load content for the game
            font = Content.Load<SpriteFont>("font");
            BG = Content.Load<Texture2D>("BG_ingame");

            //buttons
            btnMenuPlay = new Button(Content.Load<Texture2D>("Play"), graphics.GraphicsDevice);
            btnMenuPlay.setPosition(new Vector2(525, 125));
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
            MouseState mouse = Mouse.GetState();
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    IsMouseVisible = true;
                    if (btnMenuPlay.isClicked == true) CurrentGameState = GameState.Playing;
                    btnMenuPlay.Update(mouse);
                    break;
                case GameState.Settings:
                    break;
                case GameState.Credits:
                    break;
                case GameState.LevelSelect:
                    break;
                case GameState.Playing:
                    //keep game fullscreen
                    graphics.PreferredBackBufferWidth = level.Width * 50;
                    graphics.PreferredBackBufferHeight = (level.Height * 50) + 200;
                    graphics.ApplyChanges();
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
            batch.Begin();
            
            //gamestates
            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    //draw buttons
                    btnMenuPlay.Draw(batch);

                    break;
                case GameState.Settings:
                    break;
                case GameState.Credits:
                    break;
                case GameState.LevelSelect:
                    break;
                case GameState.Playing:
                    level.Draw(batch);

                    //onderste gedeelte
                    batch.Draw(BG, new Rectangle(0, 550, 1200, 200), Color.White);
                    batch.DrawString(font, "Lives: ", new Vector2(level.Width, level.Height + 550 ), Color.Black);
                    batch.DrawString(font, "Gold: ", new Vector2(level.Width, level.Height + 570), Color.Black);
                    batch.DrawString(font, "iets: ", new Vector2(level.Width, level.Height + 590), Color.Black);
                    break;
                case GameState.Pause:
                    break;
                case GameState.EndGame:
                    break;
            }
            batch.End();

            base.Draw(gameTime);
        }
    }
}
