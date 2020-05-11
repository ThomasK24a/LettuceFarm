using LettuceFarm.UI.Inventory;
using LettuceFarm.UI.Shop;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LettuceFarm
{
    public class Game1 : Game
    {
        Texture2D animals;
        Shop shop;
        GameMap map;
        Inventory inventory;
		
        public Game1()
        {
            Global._graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Global._spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new GameMap(this, 20, 15);
            shop = new Shop(this);
            map.InitializeComponent();
            inventory = new Inventory(this);
			
            // TODO: Add your initialization logic here
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            animals = this.Content.Load<Texture2D>("Sprites/animals");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            map.Draw();
            base.Draw(gameTime);
        }
    }
}
