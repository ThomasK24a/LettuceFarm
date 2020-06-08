using LettuceFarm.Game;
using LettuceFarm.Game.Crops;
using LettuceFarm.GameEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Controls
{
    public class FarmTile : Entity
    {
        #region Fields

        private MouseState _currentMouse;

        private bool _isHovering;

        private MouseState _previousMouse;

        private int posX;

        private int posY;

        private Crop plantedSeed;

        private ContentManager content;

        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
            }
        }
        public Vector2 Size { get; internal set; }
        public Color BackgroundColor { get; internal set; }
        public Vector2 Location { get; internal set; }

        #endregion

        #region Methods

        public FarmTile(Texture2D texture, Vector2 position, int frameCount, ContentManager content) : base(texture, position, frameCount)
        {
            PenColour = Color.Black;
            this.content = content;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (_isHovering)
                colour = Color.Gray;

           
            spriteBatch.Draw(Texture, Rectangle, colour);

            if (plantedSeed != null)
                spriteBatch.Draw(plantedSeed.GetTexture(), Rectangle, colour);

        }
        void Hover()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());

                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            Hover();

        }

        public void addSeed(SeedItem seed)
        {
            switch (seed.GetName())
            {
                case "corn":
                    plantedSeed = new Corn(content, position);
                    break;
                case "lettuce":
                    plantedSeed = new Lettuce(content, position);
                    break;
                case "wheat":
                    plantedSeed = new Wheat(content, position);
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}

