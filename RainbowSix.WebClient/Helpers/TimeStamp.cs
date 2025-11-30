using System;
using System.Collections.Generic;
using System.Text;

namespace RainbowSix.WebClient.Helpers
{
    public static class TimeStamp
    {
        public static int Now()
            => (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
    }
}
