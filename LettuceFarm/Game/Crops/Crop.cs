﻿using LettuceFarm.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.GameEntity
{
	public abstract class Crop : Entity, ISeed, IInventoryItem
	{
		int price;
		int count;
		
		public Crop(Texture2D texture, Vector2 position, int price, int count) : base(texture, position, 1)
		{
			this.price = price;
			this.count = count;
		}

		public virtual int GetPrice()
		{
			//TODO: replace this
			return this.price;
		}

		public virtual int GetCount()
		{
			//TODO: replace for actual amount
			return this.count;
		}

		public virtual Texture2D GetTexture()
		{
			return Texture;
		}

        public void SetCount()
        {
			this.count +=1 ;
        }

        public void SetPrice(int price)
        {
			this.price = price;
        }
    }
}
