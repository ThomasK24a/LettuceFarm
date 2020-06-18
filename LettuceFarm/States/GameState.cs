using Microsoft.Xna.Framework;
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
using System.Numerics;
using SharpDX.MediaFoundation;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace LettuceFarm.States
{
    public class GameState : State
    {
        Texture2D rainTexture;
        Texture2D buttonTexture;
        SpriteFont buttonFont;
        Texture2D farm2;
        Texture2D farmTileTexture;
        InventoryState inventory;
        ShopState shop;
        Weather weather;
        SeedItem selectedSeed = null;
        List<FarmTile> farmTiles;
        List<FarmTile> Tiles;
        MouseState mouseState;
        Texture2D slotTexture;
        Texture2D littleCow;
        Texture2D walkingCow;
        Texture2D littleChicken;
        Texture2D walkingChicken;
        Texture deadChicken;

        List<Texture2D> chickenSprites;
        List<Texture2D> cowSprites;
        public int chickenCount;
        public int cowCount;
        SpriteFont font;
        Random random = new Random();

        public int currTemp;
        public int currHum;
        public int currSun;
        TimeSpan timeTillNextWeatherUpdate;


        public GameState(Global game, GraphicsDevice graphicsDevice, ContentManager content, InventoryState inventory, MouseState mouseState, ShopState shop)
            : base(game, graphicsDevice, content)
        {
            this.chickenCount = 0;
            this.cowCount = 0;
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
            farm2 = content.Load<Texture2D>("Sprites/dirt2");
            farmTiles = new List<FarmTile>();
            Tiles = new List<FarmTile>();
            slotTexture = content.Load<Texture2D>("ItemSlot");

            //animal sprites
            littleCow = content.Load<Texture2D>("cow");
            walkingCow = content.Load<Texture2D>("Sprites/cow_walk_right");
            littleChicken = content.Load<Texture2D>("chicken");
            walkingChicken = content.Load<Texture2D>("Sprites/chicken_walk_left");
            deadChicken = content.Load<Texture2D>("Sprites/deadChicken");

            this.currHum = 0;
            this.currSun = 0;
            this.currTemp = 0;
            this.timeTillNextWeatherUpdate = new TimeSpan(0, 0, 10);
            
            var farmTile01 = new FarmTile(farm2, new Vector2(400, 100), 1, content, this);//fencetile
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
                farmTile01,//fencetile
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
                        Tiles[i * 3 + j].Position = farmTiles[i * 3 + j].Position + new Vector2(0, 200);
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


            spriteBatch.Begin();

            spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), Color.White);
            DateTime dateTime = DateTime.Now;
            string time = dateTime.ToString("h:mm tt");
            spriteBatch.DrawString(font, "Time: " + time, new Vector2(640, 15), Color.White);

            if (dayAndNight() == true)
            {
                //nightTime
                spriteBatch.Draw(grass, new Rectangle(0, 0, 800, 500), new Color(50, 50, 125));
                spriteBatch.DrawString(font, "Time: " + time, new Vector2(640, 15), Color.White);
            }


            spriteBatch.DrawString(font, "Temperature:" + currTemp.ToString(), new Vector2(640, 35), Color.White);
            spriteBatch.DrawString(font, "Humidity:" + currHum.ToString(), new Vector2(640, 55), Color.White);
            spriteBatch.DrawString(font, "Sunshine:" + currSun.ToString(), new Vector2(640, 75), Color.White);


            spriteBatch.Draw(slotTexture, new Vector2(195, 15), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "X " + chickenCount, new Vector2(320, 15), Color.White);
            spriteBatch.DrawString(font, "X " + cowCount, new Vector2(320, 40), Color.White);
            if (this.selectedSeed != null)
                spriteBatch.Draw(selectedSeed.GetTexture(), new Vector2(200, 20), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);

            spriteBatch.Draw(littleChicken, new Vector2(280, 5), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);

            spriteBatch.Draw(littleCow, new Vector2(280, 30), null, Color.White, 0f, Vector2.Zero, .5f, SpriteEffects.None, 0f);


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

        public bool dayAndNight()
        {
            DateTime dateTime = DateTime.Now;
            TimeSpan endDayTime = new TimeSpan(19, 0, 0);
            TimeSpan startDayTime = new TimeSpan(06, 0, 0);

            TimeSpan now = dateTime.TimeOfDay;
            if (endDayTime < startDayTime)
                return endDayTime <= now && now <= startDayTime;

            return !(startDayTime < now && now < endDayTime);
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

        //add animals to game when you buy them
        public void AddAnimal(LivestockItem animal)
        {
            int i = 1;
            if (animal.GetName() == "chicken")
            {
                Chicken chick = new Chicken(walkingChicken, new Vector2(500, 220));
                components.Add(chick);
                chick.Click += Livestock_Click;
                i++;
                chickenCount++;
            }

            if (animal.GetName() == "cow")
            {

                Cow cow = new Cow(walkingCow, new Vector2(420, 200));
                components.Add(cow);
                cow.Click += Livestock_Click;
                i++;
                cowCount += 1;
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

        //TODO: add Method for Addint meat ot inventory

        public override void Update(GameTime gameTime)
        {
            updateWeather(gameTime);


            for(int i = 0; i < components.Count; i++)
            {
                components[i].Update(gameTime);
                if (components[i].flaggedForDeletion)
                {
                    components.RemoveAt(i);
                }
                
            }

            MouseMethod();
            PrepareSeed();

            //animal's movement
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].Texture == walkingChicken || components[i].Texture == walkingCow)
                {
                    int minChangTime = 10;
                    int maxChangeTime = 500;
                    int directionTimer;

                    directionTimer = random.Next(minChangTime, maxChangeTime);
                    int nextIndex = random.Next(0, 5);
                    int nextSpeed = random.Next(0, 6);
                    directionTimer -= gameTime.ElapsedGameTime.Milliseconds;

                    int maxX = 540;
                    int minX = 262;
                        
                    int maxY = 265;
                    int minY =  65;

                    Vector2 Pos = components[i].Position;

                    if (directionTimer <= 0)
                    {
                        switch (nextIndex)
                        {
                            case 1:
                                Pos.X += nextSpeed;
                                break;
                            case 2:
                                Pos.X -= nextSpeed;
                                break;
                            case 3:
                                Pos.X += nextSpeed;
                                break;
                            case 4:
                                Pos.X -= nextSpeed;
                                break;
                        }
                        switch (nextIndex)
                        {
                            case 1:
                                Pos.Y += nextSpeed;
                                break;
                            case 2:
                                Pos.Y -= nextSpeed;
                                break;
                            case 3:
                                Pos.Y -= nextSpeed;
                                break;
                            case 4:
                                Pos.Y += nextSpeed;
                                break;
                        }
                        components[i].Position = Pos;
                    }

                    // Check for bounds
                    if (Pos.X > maxX)
                    {
                        Pos.X = -2;
                    }

                    else if (Pos.X < minX)
                    {
                        Pos.X = +2;
                    }

                    if (Pos.Y > maxY)
                    {
                        Pos.Y = -2;
                    }

                    else if (Pos.Y < minY)
                    {
                        Pos.Y = +2;
                    }
                }

                base.Update(gameTime);
            }
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

        //event clicker for crops
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

        //event clicker for harvesting animals
        private void Livestock_Click(object sender, EventArgs e)
        {
            if (((Livestock)sender).GetName() == "cow")
            {
                this.cowCount -= 1;
                for (int i = 0; i < inventory.Inventory.Count; i++)
                {
                    if ("cow" == inventory.Inventory[i].GetName())
                    {
                        inventory.Inventory[i].SetCount();
                    }
                }
                ((Entity)sender).flaggedForDeletion = true;


            }
            else if (((Livestock)sender).GetName() == "chicken")
            {
                this.chickenCount -= 1;
                for (int i = 0; i < inventory.Inventory.Count; i++)
                {
                    if ("chicken" == inventory.Inventory[i].GetName())
                    {
                        inventory.Inventory[i].SetCount();
                    }
                }
                ((Entity)sender).Texture = (Texture2D)deadChicken;
                ((Entity)sender).flaggedForDeletion = true;
            }
        }

        private void updateWeather(GameTime gameTime)
        {
            this.timeTillNextWeatherUpdate = timeTillNextWeatherUpdate - gameTime.ElapsedGameTime;

            if (this.timeTillNextWeatherUpdate < TimeSpan.Zero)
            {
                currTemp = weather.randomSun();
                currHum = weather.randomHumidity();
                currSun = weather.randomSun();
                this.timeTillNextWeatherUpdate = new TimeSpan(0, 0, 10);
            }
        }
    }
}
