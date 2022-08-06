using System;

namespace TwitchBot
{
    class Program
    {
        static void Main(string[] args)
        {
            int r = 0;
            int l = 0;
            int f = 0;  
            int b = 0;
            IrcClient client = new IrcClient("irc.twitch.tv", 6667, "mrjkoobot", "oauth:hm07s8h2gcwp2aq3rffr946yopzglo", "mrjkoo");

            var pinger = new Pinger(client);
            pinger.Start();

            client.SendIrcMessage("dd");

            while (true)
            {
                Console.WriteLine("Reading message");
                var message = client.ReadMessage();
                if (message.EndsWith("!r"))
                {
                    r++;
                    Console.WriteLine("right" + r);
                }
                if (message.EndsWith("!l"))
                {
                    l++;
                    Console.WriteLine("left");
                }
                if (message.EndsWith("!f"))
                {
                    f++;    
                    Console.WriteLine("forward");
                }
                if (message.EndsWith("!b"))
                {
                    b++;
                    Console.WriteLine("back");
                }

                Console.WriteLine($"Message: {message}");
            }
        }
    }
}