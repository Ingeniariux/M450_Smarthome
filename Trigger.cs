﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace smarthome
{
    public class Trigger
    {
        public Trigger()
        {
            timerThread = new Thread(new ThreadStart(Timer_trig));
            if (timers.Any())
                StartCounterThread();
        }

        Dictionary<string, List<Actor>> actors;

        Dictionary<Actor, Dictionary<TimeSpan, bool>> timers;

        TimeSpan lastTick;

        int tickInSec = 60;

        Thread timerThread;

        void StartCounterThread()
        {
            timerThread.Start();
        }

        void StopCounterThread() 
        {
            timerThread.Interrupt();
        }

        async void Timer_trig()
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(tickInSec));
            lastTick = DateTime.Now.TimeOfDay - TimeSpan.FromSeconds(tickInSec);
            while (await timer.WaitForNextTickAsync())
            {
                foreach (var keypair in timers)
                {
                    foreach (var timespan in keypair.Value)
                    {
                        if (timespan.Key >= lastTick && timespan.Key <= DateTime.Now.TimeOfDay)
                        {
                            keypair.Key.SetLogicState(timespan.Value);
                        }
                    }
                }
            }
        }

        bool Add_Timer_trig(Actor actor, TimeSpan time, bool state) 
        {
            if (timers.ContainsKey(actor))
            {
                timers[actor].Add(time, state);
            }
            else 
            { 
                timers.Add(actor, new Dictionary<TimeSpan, bool>());
                timers[actor].Add(time, state);
            }
            if (timers.Count() == 1)
                StartCounterThread();
            return true;
        }

        bool Manual_trig(Actor actor, bool state) 
        { 
        return actor.SetLogicState(state);
        }




    }
}
