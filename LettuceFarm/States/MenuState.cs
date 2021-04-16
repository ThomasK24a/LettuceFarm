using LettuceFarm.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace LettuceFarm.States
{
    public class MenuState : State
    {
        Texture2D buttonTexture;
        SpriteFont buttonFont;
        Texture2D background;
        Song song;
        SoundEffect buttonSfx;
        SoundEffectInstance buttonSound;

        public MenuState(Global game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            buttonTexture = _content.Load<Texture2D>("Button");
            buttonFont = _content.Load<SpriteFont>("defaultFont");
            background = _content.Load<Texture2D>("MenuBackground");
            this.song = _content.Load<Song>("Sound/soundtrack");
            this.buttonSfx = content.Load<SoundEffect>("Sound/selectionClick");
            this.buttonSound = buttonSfx.CreateInstance();

            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);

            var newGameButton = new Button(buttonTexture, buttonFont, new Vector2(300, 200), 1)
            {
                Text = "Play Game",
            };

            newGameButton.Click += NewGameButton_Click;

            var settingsButton = new Button(buttonTexture, buttonFont, new Vector2(300, 250), 1)
            {
                Text = "Settings",
            };

            settingsButton.Click += SettingsButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont, new Vector2(300, 300), 1)
            {
                Text = "Quit Game",
            };

            quitGameButton.Click += QuitgameButton_Click;

            components = new List<Entity>()
            {
                newGameButton,
                settingsButton,
                quitGameButton,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 500), Color.White);

            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Implement an update if need arises later
        }

        private void QuitgameButton_Click(object sender, EventArgs e)
        {
            this.buttonSound.Play();
            _global.Exit();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            this.buttonSound.Play();
            _global.ChangeState(_global.setting);
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            this.buttonSound.Play();
            _global.ChangeState(_global.Game);
        }
    }
}
