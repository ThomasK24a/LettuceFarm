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

namespace LettuceFarm.Game
{
    class InventorySlot: Entity
    {
 
        IInventoryItem item;
        ISeed seeditem;
        Texture2D slotTexture;
        Texture2D itemCount;
        SpriteFont font;
        bool isSeed;
        Button selectButton;
        bool selected = false;

        public InventorySlot(ContentManager content, Vector2 position, IInventoryItem item, float scale) : base(item.GetTexture(), position, 1)
        {
            this.position = position;
            this.item = item;
            this.scale = scale;
            this.isSeed = false;
         
            slotTexture = content.Load<Texture2D>("ItemSlot");
            font = content.Load<SpriteFont>("defaultFont");
            itemCount = content.Load<Texture2D>("itemCount");

        }
        public InventorySlot(ContentManager content, Vector2 position, ISeed seeditem, float scale) : base(seeditem.GetTexture(), position, 1)
        {
            this.position = position;
            this.seeditem = seeditem;
            this.scale = scale;
            this.isSeed = true;
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            slotTexture = content.Load<Texture2D>("ItemSlot");
            font = content.Load<SpriteFont>("defaultFont");
            itemCount = content.Load<Texture2D>("itemCount");

            var buttonFont = content.Load<SpriteFont>("defaultFont");

          selectButton = new Button(buttonTexture, buttonFont, this.position + new Vector2(-30,120), 1)
            {
                Text = "select"
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
                spriteBatch.Draw(slotTexture, position + new Vector2(-10, -11), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                spriteBatch.Draw(itemCount, position + new Vector2(19, 80), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                spriteBatch.Draw(Texture, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "x " + seeditem.GetCount(), position + new Vector2(33, 90), Color.Black);
                selectButton.Draw(gameTime, spriteBatch);
                
            }
            else
            {
                spriteBatch.Draw(slotTexture, position + new Vector2(-10, -11), null, Color.White, 0f, Vector2.Zero, scale * 0.75f, SpriteEffects.None, 0f);
                spriteBatch.Draw(itemCount, position + new Vector2(4, 50), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                spriteBatch.DrawString(font, "x " + item.GetCount(), position + new Vector2(18, 60), Color.Black);
                spriteBatch.Draw(Texture, position + new Vector2(15, 5), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
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
        }
    }
}

