using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiskOfPain.Engine
{
    class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Tile[] Tiles { get; set; }

        public List<Entity> Entities { get; set; }

        public Player Player { get; set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;

            Tiles = new Tile[Width * Height];

            Entities = new List<Entity>(10);

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Tiles[x + y * Width].Color = (x + y) % 2 == 0 ? Color.Black : Color.White;
                }
            }

            for (int i = 20; i < 40; i++)
            {
                Tiles[i + 18 * Width].Color = Color.Blue;
            }
            

            Player = new Player();
            Player.Position = new Vector2(10 * Tile.Size + Tile.Size / 2, 4 * Tile.Size + Tile.Size / 2);
            Entities.Add(Player);

            Enemy e = new Enemy();
            e.Position = new Vector2(5 * Tile.Size + Tile.Size / 2, 4 * Tile.Size + Tile.Size / 2);
            Entities.Add(e);
        }

        public Tile GetTile(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                return Tiles[0];
            }
            return Tiles[x + y * Width];
        }

        public void Update(float elapsed)
        {
            foreach (Entity e in Entities)
            {
                e.Update(elapsed);
                if (e.CollisionBox.Intersects(Player.CollisionBox))
                {
                    Player.OnCollide(e);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    spriteBatch.Draw(Util.Texture, new Rectangle(x * Tile.Size, y * Tile.Size, Tile.Size, Tile.Size), GetTile(x, y).Color);
                }
            }

            foreach (Entity e in Entities)
            {
                e.Draw(spriteBatch);
            }
        }
    }
}
