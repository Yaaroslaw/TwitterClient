using System.Text;

namespace TwitterClient.Controllers
{
    public class Tweets
    {
        public Tweet[] results;
    }
    public class Tweet
    {
        public string UserName { get; set; }

        public string TweetText { get; set; }

    }
}