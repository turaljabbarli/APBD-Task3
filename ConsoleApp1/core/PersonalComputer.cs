namespace ConsoleApp1.core
{
    using ConsoleApp1.Exceptions;
    using System;

    /// <summary>
    /// Represents a personal computer device with an optional operating system.
    /// </summary>
    public class PersonalComputer : Device
    {
        /// <summary>Gets or sets the installed operating system.</summary>
        public string? OperatingSystem { get; set; }

        /// <summary>Initializes a new <see cref="PersonalComputer"/> with an optional OS.</summary>
        public PersonalComputer(string id, string name, string? os = null)
            : base(id, name)
        {
            OperatingSystem = os;
        }

        /// <summary>Turns on the PC if an OS is installed; throws otherwise.</summary>
        public override void TurnOn()
        {
            if (string.IsNullOrWhiteSpace(OperatingSystem))
                throw new EmptySystemException();

            base.TurnOn();
        }

        /// <summary>Returns a string representation of the personal computer.</summary>
        public override string ToString()
        {
            string osInfo = string.IsNullOrEmpty(OperatingSystem) ? "No OS" : $"OS: {OperatingSystem}";
            return base.ToString() + $" | {osInfo}";
        }
    }
}