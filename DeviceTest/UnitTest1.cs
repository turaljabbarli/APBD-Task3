using ConsoleApp1.Devices;
using Xunit;

namespace DeviceTest
{
    public class UnitTest1
    {
        [Fact]
        public void Smartwatch_ShouldThrowException_WhenBatteryTooLow()
        {
            var watch = new Smartwatch("SW01", "Test Watch", 5);
            
            Assert.Throws<EmptyBatteryException>(() => watch.TurnOn());
        }
        
        [Fact]
        public void Smartwatch_TurnOn_ShouldReduceBatteryBy10()
        {
            var watch = new Smartwatch("SW02", "Test Watch", 50);

            watch.TurnOn();

            Assert.Equal(40, watch.BatteryPercentage);
        }

    }
    
    
}