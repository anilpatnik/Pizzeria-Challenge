using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LOR.Models
{
    public class Location : Base
    {
        [JsonIgnore]
        public IList<Menu> Menu { get; set; }
    }
}
