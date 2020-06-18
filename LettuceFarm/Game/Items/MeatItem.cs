using LettuceFarm.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LettuceFarm
{
    public class MeatItem : Entity, IInventoryItem
    {
        int count;
        int price;
        string name;
        int sellingPrice;

        public MeatItem(Texture2D texture, Vector2 position, int price, int count, string name, int sellingPrice) : base(texture, position, 1)
        {
            this.price = price;
            this.count = count;
            this.name = name;
            this.sellingPrice = sellingPrice;
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
            this.count += 1;
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

        public void Sell()
        {
            this.count -= 1;
        }

        public int GetSellingPrice()
        {
            return this.sellingPrice;
        }
    }
}