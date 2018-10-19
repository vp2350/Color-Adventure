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
            player = new Player(0, 0, 85, 92);
            vector2 = new Vector2(Window.ClientBounds.Width / 2, Window.ClientBounds.Height / 2);

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
                vector2.Y -= 1;
            if (kState.IsKeyDown(Keys.A))
                vector2.X -= 1;
            if (kState.IsKeyDown(Keys.S))
                vector2.Y += 1;
            if (kState.IsKeyDown(Keys.D))
                vector2.X += 1;

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

            // TODO: Add your drawing code here
            spriteBatch.Draw(player.Texture2D, new Rectangle((int)vector2.X, (int)vector2.Y, 70, 80), player.Rectangle, Color.White);

            //check key input and move
            if (kState.IsKeyDown(Keys.W) == true)
            {
                spriteBatch.Draw(player.Texture2D, new Rectangle((int)vector2.X, (int)vector2.Y, 70, 80), player.Rectangle, Color.White);
            }
            if (kState.IsKeyDown(Keys.A) == true)
            {
                spriteBatch.Draw(player.Texture2D, new Rectangle((int)vector2.X, (int)vector2.Y, 70, 80), player.Rectangle, Color.White);
            }
            if (kState.IsKeyDown(Keys.S) == true)
            {
                spriteBatch.Draw(player.Texture2D, new Rectangle((int)vector2.X, (int)vector2.Y, 70, 80), player.Rectangle, Color.White, 0,
                    Vector2.Zero, SpriteEffects.FlipVertically, 0);
            }
            if (kState.IsKeyDown(Keys.D) == true)
            {
                spriteBatch.Draw(player.Texture2D, new Rectangle((int)vector2.X, (int)vector2.Y, 70, 80), player.Rectangle, Color.White);
            }

            base.Draw(gameTime);
        }
    }
}
