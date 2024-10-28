using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class Blinds : Actor
    {
        public Blinds(RoomSensor roomSensor, WeatherSensor weatherSensor)
            : base(roomSensor, weatherSensor)
        {
        }

        public override bool UpdateState()
        {
            bool supposedstate = room_sensor.room_temp < weather_sensor.outdoor_temp && room_sensor.amount_person == 0;
            if (room_sensor.amount_person == 0)
            {
                supposedstate = true;
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
