using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LettuceFarm.States
{
    public abstract class State
    {

        #region Fields
        protected List<Entity> components;

        protected ContentManager _content;


        protected Global _global;

        protected GraphicsDevice _graphicsDevice;
        #endregion

        #region Methods

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].flaggedForDeletion)
                {
                    components.RemoveAt(i);
                }
                components[i].Update(gameTime);
            }
            spriteBatch.End();
        }

        public abstract void PostUpdate(GameTime gameTime);

        public State(Global game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _global = game;

            _graphicsDevice = graphicsDevice;

            _content = content;

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
