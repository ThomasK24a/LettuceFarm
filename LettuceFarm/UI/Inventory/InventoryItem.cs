using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.UI.Forms;
using System;
using System.Collections.Generic;
using System.Text;


namespace LettuceFarm.UI.Inventory
{
    class InventoryItem : ControlManager
    {
        int count;
        Vector2 position;
        Texture2D itemSprite;
        FilledRectangle itemBackground;
        Game game;
         public InventoryItem(Game game, Vector2 position, Texture2D itemSprite, int itemCount) : base(game)
        {
            this.position = position;
            this.itemSprite = itemSprite;
            this.count = itemCount;
            this.game = game;

            //itemBackground = new FilledRectangle(20 + Convert.ToInt32(position.X), 20 + Convert.ToInt32(position.Y), 240, 175);
            //itemBackground.BackgroundColor = Color.Brown;
        }
        public override void InitializeComponent()
        {

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        
            Global._spriteBatch.Begin();
            Global._spriteBatch.Draw(itemSprite, position + new Vector2(40, 20), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Global._spriteBatch.End();
        }
    }
}
