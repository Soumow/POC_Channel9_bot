using POC_Channel9_bot.Resources.en_us;
using POC_Channel9_bot.Sanitizers;
using POC_Channel9_bot.VideoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POC_Channel9_bot.Commands
{
    public class MostViewedCommand : ICommand
    {
        public string BuildAnswer(string question)
        {
            TimeOption option = getOption(question);
            Video video = getVideo(option);
            string responseMessage = string.Empty;
            if (video.Title != null)
            {
                responseMessage = getResponseMessage(video, option);              
            }
            else
            {
                if (option.Equals(TimeOption.ThisYear))
                {
                    responseMessage = resources.mostViewedThisYearResponse;
                }
            }
            return responseMessage;
        }

        public ResponseOption CanbeHandledbyMe(string question)
        {
            EscapeSanitizer escaptesanitzer = new EscapeSanitizer();
            string satizedResouce = escaptesanitzer.Sanitize(resources.mostViewed);
            if (question.Contains(satizedResouce))
            {
                return ResponseOption.FullyHandled;
            }
            else
            {
                return ResponseOption.NotHandled;
            }
        }

        private Video getVideo(TimeOption option)
        {
            var data = new VideoRetrieve();
            Video video = new Video();
            switch (option)
            {
                case TimeOption.ThisWeek:
                    video = data.MostViewedThisWeek;
                    break;
                case TimeOption.ThisMonth:
                    video = data.MostViewedThisMonth;
                    break;
            }
            return video;
        }

        private string getResponseMessage(Video video, TimeOption option)
        {
            string responseMessage = string.Empty;
            switch (option)
            {
                case TimeOption.ThisWeek:
                    responseMessage = string.Format(resources.mostViewedThisWeekResponse, video.Title, video.Views, video.Link);
                    break;
                case TimeOption.ThisMonth:
                    responseMessage = string.Format(resources.mostViewedThisMonthResponse, video.Title, video.Views, video.Link);
                    break;
                case TimeOption.ThisYear:
                    responseMessage = string.Format(resources.mostViewedThisYearResponse, video.Title, video.Views, video.Link);
                    break;
            }
            return responseMessage;
        }

        private TimeOption getOption(string question)
        {
            TimeOption option = TimeOption.notSpecified;
            EscapeSanitizer escaptesanitzer = new EscapeSanitizer();
            string satizedThisWeekResouce = escaptesanitzer.Sanitize(resources.thisWeek);
            string satizedThisMonthResouce = escaptesanitzer.Sanitize(resources.thisMonth);
            string satizedThisYearResouce = escaptesanitzer.Sanitize(resources.thisYear);
            if (question.Contains(satizedThisWeekResouce))
            {
                option= TimeOption.ThisWeek;
            }
            if (question.Contains(satizedThisMonthResouce))
            {
                option= TimeOption.ThisMonth;
            }
            if (question.Contains(satizedThisYearResouce))
            {
                option= TimeOption.ThisYear;
            }
            return option;
        }
    }
}