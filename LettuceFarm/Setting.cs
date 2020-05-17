using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.UI.Forms;

namespace Setting
{
    class Setting : ControlManager
    {
        
        Song song;
        Vector2 position = new Vector2(100,200);
        Button onButton, offButton, onButton2, offButton2;
        public Setting(Game1 game) : base(game)
        {
            position = new Vector2(200, 20);

            this.song = game.Content.Load<Song>("Sound/soundtrack");
            //settingBackground = game.Content.Load<Texture2D>("Assets/OptionsMenu");
           // MediaPlayer.Play(song);
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;

            onButton = new Button()
            {
                Text = "On",
                Size = new Vector2(90, 30),
                BackgroundColor = Color.Green,
                Location = this.position + new Vector2(300, 120)
            };

            onButton.Clicked += ONButton_Clicked;

            offButton = new Button()
            {
                Text = "Off",
                Size = new Vector2(90, 30),
                BackgroundColor = Color.Green,
                Location = this.position + new Vector2(400, 120)
            };

            onButton.Clicked += ONButton_Clicked;
            offButton.Clicked += OFFButton_Clicked;

            // ********************** MUSIC ON & OFF *********************************// 
            onButton2 = new Button()
            {
                Text = "On",
                Size = new Vector2(90, 30),
                BackgroundColor = Color.Green,
                Location = this.position + new Vector2(500, 120)
            };

            onButton2.Clicked += ONButton_Clicked;

            offButton2 = new Button()
            {
                Text = "Off",
                Size = new Vector2(90, 30),
                BackgroundColor = Color.Green,
                Location = this.position + new Vector2(500, 120)
            };
            //***********************************************************************//
        }
       
        private void MediaPlayer_MediaStateChanged(object sender, EventArgs e)
        {
            // 0.0f is silent, 1.0f is full volume
            MediaPlayer.Volume -= 0.1f;
           // MediaPlayer.Play(song);
        }

        private void ONButton_Clicked(object sender, EventArgs e)
        {
            //onButton.Text = "Yes";
            MediaPlayer.Play(song);
        }

        private void OFFButton_Clicked(object sender, EventArgs e)
        {
            //onButton.Text = "Yes";
            MediaPlayer.Stop();
        }

        public override void InitializeComponent()
        {

        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Controls.Add(onButton);
            Controls.Add(offButton);

        }

        
    }
}
