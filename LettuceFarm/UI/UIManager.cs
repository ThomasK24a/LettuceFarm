using MonoGame.UI.Forms;
using System;
using Microsoft.Xna.Framework;

namespace LettuceFarm.UI
{
    class UIManager : ControlManager
    {
        public UIManager(Game game) : base(game)
        {

        }

        public override void InitializeComponent()
        {
            var btn1 = new Button()
            {
                Text = "test",
                Size = new Vector2(50, 50),
                BackgroundColor = Color.Red,
                Location = new Vector2(300, 300),
            };
            btn1.Size = new Vector2(300, 200);
            btn1.Clicked += Btn1_Clicked;
            Controls.Add(btn1);
        }
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Text = "clicked";
        }
    
    }
}
