using LettuceFarm.States;
using LettuceFarm.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;
using SharpDX.XAudio2;

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
        //Inventory inventory

        Song song;

        private State currentState;

        private State nextState;

        public List<IInventoryItem> itemList;

        public void ChangeState(State state)
        {
            nextState = state;
        }

        public Global()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            itemList = new List<IInventoryItem>();
            
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
            this.song = Content.Load<Song>("Sound/soundtrack");
            
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        public void onSong()
        {
            MediaPlayer.Play(song);
        }

        public void offSong()
        {
            MediaPlayer.Stop();
        }
        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.1f;
            MediaPlayer.Play(song);
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
            //map.Draw();

            currentState.Draw(gameTime, spriteBatch); 

            base.Draw(gameTime);
        }
    }
}
