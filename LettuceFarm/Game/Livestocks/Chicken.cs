﻿using LettuceFarm.GameEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Game.Livestocks
{
	class Chicken : Livestock
	{
		public Chicken(Texture2D texture, Vector2 position) : base(texture, position,300,0,"chicken")
		{

		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			throw new NotImplementedException();
		}


		public override void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
		}
	}
}
