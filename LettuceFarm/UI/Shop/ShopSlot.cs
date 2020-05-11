using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.UI.Forms;
using Microsoft.Xna.Framework;
using MonoGame.UI.Forms.Effects;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System.Security.AccessControl;

namespace LettuceFarm.UI.Shop
{
    class ShopSlot : ControlManager
    {
        Button buyButton;
        Vector2 position;
        FilledRectangle itemBackground;
        Texture2D itemSprite;
        int itemCost;
        Game game;

        public ShopSlot(Game game, Vector2 position, Texture2D itemSprite, int itemCost) : base(game)
        {
            this.position = position;
            this.itemSprite = itemSprite;
            this.itemCost = itemCost;
            this.game = game;

            buyButton = new Button()
            {
                Text = this.itemCost.ToString(),
                Size = new Vector2(100, 30),
                BackgroundColor = Color.Green,
                Location = this.position + new Vector2(90, 160)
            };
            
            buyButton.Clicked += buyItem;

            itemBackground = new FilledRectangle(20 + Convert.ToInt32(position.X), 20 + Convert.ToInt32(position.Y), 240, 175);
            itemBackground.BackgroundColor = Color.Brown;
            
        }

        private void buyItem(object sender, EventArgs e)
        {
            buyButton.Text = "Bought";
        }

        public override void InitializeComponent()
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            
            Controls.Add(itemBackground);
            Controls.Add(buyButton);

            Global._spriteBatch.Begin();
            Global._spriteBatch.Draw(itemSprite, position + new Vector2(40, 20), null, Color.White, 0f, Vector2.Zero, 0.2f, SpriteEffects.None, 0f);
            Global._spriteBatch.End();
        }
    }
}
