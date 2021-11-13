using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TelegramChatBot;

namespace TelegramChatBot.Commands
{
    public class DictionaryWordCommand : AbstractCommand
    {
        private List<Message> telegramMessages;

        private Word word;

        private Dictionary<string, Word> Buffer;

        public DictionaryWordCommand()
        {
            CommandText = "/dictionary";

            telegramMessages = new List<Message>();

            Buffer = new Dictionary<string, Word>();
        }

        public string OutWord(Conversation chat)
        {
            chat.GetTextMessages();

            var delimiter = ",";
            var text = "Your history: " + string.Join(delimiter, chat.GetTextMessages().ToArray());

            return text;
        }
    }
}
