using LettuceFarm.GameEntity;
using LettuceFarm.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm
{
	class MapTile : Entity, ITile
	{
		private int tileHeight;
		private int tileWidth;
		private Texture2D texture;

		public MapTile()
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
