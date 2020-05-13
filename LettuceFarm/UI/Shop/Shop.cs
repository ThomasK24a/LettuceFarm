using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.UI.Shop
{
    
    class Shop
    {
        ShopSlot[] buyTab;
        ShopSlot[] sellTab;

        public Shop(Game game)
        {
            buyTab = new ShopSlot[6];
            sellTab = new ShopSlot[5];
            Texture2D placeholderSprite = game.Content.Load<Texture2D>("Sprites/Lettuce");
            buyTab[0] = new ShopSlot(game, new Vector2(0, 40), placeholderSprite, 10);
            buyTab[1] = new ShopSlot(game, new Vector2(250, 40), placeholderSprite, 20);
            buyTab[2] = new ShopSlot(game, new Vector2(500, 40), placeholderSprite, 30);
            buyTab[3] = new ShopSlot(game, new Vector2(0, 225), placeholderSprite, 50);
            buyTab[4] = new ShopSlot(game, new Vector2(250, 225), placeholderSprite, 100);
            buyTab[5] = new ShopSlot(game, new Vector2(500, 225), placeholderSprite, 1000);

            //for (int i = 0; i < buyTab.Length; i++)
            //{
            //    game.Components.Add(buyTab[i]);
            //}

            sellTab[0] = new ShopSlot(game, new Vector2(0, 40), placeholderSprite, 10);
            sellTab[1] = new ShopSlot(game, new Vector2(250, 40), placeholderSprite, 20);
            sellTab[2] = new ShopSlot(game, new Vector2(500, 40), placeholderSprite, 30);
            sellTab[3] = new ShopSlot(game, new Vector2(0, 225), placeholderSprite, 50);
            sellTab[4] = new ShopSlot(game, new Vector2(250, 225), placeholderSprite, 200);

            //for (int i = 0; i < sellTab.Length; i++)
            //{
            //    game.Components.Add(sellTab[i]);
            //}
        }
    }
}
