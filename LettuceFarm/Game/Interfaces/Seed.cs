using LettuceFarm.GameEntity;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LettuceFarm.Game
{
	public interface ISeed
	{
		public abstract int GetPrice();

		public abstract int GetCount();

		public abstract Texture2D GetTexture();

		public abstract void SetCount();

		public abstract void SetPrice(int price);

		public abstract void Buy();

		public abstract string GetName();
		public bool IsSelected();

		public void Select(bool select);

	}
}
