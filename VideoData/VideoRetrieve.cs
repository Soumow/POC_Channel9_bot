using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace POC_Channel9_bot.VideoData
{
    public class VideoRetrieve : IVideoRetrieve
    {
        public Event LiveEvent
        {
            get
            {
                Event ch9event = getEvent("https://channel9.msdn.com/odata/Events/Live");
                return ch9event;
            }
        }

        public Event LatestEvent
        {
            get
            {
                Event ch9event = getEvent("https://channel9.msdn.com/odata/Events?$orderby=Starts%20desc");
                return ch9event;
            }
        }

        public Video LatestFeaturedVideo
        {
            get
            {
                Video video = getVideo("https://channel9.msdn.com/odata/Featured?$expand=Channel9.ODataModel.Entry/Area,Channel9.ODataModel.Session/Event"); 
                return video;
            }
        }

        public Video MostViewedThisWeek
        {
            get
            {
                Video video = getVideo("https://channel9.msdn.com/odata/Entries?$expand=Area,Authors&$orderby=ViewsThisWeek%20desc");
                return video;
            }
        }

        public Video MostViewedThisMonth
        {
            get
            {
                Video video = getVideo("https://channel9.msdn.com/odata/Entries?$expand=Area,Authors&$orderby=ViewsThisMonth%20desc");
                return video;
            }
        }

        public List<Video> SearchVideos(string query)
        {
            string dataapi = "https://channel9.msdn.com/odata/Search?query=" + query + "&$filter=HasVideo eq true&$expand=Channel9.ODataModel.Entry/Area,Channel9.ODataModel.Entry/Authors,Channel9.ODataModel.Entry/Tags,Channel9.ODataModel.Session/Event,Channel9.ODataModel.Session/Speakers,Channel9.ODataModel.Session/Tags";
            List<Video> listVideos = getListVideos(dataapi);
            //Search?query={0}&$filter=HasVideo eq true&$expand=Channel9.ODataModel.Entry/Area,Channel9.ODataModel.Entry/Authors,Channel9.ODataModel.Entry/Tags,Channel9.ODataModel.Session/Event,Channel9.ODataModel.Session/Speakers,Channel9.ODataModel.Session/Tags
            return listVideos;
        }

        private List<Video> getListVideos(string dataapi)
        {
            List<Video> listVideos = new List<Video>();
            //video.Link = string.Empty;
            //video.Title = string.Empty;
            //video.Views = string.Empty;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(dataapi);
                JObject objects = JObject.Parse(json);
                JToken token = null;
                bool exist = objects.TryGetValue("value", out token);
                if (token.Count() != 0)
                {
                    for (var i =0; i <5; i++)
                    {
                        Video video = new Video();
                        video.Title = token[i]["Title"].ToString();
                        video.Link = token[i]["Permalink"].ToString();
                        video.Views = token[i]["Views"].ToString();
                        listVideos.Add(video);
                    }
                }
            }
            return listVideos;
        }

        private Video getVideo(string dataapi)
        {
            Video video = new Video();
            video.Link = string.Empty;
            video.Title = string.Empty;
            video.Views = string.Empty;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(dataapi);
                JObject objects = JObject.Parse(json);
                JToken token = null;
                bool exist = objects.TryGetValue("value", out token);
                if (token.Count() != 0)
                {
                    video.Title = token.First["Title"].ToString();
                    video.Link = token.First["Permalink"].ToString();
                    video.Views = token.First["Views"].ToString();
                }

            }
            return video;
        }

        private Event getEvent(string dataapi)
        {
            Event ch9event = new Event();
            ch9event.Link = string.Empty;
            ch9event.Title = string.Empty;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(dataapi);
                JObject objects = JObject.Parse(json);
                JToken token = null;
                bool exist = objects.TryGetValue("value", out token);
                if (token.Count() != 0)
                {
                    ch9event.Title = token.First["DisplayName"].ToString();
                    ch9event.Link = token.First["Permalink"].ToString();
                }
            }
            return ch9event;
        }
    }
}




