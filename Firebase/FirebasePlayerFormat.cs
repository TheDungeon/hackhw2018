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

        [JsonProperty(propertyName: "jump")]
        public bool Jump { get; set; }

        [JsonProperty(propertyName: "stop")]
        public bool Stop { get; set; }

        [JsonProperty(propertyName: "won")]
        public bool Won { get; set; }
    }
}
