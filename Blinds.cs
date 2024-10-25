using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class Blinds:Actor
    {
        Blinds() { }
        public override bool UpdateState()
        {
            bool supposedstate = room_sensor.room_temp < weather_sensor.outdoor_temp && room_sensor.amount_person == 0;
            if (current_State != supposedstate)
            {
                current_State = supposedstate;
                return true;
            }
            return false;
        }
    }
}
