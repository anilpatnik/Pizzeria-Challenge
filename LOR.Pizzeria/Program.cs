using System;
using System.Linq;
using LOR.Repositories;
using LOR.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LOR.Pizzeria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IPizzaService, PizzaService>()
                .AddSingleton<IPizzaRepository, PizzaRepository>()
                .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("AppDbContext"))
                .BuildServiceProvider();

            // Program starts here
            RunAsync(serviceProvider.GetService<IPizzaService>());
        }

        private static async void RunAsync(IPizzaService pizzaService)
        {
            try
            {
                // Get stores
                Console.WriteLine($"\nWelcome to LOR Pizzeria! \n\nPlease select the store location: ");
                var locations = await pizzaService.GetLocationsAsync();
                locations.ToList().ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));

                // Get store specific menu
                Console.WriteLine($"\nPlease enter the store number to get the menu");
                var locationId = Utility.IsInputNumeric();
                var menu = await pizzaService.GetMenuAsync(locationId);
                if (menu.Any())
                {
                    menu.ToList().ForEach(async x =>
                    {
                        var ingredients = await pizzaService.GetPizzaIngredientsAsync(x.PizzaTypeId);
                        Console.WriteLine($"{x.PizzaType.Id}. {x.PizzaType.Name} - " +
                                          $"{Utility.CommaSeparatedList(ingredients)} - " +
                                          $"{x.Price:C}");
                    });

                    // Order pizza
                    Console.WriteLine("\nWhat can I get you? (please enter the pizza number to order)");
                    var pizzaTypeId = Utility.IsInputNumeric();
                    if (menu.Any(x => x.LocationId == locationId && x.PizzaTypeId == pizzaTypeId))
                    {
                        // Order quantity 
                        Console.WriteLine("\nHow many pizzas would you like to have?");
                        var quantity = Utility.IsInputNumeric();
                        if (quantity > 0)
                        {
                            var pizzaType = await pizzaService.GetPizzaTypeAsync(pizzaTypeId);
                            var ingredients = await pizzaService.GetPizzaIngredientsAsync(pizzaTypeId);
                            
                            // Preparing pizza 
                            Console.WriteLine($"\nPreparing {pizzaType.Name}...");
                            Console.Write("\nAdding...");
                            ingredients.ToList().ForEach(x => Console.Write($"{x} "));

                            // Bake, Cut and Box
                            Console.WriteLine($"\n\n{Utility.Bake(pizzaType.BakeNotes)}");
                            Console.WriteLine($"\n{Utility.Cut(pizzaType.CutNotes)}");
                            Console.WriteLine($"\n{Utility.Box}");

                            // Receipt
                            var totalPrice = pizzaService.GetOrderPrice(menu, locationId, pizzaTypeId, quantity);
                            Console.WriteLine($"\nTotal price: {totalPrice:C}");

                            // yay!
                            Console.WriteLine("\nYour pizza is ready!");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\n{Utility.THANK_YOU}, pizza is not available here.");
                    }
                }
                else
                {
                    Console.WriteLine($"\n{Utility.THANK_YOU}, we're opening here soon!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nYour pizza is not ready, {e.Message}");
                Console.Clear();
                RunAsync(pizzaService);
            }
        }
    }
}

