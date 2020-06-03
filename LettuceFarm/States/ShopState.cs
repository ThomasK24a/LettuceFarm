using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LettuceFarm.Game;
using System;
using System.Collections.Generic;
using LettuceFarm.Controls;

namespace LettuceFarm.States
{
	public class ShopState : State
	{
		
		private List<IInventoryItem> invList;
		Texture2D placeholderSprite;
		Button closeButton;
        private InventoryState inventory;

        public ShopState(Global game, GraphicsDevice graphicsDevice, ContentManager contentManager, InventoryState inventory)
			: base(game, graphicsDevice, contentManager)
		{
			this.inventory = inventory;
			this.placeholderSprite = game.Content.Load<Texture2D>("Sprites/Lettuce-icon");

			invList = new List<IInventoryItem>();
			CreateInvList();

			for (int i = 0; i < (int)Math.Ceiling(((float)invList.Count / 3)); i++)
			{
				for(int j = 0; j < 3 ; j++)
				{
					if (i * 3 + j < invList.Count) 
					GenerateSlot(new Vector2(j * 250 + 65, i * 210 + 50), invList[i * 3 + j]);
				}
			}

			Texture2D closeButtonSprite = _content.Load<Texture2D>("CloseButton");
			var buttonFont = _content.Load<SpriteFont>("defaultFont");
			closeButton = new Button(closeButtonSprite, buttonFont, new Vector2(700, 20), 1);
			closeButton.Click += closeButton_Click;
			components.Add(closeButton);
		}


		public override void PostUpdate(GameTime gameTime)
		{
			//throw new NotImplementedException();
		}


		private void GenerateSlot(Vector2 position, IInventoryItem item)
		{
			ShopSlot newSlot = new ShopSlot(_content, position, item, 1, 1f, inventory);
			components.Add(newSlot);
		}

		public void CreateInvList()
		{
			Game.Crops.Wheat wheatItem = new Game.Crops.Wheat(placeholderSprite, new Vector2(-100, -100));
			Game.Crops.Lettuce lettuceItem = new Game.Crops.Lettuce(placeholderSprite, new Vector2(-100, -100));
			Game.Crops.Corn cornItem = new Game.Crops.Corn(placeholderSprite, new Vector2(-100, -100));
			invList.Add(wheatItem);
			invList.Add(lettuceItem);
			invList.Add(cornItem);

			Game.Livestocks.Cow cowItem = new Game.Livestocks.Cow(placeholderSprite, new Vector2(-100, -100));
			Game.Livestocks.Chicken chickenItem = new Game.Livestocks.Chicken(placeholderSprite, new Vector2(-100, -100));
			invList.Add(cowItem);
			invList.Add(chickenItem);

		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(new GameState(_global, _graphicsDevice, _content));
		}
	}
		
}
