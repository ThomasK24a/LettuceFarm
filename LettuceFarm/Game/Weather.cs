using System;

namespace LettuceFarm.Game
{

	public class Weather
	{
		int[] temperature;
		int[] humidity;
		int[] sunshine;
		int value;

		public Weather()
		{
			temperature = new int[] { 20, 25, 30, 35, 40, 50, 55};
			humidity = new int[] { 20, 25, 30, 35, 40, 50, 55 };
			sunshine = new int[] { 20, 25, 30, 35, 40, 50, 55 };
			value = 0;
		}

        public int randomTemp()
        {
            Random random = new Random();
            int index = random.Next(0, 7);

            return value + temperature[index];
        }

        public int randomHumidity()
        {
            Random random = new Random();
            int index = random.Next(0, 7);
            return value + humidity[index];
        }

		public int randomSun()
		{
			Random random = new Random();
			int index = random.Next(0, 7);
			return value + sunshine[index];
		}

		public bool randomRain()
        {
			Random random = new Random();
			int index = random.Next(0, 2);
			if(index == 1)
            {
				return true;
            }
			else
            {
				return false;
            }
		}
	}
}
