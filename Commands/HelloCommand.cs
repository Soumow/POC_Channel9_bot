using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POC_Channel9_bot.VideoData;
using POC_Channel9_bot.Resources.en_us;
using POC_Channel9_bot.Sanitizers;

namespace POC_Channel9_bot.Commands
{
    public class HelloCommand : ICommand
    {
        public string BuildAnswer(string question)
        {
            return resources.helloMessage;
        }

        public ResponseOption CanbeHandledbyMe(string question)
        {
            if (question.Equals(resources.hi) || question.Contains(resources.hello))
            {
                return ResponseOption.FullyHandled;
            }
            else
            {
                return ResponseOption.NotHandled;
            }      
        }
    }
}