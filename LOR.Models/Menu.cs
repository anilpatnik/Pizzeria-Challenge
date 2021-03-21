using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LOR.Models
{
    public class Menu
    {
        public int LocationId { get; set; }

        [JsonIgnore]
        public Location Location { get; set; }

        public int PizzaTypeId { get; set; }

        [JsonIgnore]
        public PizzaType PizzaType { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
