using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Up4It.Models
{
    public class MeetUp
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "creator_id")]
        public string CreatorId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty(PropertyName = "end_time")]
        public DateTime? EndTime { get; set; }

        [JsonProperty(PropertyName = "start_latitude")]
        public string StartLatitude { get; set; }

        [JsonProperty(PropertyName = "start_longitude")]
        public string StartLongitude { get; set; }

        [JsonProperty(PropertyName = "start_location_name")]
        public string StartLocationName { get; set; }

        [JsonProperty(PropertyName = "start_location_address")]
        public string StartLocationAddress { get; set; }
    }
}
