using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.UI.Forms;
using System;
using System.Collections.Generic;
using System.Text;
namespace LettuceFarm.UI.Inventory
{
    public class Inventory
    {
        InventoryItem[] inventorySlots;
        InventoryItem[] seeds;
        
        public Inventory(Game game)
        {
            inventorySlots = new InventoryItem[5];
            seeds = new InventoryItem[3];
            
            Texture2D itemSprite = game.Content.Load<Texture2D>("Sprites/Box");
            Texture2D seedSprite = game.Content.Load<Texture2D>("Sprites/Box");
            
            inventorySlots[0] = new InventoryItem(game, new Vector2(150, 100), itemSprite, 10,false);
            inventorySlots[1] = new InventoryItem(game, new Vector2(250, 100), itemSprite, 10,false);
            inventorySlots[2] = new InventoryItem(game, new Vector2(350, 100), itemSprite, 10,false);
            inventorySlots[3] = new InventoryItem(game, new Vector2(450, 100), itemSprite, 10,false);
            inventorySlots[4] = new InventoryItem(game, new Vector2(550, 100), itemSprite, 10,false);

            seeds[0] = new InventoryItem(game, new Vector2(250,200), seedSprite, 0,true);
            seeds[1] = new InventoryItem(game, new Vector2(350,200), seedSprite, 0,true);
            seeds[2] = new InventoryItem(game, new Vector2(450,200), seedSprite, 0,true);

            void CheckTest(Game game)
            {
                int areaWidth;
                int areaHeight;
                var mouseState = Mouse.GetState();
                var mousePosition = new Point(mouseState.X, mouseState.Y);
                Rectangle area = new Rectangle();
                if (mouseState.LeftButton == ButtonState.Pressed)

                {
                    for (var i = 0; i < seeds.Length; i++)
                    {
                        areaWidth = (int) seeds[i].position.Y;

                        areaHeight = (int) seeds[i].position.X;

                        area = new Rectangle((int)areaHeight, (int)areaWidth, seeds[i].itemSprite.Height, seeds[i].itemSprite.Width);

                        if (area.Contains(mousePosition))
                        {
                            game.Exit();
                        }
                    }
                }

            }


            for (int i = 0; i < inventorySlots.Length; i++)
            {
                game.Components.Add(inventorySlots[i]);
                
            }
            for (int i = 0; i < seeds.Length; i++)
            {
                game.Components.Add(seeds[i]);

            }
        }
    }
}
