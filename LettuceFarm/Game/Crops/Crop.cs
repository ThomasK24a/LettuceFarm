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
		//string name;
		int price;
		int count;
		string name;
		bool selected = false;
		public Crop(Texture2D texture, Vector2 position, int price, int count,string name) : base(texture, position, 1)
		{
			this.price = price;
			this.count = count;
			this.name = name;
			
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

		public virtual bool BuyItem()
		{
			if(99 /*replace with currency in inv*/ > GetPrice())
            {
				
				return true;
            }
            else
            {
				return false;
			}
			
		}

	
        public void SetCount()
        {
			this.count +=1 ;
        }

        public void SetPrice(int price)
        {
			this.price = price;
        }

        public void Buy()
        {
			
        }

        public string GetName()
        {
			return this.name;
        }
		public bool IsSelected()
        {
			return this.selected;
        }

		public void Select(bool select)
        {
			this.selected = select;
        }

    }
}
