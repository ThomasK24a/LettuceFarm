using LettuceFarm.Game;
using LettuceFarm.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.GameEntity
{
	public abstract class Crop : Entity
	{
		string name;
		ContentManager content;

		public Crop(Texture2D texture, Vector2 position, string name, int frameCount) : base(texture, position, frameCount)
		{
			this.name = name;
			this.content = content;
			
		}

		public virtual Texture2D GetTexture()
		{
			return Texture;
		}

        public string GetName()
        {
			return this.name;
        }
    }
}
