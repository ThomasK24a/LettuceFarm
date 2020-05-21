using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.States
{
	class Inventory : State
	{
		private List<Entity> components;
		private ContentManager contentManager;

		public Inventory(Global game, GraphicsDevice graphicsDevice, ContentManager contentManager)
			: base(game, graphicsDevice, contentManager)
		{

		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			throw new NotImplementedException();
		}

		public override void PostUpdate(GameTime gameTime)
		{
			throw new NotImplementedException();
		}

		public override void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
		}
	}
}
