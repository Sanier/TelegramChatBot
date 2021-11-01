using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramChatBot
{
    class Program
    {
        static void Main(string[] args)
        {

            var bot = new BotWorker();

            bot.Inizalize();
            bot.Start();

            Console.WriteLine("Напишите stop для прекращения работы");

            string command;
            do
            {
                command = Console.ReadLine();

            } while (command != "stop");

            bot.Stop();
        }
    }

    public class BotCredentials
    {
        public static readonly string BotToken = "2032548537:AAHIuqK5hK7Of2aFnHxfXX1NxeNKSNk8axo";
    }


}
