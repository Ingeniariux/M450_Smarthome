using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class Awnings : Actor
    {
        public Awnings(RoomSensor roomSensor, WeatherSensor weatherSensor)
            : base(roomSensor, weatherSensor)
        {
        }

        private const float max_windspeed = 30;
        private const float temperatureDifferenceThreshold = 2f;

        private bool compare_windspeed()
        {
            return max_windspeed < weather_sensor.windspeed;
        }

        public override bool UpdateState()
        {
            bool supposedstate = (room_sensor.room_temp > weather_sensor.outdoor_temp + temperatureDifferenceThreshold ||
                                  room_sensor.room_temp < weather_sensor.outdoor_temp - temperatureDifferenceThreshold) &&
                                  !weather_sensor.rain;

            if (current_State != supposedstate)
            {
                current_State = supposedstate;
                return true;
            }
            return false;
        }
    }
}
