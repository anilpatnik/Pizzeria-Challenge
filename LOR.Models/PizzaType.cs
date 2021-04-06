using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LOR.Models
{
    public class PizzaType : Base
    {
        public string BakeNotes { get; set; }

        public string CutNotes { get; set; }

        [JsonIgnore]
        public IList<Menu> Menu { get; set; }

        [JsonIgnore]
        public IList<Pizza> Pizzas { get; set; }
    }
}
