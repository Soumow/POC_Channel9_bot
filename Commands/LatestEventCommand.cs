using POC_Channel9_bot.Resources.en_us;
using POC_Channel9_bot.Sanitizers;
using POC_Channel9_bot.VideoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Channel9_bot.Commands
{
    public class LatestEventCommand : ICommand
    {
        public string BuildAnswer(string question)
        {
            var data = new VideoRetrieve();
            string responseMessage = string.Empty;
            Event ch9event = data.LatestEvent;
            if(ch9event.Title != null)
            {
                responseMessage = string.Format(resources.latestEventResponse, ch9event.Title, ch9event.Link);
            }
            return responseMessage;
        }

        public ResponseOption CanbeHandledbyMe(string question)
        {
            EscapeSanitizer escaptesanitzer = new EscapeSanitizer();
            string satizedResouce = escaptesanitzer.Sanitize(resources.latestEvent);
            if (question.Contains(satizedResouce))
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