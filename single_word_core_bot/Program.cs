using System;
using System.Threading.Tasks;

namespace SingleWordBot
{
    class Program
    {
        static Bot bot;


        public static void Main(string[] args)
        {
            bot = new Bot();
            MainAsync().Wait();
        }

        private static async Task MainAsync()
        {
            await bot.BotMain();
        }

    }
}
