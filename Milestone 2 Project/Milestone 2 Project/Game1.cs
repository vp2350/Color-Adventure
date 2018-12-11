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
        enum GameState { Menu, Instructions, Game, Gameover, Win}
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
        int frame;
        double timePerFrame = 100;
        int numFrames = 2;
        int framesElapsed;
        int level;
        const int PLAYER_Y = 30;
        const int PLAYER_HEIGHT = 20;
        const int PLAYER_WIDTH = 15;
        const int PLAYER_X_OFFSET = 6;

        // Map
        Map level1;
        Map level2;

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
            player = new Player(new Rectangle(100, 100, 25, 30));
            tiles = new List<Tile>();

            gameState = GameState.Menu;
            playerState = PlayerState.Standing;

            // Create new map, at location 300, 100 with tile size 50, 50
            level1 = new Map(new Vector2(300, 100), 50, 50);
            level2 = new Map(new Vector2(300, 100), 50, 50);

            level = 1;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.Sprite = Content.Load<Texture2D>("Player_SpriteSheet");
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
            background = Content.Load<Texture2D>("933");

            // Load map and populate it
            level1.ReadMap("level1.data");
            level1.PopulateGameMap(Content.Load<Texture2D>("GreenTile"),
                                   Content.Load<Texture2D>("RedTile"),
                                   Content.Load<Texture2D>("BlueTile"),
                                   Content.Load<Texture2D>("PurpleTile"),
                                   Content.Load<Texture2D>("YellowTile"),
                                   Content.Load<Texture2D>("WinTile"));

            level2.ReadMap("level2.data");
            level2.PopulateGameMap(Content.Load<Texture2D>("GreenTile"),
                                   Content.Load<Texture2D>("RedTile"),
                                   Content.Load<Texture2D>("BlueTile"),
                                   Content.Load<Texture2D>("PurpleTile"),
                                   Content.Load<Texture2D>("YellowTile"),
                                   Content.Load<Texture2D>("WinTile"));
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
            framesElapsed = (int)(gameTime.TotalGameTime.TotalMilliseconds / timePerFrame);
            frame = framesElapsed % numFrames + 1;

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
                    // Checks for collisions
                    CalculateCollisions();
                    playerMovements();

                    // Timer
                    Timer += gameTime.TotalGameTime.Seconds;
                    break;


                case GameState.Gameover:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        player.HasBuff = false;
                        gameState = GameState.Menu;
                        level = 1;
                    }
                    if (SingleKeyPress(Keys.Escape))
                    {
                        this.Exit();
                    }
                
                

                    // Reset player
                    player.rectangle = new Rectangle(100, 100, 25, 30);
                    break;

                case GameState.Win:
                    if (SingleKeyPress(Keys.Enter))
                    {
                        player.HasBuff = false;
                        gameState = GameState.Menu;
                        level = 1;
                    }
                    if (SingleKeyPress(Keys.Escape))
                    {
                        this.Exit();
                    }

                    // Reset player
                    player.rectangle = new Rectangle(100, 100, 25, 30);
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

                    // Draw level 1
                    if (level == 1)
                    {
                        level1.DrawMap(spriteBatch);
                    }

                    // Draw level 2
                    else if (level == 2)
                    {
                        level2.DrawMap(spriteBatch);
                    }


                    // Draw Player (basic)
                    if (playerState == PlayerState.Left)
                    {
                        spriteBatch.Draw(player.Sprite, player.rectangle, new Rectangle(PLAYER_X_OFFSET + frame * PLAYER_WIDTH, PLAYER_Y, PLAYER_WIDTH,PLAYER_HEIGHT), 
                            Color.White, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
                    }
                    else
                    {
                        spriteBatch.Draw(player.Sprite, player.rectangle, new Rectangle(PLAYER_X_OFFSET + frame * PLAYER_WIDTH, PLAYER_Y, PLAYER_WIDTH,PLAYER_HEIGHT), 
                            Color.White);
                    }

                    // Draw Text
                    spriteBatch.DrawString(spriteFont, "Level " + level, new Vector2(10, 10), Color.Black);
                    spriteBatch.DrawString(spriteFont, "Buff: " + player.HasBuff, new Vector2(10, 30), Color.Black);
                    break;

                case GameState.Gameover:
                    // These will be replaced by an image later on
                    spriteBatch.DrawString(spriteFont, "You Died!", new Vector2(350, 100), Color.Black);
                    spriteBatch.DrawString(spriteFont, "(Press 'Enter' To return to the menu)", new Vector2(250, 120), Color.Black);
                    spriteBatch.DrawString(spriteFont, "(Press 'Esc' To Exit the game", new Vector2(290, 260), Color.Black);
                    break;
                case GameState.Win:
                    spriteBatch.DrawString(spriteFont, "You win", new Vector2(100, 100), Color.Black);
                    break;
            }


            spriteBatch.End();

            base.Draw(gameTime);
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
        /// Method for player's move. Wont allow character to move around map
        /// </summary>
        public void playerMovements()
        {
            if (kbState.IsKeyDown(Keys.W))
            {
                int mapLoc_X = 0;
                int mapLoc_Y = 0;

                // Set boundaries for level 1
                if (level == 1)
                {
                    mapLoc_X = (int)level1.MapLocation.X;
                    mapLoc_Y = (int)level1.MapLocation.Y;
                }

                // Set boundaries for level 2
                else if (level == 2)
                {
                    mapLoc_X = (int)level2.MapLocation.X;
                    mapLoc_Y = (int)level2.MapLocation.Y;
                }

                // Level boundary boxes
                if (player.PositionY <= mapLoc_Y && player.PositionX >= mapLoc_X)
                {
                    return;
                }

                // Screen Boundary box
                if (player.PositionY == 0)
                {
                    return;
                }
                playerState = PlayerState.Up;
                player.PositionY -= 2;
            }

            if (kbState.IsKeyDown(Keys.S))
            {
                int tilesUp = 0;
                int mapLoc_X = 0;
                int mapLoc_Y = 0;
                int tileHeight = 0;

                // Set boundaries for level 1
                if (level == 1)
                {
                    mapLoc_X = (int)level1.MapLocation.X;
                    mapLoc_Y = (int)level1.MapLocation.Y;
                    tileHeight = level1.TileHeight;
                    tilesUp = 4;
                }

                // Set boundaries for level 2
                else if (level == 2)
                {
                    mapLoc_X = (int)level2.MapLocation.X;
                    mapLoc_Y = (int)level2.MapLocation.Y;
                    tileHeight = level2.TileHeight;
                    tilesUp = 7;
                }

                // Level boundary boxes
                if (player.PositionY + PLAYER_HEIGHT >= mapLoc_Y + (tileHeight * tilesUp) && player.PositionX >= mapLoc_X)
                {
                    return;
                }

                // Screen Boundary box
                if (player.PositionY + PLAYER_HEIGHT == GraphicsDevice.Viewport.Height)
                {
                    return;
                }
                playerState = PlayerState.Down;
                player.PositionY += 2;
            }

            if (kbState.IsKeyDown(Keys.A))
            {
                if (player.PositionX == 0)
                {
                    return;
                }
                playerState = PlayerState.Left;
                player.PositionX -= 2;
            }

            if (kbState.IsKeyDown(Keys.D))
            {
                int tilesUp = 0;
                int tilesRight = 0;
                int mapLoc_X = 0;
                int mapLoc_Y = 0;
                int tileHeight = 0;
                int tileWidth = 0;

                // Set boundaries for level 1
                if (level == 1)
                {
                    mapLoc_X = (int)level1.MapLocation.X;
                    mapLoc_Y = (int)level1.MapLocation.Y;
                    tileHeight = level1.TileHeight;
                    tileWidth = level1.TileHeight;
                    tilesUp = 5;
                    tilesRight = 4;
                }

                // Set boundaries for level 2
                else if (level == 2)
                {
                    mapLoc_X = (int)level2.MapLocation.X;
                    mapLoc_Y = (int)level2.MapLocation.Y;
                    tileHeight = level2.TileHeight;
                    tileWidth = level2.TileHeight;
                    tilesUp = 7;
                    tilesRight = 7;
                }

                // Level boundary boxes
                if ((player.PositionX + PLAYER_WIDTH >= mapLoc_X + (tileWidth * tilesUp) ||
                    (player.PositionX + PLAYER_WIDTH >= mapLoc_X && (player.PositionY + PLAYER_HEIGHT >= mapLoc_Y + (tileHeight * tilesRight) ||
                                                                     player.PositionY <= mapLoc_Y))))
                {
                    return;
                }

                // Screen Boundary box
                if (player.PositionX + PLAYER_WIDTH == GraphicsDevice.Viewport.Width)
                {
                    return;
                }
                playerState = PlayerState.Right;
                player.PositionX += 2;
            }
        }

        // Handles collisions between player and map
        public void CalculateCollisions()
        {
            int result = 0;

            // Calculate collisions for level 1
            if (level == 1)
            {
                result = level1.CalculateCollisions(player);
            }
            // Calculate collisions for level 2
            else if (level == 2)
            {
                result = level2.CalculateCollisions(player);
            }

            switch (result)
            {
                // Normal tile is landed on, nothing needs to be done
                case 1:
                    break;

                // Give Buff tile is landed on
                case 2:
                    player.HasBuff = true;
                    break;

                // Buff Required tile is landed on
                case 3:
                    if (!player.HasBuff)
                    {
                        gameState = GameState.Gameover;
                    }
                    break;

                // Move tile is landed on
                case 4:
                    player.PositionX -= 50;
                    break;
                
                // Kill tile is landed on
                case 5:
                    gameState = GameState.Gameover;
                    break;
                
                // Win tile is landed on
                case 6:

                    // Change to level 2
                    if (level == 1)
                    {
                        level = 2;
                        // Reset player
                        player.rectangle = new Rectangle(100, 100, 25, 30);
                        break;
                    }

                    gameState = GameState.Win;
                    break;

                default:
                    break;
            }
        }
        
    }
}
