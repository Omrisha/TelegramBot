using System;
using Telegram.Bot;

namespace Bot
{
    class Program
    {
        static ITelegramBotClient botClient;
        static AppDbContext dbContext;
        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("1626236843:AAGEDeKWb5sYkrsh3tZvwpN36gN03xh7UWo");
            dbContext = new AppDbContext();
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            botClient.OnMessage += BotClient_OnMessage;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }

        private static async void BotClient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");


                Phrase entity = new Phrase { Id = Guid.NewGuid().ToString(), Value = e.Message.Text, Answer = "" };
                dbContext.Phrases.Add(entity);
                dbContext.SaveChanges();
                await botClient.SendTextMessageAsync(
                    chatId: e.Message.Chat,
                    text: "You said:\n" + e.Message.Text
                    );
            }
        }
    }
}
