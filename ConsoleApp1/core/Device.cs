namespace ConsoleApp1.core
{
/// <summary>
/// Represents an abstract electronic device with basic properties and power control.
/// </summary>
public abstract class Device
{
    /// <summary>Gets or sets the unique ID of the device.</summary>
    public string Id { get; set; }

    /// <summary>Gets or sets the name of the device.</summary>
    public string Name { get; set; }

    /// <summary>Gets a value indicating whether the device is turned on.</summary>
    public bool IsTurnedOn { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Device"/> class with ID and name.
    /// </summary>
    public Device(string id, string name)
    {
        Id = id;
        Name = name;
        IsTurnedOn = false;
    }

    /// <summary>Turns the device on.</summary>
    public virtual void TurnOn() => IsTurnedOn = true;

    /// <summary>Turns the device off.</summary>
    public virtual void TurnOff() => IsTurnedOn = false;

    /// <summary>Returns a string representation of the device.</summary>
    public override string ToString() =>
        $"{GetType().Name}: {Name} (ID: {Id}) - {(IsTurnedOn ? "ON" : "OFF")}";
}
}
