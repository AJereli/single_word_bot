using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace SingleWordBot
{
    public class Bot
    {
        readonly private ITelegramBotClient botClient;

        public Bot()
        {
            botClient = new TelegramBotClient("895198692:AAGcsvPQogiNGxexv6rdpMC0XHej6nKJfM0");

        }

        public async Task BotMain (){
            var me = await botClient.GetMeAsync();
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            await Task.Delay(int.MaxValue);
        }

        async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "You said:\n" + e.Message.Text
                );
            }
        }
    }
}
