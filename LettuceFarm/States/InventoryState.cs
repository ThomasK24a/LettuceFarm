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
	class InventoryState : State
	{
		
		List<IInventoryItem> Inventory;
		Texture2D itemSprite;
		Button closeButton;

		public InventoryState(Global game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
		{
			Inventory = new List<IInventoryItem>();

		
			this.itemSprite = game.Content.Load<Texture2D>("Sprites/Lettuce");

			CreateInventory();

			for (int i = 0; i < (int)Math.Ceiling(((float)Inventory.Count / 3)); i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (i * 3 + j < Inventory.Count)
						GenerateSlot(new Vector2(j * 200 + 200, i * 100 + 10), Inventory[i * 3 + j], Inventory[i * 3 + j].GetCount());
				}
			}

			SpriteFont buttonFont = _content.Load<SpriteFont>("defaultFont");
			Texture2D closeButtonSprite = _content.Load<Texture2D>("CloseButton");
			closeButton = new Button(closeButtonSprite, buttonFont, new Vector2(700, 0), 1);
            closeButton.Click += CloseButton_Click;
			components.Add(closeButton);
		
		}

        private void CloseButton_Click(object sender, EventArgs e)
        {
			_global.ChangeState(new GameState(_global, _graphicsDevice, _content));
		}

        void CreateInventory()
        {
			Game.Crops.Wheat wheatItem = new Game.Crops.Wheat(itemSprite, new Vector2(-100, -100));
			Game.Crops.Wheat wheatSeed = new Game.Crops.Wheat(itemSprite, new Vector2(-100, -100));

			Game.Crops.Lettuce lettuceItem = new Game.Crops.Lettuce(itemSprite, new Vector2(-100, -100));
			Game.Crops.Lettuce lettuceSeed = new Game.Crops.Lettuce(itemSprite, new Vector2(-100, -100));

			Game.Crops.Corn cornItem = new Game.Crops.Corn(itemSprite, new Vector2(-100, -100));
			Game.Crops.Corn cornSeed = new Game.Crops.Corn(itemSprite, new Vector2(-100, -100));
			
			Inventory.Add(wheatItem);
			Inventory.Add(wheatSeed);

			Inventory.Add(lettuceItem);
			Inventory.Add(lettuceSeed);

			Inventory.Add(cornItem);
			Inventory.Add(cornSeed);

			Game.Livestocks.Cow cowItem = new Game.Livestocks.Cow(itemSprite, new Vector2(-100, -100));
			Game.Livestocks.Chicken chickenItem = new Game.Livestocks.Chicken(itemSprite, new Vector2(-100, -100));

			Inventory.Add(cowItem);
			Inventory.Add(chickenItem);

		}
        private void GenerateSlot(Vector2 position, IInventoryItem item, int count)
        {
            InventorySlot newSlot = new InventorySlot(_content, position, item, 1, 0.45f, item.GetCount());

            components.Add(newSlot);
        }

        public override void PostUpdate(GameTime gameTime)
		{
			
		}

		public override void Update(GameTime gameTime)
		{
			closeButton.Update(gameTime);
		}
	}
}
