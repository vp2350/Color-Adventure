using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace Milestone_2_Project
{
    class Map
    {
        // Default map size is 7x7 tiles
        Tile[,] gameMap;
        int[,] tileType;

        // Defines where the top left of the first tile will be and the size of each tile
        Vector2 mapLocation;
        int tileWidth;
        int tileHeight;

        // Readable
        public Tile[,] GameMap
        {
            get
            {
                return gameMap;
            }
        }


        public Map(Vector2 mapLocation, int tileWidth, int tileHeight)
        {
            gameMap = new Tile[7, 7];
            this.mapLocation = mapLocation;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
        }


        // Reads the int values from the data file to use to determine tile type
        public void ReadMap(String mapName)
        {
            tileType = new int[7, 7];

            FileStream filestream = new FileStream("../../../../Resources/Levels/" + mapName, FileMode.Open, FileAccess.Read);

            BinaryReader reader = new BinaryReader(filestream);

            // Read data from file.
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    int current = reader.ReadInt32();
                    tileType[y,x] = current;
                }
            }

            reader.Close();
            filestream.Close();
        }


        // Uses tileType array to populate the gameMap with tiles and adds textures to the tiles in the map
        public void PopulateGameMap(Texture2D normalTile, Texture2D killTile, Texture2D buffTile, Texture2D buffReqTile, Texture2D moveTile, Texture2D winTile)
        {
            // Do not perform method unless a map has been read.
            if (tileType == null)
            {
                return;
            }

            int current = 0;
            Rectangle lastRectangle = new Rectangle((int)mapLocation.X, (int)mapLocation.Y, tileWidth, tileHeight);

            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    // Get the tile type at current index
                    current = tileType[x, y];

                    // Create new tile object depending on 
                    switch (current)
                    {
                        case 1:
                            gameMap[x, y] = new TileNormal(lastRectangle);
                            gameMap[x, y].Sprite = normalTile;
                            break;
                        case 2:
                            gameMap[x, y] = new TileKill(lastRectangle);
                            gameMap[x, y].Sprite = killTile;
                            break;
                        case 3:
                            gameMap[x, y] = new TileBuff(lastRectangle);
                            gameMap[x, y].Sprite = buffTile;
                            break;
                        case 4:
                            gameMap[x, y] = new TileBuffReq(lastRectangle);
                            gameMap[x, y].Sprite = buffReqTile;
                            break;
                        case 5:
                            gameMap[x, y] = new TileMove(lastRectangle);
                            gameMap[x, y].Sprite = moveTile;
                            break;
                        case 6:
                            gameMap[x, y] = new TileWin(lastRectangle);
                            gameMap[x, y].Sprite = winTile;
                            break;
                        default:
                            // If the number is 0, the tile is meant to be blank, so, no tile will be put here.
                            break;

                    }

                    // Move next rectangle right
                    lastRectangle = new Rectangle(lastRectangle.X + lastRectangle.Width, lastRectangle.Y, tileWidth, tileHeight);
                }

                // Move next rectangle down and back underneath beginning of last row
                lastRectangle = new Rectangle((int)mapLocation.X, lastRectangle.Y + lastRectangle.Height, tileWidth, tileHeight);
            }
        }

        // Loops through each tile in the map and draws it.
        public void DrawMap(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in gameMap)
            {
                if (tile != null)
                {
                    spriteBatch.Draw(tile.Sprite, tile.rectangle, Color.White);
                }
            }
        }

        // Returns an integer depending on the type of tile that is being colided with
        public int CalculateCollisions(Player player)
        {

            foreach (Tile tile in gameMap)
            {
                // Normal tile, returns 1
                if (tile is TileNormal)
                {
                    if (tile.CheckCollision(player))
                    {
                        return 1;
                    }
                }

                // Give Buff tile, returns 2
                else if (tile is TileBuff)
                {
                    if (tile.CheckCollision(player))
                    {
                        return 2;
                    }
                }

                // Buff Required tile, returns 3
                else if (tile is TileBuffReq)
                {
                    if (tile.CheckCollision(player))
                    {
                        return 3;
                    }
                }

                // Move tile, returns 4
                else if (tile is TileMove)
                {
                    if (tile.CheckCollision(player))
                    {
                        return 4;
                    }
                }

                // Kill tile, returns 5
                else if (tile is TileKill)
                {
                    if (tile.CheckCollision(player))
                    {
                        return 5;
                    }
                }

                // Win tile, returns 6
                else if (tile is TileWin)
                {
                    if (tile.CheckCollision(player))
                    {
                        return 6;
                    }
                }
            }

            return 0;
        }
    }
}
