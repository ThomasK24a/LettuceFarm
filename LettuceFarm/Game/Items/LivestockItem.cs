using LettuceFarm.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm
{
	public class LivestockItem : Entity, IInventoryItem
	{
		int count;
		int price;
		string name;
		public LivestockItem(Texture2D texture, Vector2 position, int price, int count, string name) : base(texture, position, 1)
		{
			this.price = price;
			this.count = count;
			this.name = name;
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


        public void Buy()
        {
			SetCount();
        }

		public string GetName()
		{
			return this.name;
		}

    }
}
