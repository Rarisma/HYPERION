using System.Device.Gpio;
using Trilosharp;

namespace TriloTestingApp;

public class Test
{
    static void Main(string[] args)
    {
        Initalise.Init();
        CancellationToken token = new();
        Console.WriteLine("TriloTest - Looking for A button.");
        try
        {
            Console.WriteLine("Press the A button on the trillobot.");
            GPIO.controller.WaitForEvent(GPIO.APin, PinEventTypes.Rising, token);
            Console.WriteLine("A Press detected.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"TrilloTest Error - {e.Message}");
        }
        
    }
}