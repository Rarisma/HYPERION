using System.Device.Gpio;
using System.Device.Gpio.Drivers;

namespace Trilosharp;


//Handles all interactions with GPIO
//SPIN ETERNALLY
public static class GPIO
{
    //These are the button pins
    public static int APin = 5;
    public static int BPin = 6;
    public static int XPin = 16;
    public static int YPin = 24;

    //These are the lighting pins
    public static int LedAPin = 23;
    public static int LedBPin = 22;
    public static int LedXPin = 17;
    public static int LedYPin = 27;
    
    //These are the Motor pins
    public static int ENPin = 26;
    public static int LeftP = 8;
    public static int LeftN = 11;
    public static int RightP = 10;
    public static int RightN = 9;
    
    //These are the Ultrasonic sensor pins
    public static int TrigPin = 13;
    public static int EchoPin = 25;
    
    //This is the servo pin
    public static int ServoPin = 12;

    //Underlighting pin
    public static int UnderlightingENPin = 7;

    public static double SpeedOfSound = 343 * 100 * 1E9;
    
    //Controllers
    public static RaspberryPi3Driver Altcontroller;
    public static GpioController controller;
    
    /// <summary>
    /// Initalises the Pi's GPIO stuff
    /// </summary>
    public static void InitGPIO()
    {
        controller = new();
        Altcontroller = new();
        
        controller.SetPinMode(APin,PinMode.Input);
        controller.SetPinMode(BPin,PinMode.Input);
        controller.SetPinMode(XPin,PinMode.Input);
        controller.SetPinMode(YPin,PinMode.Input);
    }
    
}