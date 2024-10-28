using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public abstract class Actor
    {
        protected RoomSensor room_sensor;
        protected WeatherSensor weather_sensor;
        protected bool current_logic_state;
        protected bool current_State;

        protected Actor(RoomSensor roomSensor, WeatherSensor weatherSensor)
        {
            room_sensor = roomSensor;
            weather_sensor = weatherSensor;

            if (weather_sensor != null)
            {
                weather_sensor.ProcessCompleted += Weather_sensor_ProcessCompleted;
            }
        }

        public bool CurrentState => current_State;

        private void Weather_sensor_ProcessCompleted()
        {
            UpdateState();
        }

        public bool SetLogicState(bool state)
        {
            if (current_logic_state != state)
            {
                current_logic_state = state;
                return true;
            }
            return false;
        }

        public abstract bool UpdateState();

    }
}
