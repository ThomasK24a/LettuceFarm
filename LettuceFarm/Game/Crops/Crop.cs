using LettuceFarm.Game;
using LettuceFarm.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.GameEntity
{
	public abstract class Crop : Entity
	{
		string name;

		public Crop(Texture2D texture, Vector2 position, string name, int frameCount) : base(texture, position, frameCount)
		{
			this.name = name;
			
		}

        public string GetName()
        {
			return this.name;
        }

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
			DrawAnimation(spriteBatch);
		}
	}
}
