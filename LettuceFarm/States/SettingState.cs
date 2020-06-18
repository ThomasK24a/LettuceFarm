﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using LettuceFarm.Controls;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace LettuceFarm.States
{
	public class SettingState: State
	{
		Texture2D buttonTexture;
		SpriteFont buttonFont;
		Texture2D background;

		public SettingState(Global game, GraphicsDevice graphicsDevice, ContentManager content)
			: base(game, graphicsDevice, content)
		{
			buttonTexture = _content.Load<Texture2D>("Button");
			buttonFont = _content.Load<SpriteFont>("defaultFont");
			background = _content.Load<Texture2D>("MenuBackground");

			var newGameButton = new Button(buttonTexture, buttonFont, new Vector2(300, 200), 1)
			{
				Text = "Back to Menu",
			};

			newGameButton.Click += NewGameButton_Click;

			var soundOnButton = new Button(buttonTexture, buttonFont, new Vector2(300, 250), 1)
			{
				Text = "Sound On",
			};

			soundOnButton.Click += soundOn_Click;

			var soundOffButton = new Button(buttonTexture, buttonFont, new Vector2(300, 300), 1)
			{
				Text = "Sound Off",
			};

			soundOffButton.Click += soundOff_Click;

			components = new List<Entity>()
			{
				newGameButton,
				soundOnButton,
				soundOffButton,
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

		private void soundOn_Click(object sender, EventArgs e)
		{
			MediaPlayer.IsMuted = false;
		}

		private void soundOff_Click(object sender, EventArgs e)
		{
			MediaPlayer.IsMuted = true;
		}

		private void NewGameButton_Click(object sender, EventArgs e)
		{
			_global.ChangeState(_global.menu);
		}
	}
}
