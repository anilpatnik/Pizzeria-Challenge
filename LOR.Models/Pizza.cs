using System.Text.Json.Serialization;

namespace LOR.Models
{
    public class Pizza
    {
        public int PizzaTypeId { get; set; }

        [JsonIgnore]
        public PizzaType PizzaType { get; set; }

        public int IngredientId { get; set; }

        [JsonIgnore]
        public Ingredient Ingredient { get; set; }
    }
}
