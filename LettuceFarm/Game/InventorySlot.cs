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

namespace LettuceFarm.Game
{
    class InventorySlot: Entity
    {
 
        IInventoryItem item;
        ISeed seeditem;
        Texture2D slotTexture;
        SpriteFont font;
        bool isSeed;
        Button selectButton;

        public InventorySlot(ContentManager content, Vector2 position, IInventoryItem item, int frameCount, float scale) : base(item.GetTexture(), position, 1)
        {
            this.position = position;
            this.item = item;
            this.scale = scale;
            this.isSeed = false;
         
            slotTexture = content.Load<Texture2D>("ItemSlot");
            font = content.Load<SpriteFont>("defaultFont");

        }
        public InventorySlot(ContentManager content, Vector2 position, ISeed seeditem, int frameCount, float scale) : base(seeditem.GetTexture(), position, 1)
        {
            this.position = position;
            this.seeditem = seeditem;
            this.scale = scale;
            this.isSeed = true;
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            slotTexture = content.Load<Texture2D>("ItemSlot");
            font = content.Load<SpriteFont>("defaultFont");

            var buttonFont = content.Load<SpriteFont>("defaultFont");

          selectButton = new Button(buttonTexture, buttonFont, this.position + new Vector2(-15,100), frameCount)
            {
                Text = "select"
            };
            selectButton.Click += SelectButton_Click;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            selectButton.Text = "selected";
            System.Console.WriteLine("selected");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(slotTexture, position + new Vector2(-15, -10), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            if (this.isSeed)
            {
                spriteBatch.Draw(slotTexture, position + new Vector2(-15, -10), null, Color.White, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 0f);

                spriteBatch.DrawString(font, "X " + seeditem.GetCount(), position + new Vector2(80, 55), Color.White);

               selectButton.Draw(gameTime, spriteBatch);
            }
            else
            {
                spriteBatch.DrawString(font, "X " + item.GetCount(), position + new Vector2(20, 55), Color.White);
            }

            spriteBatch.Draw(Texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);        
        }

        public override void Update(GameTime gameTime)
        {
            if (this.isSeed)
            {
                selectButton.Update(gameTime);

            }
        }
    }
}

