using RainbowSix.WebClient.Interfaces;

namespace RainbowSix.API
{
    public class RainbowSixLogger : IHttpConnectionLogger
    {
        public void Write(string message)
        {
            Console.Write(message);
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
