﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using LettuceFarm.Controls;
using System.Collections.Generic;
using LettuceFarm.GameEntity;
using LettuceFarm.Game;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Sprites;
using LettuceFarm.Game.Livestocks;

namespace LettuceFarm.States
{
    public class GameState : State
    {
        Texture2D rainTexture;
        Texture2D buttonTexture;
        SpriteFont buttonFont;
        Texture2D farmTileTexture;
        InventoryState inventory;
        ShopState shop;
        private Weather weather;
        SeedItem selectedSeed = null;
        List<FarmTile> farmTiles;
        List<FarmTile> Tiles;
        MouseState mouseState;
        Texture2D slotTexture;
        Texture2D littleCow;
        Texture2D walkingCow;
        Texture2D littleChicken;
        Texture2D walkingChicken;
        List<Texture2D> chickenSprites;
        List<Texture2D> cowSprites;
        public int chickenCount;
        public int cowCount;
        SpriteFont font;
        public Clock clock;

        public GameState(Global game, GraphicsDevice graphicsDevice, ContentManager content, InventoryState inventory, MouseState mouseState, ShopState shop)
            : base(game, graphicsDevice, content)
        {
            this.chickenCount = 0;
            this.cowCount = 0;
            clock = new Clock(6f);
            font = _content.Load<SpriteFont>("defaultFont");

            this.chickenSprites = new List<Texture2D>();
            this.cowSprites = new List<Texture2D>();

            this.mouseState = mouseState;
            this.inventory = inventory;
            this.shop = shop;

            this.weather = new Weather();

            this.rainTexture = content.Load<Texture2D>("rain");
            this.buttonTexture = content.Load<Texture2D>("Button");
            buttonFont = content.Load<SpriteFont>("defaultFont");
            this.farmTileTexture = content.Load<Texture2D>("dirt");
            farmTiles = new List<FarmTile>();
            Tiles = new List<FarmTile>();
            slotTexture = content.Load<Texture2D>("ItemSlot");

            littleCow = content.Load<Texture2D>("cow");
            walkingCow = content.Load<Texture2D>("Sprites/cow_walk_right");
            littleChicken = content.Load<Texture2D>("chicken");
            walkingChicken = content.Load<Texture2D>("Sprites/chicken_walk_left");

            for (int i = 0; i < 9; i++)
            {
                farmTiles.Add(new FarmTile(farmTileTexture, new Vector2(-100, -100), 1, content, this));
                Tiles.Add(new FarmTile(farmTileTexture, new Vector2(-100, -100), 1, content, this));
            }


            for (int i = 0; i < (int)Math.Ceiling(((float)farmTiles.Count / 3)); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i * 3 + j < farmTiles.Count)
                    {
                        farmTiles[i * 3 + j].Position = new Vector2(j * 60, i * 55 + 40);
                        farmTiles[i * 3 + j].Click += farmTile_Click;
                    }
                }
            }


            for (int i = 0; i < 9; i++)
            {
                chickenSprites.Add(littleChicken);
                cowSprites.Add(littleCow);
            }


            var menuButton = new Button(buttonTexture, buttonFont, new Vector2(5, 435), 1)
            {
                Text = "Menu",
            };

            menuButton.Click += menuButton_Click;

            var inventoryButton = new Button(buttonTexture, buttonFont, new Vector2(320, 435), 1)
            {
                Text = "Inventory",
            };

            inventoryButton.Click += inventoryButton_Click;

            var shopButton = new Button(buttonTexture, buttonFont, new Vector2(635, 435), 1)
            {
                Text = "Shop",
            };

            shopButton.Click += shopButton_Click;

            components = new List<Entity>()
            {
                farmTiles[0],
                farmTiles[1],
                farmTiles[2],
                farmTiles[3],
                farmTiles[4],
                farmTiles[5],
                farmTiles[6],
                farmTiles[7],
                farmTiles[8],
                Tiles[0],
                Tiles[1],
                Tiles[2],
                Tiles[3],
                Tiles[4],
                Tiles[5],
                Tiles[6],
                Tiles[7],
                Tiles[8],
                menuButton,
                inventoryButton,
                shopButton,
            };

        }
        public void BuyLand()
        {
            for (int i = 0; i < (int)Math.Ceiling(((float)farmTiles.Count / 3)); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i * 3 + j < farmTiles.Count)
                    {
                        Tiles[i * 3 + j].Position = farmTiles[i * 3 + j].Position + new Vector2(0, 225);
                        Tiles[i * 3 + j].Click += farmTile_Click;
                    }
                }
            }
        }

        private void GameState_Click(object sender, EventArgs e)
        {
            if (selectedSeed != null)
                ((FarmTile)sender).addSeed(selectedSeed);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Texture2D grass = _content.Load<Texture2D>("Grass");
            int Temp = weather.randomSun();
            int Hum = weather.randomHumidity();
            int Sun = weather.randomSun();

            spriteBatch.Begin();

            spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), new Color(228, 228, 242));

            spriteBatch.DrawString(font, "Time: " + clock.TimeToString(), new Vector2(640, 15), Color.White);

            //day time
            if (clock.getTime() >= 12f)
            {
                spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);
                spriteBatch.DrawString(font, "Time: " + clock.TimeToString(), new Vector2(640, 15), Color.White);
            }

            //night time
            if (clock.getTime() >= 18f)
            {
                spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), new Color(50, 50, 125));
                spriteBatch.DrawString(font, "Time: " + clock.TimeToString(), new Vector2(640, 15), Color.White);
            }

            //reset to day time
            if (clock.getTime() >= 23f)
            {
                clock.setTime(6f);
            }

            spriteBatch.DrawString(font, "Temperature:" + Temp.ToString(), new Vector2(640, 35), Color.White);
            spriteBatch.DrawString(font, "Humidity:" + Hum.ToString(), new Vector2(640, 55), Color.White);
            spriteBatch.DrawString(font, "Sunshine:" + Sun.ToString(), new Vector2(640, 75), Color.White);

            spriteBatch.Draw(slotTexture, new Vector2(195, 15), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "X " + chickenCount, new Vector2(320, 15), Color.White);
            spriteBatch.DrawString(font, "X " + cowCount, new Vector2(320, 40), Color.White);
            if (this.selectedSeed != null)
                spriteBatch.Draw(selectedSeed.GetTexture(), new Vector2(200, 20), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);

            spriteBatch.Draw(littleChicken, new Vector2(280, 5), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);

            spriteBatch.Draw(littleCow, new Vector2(280, 30), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);


            var pos = new Vector2(200, 150);
            var _pos = new Vector2(500, 150);

            if (this.chickenCount > 0)
            {
                for (int i = 0; i < (int)Math.Ceiling(((float)chickenSprites.Count / 3)); i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i * 3 + j < chickenCount)
                        {
                            spriteBatch.Draw(chickenSprites[i * 3 + j], _pos + new Vector2(j * 90, i * 80 + 40), null, Color.White, 0f, Vector2.Zero, .45f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            if (this.cowCount > 0)
            {
                //for (int i = 0; i < this.cowCount; i++)
                //	spriteBatch.Draw(cowSprites[i], i * pos + new Vector2(185, 50), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                for (int i = 0; i < (int)Math.Ceiling(((float)cowSprites.Count / 3)); i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (i * 3 + j < cowCount)
                        {
                            spriteBatch.Draw(cowSprites[i * 3 + j], pos + new Vector2(j * 90, i * 80 + 40), null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }

            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);

            if (this.selectedSeed != null)
            {
                spriteBatch.Draw(selectedSeed.GetTexture(), new Vector2(Mouse.GetState().X, Mouse.GetState().Y), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0f);
            }
            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Implement an update if need arises later
        }

        void PrepareSeed()
        {
            foreach (SeedItem seeds in inventory.seeds)
            {
                if (seeds.IsSelected() == false)
                {
                    this.selectedSeed = null;
                }
            }

            foreach (SeedItem seeds in inventory.seeds)
            {
                if (seeds.IsSelected() && (seeds.GetCount() > 0))
                {
                    this.selectedSeed = seeds;
                }
            }
        }

        Vector2 chickenPosition;
        public void AddAnimal(LivestockItem animal)

        {

            if (animal.GetName() == "chicken")
            {
                for (int i = 0; i < 4; i++)
                    components.Add(new Chicken(walkingChicken, chickenPosition = new Vector2(i * 200, 195)));
            }

            if (animal.GetName() == "cow")
            {
                for (int i = 0; i < 4; i++)
                    // components.Add(new Cow(littleCow, new Vector2(200, 200)));
                    components.Add(new Cow(walkingCow, chickenPosition = new Vector2(i * 200, 185)));
            }


        }
        void MouseMethod()
        {
            if (Mouse.GetState().RightButton == ButtonState.Pressed && selectedSeed != null)
            {
                selectedSeed.Select(false);
                selectedSeed = null;
            }
        }


        public bool addCropToInventory(Crop crop)
        {
            for (int i = 0; i < inventory.Inventory.Count; i++)
            {
                if (crop.GetName() == inventory.Inventory[i].GetName())
                {
                    inventory.Inventory[i].SetCount();
                    return true;
                }
            }
            return false;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
            {
                component.Update(gameTime);
            }
           
            MouseMethod();
            PrepareSeed();


            int minChangTime = 10;
            int maxChangeTime = 100;
            int directionTimer;
            Random random = new Random();
            directionTimer = random.Next(minChangTime, maxChangeTime);
            int nextIndex = random.Next(0, 5);

            directionTimer -= gameTime.ElapsedGameTime.Milliseconds;
            if (directionTimer <= 0)
            {
                switch (nextIndex)
                {
                    case 1:
                        chickenPosition.X++;
                        break;
                    case 2:
                        chickenPosition.X--;
                        break;
                    case 3:
                        chickenPosition.X++;
                        break;
                    case 4:
                        chickenPosition.X--;
                        break;
                }
                switch (nextIndex)
                {
                    case 1:
                        chickenPosition.Y++;
                        break;
                    case 2:
                        chickenPosition.Y--;
                        break;
                    case 3:
                        chickenPosition.Y--;
                        break;
                    case 4:
                        chickenPosition.Y++;
                        break;
                }
            }

            clock.time += (float)gameTime.ElapsedGameTime.TotalMinutes;

            base.Update(gameTime);

        }

        private void shopButton_Click(object sender, EventArgs e)
        {
            _global.ChangeState(_global.shop);
        }

        private void inventoryButton_Click(object sender, EventArgs e)
        {
            _global.ChangeState(_global.inventory);
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            _global.ChangeState(_global.menu);
        }

        private void farmTile_Click(object sender, EventArgs e)
        {
            if (selectedSeed != null && ((FarmTile)sender).plantedSeed == null)
            {
                ((FarmTile)sender).addSeed(selectedSeed);
            }
            else if (((FarmTile)sender).plantedSeed != null)
            {
                ((FarmTile)sender).harvestCrop();
            }
        }
    }
}
