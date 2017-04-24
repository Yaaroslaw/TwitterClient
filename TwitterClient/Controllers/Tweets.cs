using System.Text;
using Newtonsoft.Json;

namespace TwitterClient.Controllers
{
    public class Tweets
    {
        public Tweet[] results;
    }
    public class Tweet
    {
        [JsonProperty("from_user")]
        public string UserName { get; set; }

        [JsonProperty("from_user")]
        public string TweetText { get; set; }

    }
}