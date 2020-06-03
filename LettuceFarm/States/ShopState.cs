using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LettuceFarm.Game;
using System;
using System.Collections.Generic;
using LettuceFarm.Controls;

namespace LettuceFarm.States
{
	class ShopState : State
	{
		
		private List<IInventoryItem> invList;
		Texture2D placeholderSprite;
		Button closeButton;

		public ShopState(Global game, GraphicsDevice graphicsDevice, ContentManager contentManager)
			: base(game, graphicsDevice, contentManager)
		{
			this.placeholderSprite = game.Content.Load<Texture2D>("lettuce");


			invList = new List<IInventoryItem>();
			CreateInvList();

			for (int i = 0; i < (int)Math.Ceiling(((float)invList.Count / 3)); i++)
			{
				for(int j = 0; j < 3 ; j++)
				{
					if (i * 3 + j < invList.Count) 
					GenerateSlot(new Vector2(j * 250 + 105, i * 210 + 50), invList[i * 3 + j]);
				}
			}

			Texture2D closeButtonSprite = _content.Load<Texture2D>("CloseButton");
			var buttonFont = _content.Load<SpriteFont>("defaultFont");
			closeButton = new Button(closeButtonSprite, buttonFont, new Vector2(700, 20), 1);
			closeButton.Click += closeButton_Click;
			components.Add(closeButton);
		}

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
			spriteBatch.Begin();
			spriteBatch.Draw(_content.Load<Texture2D>("storeBackground"), new Vector2(25,20), Color.White);
			foreach (Entity component in components)
			{
				component.Draw(gameTime, spriteBatch);
			}
			spriteBatch.End();
		}


        public override void PostUpdate(GameTime gameTime)
		{
			//throw new NotImplementedException();
		}


		private void GenerateSlot(Vector2 position, IInventoryItem item)
		{
			ShopSlot newSlot = new ShopSlot(_content, position, item, 1, 1f);
			components.Add(newSlot);
		}

		public void CreateInvList()
		{
			Game.Crops.Wheat wheatSeeds = new Game.Crops.Wheat(_content.Load<Texture2D>("seeds_wheat"), new Vector2(-100, -100));
			Game.Crops.Lettuce lettuceSeeds = new Game.Crops.Lettuce(_content.Load<Texture2D>("seeds_lettuce"), new Vector2(-100, -100));
			Game.Crops.Corn cornSeeds = new Game.Crops.Corn(_content.Load<Texture2D>("seeds_corn"), new Vector2(-100, -100));
			invList.Add(wheatSeeds);
			invList.Add(lettuceSeeds);
			invList.Add(cornSeeds);

			Game.Livestocks.Cow cowItem = new Game.Livestocks.Cow(_content.Load<Texture2D>("cow"), new Vector2(-100, -100));
			Game.Livestocks.Chicken chickenItem = new Game.Livestocks.Chicken(_content.Load<Texture2D>("chicken"), new Vector2(-100, -100));
			invList.Add(cowItem);
			invList.Add(chickenItem);

		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(new GameState(_global, _graphicsDevice, _content));
		}
	}
		
}
