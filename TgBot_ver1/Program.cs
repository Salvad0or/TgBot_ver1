using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TgBot_ver1
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            string ApiToken = "5156177003:AAFGMepLTciboz5oG6Yglm2usY3EchASwRc";

            TelegramBotClient botClient = new TelegramBotClient(ApiToken);

            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;



            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = {}
            };


            botClient.StartReceiving(HandleUpdateAync, HandlePollingErrorAsync, receiverOptions, cancellationToken);

            Console.ReadKey();

        }

        static async Task HandleUpdateAync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            var chatId = update.Message.Chat.Id;


            Message m = await botClient.SendTextMessageAsync
                (
                   chatId,
                   update.Message.Text
                );

        }

        static async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }




    }
}
