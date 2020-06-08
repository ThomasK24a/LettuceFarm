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
		List<Texture2D> chickenSprites;
		List<Texture2D> cowSprites;

		Texture2D buttonTexture;
		SpriteFont buttonFont;
		Texture2D farmTileTexture;
		InventoryState inventory;
		ShopState shop;
		ISeed selectedSeed = null;
		List<FarmTile> farmTiles;
		MouseState mouseState;
		Texture2D slotTexture;
		Texture2D littleCow;
		Texture2D littleChicken;
		public int chickenCount;
		public int cowCount;
		SpriteFont font;

		public GameState(Global game, GraphicsDevice graphicsDevice, ContentManager content, InventoryState inventory, MouseState mouseState, ShopState shop)
			: base(game, graphicsDevice, content)
		{
			this.chickenCount = 0;
			this.cowCount = 0;
			font = _content.Load<SpriteFont>("defaultFont");
			this.chickenSprites = new List<Texture2D>();
			this.mouseState = mouseState;
			this.inventory = inventory;
			this.shop = shop;
			this.buttonTexture = content.Load<Texture2D>("Button");
			buttonFont = content.Load<SpriteFont>("defaultFont");
			this.farmTileTexture = content.Load<Texture2D>("dirt");
			farmTiles = new List<FarmTile>();
			slotTexture = content.Load<Texture2D>("ItemSlot");

			littleCow = content.Load<Texture2D>("cow");
			littleChicken = content.Load<Texture2D>("chicken");

			for (int i = 0; i < 9; i++)
				farmTiles.Add(new FarmTile(farmTileTexture, new Vector2(-100, -100), 1));

			for (int i = 0; i < (int)Math.Ceiling(((float)farmTiles.Count / 3)); i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (i * 3 + j < farmTiles.Count)
                    {
						farmTiles[i * 3 + j].position = new Vector2(j * 60, i * 55 + 40);
						farmTiles[i * 3 + j].Click += farmTile_Click;
					}
						
					
				}
			}

			for(int i = 0; i<9; i++)
            {
				chickenSprites.Add(littleChicken);
				//cowSprites.Add(littleCow);
            }
			

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



			farmTiles[0],
			farmTiles[1],
			farmTiles[2],
			farmTiles[3],
			farmTiles[4],	
			farmTiles[5],
			farmTiles[6],	
			farmTiles[7],
            farmTiles[8],

			menuButton,
				inventoryButton,
				shopButton,

			};

            //_sprites = new List<ChickenSprite>()
            //{
            //    new ChickenSprite(new Dictionary<string, Animation>()
            //    {
            //        {
            //            "WalkUp", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_up"), 4)
            //        },

            //            {
            //                "WalkDown", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_down"), 4)
            //            },

            //            {
            //                "WalkLeft", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_left"), 4)
            //            },

            //            {
            //                "WalkRight", new Animation(_content.Load<Texture2D>("Sprites/chicken_walk_right"), 4)
            //            },

            //        })
            //        {
            //            Position = new Vector2(100, 100),
            //        },
            //    };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			
			Texture2D grass = _content.Load<Texture2D>("Grass");
			

			spriteBatch.Begin();

			spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);

			spriteBatch.Draw(slotTexture, new Vector2(195, 15), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
			spriteBatch.DrawString(font, "X " + chickenCount, new Vector2(320, 15), Color.White);
			spriteBatch.DrawString(font, "X " + cowCount, new Vector2(320, 40), Color.White);
			if (this.selectedSeed != null) 
				spriteBatch.Draw(selectedSeed.GetTexture(), new Vector2(200, 20), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
				
			spriteBatch.Draw(littleChicken, new Vector2(280, 5), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
			
			spriteBatch.Draw(littleCow, new Vector2(280, 30), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
			var pos = new Vector2(150,100);

            if (this.chickenCount > 0) 


            {
				 for(int i = 0; i < this.chickenCount; i++)
				spriteBatch.Draw(chickenSprites[i], i * pos + new Vector2(80, 50), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

			}
			if (this.cowCount > 0)


			{
				for (int i = 0; i < this.chickenCount; i++)
					spriteBatch.Draw(cowSprites[i], i * pos + new Vector2(180, 50), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

			}

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
		void PrepareSeed()
		{
			foreach (ISeed seeds in inventory.seeds)
            {
				if (seeds.IsSelected() == false)
                {
					this.selectedSeed = null;
				}
					
			}
				
			foreach (ISeed seeds in inventory.seeds)
            {
				if (seeds.IsSelected() && (seeds.GetCount() > 0))
				{
					this.selectedSeed = seeds;
				}
			}

		}

		void PrepareLiveStock()
        {
			foreach (IInventoryItem liveStock in shop.invList)
            {
				if (liveStock.GetName() == "chicken")
			
					this.chickenCount = liveStock.GetCount();
				if (liveStock.GetName() == "cow")

					this.cowCount = liveStock.GetCount();
				
			}
            
				

		}

		void MouseMethod()
		{
			if (Mouse.GetState().RightButton == ButtonState.Pressed && selectedSeed != null)
			{
				selectedSeed.Select(false);
				selectedSeed = null;
			}
		}
	
		public override void Update(GameTime gameTime)
		{
			
			
			foreach (var component in components)
            {
				component.Update(gameTime);
			}
			MouseMethod();
			PrepareSeed();
			PrepareLiveStock();
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

		private void farmTile_Click(object sender, EventArgs e)
        {
			if(selectedSeed != null)
				((FarmTile) sender).addSeed(selectedSeed);
        }
	}
}
