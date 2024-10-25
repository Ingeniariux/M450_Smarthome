using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class Awnings : Actor
    {
        public Awnings() { }

        float max_windspeed = 30;

        bool compare_windspeed() 
        {
            return max_windspeed < weather_sensor.windspeed;
        }
        public override bool UpdateState()
        {
            bool supposedstate = compare_windspeed() && !weather_sensor.rain;
            if (current_State != supposedstate)
            {
                current_State = supposedstate;
                return true;
            }
            return false;
        }
    }
}
