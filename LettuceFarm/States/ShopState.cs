using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LettuceFarm.Game;
using System;
using System.Collections.Generic;


namespace LettuceFarm.States
{
	class ShopState : State
	{
		
		private List<IInventoryItem> invList;
		Texture2D placeholderSprite;

		public ShopState(Global game, GraphicsDevice graphicsDevice, ContentManager contentManager)
			: base(game, graphicsDevice, contentManager)
		{
			this.placeholderSprite = game.Content.Load<Texture2D>("Sprites/Lettuce");

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
		}


		public override void PostUpdate(GameTime gameTime)
		{
			//throw new NotImplementedException();
		}


		private void GenerateSlot(Vector2 position, IInventoryItem item)
		{
			ShopSlot newSlot = new ShopSlot(content, position, item, 1);
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
	}
		
}
