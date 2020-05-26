using LettuceFarm.GameEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Game.Crops
{
	class Corn : Crop
	{
		public Corn(Texture2D texture, Vector2 position) : base(texture, position)
		{

		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			throw new NotImplementedException();
		}



		public override void Update(GameTime gameTime)
		{
			//throw new NotImplementedException();
		}
	}
}
