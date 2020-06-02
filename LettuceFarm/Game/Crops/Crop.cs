using LettuceFarm.Game;
using LettuceFarm.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.GameEntity
{
	public abstract class Crop : Entity, ISeed, IInventoryItem
	{
		
		public Crop(Texture2D texture, Vector2 position) : base(texture, position, 1)
		{

		}

		public virtual int GetPrice()
		{
			//TODO: replace this
			return 5;
		}

		public virtual int GetCount()
		{
			//TODO: replace for actual amount
			return 10;
		}

		public virtual Texture2D GetTexture()
		{
			return Texture;
		}

		public virtual bool BuyItem()
		{
			if(99 /*replace with currency in inv*/ > GetPrice())
            {
				//currency =- GetPrice();
				//inventory.addItem(this); (make inventory add this item to it
				return true;
            }
            else
            {
				return false;
			}
			
		}

	}
}
