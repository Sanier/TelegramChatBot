using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace TelegramChatBot
{
    class Messenger
    {
        public string CreateTextMessage(Conversation chat)
        {
            chat.GetTextMessages();

            var delimiter = ",";
            var text = "Your history: " + string.Join(delimiter, chat.GetTextMessages().ToArray());

            return text;
        }


    }
}
