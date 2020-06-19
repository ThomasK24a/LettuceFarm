using LettuceFarm.Controls;
using LettuceFarm.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LettuceFarm.GameEntity
{
    public abstract class Crop : Entity
    {
        string name;
        public TimeSpan timeTillNextStage;
        Random random;
        int minGrowTime;
        int maxGrowTime;
        FarmTile farmTile;
        GameState game;
        int minTemp;
        int maxTemp;
        int minHum;
        int maxHum;

        public Crop(Texture2D texture, Vector2 position, string name, int frameCount, int minGrowTime, int maxGrowTime, FarmTile farmTile, GameState game, int minTemp, int maxTemp, int minHum, int maxHum) : base(texture, position, frameCount)
        {
            this.farmTile = farmTile;
            this.minGrowTime = minGrowTime;
            this.maxGrowTime = maxGrowTime;
            this.random = new Random();
            this.name = name;
            int secondsTillNextStage = random.Next(minGrowTime, maxGrowTime);
            this.timeTillNextStage = TimeSpan.FromSeconds(secondsTillNextStage);
            this.game = game;
            this.minTemp = minTemp;
            this.maxTemp = maxTemp;
            this.minHum = minHum;
            this.maxHum = maxHum;
        }

        public string GetName()
        {
            return this.name;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawAnimation(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (game.currHum > minHum && game.currHum < maxHum && game.currTemp > minTemp && game.currTemp < maxTemp)
            {
                timeTillNextStage = timeTillNextStage.Subtract(gameTime.ElapsedGameTime * game.currSun / 10);
            }
            else
            {
                timeTillNextStage = timeTillNextStage.Subtract(gameTime.ElapsedGameTime * game.currSun / 100);
            }

            if (timeTillNextStage.TotalMilliseconds < 0 && CurrentFrame < FrameCount - 1)
            {
                CurrentFrame++;
                timeTillNextStage = TimeSpan.FromSeconds(random.Next(minGrowTime, maxGrowTime));
            }
            else if (timeTillNextStage.TotalMilliseconds < 0)
            {
                farmTile.removeCrop();
            }
        }
    }
}
