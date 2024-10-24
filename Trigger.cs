using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smarthome
{
    public class Trigger
    {
        public Trigger() { }

        Dictionary<string, List<Actor>> actors;

        Dictionary<Dictionary<TimeSpan, bool>, List<Actor>> timers;

        bool Actor_switch(bool state) { }

        bool Timer_trig(Actor actor, bool state, TimeSpan time) { }

        bool Manual_trig(Actor actor, bool state) { }




    }
}
