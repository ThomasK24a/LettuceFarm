using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using LettuceFarm.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettuceFarm.States
{
	public class MenuState : State
	{
		private List<Entity> components;
		private ContentManager contentManager;

		public MenuState(Global game, GraphicsDevice graphicsDevice, ContentManager contentManager)
			: base(game, graphicsDevice, contentManager)
		{
			var buttonTexture = content.Load<Texture2D>("Sprites/Button");
			var buttonFont = content.Load<SpriteFont>("defaultFont");

			var newGameButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(300, 200),
				Text = "New Game",
			};

			newGameButton.Click += NewGameButton_Click;

			var settingsButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(300, 250),
				Text = "Settings",
			};

			settingsButton.Click += SettingsButton_Click;

			var quitGameButton = new Button(buttonTexture, buttonFont)
			{
				Position = new Vector2(300, 300),
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

			foreach (var component in components)
				component.Draw(gameTime, spriteBatch);

			spriteBatch.End();
		}

		public override void PostUpdate(GameTime gameTime)
		{
			//Implement an update if need arises later
		}

		public override void Update(GameTime gameTime)
		{
			foreach (var component in components)
				component.Update(gameTime);
		}

		private void QuitgameButton_Click(object sender, EventArgs e)
		{
			game.Exit();
		}

		private void SettingsButton_Click(object sender, EventArgs e)
		{
			//Link to Issac settings window later
		}

		private void NewGameButton_Click(object sender, EventArgs e)
		{
			game.ChangeState(new GameState(game, graphicsDevice, contentManager));
		}
	}
}
