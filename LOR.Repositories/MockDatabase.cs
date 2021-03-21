using System.Collections.Generic;
using LOR.Models;

namespace LOR.Repositories
{
    public static class MockDatabase
    {
        public static IEnumerable<Location> Locations => new List<Location> 
        {
            new Location {Id = 1, Name = "Sydney"},
            new Location {Id = 2, Name = "Brisbane"},
            new Location {Id = 3, Name = "Gold Coast"}
        };

        public static IEnumerable<PizzaType> PizzaTypes => new List<PizzaType>
        {
            new PizzaType { Id = 1, Name = "Capriciosa" },
            new PizzaType { Id = 2, Name = "Florenza", CutNotes = "Cutting pizza into 6 slices with a special knife..." },
            new PizzaType { Id = 3, Name = "Margherita", BakeNotes = "Baking pizza for 15 minutes at 200 degrees..." },
            new PizzaType { Id = 4, Name = "Inferno" }
        };

        public static IEnumerable<Ingredient> Ingredients => new List<Ingredient>
        {
            new Ingredient { Id = 1, Name = "Chicken" },
            new Ingredient { Id = 2, Name = "Ham" },
            new Ingredient { Id = 3, Name = "Pastrami" },
            new Ingredient { Id = 4, Name = "Mushrooms" },
            new Ingredient { Id = 5, Name = "Onion" },
            new Ingredient { Id = 6, Name = "Garlic" },
            new Ingredient { Id = 7, Name = "Olives" },
            new Ingredient { Id = 8, Name = "Chili Peppers" },
            new Ingredient { Id = 9, Name = "Cheese" },
            new Ingredient { Id = 10, Name = "Mozarella" },
            new Ingredient { Id = 11, Name = "Feta" },
            new Ingredient { Id = 12, Name = "Oregano" },
            new Ingredient { Id = 13, Name = "Rosemary" }
        };

        public static IEnumerable<Menu> Menu => new List<Menu>
        {
            new Menu { LocationId = 1, PizzaTypeId = 1, Price = 30.00 },
            new Menu { LocationId = 1, PizzaTypeId = 4, Price = 31.00 },

            new Menu { LocationId = 2, PizzaTypeId = 1, Price = 20.00 },
            new Menu { LocationId = 2, PizzaTypeId = 2, Price = 21.00 },
            new Menu { LocationId = 2, PizzaTypeId = 3, Price = 22.00 }
        };

        public static IEnumerable<Pizza> Pizzas => new List<Pizza>
        {
            new Pizza { PizzaTypeId = 1, IngredientId = 2 },
            new Pizza { PizzaTypeId = 1, IngredientId = 4 },
            new Pizza { PizzaTypeId = 1, IngredientId = 9 },
            new Pizza { PizzaTypeId = 1, IngredientId = 10 },

            new Pizza { PizzaTypeId = 2, IngredientId = 3 },
            new Pizza { PizzaTypeId = 2, IngredientId = 7 },
            new Pizza { PizzaTypeId = 2, IngredientId = 5 },
            new Pizza { PizzaTypeId = 2, IngredientId = 10 },

            new Pizza { PizzaTypeId = 3, IngredientId = 5 },
            new Pizza { PizzaTypeId = 3, IngredientId = 6 },
            new Pizza { PizzaTypeId = 3, IngredientId = 10 },
            new Pizza { PizzaTypeId = 3, IngredientId = 12 },

            new Pizza { PizzaTypeId = 4, IngredientId = 1 },
            new Pizza { PizzaTypeId = 4, IngredientId = 8 },
            new Pizza { PizzaTypeId = 4, IngredientId = 9 },
            new Pizza { PizzaTypeId = 4, IngredientId = 10 }
        };
    }
}
