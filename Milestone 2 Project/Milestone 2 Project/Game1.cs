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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState kState;
        SpriteFont spriteFont;
        Vector2 vector2;
        Player player;
        List<Tile> tiles;

        //keyboard attributes
        Boolean[] wasd = { false, false, false, false };
        string[] wasdStr = { "W", "A", "S", "D" };


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
            // TODO: Add your initialization logic here
            player = new Player(100, 100, 50, 50);
            vector2 = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);
            tiles = new List<Tile>();

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
            // TODO: use this.Content to load your game content here
            player.Sprite = Content.Load<Texture2D>("PlayerSprite");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            kState = Keyboard.GetState();

            //change position based on button press
            if (kState.IsKeyDown(Keys.W))
                player.PositionY -= 2;
            if (kState.IsKeyDown(Keys.A))
                player.PositionX -= 2;
            if (kState.IsKeyDown(Keys.S))
                player.PositionY += 2;
            if (kState.IsKeyDown(Keys.D))
                player.PositionX += 2;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);
           
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            if (kState.IsKeyDown(Keys.A))
            {
                spriteBatch.Draw(player.Sprite, player.Position, player.sourceRec, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                spriteBatch.Draw(player.Sprite, player.Position, player.sourceRec, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            }
            spriteBatch.DrawString(spriteFont, "Milestone 2", new Vector2(10, 10), Color.Black);
            //draw each tile
            //will change in later iterations

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
