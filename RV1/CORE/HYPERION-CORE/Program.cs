using System.Device.Gpio;
using System.Device.Pwm;
using System.Device.Pwm.Drivers;
using Trilosharp;
//Poison Jam, Casting a shadow over your neighbour hood!
namespace TriloTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TriloTest by Jake Shaw (Rarisma)");
            Initalise.Init();
            Console.WriteLine("Starting Testing...\nPerforming Button Test");
            /*TestButton(Enums.Buttons.A);
            TestButton(Enums.Buttons.B);
            TestButton(Enums.Buttons.X);
            TestButton(Enums.Buttons.Y);*/
            Console.WriteLine("Button Test Complete\nSetting motors to max for 5 seconds");
            GPIO.controller.Write(GPIO.ENPin,PinValue.High);
            var softwarePwmChannel = new SoftwarePwmChannel(GPIO.LeftN, 100, 0.25,true);
//            var softwarePwmChannel2 = new SoftwarePwmChannel(GPIO.LeftP, 100, 0.25,true);
            softwarePwmChannel.Start();
           // softwarePwmChannel2.Start();
            Console.WriteLine("Motor maxed");
            Thread.Sleep(2000);
           // GPIO.controller.Write(GPIO.ENPin, PinValue.High);


        }

        private static void TestButton(Enums.Buttons Button)
        {
            CancellationToken token = new(); //No idea what this does, but its needed.
            try
            {
                Console.WriteLine($"Press the {Enum.GetName(Button)} button on the trilobot.");
                GPIO.controller.WaitForEvent(GPIO.APin, PinEventTypes.Rising, token);
                Console.WriteLine($"{Enum.GetName(Button)} Press detected.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error - {e.Message}");
            }
        }
    }
}