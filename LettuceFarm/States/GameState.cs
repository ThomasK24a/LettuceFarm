using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using LettuceFarm.Controls;
using System.Collections.Generic;
using LettuceFarm.Manager;
using LettuceFarm.GameEntity;
using LettuceFarm.Game;
using Microsoft.Xna.Framework.Input;

namespace LettuceFarm.States
{
	public class GameState : State
	{
		//private MapTile myMapTile = new MapTile(30, 30, 6, 6);
		//private List<ChickenSprite> _sprites;
		Texture2D buttonTexture;
		SpriteFont buttonFont;
		Texture2D farmTileTexture;
		InventoryState inventory;
		ISeed selectedSeed = null;
		public GameState(Global game, GraphicsDevice graphicsDevice, ContentManager content, InventoryState inventory)
			: base(game, graphicsDevice, content)
		{
			this.inventory = inventory;
			//seed = inventory.selected.GetTexture();
			this.buttonTexture = content.Load<Texture2D>("Button");
			buttonFont = content.Load<SpriteFont>("defaultFont");
			this.farmTileTexture = content.Load<Texture2D>("dirt");


			var farmTile01 = new FarmTile(farmTileTexture, new Vector2(10, 10), 1);
			var farmTile04 = new FarmTile(farmTileTexture, new Vector2(10, 70), 1);
			var farmTile05 = new FarmTile(farmTileTexture, new Vector2(10, 130), 1);
			var farmTile02 = new FarmTile(farmTileTexture, new Vector2(70, 10), 1);
			var farmTile06 = new FarmTile(farmTileTexture, new Vector2(70, 70), 1);
			var farmTile07 = new FarmTile(farmTileTexture, new Vector2(70, 130), 1);
			var farmTile03 = new FarmTile(farmTileTexture, new Vector2(130, 10), 1);
			var farmTile08 = new FarmTile(farmTileTexture, new Vector2(130, 70), 1);
			var farmTile09 = new FarmTile(farmTileTexture, new Vector2(130, 130), 1);

			//var farmTile06 = new FarmTile(farmTileTexture, new Vector2(10, 10), 1);
			//var farmTile07 = new FarmTile(farmTileTexture, new Vector2(10, 10), 1);

			var menuButton = new Button(buttonTexture, buttonFont, new Vector2(5, 435), 1)
			{
				Text = "Menu",
			};

			menuButton.Click += menuButton_Click;

			var inventoryButton = new Button(buttonTexture, buttonFont, new Vector2(320, 435), 1)
			{
				Text = "Inventory",
			};

			inventoryButton.Click += inventoryButton_Click;

			var shopButton = new Button(buttonTexture, buttonFont, new Vector2(635, 435), 1)
			{
				Text = "Shop",
			};

			shopButton.Click += shopButton_Click;

			components = new List<Entity>()
			{
				farmTile01,
				farmTile02,
				farmTile03,
				farmTile04,
				farmTile05,
				farmTile06,
				farmTile07,
				farmTile08,
				farmTile09,
				menuButton,
				inventoryButton,
				shopButton,
			};

			//_sprites = new List<ChickenSprite>()
			//{
			//	new ChickenSprite(new Dictionary<string, Animation>()
			//	{
			//		{ 
			//			"WalkUp", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_up"), 4) 
			//		},

			//		{ 
			//			"WalkDown", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_down"), 4) 
			//		},

			//		{ 
			//			"WalkLeft", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_left"), 4) 
			//		},

			//		{ 
			//			"WalkRight", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_right"), 4) 
			//		},

			//	})
			//	{
			//		Position = new Vector2(100, 100),
			//	},
			//};
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			
			Texture2D grass = _content.Load<Texture2D>("Grass");
			
			//Texture2D buttonTexture = game.Content.Load<Texture2D>("Button");	
			//SpriteFont buttonFont = game.Content.Load<SpriteFont>("defaultFont");

			spriteBatch.Begin();

			spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);
            

			//myMapTile.draw(spriteBatch);
			//foreach (var sprite in _sprites)
			//sprite.Draw(spriteBatch);

			foreach (var component in components)
			component.Draw(gameTime, spriteBatch);

			if (this.selectedSeed != null)
			{

				spriteBatch.Draw(selectedSeed.GetTexture(), new Vector2(Mouse.GetState().X, Mouse.GetState().Y), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);

			}

			spriteBatch.End();
		}

		public override void PostUpdate(GameTime gameTime)
		{
			//Implement an update if need arises later
		}

		public override void Update(GameTime gameTime)
		{
			if (Mouse.GetState().RightButton == ButtonState.Pressed && selectedSeed != null)
            {
				selectedSeed.Select(false);
				selectedSeed = null;
			}
				
            foreach (var component in components)
				component.Update(gameTime);

            foreach(ISeed seed in inventory.seeds)
            {
                if (seed.IsSelected())
                {
					this.selectedSeed = seed;

					if (seed.GetName() != selectedSeed.GetName() )
                    {
						seed.Select(false);
                    }
                }
            }

			//foreach (var sprite in _sprites)
			//	sprite.Update(gameTime, _sprites);
		}

		private void shopButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(_global.shop);
		}

		private void inventoryButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(_global.inventory);
		}

		private void menuButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(_global.menu);
		}

	}
}
