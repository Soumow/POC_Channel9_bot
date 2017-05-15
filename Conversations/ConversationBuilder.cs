using POC_Channel9_bot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Channel9_bot.Conversations
{
    public class ConversationBuilder
    {
        public string Read(string question)
        {
            CommandDetector commandDetector = new CommandDetector();
            ICommand command = commandDetector.DetectCommand(question);
            return command.BuildAnswer(question);
        }
    }
}