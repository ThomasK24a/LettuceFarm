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
            this.position = position;
            this.item = item;
            this.scale = scale;
            this.inventory = inv;
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            slotTexture = content.Load<Texture2D>("ItemSlot");
            seedTexture = content.Load<Texture2D>("seeds");

            var buttonFont = content.Load<SpriteFont>("defaultFont");

            buyButton = new Button(buttonTexture, buttonFont, this.position + new Vector2(-35, 120), frameCount)
            {
                Text = "-" + this.item.GetPrice().ToString() + " coins"
            };
            
            buyButton.Click += BuyItem;

            //itemBackground = new FilledRectangle(20 + Convert.ToInt32(position.X), 20 + Convert.ToInt32(position.Y), 240, 175);
            //itemBackground.BackgroundColor = Color.Brown;
            
        }

        private void BuyItem(object sender, EventArgs e)
        {
            buyButton.Text = "Bought";
            inventory.seeds[0].SetCount();
        }

      

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { 
            spriteBatch.Draw(slotTexture, position + new Vector2(-10, -11), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.Draw(item.GetTexture(), position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
      
            buyButton.Draw(gameTime, spriteBatch);
            
        }

        public override void Update(GameTime gameTime)
        {
            buyButton.Update(gameTime);
        }
    }
}
