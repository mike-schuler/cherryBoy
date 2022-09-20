using System;
using System.Linq;
using System.IO;
using System.Threading;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();

        }
    }
}