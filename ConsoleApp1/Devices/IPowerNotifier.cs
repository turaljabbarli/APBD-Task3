namespace ConsoleApp1.Devices
{
    /// <summary>
    /// Interface for devices that notify about low battery.
    /// </summary>
    public interface IPowerNotifier
    {
        /// <summary>Triggers a battery warning notification.</summary>
        void NotifyLowBattery();
    }
}