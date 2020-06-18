using LettuceFarm.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LettuceFarm.GameEntity
{
    public class SeedItem : Entity, IInventoryItem
    {
        int price;
        int count;
        string name;
        bool selected = false;

        public SeedItem(Texture2D texture, Vector2 position, int price, int count, string name) : base(texture, position, 1)
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

        public virtual bool BuyItem()
        {
            if (99 > GetPrice())
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
            this.count += 1;
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

        public void Plant()
        {
            if (this.count > 0)
            {
                this.count -= 1;
            }
        }

        public void Sell()
        {
            this.count -= 1;
        }

        public int GetSellingPrice()
        {
            throw new NotImplementedException();
        }
    }
}