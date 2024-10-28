namespace smarthome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherSensor weatherSensor = new WeatherSensor();
            RoomSensor bedroomSensor = new RoomSensor();
            RoomSensor livingRoomSensor = new RoomSensor();
            RoomSensor terraceSensor = new RoomSensor();

            HeatingValve bedroomHeatingValve = new HeatingValve(bedroomSensor, weatherSensor);
            HeatingValve livingRoomHeatingValve = new HeatingValve(livingRoomSensor, weatherSensor);
            Blinds bedroomBlinds = new Blinds(bedroomSensor, weatherSensor);
            Blinds livingRoomBlinds = new Blinds(livingRoomSensor, weatherSensor);
            Awnings terraceAwnings = new Awnings(terraceSensor, weatherSensor);

            Trigger trigger = new Trigger();
            trigger.Add_Timer_trig(bedroomHeatingValve, TimeSpan.FromMinutes(0), true);
            trigger.Add_Timer_trig(livingRoomHeatingValve, TimeSpan.FromMinutes(0), true);
            trigger.Add_Timer_trig(bedroomBlinds, TimeSpan.FromMinutes(0), true);
            trigger.Add_Timer_trig(livingRoomBlinds, TimeSpan.FromMinutes(0), true);
            trigger.Add_Timer_trig(terraceAwnings, TimeSpan.FromMinutes(0), true);

            // Simulate data changes and update states
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Simulation Iteration: " + (i + 1));

                weatherSensor.Simulate();
                bedroomSensor.Simulate();
                livingRoomSensor.Simulate();
                terraceSensor.Simulate();

                Console.WriteLine($"Weather - Outdoor Temp: {weatherSensor.OutdoorTemp}, Wind Speed: {weatherSensor.WindSpeed}, Raining: {weatherSensor.IsRaining}");
                Console.WriteLine($"Bedroom - Room Temp: {bedroomSensor.RoomTemp}, Amount of Persons: {bedroomSensor.AmountPerson}");
                Console.WriteLine($"Living Room - Room Temp: {livingRoomSensor.RoomTemp}, Amount of Persons: {livingRoomSensor.AmountPerson}");
                Console.WriteLine($"Terrace - Room Temp: {terraceSensor.RoomTemp}, Amount of Persons: {terraceSensor.AmountPerson}");

                bedroomHeatingValve.UpdateState();
                livingRoomHeatingValve.UpdateState();
                bedroomBlinds.UpdateState();
                livingRoomBlinds.UpdateState();
                terraceAwnings.UpdateState();

                Console.WriteLine($"Bedroom Heating Valve State: {bedroomHeatingValve.CurrentState}");
                Console.WriteLine($"Living Room Heating Valve State: {livingRoomHeatingValve.CurrentState}");
                Console.WriteLine($"Bedroom Blinds State: {bedroomBlinds.CurrentState}");
                Console.WriteLine($"Living Room Blinds State: {livingRoomBlinds.CurrentState}");
                Console.WriteLine($"Terrace Awnings State: {terraceAwnings.CurrentState}");
                Console.WriteLine();
            }

            // Manual Activation/Deactivation
            while (true)
            {
                Console.WriteLine("Enter 'activate' or 'deactivate' followed by the actor id  to change the state: " +
                    "\n1 = Bedroom Heating" +
                    "\n2 = Living room Heating" +
                    "\n3 = Bedroom Blinds" +
                    "\n4 = Living room Blinds" +
                    "\n5 = Terrace Awnings" +
                    "\nType 'exit' to quit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;

                var parts = input.Split(' ');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please enter again.");
                    continue;
                }

                string action = parts[0].ToLower();
                string actorName = parts[1];

                Actor actor = null;
                switch (actorName)
                {
                    case "1":
                        actor = bedroomHeatingValve;
                        break;
                    case "2":
                        actor = livingRoomHeatingValve;
                        break;
                    case "3":
                        actor = bedroomBlinds;
                        break;
                    case "4":
                        actor = livingRoomBlinds;
                        break;
                    case "5":
                        actor = terraceAwnings;
                        break;
                    default:
                        Console.WriteLine("Unknown actor name.");
                        continue;
                }

                bool newState = action == "activate";
                if (actor.SetLogicState(newState))
                {
                    Console.WriteLine($"After {action}ting {actorName}:");
                }

                Console.WriteLine($"Bedroom Heating Valve State: {bedroomHeatingValve.CurrentState}");
                Console.WriteLine($"Living Room Heating Valve State: {livingRoomHeatingValve.CurrentState}");
                Console.WriteLine($"Bedroom Blinds State: {bedroomBlinds.CurrentState}");
                Console.WriteLine($"Living Room Blinds State: {livingRoomBlinds.CurrentState}");
                Console.WriteLine($"Terrace Awnings State: {terraceAwnings.CurrentState}");
                Console.WriteLine();
            }
        }
    }
}
