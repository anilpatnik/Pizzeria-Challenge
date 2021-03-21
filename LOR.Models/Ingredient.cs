using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LOR.Models
{
    public class Ingredient: Base
    {
        [JsonIgnore]
        public IList<Pizza> Pizzas { get; set; }
    }
}
