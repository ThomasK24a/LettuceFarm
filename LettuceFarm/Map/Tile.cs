using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Map
{
    internal class Tile : IGameComponent
    {
        Texture2D texture { get; set; }
        Vector2 position { get; set; }

        public Tile(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Initialize()
        {
            
        }

        public void Draw()
        {
            Global._spriteBatch.Begin();
            Global._spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Global._spriteBatch.End();
        }
    }
}
