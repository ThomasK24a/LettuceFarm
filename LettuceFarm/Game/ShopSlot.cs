using LettuceFarm.Controls;
using LettuceFarm.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace LettuceFarm.Game
{
    class ShopSlot : Entity
    {
        Button buyButton;
        IInventoryItem item;
        InventoryState inventory;
        ShopState shop;
        Texture2D slotTexture;
        Texture2D seedTexture;

        public ShopSlot(ContentManager content, Vector2 position, IInventoryItem item, int frameCount, float scale, InventoryState inv, ShopState shop) : base(item.GetTexture(), position, 1)
        {
            this.shop = shop;
            this.Position = position;
            this.item = item;
            this.scale = scale;
            this.inventory = inv;

            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            slotTexture = content.Load<Texture2D>("ItemSlot");
            seedTexture = content.Load<Texture2D>("seeds");

            var buttonFont = content.Load<SpriteFont>("defaultFont");

            buyButton = new Button(buttonTexture, buttonFont, this.Position + new Vector2(-35, 120), frameCount)
            {
                Text = "-" + this.item.GetPrice().ToString() + " coins"
            };
            buyButton.Click += BuyItem;
        }

        private void BuyItem(object sender, EventArgs e)
        {
            if (inventory.Coins >= this.item.GetPrice())
            {
                if (this.item.GetName() == "lettuce" || this.item.GetName() == "wheat" || this.item.GetName() == "corn")
                {
                    for (int i = 0; i < inventory.seeds.Count; i++)
                        if (this.item.GetName() == inventory.seeds[i].GetName() && inventory.Coins >= inventory.seeds[i].GetPrice())
                        {
                            inventory.seeds[i].SetCount();
                            inventory.Coins -= inventory.seeds[i].GetPrice();
                        }
                }
                else if (this.item.GetName() == "chicken")
                {
                    shop.addItem(item);
                    inventory.Coins -= item.GetPrice();
                }
                else if (this.item.GetName() == "cow")
                {
                    shop.addItem(item);
                    inventory.Coins -= item.GetPrice();
                }
                else if (this.item.GetName() == "farmslot" && this.item.GetCount() < 1)
                {
                    shop.PrepareLand(item);
                    this.item.SetCount();
                    this.buyButton.Text = "sold out!";
                    inventory.Coins -= this.item.GetPrice();
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(slotTexture, Position + new Vector2(-10, -11), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(item.GetTexture(), Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            buyButton.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            buyButton.Update(gameTime);
        }
    }
}
