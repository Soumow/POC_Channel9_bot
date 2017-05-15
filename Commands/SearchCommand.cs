using POC_Channel9_bot.Resources.en_us;
using POC_Channel9_bot.Sanitizers;
using POC_Channel9_bot.VideoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Channel9_bot.Commands
{
    public class SearchCommand : ICommand
    {
        public string BuildAnswer(string question)
        {
            if(question.Contains(resources.search))
            {
                question = question.Replace(resources.search, "");
            }
            if (question.Contains(resources.character))
            {
                question = question.Replace(resources.character, "");
            }
            VideoRetrieve data = new VideoRetrieve();
            List<Video> listvideos = data.SearchVideos(question);
            string responseMessage = string.Empty;
            if (listvideos.Count != 0)
            {
                responseMessage = string.Format(resources.SearchResponse, question.Trim())+":";
                for (var i=0; i<5;i++)
                {
                    responseMessage += " Video num "+(i+1)+": "+listvideos[i].Title+" "+ listvideos[0].Link+" | ";
                }               
            }
            else
            {
                responseMessage = string.Format(resources.SearchResponseFail, question);
            }
            return responseMessage;
        }

        public ResponseOption CanbeHandledbyMe(string question)
        {
            EscapeSanitizer escaptesanitzer = new EscapeSanitizer();
            string satizedResouce = escaptesanitzer.Sanitize(resources.search);
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