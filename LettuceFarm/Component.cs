﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Setting
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);


        public abstract void Update(GameTime gameTime);
    }
}
