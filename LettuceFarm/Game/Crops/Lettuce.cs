using LettuceFarm.Controls;
using LettuceFarm.GameEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Game.Crops
{
	class Lettuce : Crop
	{
		public Lettuce(ContentManager content, Vector2 position, FarmTile farmTile) : base(content.Load<Texture2D>("lettuceCrop"), position, "lettuce", 5, 30, 50, farmTile)
		{

		}
	}
}
