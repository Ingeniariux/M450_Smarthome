using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public abstract class Actor
    {
        bool current_logic_state;
        RoomSensor room_sensor;
        WeatherSensor weather_sensor;

         bool SetLogicState()
        { }

         bool Compare_temp()
        { }

        public abstract bool UpdateState();

    }
}
