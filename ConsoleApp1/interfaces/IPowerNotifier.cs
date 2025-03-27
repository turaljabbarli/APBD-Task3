namespace ConsoleApp1.interfaces
{
    /// <summary>
    /// Interface for devices that can notify the user about low battery.
    /// </summary>
    public interface IPowerNotifier
    {
        /// <summary>
        /// Triggers a notification when the battery is low.
        /// </summary>
        void NotifyLowBattery();
    }
}