using POC_Channel9_bot.Resources.en_us;
using POC_Channel9_bot.Sanitizers;
using POC_Channel9_bot.VideoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Channel9_bot.Commands
{
    public class FeaturedVideoCommand : ICommand
    {
        public string BuildAnswer(string question)
        {
            VideoRetrieve data = new VideoRetrieve();
            Video video = data.LatestFeaturedVideo;
            string responseMessage = string.Empty;
            if (video != null)
            {
                responseMessage = string.Format(resources.featuredVideoResponse, video.Title, video.Link);
            }
            return responseMessage;
        }

        public ResponseOption CanbeHandledbyMe(string question)
        {
            EscapeSanitizer escaptesanitzer = new EscapeSanitizer();
            string satizedResouce = escaptesanitzer.Sanitize(resources.featured);
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