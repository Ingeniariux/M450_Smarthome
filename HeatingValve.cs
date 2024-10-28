using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class HeatingValve : Actor
    {
        public HeatingValve(RoomSensor roomSensor, WeatherSensor weatherSensor)
            : base(roomSensor, weatherSensor)
        {
        }

        public override bool UpdateState()
        {
            bool supposedstate = room_sensor.room_temp > weather_sensor.outdoor_temp;

            if (room_sensor.room_temp <= 15)
            {
                supposedstate = true;
            }
            else if (room_sensor.room_temp > 24)
            {
                supposedstate = false;
            }

            if (current_State != supposedstate)
            {
                current_State = supposedstate;
                SetLogicState(supposedstate);
                return true;
            }
            return false;
        }
    }
}
