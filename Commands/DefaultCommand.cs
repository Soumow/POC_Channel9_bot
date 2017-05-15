using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Channel9_bot.Commands
{
    public class DefaultCommand : ICommand
    {
        public string BuildAnswer(string question)
        {
            return Resources.en_us.resources.defaultMessage;
        }

        public ResponseOption CanbeHandledbyMe(string text)
        {
            return ResponseOption.FullyHandled;
        }
    }
}