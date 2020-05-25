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
		private List<ChickenSprite> _sprites;
		Texture2D buttonTexture;
		SpriteFont buttonFont;
		public GameState(Global game, GraphicsDevice graphicsDevice, ContentManager content)
			: base(game, graphicsDevice, content)
		{
			 buttonTexture = _content.Load<Texture2D>("Button");
			 buttonFont = _content.Load<SpriteFont>("defaultFont");


			var menuButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(5, 435),
				Text = "Menu",
			};

			menuButton.Click += menuButton_Click;

			var inventoryButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(320, 435),
				Text = "Inventory",
			};

			inventoryButton.Click += inventoryButton_Click;

			var shopButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(635, 435),
				Text = "Shop",
			};

			shopButton.Click += shopButton_Click;

			components = new List<Entity>()
			{
				menuButton,
				inventoryButton,
				shopButton,
			};

			_sprites = new List<ChickenSprite>()
		{
		new ChickenSprite(new Dictionary<string, Animation>()
		{
			{ "WalkUp", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_up"), 4) },

			{ "WalkDown", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_down"), 4) },

			{ "WalkLeft", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_left"), 4) },

			{ "WalkRight", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_right"), 4) },

		})
		{
			Position = new Vector2(100, 100),
		},
			};
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			Texture2D grass = _content.Load<Texture2D>("Grass");
			//Texture2D buttonTexture = game.Content.Load<Texture2D>("Button");
			//SpriteFont buttonFont = game.Content.Load<SpriteFont>("defaultFont");
			spriteBatch.Begin();


			spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);
			//spriteBatch.Draw(buttonTexture, new Rectangle(0, 0, 60, 40), Color.White);
			//spriteBatch.Draw(buttonFont, new Rectangle(0, 0, 60, 40), Color.White);
			//spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);
			foreach (var sprite in _sprites)
				sprite.Draw(spriteBatch);

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

			foreach (var sprite in _sprites)
				sprite.Update(gameTime, _sprites);
		}

		private void shopButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(new ShopState(_global, _graphicsDevice, _content));
		}

		private void inventoryButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(new InventoryState(_global, _graphicsDevice, _content));
		}

		private void menuButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(new MenuState(_global, _graphicsDevice, _content));
		}
	}
}
