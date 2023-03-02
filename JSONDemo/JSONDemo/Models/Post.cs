using Newtonsoft.Json;

namespace JSONDemo.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Post>>(myJsonResponse);
    public class Post
    {
        public int PostId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
