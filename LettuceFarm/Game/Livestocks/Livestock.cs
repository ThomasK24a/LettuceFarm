using LettuceFarm.Game;
using LettuceFarm.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Game.Livestocks
{
    public abstract class Livestock : Entity
    {
        string name;

        public Livestock(Texture2D texture, Vector2 position, string name, int frameCount) : base(texture, position, frameCount)
        {
            this.name = name;

        }

        public string GetName()
        {
            return this.name;
        }
    }
}
