using LettuceFarm.GameEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.UI.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Map
{
	class FarmTile : Entity
	{

		private int tileHeight;
		private int tileWidth;
		private Texture2D texture;

		public FarmTile()
		{
			//hard code tile sizes here 
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Begin();
			//Here a single unit of a Farmtile is drawn

			spriteBatch.End();
		}

		public void plant(Crop crop)
		{
			throw new NotImplementedException();
		}

		public override void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
		}
	}
}
