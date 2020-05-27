using LettuceFarm.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm
{
	public abstract class Livestock : Entity, IInventoryItem, IMeat
	{
		public Livestock(Texture2D texture, Vector2 position) : base(texture, position, 1)
		{

		}

		public virtual int GetPrice()
		{
			//TODO: replace this
			return 5;
		}
		public virtual int GetCount()
		{
			return 10;
		}

		public virtual Texture2D GetTexture()
		{
			return Texture;
		}
	}
}
