using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.UI.Forms;
using System;
using System.Collections.Generic;
using System.Text;
namespace LettuceFarm.UI.Inventory
{
    class Inventory
    {
        InventoryItem[] inventorySlots;

        public Inventory(Game game)
        {
            inventorySlots = new InventoryItem[5];
            Texture2D placeholderSprite = game.Content.Load<Texture2D>("Sprites/Box");

            inventorySlots[0] = new InventoryItem(game, new Vector2(0, 40), placeholderSprite, 10);
            inventorySlots[1] = new InventoryItem(game, new Vector2(0, 60), placeholderSprite, 10);
            inventorySlots[2] = new InventoryItem(game, new Vector2(0, 80), placeholderSprite, 10);
            inventorySlots[3] = new InventoryItem(game, new Vector2(0, 100), placeholderSprite, 10);
            inventorySlots[4] = new InventoryItem(game, new Vector2(0, 120), placeholderSprite, 10);

            for (int i = 0; i < inventorySlots.Length; i++)
            {
                game.Components.Add(inventorySlots[i]);
            }
        }
    }
}
