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
        KeyboardState kbState;
        KeyboardState previousKbState;

        // GameObjects
        Player player;
        List<Tile> tiles;

        // Testing Tiles
        Tile tileNormal;
        Tile tileKill;
        Tile tileBuff;
        Tile tileBuffReq;
        Tile tileMove;

        //background
        Texture2D background;

        //Timer
        float Timer = 0;


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
            player = new Player(new Rectangle(100, 100, 10, 16));
            tiles = new List<Tile>();

            // Testing Tiles
            tileNormal = new TileNormal(new Rectangle(200, 50, 50, 50));
            tileKill = new TileKill(new Rectangle(200, 100, 50, 50));
            tileBuff = new TileBuff(new Rectangle(200, 150, 50, 50));
            tileBuffReq = new TileBuffReq(new Rectangle(200, 200, 50, 50));
            tileMove = new TileMove(new Rectangle(200, 250, 50, 50));

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
            background = Content.Load<Texture2D>("933");

            // Testing Tiles
            tileNormal.Sprite = Content.Load<Texture2D>("GreenTile");
            tileKill.Sprite = Content.Load<Texture2D>("RedTile");
            tileBuff.Sprite = Content.Load<Texture2D>("BlueTile");
            tileBuffReq.Sprite = Content.Load<Texture2D>("PurpleTile");
            tileMove.Sprite = Content.Load<Texture2D>("YellowTile");
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

            // Updates keyboard state
            previousKbState = kbState;
            kbState = Keyboard.GetState();

            switch (gameState)
            {
                case GameState.Menu:
                    // Pressing enter starts the game
                    if (SingleKeyPress(Keys.Enter))
                    {
                        gameState = GameState.Game;
                    }
                    if (SingleKeyPress(Keys.Escape))
                    {
                        this.Exit();
                    }
                    // Pressing i enters the instructions menu
                    if (SingleKeyPress(Keys.I))
                    {
                        gameState = GameState.Instructions;
                    }
                    break;

                case GameState.Instructions:
                    // Pressing enter returns to the menu
                    if (SingleKeyPress(Keys.Enter))
                    {
                        gameState = GameState.Menu;
                    }
                    break;

                case GameState.Game:
                    // checks for collisions
                    UpdateCollisions();
                    playerMovements();
                    //timer
                    Timer += gameTime.TotalGameTime.Seconds;
                    break;

                case GameState.Gameover:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        player.HasBuff = false;
                        gameState = GameState.Menu;
                    }
                    if (SingleKeyPress(Keys.Escape))
                    {
                        this.Exit();
                    }

                    // Reset player
                    player.rectangle = new Rectangle(100, 100, 10, 16);
                    break;
            }


            kbState = Keyboard.GetState();


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

            switch (gameState)
            {
                case GameState.Menu:
                    // These will be replaced by an image later on
                    spriteBatch.Draw(background, new Rectangle(0, 0, GraphicsDevice.Viewport.Width , GraphicsDevice.Viewport.Height), Color.White);
                    spriteBatch.DrawString(spriteFont, "Ultimate Tile Challenge!", new Vector2(305, 200), Color.Red);
                    spriteBatch.DrawString(spriteFont, "(Press 'Enter' To Play)", new Vector2(308, 220), Color.Red);
                    spriteBatch.DrawString(spriteFont, "(Press 'i' To view instructions)", new Vector2(282, 240), Color.Red);
                    spriteBatch.DrawString(spriteFont, "(Press 'Esc' To Exit the game)",new Vector2(290,260),Color.Red);
                    break;

                case GameState.Instructions:
                    // These will be replaced by an image later on
                    spriteBatch.DrawString(spriteFont, "Green tiles do nothing and are safe", new Vector2(250, 160), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Red tiles will kill you instantly", new Vector2(275, 180), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Blue tiles will give you a buff", new Vector2(275, 200), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Purple tiles will kill you without a buff", new Vector2(245, 220), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Yellow tiles will move you", new Vector2(285, 240), Color.Black);
                    spriteBatch.DrawString(spriteFont, "(Press 'Enter' to return to the menu)", new Vector2(252, 300), Color.Black);
                    break;

                case GameState.Game:
                    // Draw Test Tiles
                    spriteBatch.Draw(tileNormal.Sprite, tileNormal.rectangle, Color.White);
                    spriteBatch.Draw(tileKill.Sprite, tileKill.rectangle, Color.White);
                    spriteBatch.Draw(tileBuff.Sprite, tileBuff.rectangle, Color.White);
                    spriteBatch.Draw(tileBuffReq.Sprite, tileBuffReq.rectangle, Color.White);
                    spriteBatch.Draw(tileMove.Sprite, tileMove.rectangle, Color.White);
                    spriteBatch.DrawString(spriteFont, Timer.ToString(), new Vector2(50,50), Color.Blue);

                    // Draw Player (basic)
                    if (playerState == PlayerState.Left)
                    {
                        spriteBatch.Draw(player.Sprite, player.rectangle, player.SourceRec, Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                    }
                    else
                    {
                        spriteBatch.Draw(player.Sprite, player.rectangle, Color.White);
                    }

                    // Draw Text
                    spriteBatch.DrawString(spriteFont, "Milestone 2", new Vector2(10, 10), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Buff: " + player.HasBuff, new Vector2(10, 30), Color.Black);
                    break;

                case GameState.Gameover:
                    // These will be replaced by an image later on
                    spriteBatch.DrawString(spriteFont, "You Died!", new Vector2(350, 100), Color.Black);
                    spriteBatch.DrawString(spriteFont, "(Press 'Enter' To return to the menu)", new Vector2(250, 120), Color.Black);
                    spriteBatch.DrawString(spriteFont, "(Press 'Esc' To Exit the game", new Vector2(290, 260), Color.Black);
                    break;
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }

        // Processes collisions
        public void UpdateCollisions()
        {
            if (tileKill.CheckCollision(player))
            {
                gameState = GameState.Gameover;
            }

            if (tileBuff.CheckCollision(player))
            {
                player.HasBuff = true;
            }

            if (tileBuffReq.CheckCollision(player))
            {
                if (!player.HasBuff)
                {
                    gameState = GameState.Gameover;
                }
            }

            if (tileMove.CheckCollision(player))
            {
                player.PositionX -= 50;
            }
        }

        // Processes pressing a key once
        public Boolean SingleKeyPress(Keys key)
        {
            if (kbState.IsKeyDown(key) && previousKbState.IsKeyUp(key))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// method for player's move
        /// </summary>
        public void playerMovements()
        {
            if (kbState.IsKeyDown(Keys.W))
            {
                playerState = PlayerState.Up;
                player.PositionY -= 2;
            }
            if (kbState.IsKeyDown(Keys.S))
            {
                playerState = PlayerState.Down;
                player.PositionY += 2;
            }
            if (kbState.IsKeyDown(Keys.A))
            {
                playerState = PlayerState.Left;
                player.PositionX -= 2;
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                playerState = PlayerState.Right;
                player.PositionX += 2;
            }
        }
        
    }
}
