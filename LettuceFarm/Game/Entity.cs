using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm
{
	public abstract class Entity : Animation
	{
		public Vector2 position;
		public Color tintColor;
		public int spriteWidth;
		public int spriteHeight;

		public Entity(Texture2D texture, Vector2 position, int frameCount) : base(texture, frameCount)
		{
			this.position = position;
			this.tintColor = Color.White;
		}

		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			
			spriteBatch.Draw(Texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			
			spriteBatch.End();
		}

		public abstract void Update(GameTime gameTime);

	}
}
