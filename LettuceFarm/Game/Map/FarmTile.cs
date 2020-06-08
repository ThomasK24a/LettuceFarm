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
    public class FarmTile : Entity, IInventoryItem
    {
        #region Fields

        private MouseState _currentMouse;

        private bool _isHovering;

        private MouseState _previousMouse;

        private int posX;

        private int posY;

        private int Price;

        private Crop plantedSeed;

        private ContentManager content;


        private string Name;
        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
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

            this.Price = 250;
            this.Name = "soil";

            this.content = content;

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var colour = Color.White;

            if (_isHovering)
                colour = Color.Gray;

           
            spriteBatch.Draw(Texture, Rectangle, colour);

            if (plantedSeed != null)
                plantedSeed.Draw(gameTime, spriteBatch);

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

            if (plantedSeed != null)
            {
                plantedSeed.Update(gameTime);
            }
                
        }

        public void addSeed(SeedItem seed)
        {
            if(seed.GetCount() > 0 && plantedSeed == null)
            {
                switch (seed.GetName())
                {
                    case "corn":
                        plantedSeed = new Corn(content, Position);
                        seed.Plant();
                        break;
                    case "lettuce":
                        plantedSeed = new Lettuce(content, Position);
                        seed.Plant();
                        break;
                    case "wheat":
                        plantedSeed = new Wheat(content, Position);
                        seed.Plant();
                        break;
                    default:
                        break;
                }
            }
        }

        public int GetPrice()
        {
            return this.Price;
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public Texture2D GetTexture()
        {
            return this.Texture;
        }

        public void SetCount()
        {
            //throw new NotImplementedException();
        }

        public void SetPrice(int price)
        {
            ///throw new NotImplementedException();
        }

        public void Buy()
        {
            //throw new NotImplementedException();
        }

        public string GetName()
        {
            return this.Name;
        }

        #endregion
    }
}

