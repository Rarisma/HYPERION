using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibHYPERION
{
    public static class Info
    {
        /// <summary>
        /// This is the default server URL that HYPERION CORE operates on
        /// Since CORE uses an ESP32 and hosts it's own Wifi Network
        /// 192.168.4.1 is the default IP address.
        /// </summary>
        public static Uri ServerURL = new("http://192.168.4.1/");
    }
}
