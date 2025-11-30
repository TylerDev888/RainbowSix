using RainbowSix.WebClient.Interfaces;

namespace RainbowSix.ConsoleApp
{
    public class ConnectionLogger : IHttpConnectionLogger
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
