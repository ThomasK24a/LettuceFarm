using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LettuceFarm
{
    class MapTile
    {
        private int tileWidth;
        private int tileHeight;
        private int width;
        private int height;
        //private Texture2D texture;

        public MapTile(int pTileHeight, int pTileWidth, int pWidth, int pHeight)
        {
            tileWidth = pTileWidth;
            tileHeight = pTileHeight;
            width = pWidth;
            height = pHeight;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            Vector2 tilePosition = Vector2.Zero;
        }
    }
}