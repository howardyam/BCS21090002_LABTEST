using BCS21090002_LABTEST.ViewModel;

using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BCS21090002_LABTEST.Model
{

    public class PostRecord
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }
    }

}
