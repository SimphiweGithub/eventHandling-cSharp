using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Events3
{

    //Implement a system based on event changes for temperature management system
    //Class to declare delegates and OnTemperatureChange Events
    //Class to declare event arguments based on temperature changes
    //Class - Program class
    public class Program
    {
        public static void Main(string[] args)
        {
            TemperatureMonitor monitor = new TemperatureMonitor();
            monitor.TemperatureChanged += TemperatureChangedEventHandler; //Subscribe to the TemperatureChanged event
            monitor.Monitor(); //Start monitoring the temperature
        }

        static void TemperatureChangedEventHandler(object sender, TemperatureEventArgs e)
        {
            Console.WriteLine($"Temperature changed to {e.Temperature}°C");
        }
    }

    class TemperatureMonitor
    {
        public event EventHandler<TemperatureEventArgs> TemperatureChanged; //Event to notify when the temperature changes

        public void Monitor()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int temperature = random.Next(-20, 50); //Generate a random temperature between -20 and 50 degrees Celsius
                Console.WriteLine($"Current temperature: {temperature}°C");
                OnTemperatureChanged(new TemperatureEventArgs(temperature)); //Raise the event
                System.Threading.Thread.Sleep(3000); //Wait for 1 second before generating the next temperature

            }
        }
        protected virtual void OnTemperatureChanged(TemperatureEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e); //Invoke the event, if it is not null the ? is a nullable that checks if the event has been subscribed to
        }
    }

    class TemperatureEventArgs : EventArgs
    {
        public int Temperature { get; }
        public TemperatureEventArgs(int temperature)
        {
            Temperature = temperature;
        }
    }

}
