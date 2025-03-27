using ConsoleApp1.Devices;

class Program
{
    static void Main()
    {
        Console.WriteLine("Working dir: " + Directory.GetCurrentDirectory());

        var manager = DeviceManagerFactory.Create("devices.txt");

        manager.ShowAllDevices();

        manager.TurnOnDevice("SW001");
        manager.EditDevice("PC001", "Office Laptop");

        manager.SaveToFile("devices_updated.txt");
    }
}