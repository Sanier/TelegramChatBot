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
        private Dictionary<string, Word> Buffer;
        
        private Conversation chat;

        private TelegramBotClient botClient;

        public DictionaryWordCommand()
        {
            CommandText = "/dictionary";

            Buffer = new Dictionary<string, Word>();

            //OutWord();
        }

        public string OutWord()
        {
            chat.GetTextMessages();

            var delimiter = ",";
            var text = "Your history: " + string.Join(delimiter, chat.GetTextMessages().ToList());

            botClient.SendTextMessageAsync(chat.GetId(), text);

            return text;
        }
    }
}
