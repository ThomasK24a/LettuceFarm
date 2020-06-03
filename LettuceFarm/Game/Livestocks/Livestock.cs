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
		int count;
		int price;
		public Livestock(Texture2D texture, Vector2 position) : base(texture, position, 1)
		{

		}

		public virtual int GetPrice()
		{
			
			return this.price;
		}
		public virtual int GetCount()
		{
			return this.count;
		}

		public virtual Texture2D GetTexture()
		{
			return Texture;
		}

        public void SetCount()
        {
			this.count += 1 ;
        }

        public void SetPrice(int price)
        {
			this.price = price;
        }

        public bool BuyItem()
        {
            throw new NotImplementedException();
        }
    }
}
