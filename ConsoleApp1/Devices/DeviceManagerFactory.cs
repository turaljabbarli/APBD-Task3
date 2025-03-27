using ConsoleApp1.Devices;

public static class DeviceManagerFactory
{
    public static DeviceManager Create(string filePath)
    {
        return new DeviceManager(new FileDeviceLoader(), filePath);
    }
}