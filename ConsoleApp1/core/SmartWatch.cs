namespace ConsoleApp1.core
{
    using ConsoleApp1.interfaces;
    using ConsoleApp1.Exceptions;
    using System;

    /// <summary>
    /// Represents a smartwatch device with battery tracking and low-battery notifications.
    /// </summary>
    public class Smartwatch : Device, IPowerNotifier
    {
        private int _batteryPercentage;

        /// <summary>Gets or sets the battery percentage (0–100).</summary>
        public int BatteryPercentage
        {
            get => _batteryPercentage;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException();

                _batteryPercentage = value;

                if (_batteryPercentage < 20)
                    NotifyLowBattery();
            }
        }

        /// <summary>Initializes a new <see cref="Smartwatch"/> with ID, name, and battery.</summary>
        public Smartwatch(string id, string name, int batteryPercentage)
            : base(id, name)
        {
            BatteryPercentage = batteryPercentage;
        }

        /// <summary>
        /// Turns on the smartwatch if battery is 11% or higher, and decreases battery by 10%.
        /// </summary>
        public override void TurnOn()
        {
            if (BatteryPercentage < 11)
                throw new EmptyBatteryException();

            base.TurnOn();
            BatteryPercentage -= 10;
        }

        /// <summary>Displays a low battery warning message to the console.</summary>
        public void NotifyLowBattery()
        {
            Console.WriteLine($"⚠️ Battery low ({BatteryPercentage}%) on {Name}");
        }

        /// <summary>Returns a string representation of the smartwatch.</summary>
        public override string ToString()
        {
            return base.ToString() + $" | Battery: {BatteryPercentage}%";
        }
    }
}