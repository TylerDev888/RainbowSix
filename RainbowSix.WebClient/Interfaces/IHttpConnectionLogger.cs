using System;
using System.Collections.Generic;
using System.Text;

namespace RainbowSix.WebClient.Interfaces
{
    public interface IHttpConnectionLogger
    {
        void Write(string message);
        void WriteLine(string message);
    }
}
