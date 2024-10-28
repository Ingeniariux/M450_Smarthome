using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class RoomSensor
    {
        private Random random = new Random();

        public RoomSensor()
        {
            amount_person = 0;
            room_temp = random.Next(18, 25);
        }

        public int amount_person { get; private set; }
        public float room_temp { get; private set; }

        public int AmountPerson => amount_person;
        public float RoomTemp => room_temp;

        public void Simulate()
        {
            amount_person = random.Next(0, 4);
            room_temp += random.Next(-1, 2); 
            room_temp = Math.Clamp(room_temp, 15, 30);
        }
    }
}
