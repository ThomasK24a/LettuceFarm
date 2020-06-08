using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System.Security.AccessControl;
using LettuceFarm.Controls;
using Microsoft.Xna.Framework.Content;
using LettuceFarm.States;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Input;

namespace LettuceFarm.Game
{
    class ShopSlot : Entity
    {
        Button buyButton;
        IInventoryItem item;
        InventoryState inventory;
        Texture2D slotTexture;
        Texture2D seedTexture;

        public ShopSlot(ContentManager content, Vector2 position, IInventoryItem item, int frameCount, float scale, InventoryState inv) : base(item.GetTexture(), position, 1)
        {

         
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
            if (this.item.GetName() == "lettuce" || this.item.GetName() == "wheat" || this.item.GetName() == "corn")
            {
                for (int i = 0; i < inventory.seeds.Count; i++)
                    if (this.item.GetName() == inventory.seeds[i].GetName() && inventory.Coins >= inventory.seeds[i].GetPrice())
                    {
                        inventory.seeds[i].SetCount();
                        inventory.Coins -= inventory.seeds[i].GetPrice();
                    }
            }
            else if(inventory.Coins >= this.item.GetPrice() && this.item.GetCount() < 9 )
            {
                this.item.SetCount();
                inventory.Coins -= this.item.GetPrice();
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
