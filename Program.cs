using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using System.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace TelegramBotProject
{
    class Program
    {
           static MovieService _move = new MovieService();
        const string COMMAND_LIST = 
            @"Список команд:
           /film - введите назание фильма
            ";
        static void Main(string[] args)
        {
            var client = new TelegramBotClient($"{ConfigurationManager.AppSetting["key"]}");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            Console.WriteLine($"{message.Chat.FirstName} | {message.Text} | {message.Photo}");
            if (message.Text == null || message.Type != Telegram.Bot.Types.Enums.MessageType.Unknown)
                return;
           
   
            var msgArgs = message.Text.Split(' ');
            string text;
                switch (msgArgs[0])
                {
                    case "/start":
                        text = COMMAND_LIST;
                        break;
                case "/film":
                    text = COMMAND_LIST;
                    break;
                }
            await botClient.SendTextMessageAsync(message.From.Id, message.Text);



        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
