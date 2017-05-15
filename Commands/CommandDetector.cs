using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Channel9_bot.Commands
{
    public class CommandDetector : ICommandDetector 
    {
        private List<ICommand> commands = new List<ICommand>();
        public CommandDetector()
        {
            initializeCommand();
        }

        private void initializeCommand()
        {
            commands.Add(new FeaturedVideoCommand());
            commands.Add(new LatestEventCommand());
            commands.Add(new LiveVideoCommand());
            commands.Add(new MostViewedCommand());
            commands.Add(new HelloCommand());
            commands.Add(new SearchCommand());
        }

        public ICommand DetectCommand(string question)
        {
            foreach (ICommand command in commands)
            {
                if(command.CanbeHandledbyMe(question).Equals(ResponseOption.FullyHandled))
                {
                    return command;
                }
            }
            return new DefaultCommand();
        }
    }
}