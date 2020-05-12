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
        public Vector2 position;
        public Texture2D itemSprite;
        FilledRectangle itemBackground;
        bool isSeed;
        Button selectButton;

        Game game;
         public InventoryItem(Game game, Vector2 position, Texture2D itemSprite, int itemCount, bool isSeed) : base(game)
        {
            this.position = position;
            this.itemSprite = itemSprite;
            this.count = itemCount;
            this.game = game;
            this.isSeed = isSeed;
            selectButton = new Button()
            {
                Text = "Plant",
                Size = new Vector2(50, 30),
                BackgroundColor = Color.Green,
                Location = this.position + new Vector2(45, 100)
            };
            selectButton.Clicked += SelectButton_Clicked;

            itemBackground = new FilledRectangle(  Convert.ToInt32(position.X), Convert.ToInt32(position.Y), 125, 200);
            itemBackground.BackgroundColor = Color.BurlyWood;
        }

        private void SelectButton_Clicked(object sender, EventArgs e)
        {
            if(selectButton.Text == "Plant")
            {
                selectButton.Text = "Selected";

            }
            else if(selectButton.Text == "Selected")
            {
                selectButton.Text = "Plant";
            }
        }

        public override void InitializeComponent()
        {

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Controls.Add(itemBackground);

            if (this.isSeed)
            {
                Controls.Add(selectButton);
            }
            Global._spriteBatch.Begin();
            Global._spriteBatch.Draw(itemSprite, position + new Vector2(40, 20), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Global._spriteBatch.End();
        }
    }
}
