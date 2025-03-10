﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using LibHYPERION;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

namespace HYPERIONMobile
{
    public sealed partial class MainPage : Page
    {
        private Sensor AltSensor = new Sensor("BMP390 (Alt)", "Altitude", "M");
        private Sensor PressureSensor = new Sensor("BMP390 (Pres)", "Pressure", "HPa");
        private Sensor TempSensor = new Sensor("BMP390 (Temp)", "Temp", "℃");
        public MainPage()
        {
            this.InitializeComponent();
            //SensorReadouts.Text = "";
        }
        
        
    }
}
