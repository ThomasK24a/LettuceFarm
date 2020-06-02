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
    class InventorySlot: Entity
    {
 
        IInventoryItem item;
        Texture2D slotTexture;
        SpriteFont font;
        int itemCount;


        public InventorySlot(ContentManager content, Vector2 position, IInventoryItem item, int frameCount, float scale, int itemCount) : base(item.GetTexture(), position, 1)
        {
            this.position = position;
            this.item = item;
            this.scale = scale;
            this.itemCount = item.GetCount();
            Texture2D buttonTexture = content.Load<Texture2D>("Button");
            slotTexture = content.Load<Texture2D>("ItemSlot");
            font = content.Load<SpriteFont>("defaultFont");

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(slotTexture, position + new Vector2(-10, -11), null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "X " + itemCount, position + new Vector2(20, 55), Color.White);

            spriteBatch.Draw(Texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

        
        }

        public override void Update(GameTime gameTime)
        {
          
        }
    }
}

