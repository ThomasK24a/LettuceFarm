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
using System.Windows.Forms.VisualStyles;
using LettuceFarm.States;
using LettuceFarm.GameEntity;

namespace LettuceFarm.Game
{
    class InventorySlot: Entity
    { 
        IInventoryItem item;
        SeedItem seeditem;
        Texture2D slotTexture;
        Texture2D itemCount;
        SpriteFont font;
        bool isSeed;
        Button selectButton;     
        Button sellButton;
        InventoryState inventory;
        public InventorySlot(ContentManager content, Vector2 position, IInventoryItem item, float scale, InventoryState inventory) : base(item.GetTexture(), position, 1)
        {
           
            this.Position = position;
            this.item = item;
            this.scale = scale;
            this.isSeed = false;
            this.inventory = inventory;
            Texture2D buttonTexture = content.Load<Texture2D>("itemCount");
            slotTexture = content.Load<Texture2D>("ItemSlot");
            font = content.Load<SpriteFont>("defaultFont");
            itemCount = content.Load<Texture2D>("itemCount");
            var buttonFont = content.Load<SpriteFont>("defaultFont");

            sellButton = new Button(buttonTexture, buttonFont, this.Position + new Vector2(10, 100), 1)
            {
                Text = "sell"
            };
            sellButton.Click += SellButton_Click;
        }

        private void SellButton_Click(object sender, EventArgs e)
        {
            
            if(this.item.GetCount() > 0)
            {
                this.item.Sell();
                this.inventory.Coins += this.item.GetSellingPrice();
            }

            
        }

        public InventorySlot(ContentManager content, Vector2 position, SeedItem seeditem, float scale) : base(seeditem.GetTexture(), position, 1)
        {
            this.Position = position;
            this.seeditem = seeditem;
            this.scale = scale;
            this.isSeed = true;
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            slotTexture = content.Load<Texture2D>("ItemSlot");
            font = content.Load<SpriteFont>("defaultFont");
            itemCount = content.Load<Texture2D>("itemCount");

            var buttonFont = content.Load<SpriteFont>("defaultFont");

          selectButton = new Button(buttonTexture, buttonFont, this.Position + new Vector2(-30,120), 1)
            {
                Text = "select",
            };
            selectButton.Click += SelectButton_Click;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if(!this.seeditem.IsSelected())
            {
                
                this.seeditem.Select(true);
            }
            else
            {
               
                this.seeditem.Select(false);
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (this.isSeed)
            {
                spriteBatch.Draw(slotTexture, Position + new Vector2(-10, -11), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                spriteBatch.Draw(itemCount, Position + new Vector2(19, 80), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "x " + seeditem.GetCount(), Position + new Vector2(33, 90), Color.Black);
                selectButton.Draw(gameTime, spriteBatch);    
            }
            else
            {
                spriteBatch.Draw(slotTexture, Position + new Vector2(-10, -11), null, Color.White, 0f, Vector2.Zero, scale * 0.75f, SpriteEffects.None, 0f);
                spriteBatch.Draw(itemCount, Position + new Vector2(4, 50), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "x " + item.GetCount(), Position + new Vector2(18, 60), Color.Black);
                spriteBatch.Draw(Texture, Position + new Vector2(15, 5), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                sellButton.Draw(gameTime, spriteBatch);
            }           
        }

        public override void Update(GameTime gameTime)
        {
            if (seeditem != null && seeditem.IsSelected())
                selectButton.Text = "selected";
            else if(seeditem != null)
                selectButton.Text = "select";
           

            if (this.isSeed)
            {
                selectButton.Update(gameTime);
            }
            else
            {
                sellButton.Update(gameTime);

            }

        }
    }
}

