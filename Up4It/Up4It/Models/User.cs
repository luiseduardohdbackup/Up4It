using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Up4It.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "provider_id")]
        public string UserId { get; set; }
        [JsonProperty(PropertyName = "registration_provider")]
        public string AuthorizationProvider { get; set; }
        [JsonProperty(PropertyName = "registration_latitude")]
        public string RegistrationLatitude { get; set; }
        [JsonProperty(PropertyName = "registration_longitude")]
        public string RegistrationLongitude { get; set; }
        [JsonProperty(PropertyName = "last_checkin")]
        public DateTime LastCheckin { get; set; }
        [JsonProperty(PropertyName = "last_checkin_latitude")]
        public string LastCheckinLatitude { get; set; }
        [JsonProperty(PropertyName = "last_checkin_longitude")]
        public string LastCheckinLongitude { get; set; }
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }
    }
}
