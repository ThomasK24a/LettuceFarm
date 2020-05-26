using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
namespace LettuceFarm
{
    public class Animation
    {
        public int CurrentFrame { get; set; }

        public int FrameCount { get; private set; }

        public int FrameHeight { get { return Texture.Height; } }

        public float FrameSpeed { get; set; }

        public int FrameWidth { get { return Texture.Width / FrameCount; } }

        public bool IsActivateAnimator { get; set; }

        public Texture2D Texture { get; private set; }

        public Animation(Texture2D texture, int frameCount)
        {
            this.Texture = texture;

            this.CurrentFrame = 0;

            this.FrameCount = frameCount;

            this.IsActivateAnimator = true;

            this.FrameSpeed = 0.2f;
        }
    }
}
