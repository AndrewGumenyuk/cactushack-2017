using Newtonsoft.Json;

namespace HealthyFood.ViewModels
{
    public class Recipe
    {
        public Recipe(
            string name,
            string thumbnail,
            string content)
        {
            Name = name;
            Thumbnail = thumbnail;
            Content = content;
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; }

        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; }
    }
}
