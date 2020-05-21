
using LettuceFarm.States;
using LettuceFarm.UI.Inventory;
using LettuceFarm.UI.Shop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace LettuceFarm
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        //Texture2D animals;
        //Shop shop;
        //GameMap map;
        //Inventory inventory;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private State currentState;

        private State nextState;

        public void ChangeState(State state)
        {
            nextState = state;
        }

        public Game()
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
            //inventory = new Inventory(this);
			
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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //map.Draw();

            currentState.Draw(gameTime, spriteBatch); 

            base.Draw(gameTime);
        }
    }
}
