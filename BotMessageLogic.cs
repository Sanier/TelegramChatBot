using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramChatBot
{
    class BotMessageLogic
    {
        private readonly Messenger messanger;

        private readonly Dictionary<long, Conversation> chatList;

        private readonly ITelegramBotClient botClient;

        public BotMessageLogic(ITelegramBotClient botClient)
        {
            this.botClient = botClient;
            messanger = new Messenger(botClient);
            chatList = new Dictionary<long, Conversation>();
        }

        public async Task Response(MessageEventArgs e)
        {
            var Id = e.Message.Chat.Id;

            if (!chatList.ContainsKey(Id))
            {
                var newchat = new Conversation(e.Message.Chat);

                chatList.Add(Id, newchat);
            }

            var chat = chatList[Id];

            chat.AddMessage(e.Message);

            if (chat.GetLastMessage() == "/dictionary")
            {
                await SendOutMessage(chat);
            }

            await SendTextMessage(chat);
        }

        private async Task SendTextMessage(Conversation chat)
        {
            await messanger.MakeAnswer(chat);
        }

        private async Task SendOutMessage(Conversation chat)
        {
            var text = messanger.Diction(chat);

            await botClient.SendTextMessageAsync(chatId: chat.GetId(), text: text);
        }
    }
}
