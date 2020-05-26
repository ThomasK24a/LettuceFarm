using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.States
{
    public abstract class State
    {
        #region Fields
        protected List<Entity> components;

        protected ContentManager content;

        protected GraphicsDevice graphicsDevice;

        protected Global game;

        #endregion


        #region Methods

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Entity component in components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        public abstract void PostUpdate(GameTime gameTime);

        public State(Global game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.game = game;

            this.graphicsDevice = graphicsDevice;

            this.content = content;

            this.components = new List<Entity>();
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (Entity component in components)
            {
                component.Update(gameTime);
            }
        }
        #endregion
    }
}
