using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Game
{
	public interface IInventoryItem
	{
		public abstract int GetPrice();

		public abstract Texture2D GetTexture();
	}
}
