using LettuceFarm.Controls;
using LettuceFarm.GameEntity;
using LettuceFarm.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LettuceFarm.Game.Crops
{
    class Corn : Crop
    {
        public Corn(ContentManager content, Vector2 position, FarmTile farmTile, GameState game) : base(content.Load<Texture2D>("cornCrop"), position, "corn", 5, 20, 30, farmTile, game, 20, 40, 40, 70)
        {

        }
    }
}
