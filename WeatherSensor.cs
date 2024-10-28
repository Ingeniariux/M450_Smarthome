using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class WeatherSensor
    {
        private Random random = new Random();

        public WeatherSensor()
        {
            outdoor_temp = random.Next(-5, 15);
            windspeed = random.Next(0, 50);
            rain = random.Next(0, 2) == 1;
        }

        public float outdoor_temp { get; private set; }
        public float windspeed { get; private set; }
        public bool rain { get; private set; }
        public float OutdoorTemp => outdoor_temp;
        public float WindSpeed => windspeed;
        public bool IsRaining => rain;

        public delegate void Notify();

        public event Notify ProcessCompleted;

        public void Simulate()
        {
            // Simulate changes in weather
            outdoor_temp += random.Next(-2, 3);
            outdoor_temp = Math.Clamp(outdoor_temp, -10, 20);
            windspeed = random.Next(0, 60);
            rain = random.Next(0, 2) == 1;

            // Notify subscribers
            ProcessCompleted?.Invoke();
        }
    }
}
