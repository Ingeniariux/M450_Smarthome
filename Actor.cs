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
        protected RoomSensor room_sensor;
        protected WeatherSensor weather_sensor;

        protected Actor() { weather_sensor.ProcessCompleted += Weather_sensor_ProcessCompleted; }

        protected bool current_State;
        private void Weather_sensor_ProcessCompleted()
        {
            UpdateState();
        }

        public bool SetLogicState( bool state)
        {
            if (current_logic_state != state)
            {
                current_logic_state = state;
                return true;
            }
            return false;
        }

         bool Compare_temp(float temp1, float temp2)
        { 
        return temp1 > temp2;
        }

        public abstract bool UpdateState();

    }
}
