using LettuceFarm.Controls;
using LettuceFarm.Game;
using LettuceFarm.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

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
	
		public Crop(Texture2D texture, Vector2 position, string name, int frameCount, int minGrowTime, int maxGrowTime, FarmTile farmTile) : base(texture, position, frameCount)
		{
			this.farmTile = farmTile;
			this.minGrowTime = minGrowTime;
			this.maxGrowTime = maxGrowTime;
			this.random = new Random();
			this.name = name;
			int secondsTillNextStage = random.Next(minGrowTime, maxGrowTime);
			this.timeTillNextStage = TimeSpan.FromSeconds(secondsTillNextStage);
		}

        public string GetName()
        {
			return this.name;
        }

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			//spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
			DrawAnimation(spriteBatch);
			
		}

        public override void Update(GameTime gameTime)
        {

			timeTillNextStage = timeTillNextStage.Subtract(gameTime.ElapsedGameTime);
			if(timeTillNextStage.TotalMilliseconds < 0 && CurrentFrame < FrameCount - 1)
            {
				CurrentFrame++;
				timeTillNextStage = TimeSpan.FromSeconds(random.Next(minGrowTime, maxGrowTime));
			}else if(timeTillNextStage.TotalMilliseconds < 0)
            {
				farmTile.removeCrop();

			}

        }


    }
}
