using LettuceFarm.States;
using LettuceFarm.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;

namespace LettuceFarm
{
    public class Global : Microsoft.Xna.Framework.Game
    {
        //Texture2D animals;
        //Shop shop;
        //GameMap map;
        //Inventory inventory;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public InventoryState inventory;
        public ShopState shop;
        public MenuState menu;
        public SettingState setting;
        public GameState Game;
        //Inventory inventory



        private State currentState;

        private State nextState;


        public void ChangeState(State state)
        {
            nextState = state;
        }

        public Global()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            
        }

        protected override void Initialize()
        {
            //Global._spriteBatch = new SpriteBatch(GraphicsDevice);
            //map = new GameMap(this, 20, 15);
            //shop = new Shop(this);
            //map.InitializeComponent();
            inventory = new InventoryState(this, graphics.GraphicsDevice, Content);
            shop = new ShopState(this, graphics.GraphicsDevice, Content, inventory);
            menu = new MenuState(this, graphics.GraphicsDevice, Content);
            setting = new SettingState(this, graphics.GraphicsDevice, Content);
            Game = new GameState(this, graphics.GraphicsDevice, Content);

            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            spriteBatch = new SpriteBatch(GraphicsDevice);

            currentState = new MenuState(this, graphics.GraphicsDevice, Content);
            

        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            if (nextState != null)
            {
                currentState = nextState;

                nextState = null;
            }

            currentState.Update(gameTime);

            currentState.PostUpdate(gameTime);

            base.Update(gameTime);
            // TODO: Add your update logic here
            //inventory.CheckTest(this);

        }

        protected override void Draw(GameTime gameTime)
        { 
            

            // TODO: Add your drawing code here

            currentState.Draw(gameTime, spriteBatch); 

            base.Draw(gameTime);
        }
    }
}
