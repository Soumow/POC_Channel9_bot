using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_Channel9_bot.VideoData
{
    interface IVideoRetrieve
    {
        Video MostViewedThisWeek { get; }
        Event LiveEvent { get; }
        Event LatestEvent { get; }
        Video LatestFeaturedVideo { get; }
        Video MostViewedThisMonth { get; }
        List<Video> SearchVideos(string query);
    }
}
