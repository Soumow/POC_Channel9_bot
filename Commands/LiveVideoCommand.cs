using POC_Channel9_bot.Resources.en_us;
using POC_Channel9_bot.Sanitizers;
using POC_Channel9_bot.VideoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Channel9_bot.Commands
{
    public class LiveVideoCommand : ICommand
    {
        public string BuildAnswer(string question)
        {
            var data = new VideoRetrieve();
            Event ch9event = data.LiveEvent;
            string responseMessage = string.Empty;
            if (ch9event.Title.Equals(string.Empty))
            {
                responseMessage = resources.noLiveEventResponse;
            }
            else
            {
                responseMessage = string.Format(resources.liveEventResponse, ch9event.Title, ch9event.Link);
            }             
            return responseMessage;
        }

        public ResponseOption CanbeHandledbyMe(string question)
        {
            EscapeSanitizer escaptesanitzer = new EscapeSanitizer();
            string satizedResouce = escaptesanitzer.Sanitize(resources.live);
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