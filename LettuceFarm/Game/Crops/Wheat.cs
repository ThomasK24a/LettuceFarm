using LettuceFarm.Controls;
using LettuceFarm.GameEntity;
using LettuceFarm.States;
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
		public Wheat(ContentManager content, Vector2 position, FarmTile farmTile, GameState game) : base(content.Load<Texture2D>("wheatCrop"), position, "wheat", 5, 50, 70, farmTile, game, 10, 30, 50, 90)
		{

		}
	}
}
