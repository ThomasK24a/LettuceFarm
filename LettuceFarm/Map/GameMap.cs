using LettuceFarm.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm
{
    class GameMap
    {
        Tile[,] map;
        Texture2D grass;
        int width;
        int height;
        Game game;

        public GameMap(Game game, int width, int height)
        {
            this.game = game;
            grass = game.Content.Load<Texture2D>("Grass");
            this.width = width;
            this.height = height;
            map = new Tile[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    map[i, j] = new Tile(grass, new Vector2(i * 40, j * 40));
                    
                }
            }
        }

        public void InitializeComponent()
        {
            
        }

        public void Draw()
        {
            for (int i = 0; i < this.width; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    map[i, j].Draw();
                }
            }
        }
    }
}
