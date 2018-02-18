using Newtonsoft.Json;

namespace HackHW2018.Firebase
{
    public class FirebasePlayerFormat
    {

        public string Key { get; set; }

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }

        [JsonProperty(propertyName: "color")]
        public int Color { get; set; }

        [JsonProperty(propertyName: "isAlive")]
        public bool IsAlive { get; set; }
    }
}
