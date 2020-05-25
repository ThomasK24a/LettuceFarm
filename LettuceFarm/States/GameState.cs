using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using LettuceFarm.GameEntity;
using LettuceFarm.Manager;

namespace LettuceFarm.States
{
	public class GameState : State
	{
		private ContentManager contentManager;
		private Player playerEntity;
		private List<ChickenSprite> _sprites;
		SpriteBatch spriteBatch;
		public GameState(Global game, GraphicsDevice graphicsDevice, ContentManager content)
			: base(game, graphicsDevice, content)
		{
			_sprites = new List<ChickenSprite>()
		{
		new ChickenSprite(new Dictionary<string, Animation>()
		{
		  { "WalkUp", new Animation(game.Content.Load<Texture2D>("Sprites/chicken_walk_up"), 4) },
		{ "WalkDown", new Animation(game.Content.Load<Texture2D>("Sprites/chicken_walk_down"), 4) },
		{ "WalkLeft", new Animation(game.Content.Load<Texture2D>("Sprites/chicken_walk_left"), 4) },
		{ "WalkRight", new Animation(game.Content.Load<Texture2D>("Sprites/chicken_walk_right"), 4) },
		})
		{
		  Position = new Vector2(100, 100),
		},
	  };
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
			foreach (var sprite in _sprites)
				sprite.Draw(spriteBatch);

			spriteBatch.End();
		}

		public override void PostUpdate(GameTime gameTime)
		{
		
		}

		public override void Update(GameTime gameTime)
		{
			foreach (var sprite in _sprites)
				sprite.Update(gameTime, _sprites);

			
		}
	}
}
