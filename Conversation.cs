using System.Collections.Generic;
using Telegram.Bot.Types;
using TelegramChatBot.Commands;

namespace TelegramChatBot
{
    public class Conversation
    {
        private readonly Chat telegramChat;

        private readonly List<Message> telegramMessages;

        public Dictionary<string, Word> dictionary;

        public bool IsAddingInProcess;

        public Conversation(Chat chat)
        {
            telegramChat = chat;
            telegramMessages = new List<Message>();
            dictionary = new Dictionary<string, Word>();
        }

        public void AddMessage(Message message)
        {
            telegramMessages.Add(message);
        }

        public void AddWord(string key, Word word)
        {
            dictionary.Add(key, word);
        }

        public void ClearHistory()
        {
            telegramMessages.Clear();
        }

        public List<string> GetTextMessages()
        {
            var textMessages = new List<string>();

            foreach (var message in telegramMessages)
            {
                if (message.Text != null)
                {
                    textMessages.Add(message.Text);
                }
            }

            return textMessages;
        }

        public long GetId() => telegramChat.Id;

        public string GetLastMessage() => telegramMessages[telegramMessages.Count - 1].Text;
    }
}
