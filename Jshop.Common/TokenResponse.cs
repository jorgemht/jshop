namespace Jshop.Common
{
    using Newtonsoft.Json;
    using System;

    public class TokenResponse
    {
        [JsonProperty("token")]
        public string token { get; set; }

        [JsonProperty("expiration")]
        public DateTimeOffset expiration { get; set; }
    }
}
