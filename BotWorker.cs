﻿using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramChatBot
{
    class BotWorker
    {
        private ITelegramBotClient botClient;
        private BotMessageLogic logic;

        public void Inizalize()
        {
            botClient = new TelegramBotClient(BotCredentials.BotToken); 
            logic = new BotMessageLogic(botClient);
        }

        public void Start()
        {
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
        }

        public void Stop()
        {
            botClient.StopReceiving();
        }

        private async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message != null)
            {
                Console.WriteLine("Получено сообщение в чате: {0}" , e.Message.Chat.Id);

                await logic.Response(e);
            }
        }
    }
}
