using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class WeatherSensor
    {
        public WeatherSensor() { }

        public float outdoor_temp { get; private set; }
        public float windspeed { get; private set; }
        public bool rain { get; private set; }

        public delegate void Notify();

        public event Notify ProcessCompleted;
        void Simulate()
        {
            //Realistically change Values
            ProcessCompleted.Invoke();
        }
    }
}
