using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace LettuceFarm
{
    public class Animation
    {
        private float _timer;

        public int CurrentFrame { get; set; }

        public int FrameCount { get; set; }

        public int FrameHeight { get { return Texture.Height; } }

        public float FrameSpeed { get; set; }

        public int FrameWidth { get { return Texture.Width / FrameCount; } }

        public bool IsActivateAnimator { get; set; }

        public Texture2D Texture { get; set; }

        public Vector2 Position { get; set; }

        public Animation(Texture2D texture, int frameCount)
        {
            this.Texture = texture;

            this.CurrentFrame = 0;

            this.FrameCount = frameCount;
            //If the framecount is higher than 1 it's automatically animated
            this.IsActivateAnimator = frameCount > 1;

            this.FrameSpeed = 0.2f;

            this._timer = 0f;
        }

        public void DrawAnimation(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, new Rectangle(CurrentFrame * FrameWidth, 0, FrameWidth, FrameHeight), Color.White);
        }

        public void Play(Animation animation)
        {
            this.Texture = animation.Texture;

            this.CurrentFrame = 0;

            this.FrameCount = animation.FrameCount;

            this.IsActivateAnimator = animation.IsActivateAnimator;

            this.FrameSpeed = animation.FrameSpeed;

            this._timer = 0f;
        }

        public void Stop()
        {
            IsActivateAnimator = false;
        }

        public void UpdateAnimation(GameTime gameTime)
        {
            if (IsActivateAnimator)
            {
                _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (_timer > FrameSpeed)
                {
                    _timer = 0f;

                    CurrentFrame++;

                    if (CurrentFrame >= FrameCount)
                        CurrentFrame = 0;
                }
            }
        }
    }
}

