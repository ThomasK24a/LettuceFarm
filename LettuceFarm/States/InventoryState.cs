using LettuceFarm.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using LettuceFarm.Controls;
using System.Runtime.CompilerServices;

namespace LettuceFarm.States
{
	public class InventoryState : State
	{
		
		public List<IInventoryItem> Inventory;
		public List<ISeed> seeds;

		public ISeed selected = null;

		public int Coins;

		Texture2D lettuceSprite;
		Texture2D lettuceSeedSprite;

		Texture2D cornSprite;
		Texture2D cornSeedSprite;

		Texture2D wheatSprite;
		Texture2D wheatSeedSprite;

		Texture2D cowSprite;
		Texture2D chickenSprite;
		SpriteFont font;

		Button closeButton;



		public InventoryState(Global game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
		{
			Inventory = new List<IInventoryItem>();
			seeds = new List<ISeed>();
			this.Coins = 500;

            font = _content.Load<SpriteFont>("defaultFont");


			this.lettuceSprite = game.Content.Load<Texture2D>("Sprites/Lettuce-icon");
			this.lettuceSeedSprite = game.Content.Load<Texture2D>("seeds_lettuce");

			this.cornSprite = game.Content.Load<Texture2D>("Sprites/Corn");
			this.cornSeedSprite = game.Content.Load<Texture2D>("seeds_corn");

			this.wheatSprite = game.Content.Load<Texture2D>("Sprites/wheat");
			this.wheatSeedSprite = game.Content.Load<Texture2D>("seeds_wheat");

			this.cowSprite = game.Content.Load<Texture2D>("Sprites/Beef");
			this.chickenSprite = game.Content.Load<Texture2D>("Sprites/chicken_leg");


			CreateInventory();


            for (int i = 0; i < (int)Math.Ceiling(((float)Inventory.Count / 3)); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i * 3 + j < Inventory.Count)

                        GenerateSlot(new Vector2(j * 200 + 220, i * 110 + 10), Inventory[i * 3 + j], Inventory[i * 3 + j].GetCount());
                }
            }

            for (int i = 0 +1 ; i < seeds.Count + 1; i++)
            {
                GenerateSeedSlot(new Vector2(i * 200 + 20, 25 * +10), seeds[i-1], seeds[i-1].GetCount());
            }

            SpriteFont buttonFont = _content.Load<SpriteFont>("defaultFont");
			Texture2D closeButtonSprite = _content.Load<Texture2D>("CloseButton");
			closeButton = new Button(closeButtonSprite, buttonFont, new Vector2(700, 10), 1);
            closeButton.Click += CloseButton_Click;
			components.Add(closeButton);
			
		}

        private void CloseButton_Click(object sender, EventArgs e)
        {
			_global.ChangeState(_global.Game);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			spriteBatch.Draw(_content.Load<Texture2D>("storeBackground"), new Vector2(60, 0), Color.White);
			spriteBatch.DrawString(font, "Coins " + Coins,  new Vector2(80, 20), Color.White);
			foreach (Entity component in components)
			{
				component.Draw(gameTime, spriteBatch);
			}
			spriteBatch.End();
		}
		void CreateInventory()
        {
			Game.Crops.Wheat wheatItem = new Game.Crops.Wheat(wheatSprite, new Vector2(-100, -100));
			Game.Crops.Wheat wheatSeed = new Game.Crops.Wheat(wheatSeedSprite, new Vector2(-100, -100));

			Game.Crops.Lettuce lettuceItem = new Game.Crops.Lettuce(lettuceSprite, new Vector2(-100, -100));
			Game.Crops.Lettuce lettuceSeed = new Game.Crops.Lettuce(lettuceSeedSprite, new Vector2(-100, -100));

			Game.Crops.Corn cornItem = new Game.Crops.Corn(cornSprite, new Vector2(-100, -100));
			Game.Crops.Corn cornSeed = new Game.Crops.Corn(cornSeedSprite, new Vector2(-100, -100));

			Game.Livestocks.Cow cowItem = new Game.Livestocks.Cow(cowSprite, new Vector2(-100, -100));
			Game.Livestocks.Chicken chickenItem = new Game.Livestocks.Chicken(chickenSprite, new Vector2(-100, -100));

            Inventory.Add(wheatItem);
            Inventory.Add(lettuceItem);
            Inventory.Add(cornItem);



            Inventory.Add(cowItem);
            Inventory.Add(chickenItem);

            seeds.Add(wheatSeed);
			seeds.Add(lettuceSeed);
			seeds.Add(cornSeed);


		}
		private void GenerateSlot(Vector2 position, IInventoryItem  item, int count)
        {
			InventorySlot newSlot = new InventorySlot(_content, position, item, 1, 0.85f);
            components.Add(newSlot);
        }
		private void GenerateSeedSlot(Vector2 position, ISeed item, int count)
		{
			InventorySlot newSlot = new InventorySlot(_content, position, item, 1, 0.85f);

			components.Add(newSlot);
		}


		public override void PostUpdate(GameTime gameTime)
		{
		
			
		}

	
	}
}
