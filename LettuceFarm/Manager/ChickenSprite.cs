using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace LettuceFarm.Manager
{
    public class ChickenSprite
    {
        #region Fields
        int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        Random myRandom = new Random();

        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        protected Vector2 _position;
        protected Texture2D _texture;

        #endregion

        #region Properties

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public float Speed = 1f;

        public Vector2 Velocity;

        #endregion

        #region Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
                spriteBatch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(spriteBatch);
            else throw new Exception("Error");
        }

        public virtual void Move()
        {
            _position.X = (screenWidth / 6);
            int x = (int)_position.X;
            Console.WriteLine("New " + x);
            //Console.WriteLine(_position.X);

            //int random = myRandom.Next(0, 1);

            //if (random == 0)
            //{

                Velocity.X = -1f;
                Velocity.X = 1f;

          //  }
            //if (random == 1)
            //{
            //    Velocity.X = 1f;
            //    Velocity.Y = 1f;
            //}

            // if (random == 1)
            // {
            //Velocity.X = 1f;
            //Velocity.X = -1f;
            //
            //}
            //}
        }


        protected virtual void SetAnimations()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else _animationManager.Stop();
        }

        public ChickenSprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public ChickenSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List<ChickenSprite> sprites)
        {
            Move();
            SetAnimations();
            _animationManager.Update(gameTime);

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        #endregion
    }
}
