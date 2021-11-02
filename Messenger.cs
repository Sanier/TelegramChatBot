﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramChatBot.Commands;

namespace TelegramChatBot
{
    public class Messenger
    {
        private ITelegramBotClient botClient;

        public CommandParser parser;

        public Messenger(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            parser = new CommandParser();

            RegisterCommands();
        }

        private void RegisterCommands()
        {
            parser.AddCommand(new AddWordCommand(botClient));
            parser.AddCommand(new DeleteWordCommand());
        }

        public async Task MakeAnswer(Conversation chat)
        {
            var lastmessage = chat.GetLastMessage();

            if (chat.IsAddingInProcess)
            {
                parser.NextStage(lastmessage, chat);

                return;
            }
        }

        public async Task ExecCommand(Conversation chat, string command)
        {
            if (parser.IsTextCommand(command))
            {
                var text = parser.GetMessageText(command, chat);

                await SendText(chat, text);
            }

            if (parser.IsAddingCommand(command))
            {
                chat.IsAddingInProcess = true;
                parser.StartAddingWord(command, chat);
            }
        }

        private string CreateTextMessage()
        {
            var text = "Нет комманды";

            return text;
        }

        private async Task SendText(Conversation chat, string text)
        {
            await botClient.SendTextMessageAsync(chatId: chat.GetId(), text: text);
        }
    }
}
