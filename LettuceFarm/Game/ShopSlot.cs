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

namespace LettuceFarm.Game
{
    class ShopSlot : Entity
    {
        Button buyButton;
        IInventoryItem item;
        Texture2D slotTexture;

        public ShopSlot(ContentManager content, Vector2 position, IInventoryItem item, int frameCount) : base(item.GetTexture(), position, 1)
        {
            this.position = position;
            this.item = item;

            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            slotTexture = content.Load<Texture2D>("ItemSlot");

            var buttonFont = content.Load<SpriteFont>("defaultFont");

            buyButton = new Button(buttonTexture, buttonFont, this.position + new Vector2(15, 140), frameCount)
            {
                Text = this.item.GetPrice().ToString()
            };
            
            buyButton.Click += BuyItem;

            //itemBackground = new FilledRectangle(20 + Convert.ToInt32(position.X), 20 + Convert.ToInt32(position.Y), 240, 175);
            //itemBackground.BackgroundColor = Color.Brown;
            
        }

        private void BuyItem(object sender, EventArgs e)
        {
            buyButton.Text = "Bought";
        }

      

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        { 

            spriteBatch.Begin();
            spriteBatch.Draw(slotTexture, position + new Vector2(0, -25), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(Texture, position, null, Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(buyButton.textures[currentFrame], buyButton.Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            buyButton.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            
        }

        public override void Update(GameTime gameTime)
        {
            buyButton.Update(gameTime);
        }
    }
}
