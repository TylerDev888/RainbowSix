using RainbowSix.WebClient.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RainbowSix.WebClient.Interfaces
{
    public interface IWebSocketLogger
    {
        void Write(WebSocketMessageType webSocketMessageType, string data, int length, int time);
        void WriteLine(WebSocketMessageType webSocketMessageType, string data, int length, int time);
    }
}
