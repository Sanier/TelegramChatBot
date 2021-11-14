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
        public DictionaryWordCommand()
        {
            CommandText = "/dictionary";
        }
    }
}
