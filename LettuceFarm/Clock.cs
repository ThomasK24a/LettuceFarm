using System;
using System.Collections.Generic;
using System.Text;

namespace LettuceFarm
{
   public class Clock
    {
        public float time;

        public Clock(float time)
        {
            this.time = time;
        }
        
        public float getTime()
        { 
            return this.time;
        }

        public string TimeToString()
        {
            if(this.time >= 0f && this.time <= 12)
            {
                return this.roundTime() + " AM";
            }

            else
            {
                return this.roundTime() + " PM";
            }
        }

        public void setTime(float time)
        {
            this.time = time;
        }
        //round to two decimal places
        public double roundTime()
        {
            //float timeRound = (float)Math.Round(this.timer * 1000f) / 1000f;
            double timeRound = Math.Round(this.time, 2);

            return timeRound;
        }

        //reset time
        public void timerNight()
        {
            this.time = 0f;
        }
    }
}
