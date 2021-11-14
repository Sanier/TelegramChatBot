using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramChatBot.Commands;

namespace TelegramChatBot
{
    public class CommandParser
    {
        private readonly List<IChatCommand> Command;

        private readonly AddingController addingController;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
            addingController = new AddingController();
        }

        public void AddCommand(IChatCommand chatCommand)
        {
            Command.Add(chatCommand);
        }

        public bool IsMessageCommand(string message)
        {
            return Command.Exists(x => x.CheckMessage(message));
        }

        public bool IsTextCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is IChatTextCommand;
        }

        public string GetMessageText(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as IChatTextCommand;

            if ((command is IChatTextCommandWithAction))
            {
                if (!(command as IChatTextCommandWithAction).DoAction(chat))
                {
                    return "Ошибка выполнения команды!";
                };
            }

            return command.ReturnText();
        }

        //public bool OutDictionaryText(string message)
        //{
        //    var command = Command.Find(x => x.CheckMessage(message));

        //    return command is DictionaryWordCommand;
        //}

        public bool IsAddingCommand(string message)
        {
            var command = Command.Find(x => x.CheckMessage(message));

            return command is AddWordCommand;
        }

        public void StartAddingWord(string message, Conversation chat)
        {
            var command = Command.Find(x => x.CheckMessage(message)) as AddWordCommand;

            addingController.AddFirstState(chat);
            command.StartProcessAsync(chat);
        }

        public void NextStage(string message, Conversation chat)
        {
            var command = Command.Find(x => x is AddWordCommand) as AddWordCommand;

            command.DoForStageAsync(addingController.GetStage(chat), chat, message);

            addingController.NextStage(message, chat);
        }
    }
}
