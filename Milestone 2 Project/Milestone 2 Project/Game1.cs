using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Milestone_2_Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        enum PlayerState { Standing, Up, Down, Left, Right}
        enum GameState { Menu, Instructions, Game, Gameover}
        GameState gameState;
        PlayerState playerState;

        // Graphics
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spriteFont;
        KeyboardState kState;

        // GameObjects
        Player player;
        List<Tile> tiles;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player = new Player(new Rectangle(100, 100, 50, 50));
            tiles = new List<Tile>();
            gameState = GameState.Menu;
            playerState = PlayerState.Standing;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.Sprite = Content.Load<Texture2D>("PlayerSprite");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world, checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Esc key instantly exits game.
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // Moves player and updates player state.
            kState = Keyboard.GetState();
            if (kState.IsKeyDown(Keys.W))
            {
                playerState = PlayerState.Up;
                player.PositionY -= 2;
            }
            if (kState.IsKeyDown(Keys.S))
            {
                playerState = PlayerState.Down;
                player.PositionY += 2;
            }
            if (kState.IsKeyDown(Keys.A))
            {
                playerState = PlayerState.Left;
                player.PositionX -= 2;
            }
            if (kState.IsKeyDown(Keys.D))
            {
                playerState = PlayerState.Right;
                player.PositionX += 2;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
            spriteBatch.Begin();

            // Draw Player
            if (playerState == PlayerState.Left)
            {
                spriteBatch.Draw(player.Sprite, player.Position, player.SourceRec, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(player.Sprite, player.Position, player.SourceRec, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            }

            // Draw Text
            spriteBatch.DrawString(spriteFont, "Milestone 2", new Vector2(10, 10), Color.Black);

            //draw each tile
            //will change in later iterations


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
