using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Text;


namespace DiscordBot
{
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string Token { get; private set; }
        [JsonProperty("CommandPrefix")]
        public string Prefix { get; private set; }
        [JsonProperty("appSecret")]
        public string appSecret { get; private set; }
        [JsonProperty("appId")]
        public string appID { get; private set; }    

    }
}
