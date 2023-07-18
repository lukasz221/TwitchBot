using System;
using WindowsInput;
using WindowsInput.Native;

namespace TwitchBot
{
    class Program
    {
        static void Main(string[] args)
        {
            InputSimulator sim = new InputSimulator();
            int r = 0;
            int l = 0;
            int f = 0;  
            int b = 0;
            IrcClient client = new IrcClient("irc.twitch.tv", 6667, "MrJKooBot", "oauth:hm07s8h2gcwp2aq3rffr946yopzglo", "mrjkoo");

            var pinger = new Pinger(client);
            pinger.Start();
            Random rnd = new Random();

            while (true)
            {
                Console.WriteLine("Reading message");
                var message = client.ReadMessage();
                if (message.EndsWith("!hi"))
                {
                    client.SendChatMessage($"hello");
                   // sim.Keyboard.Sleep(1000);
                  //  sim.Keyboard.TextEntry("13213dsadas");
                }
                if (message.EndsWith("!dice") || (message.EndsWith("!Dice")))
                {
                    client.SendChatMessage($"{rnd.Next(1,6)}");
                }
                if ((message.EndsWith("!w")) || (message.EndsWith("!W")))
                {
                    client.SendChatMessage("W");
                    sim.Keyboard.Sleep(10);
                    sim.Keyboard.TextEntry("!W");
                    sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                }

                Console.WriteLine($"Message: {message}");
            }
        }
    }
}