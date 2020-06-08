using LettuceFarm.GameEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Game.Crops
{
	class Wheat : Crop
	{
		public Wheat(ContentManager content, Vector2 position) : base(content.Load<Texture2D>("lettuceCrop"), position, "wheat", 5)
		{

		}
	}
}
