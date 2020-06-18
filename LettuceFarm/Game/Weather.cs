using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm.Game
{
	public class Weather
	{
		int[] temperature;
		int[] humidity;
		int[] sunshine;
		int value;
        bool rain;

		public Weather()
		{
			temperature = new int[] { 20, 25, 30, 35, 40, 50, 55};
			humidity = new int[] { 20, 25, 30, 35, 40, 50, 55 };
			sunshine = new int[] { 20, 25, 30, 35, 40, 50, 55 };
			rain = false;
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
	}
}
