using Microsoft.Xna.Framework.Graphics;

namespace LettuceFarm.Game
{
    public interface IInventoryItem
    {
        public abstract int GetPrice();

        public abstract int GetCount();

        public abstract Texture2D GetTexture();

        public abstract void SetCount();

        public abstract void SetPrice(int price);

        public abstract void Buy();

        public abstract string GetName();

        public abstract void Sell();

        public abstract int GetSellingPrice();
    }
}
