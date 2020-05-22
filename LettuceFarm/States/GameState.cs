using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using LettuceFarm.GameEntity;

namespace LettuceFarm.States
{
	public class GameState : State
	{
		private ContentManager contentManager;
		private Player playerEntity;

		public GameState(Global game, GraphicsDevice graphicsDevice, ContentManager content)
			: base(game, graphicsDevice, content)
		{
		}
		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			Texture2D grass = game.Content.Load<Texture2D>("Grass");

			spriteBatch.Begin();
			
			/*
			Set the entire background to Green to represent non growing land then add 
			Farm tiles to the rest of the map on top of the green background like below.
			Where (f) represents farm tile amd (m) green background

			fffmfffmmmmmmm
			fffmfffmmmmmmm
			fffmfffmmmmmmm
			mmmmmmmmmmmmmm
			mmmmmmmmmmmmmm
			mmmmmmmmmmmmmm
			*/

			spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);
			spriteBatch.End();
		}

		public override void PostUpdate(GameTime gameTime)
		{

		}

		public override void Update(GameTime gameTime)
		{

		}
	}
}
