using Newtonsoft.Json;

namespace GettyImages.Api.OnlineTests.StepBindings.TestModels
{
    [JsonObject]
    public class TestVideoMetaData
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}