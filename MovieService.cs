using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace TelegramBotProject
{
    public class MovieService
    {

        public void Movie()
        {
            var _token = "1M98HF0-C6149RC-MJ6T4SD-H298MAM";
            string movie = Console.ReadLine();
            var request = new GetRequest($"https://api.kinopoisk.dev/movie?isStrict=false&search={movie}&field=name&token={_token}");
            request.Run();
            var response = request.Response;
            var json = JObject.Parse(response);
            var docs = json["docs"];
            foreach (var doc in docs)
            {
                var name = doc["name"];
                Console.WriteLine($"{name}");
            }
        }
    }
}

