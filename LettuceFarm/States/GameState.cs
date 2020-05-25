using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using LettuceFarm.Controls;
using System.Collections.Generic;
using LettuceFarm.Manager;

namespace LettuceFarm.States
{
	public class GameState : State
	{
		private List<Entity> components;
		private ContentManager contentManager;
		private List<ChickenSprite> _sprites;
		Texture2D buttonTexture;
		SpriteFont buttonFont;
		public GameState(Global game, GraphicsDevice graphicsDevice, ContentManager contentManager)
			: base(game, graphicsDevice, contentManager)
		{
			 buttonTexture = game.Content.Load<Texture2D>("Button");
			 buttonFont = game.Content.Load<SpriteFont>("defaultFont");


			var menuButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(0, 500),
				Text = "Menu",
			};

			menuButton.Click += menuButton_Click;

			var inventoryButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(400, 500),
				Text = "Inventory",
			};

			inventoryButton.Click += inventoryButton_Click;

			var shopButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(800, 500),
				Text = "Shop",
			};

			shopButton.Click += shopButton_Click;

			components = new List<Entity>()
			{
				menuButton,
				inventoryButton,
				shopButton,
			};

		//	_sprites = new List<ChickenSprite>()
		//{
		//new ChickenSprite(new Dictionary<string, Animation>()
		//{
		//	{ "WalkUp", new Animation(game.Content.Load<Texture2D>("Sprites/chicken_walk_up"), 4) },

		//	{ "WalkDown", new Animation(game.Content.Load<Texture2D>("Sprites/chicken_walk_down"), 4) },

		//	{ "WalkLeft", new Animation(game.Content.Load<Texture2D>("Sprites/chicken_walk_left"), 4) },

		//	{ "WalkRight", new Animation(game.Content.Load<Texture2D>("Sprites/chicken_walk_right"), 4) },

		//})
		//{
		//	Position = new Vector2(100, 100),
		//},
		//	};
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			Texture2D grass = game.Content.Load<Texture2D>("Grass");
			//Texture2D buttonTexture = game.Content.Load<Texture2D>("Button");
			//SpriteFont buttonFont = game.Content.Load<SpriteFont>("defaultFont");
			spriteBatch.Begin();


			spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);
			spriteBatch.Draw(buttonTexture, new Rectangle(0, 0, 60, 40), Color.White);
			spriteBatch.Draw(buttonFont, new Rectangle(0, 0, 60, 40), Color.White);
			//spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);
			//foreach (var sprite in _sprites)
			//	sprite.Draw(spriteBatch);

			foreach (var component in components)
				component.Draw(gameTime, spriteBatch);

			spriteBatch.End();
		}

		public override void PostUpdate(GameTime gameTime)
		{
			//Implement an update if need arises later
		}

		public override void Update(GameTime gameTime)
		{
			foreach (var component in components)
				component.Update(gameTime);

			//foreach (var sprite in _sprites)
			//	sprite.Update(gameTime, _sprites);
		}

		private void shopButton_Click(object sender, EventArgs e)
		{
			game.ChangeState(new ShopState(game, graphicsDevice, contentManager));
		}

		private void inventoryButton_Click(object sender, EventArgs e)
		{
			game.ChangeState(new InventoryState(game, graphicsDevice, contentManager));
		}

		private void menuButton_Click(object sender, EventArgs e)
		{
			game.ChangeState(new MenuState(game, graphicsDevice, contentManager));
		}
	}
}
