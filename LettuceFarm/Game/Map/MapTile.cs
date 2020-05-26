using LettuceFarm.GameEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended;

namespace LettuceFarm
{
	class MapTile
	{
		private int tileWidth;
		private int tileHeight;
		private int width;
		private int height;
		private Texture2D texture;

		public MapTile(int pTileHeight, int pTileWidth, int pWidth, int pHeight)
		{
			//hard code tile sizes here
			tileWidth = pTileWidth;
			tileHeight = pTileHeight;
			width = pWidth;
			height = pHeight;
		}

		public void draw(SpriteBatch spriteBatch)
		{
			Vector2 tilePosition = Vector2.Zero;

			//spriteBatch.Begin();
			for (int x = 0; x < width; x++)
			{
				for(int y= 0; y<height; y++)
				{
					spriteBatch.FillRectangle(tilePosition, new Size2(tileWidth, tileHeight), Color.Transparent);
					spriteBatch.FillRectangle(tilePosition + new Vector2(1,1), new Size2(tileWidth -2, tileHeight-2), Color.Black);
					tilePosition.Y += tileHeight;

				}
				tilePosition.Y = 0;
				tilePosition.X += tileWidth;
			}
			//spriteBatch.End();
		}
	}

}
