using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Company.Function
{
    public class Counter 
    {
        [JsonProperty(PropertyName = "id")]
        public string Id {get; set;}

        [JsonProperty(PropertyName = "count")]
        public int Count {get; set;}
    }
}