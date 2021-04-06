using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LOR.Models;
using LOR.Repositories;

namespace LOR.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        /// <summary>
        /// Get Stores
        /// </summary>
        public async Task<IEnumerable<Location>> GetLocationsAsync() => await _pizzaRepository.GetLocationsAsync();

        /// <summary>
        /// Get Pizza Type
        /// </summary>
        /// <returns></returns>
        public async Task<PizzaType> GetPizzaTypeAsync(int pizzaTypeId)
        {
            var pizzaTypes = await _pizzaRepository.GetPizzaTypesAsync();

            return pizzaTypes.FirstOrDefault(x => x.Id == pizzaTypeId);
        }

        /// <summary>
        /// Get Store Menu
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Menu>> GetMenuAsync(int locationId)
        {
            var menu = await _pizzaRepository.GetMenuAsync();

            return menu.Where(x => x.LocationId == locationId);
        }

        /// <summary>
        /// Get Pizza with Ingredients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Pizza>> GetPizzaAsync(int pizzaTypeId)
        {
            var pizzas = await _pizzaRepository.GetPizzasAsync();

            return pizzas.Where(x => x.PizzaTypeId == pizzaTypeId);
        }

        /// <summary>
        /// Get Pizza Ingredients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetPizzaIngredientsAsync(int pizzaTypeId)
        {
            var pizza = await GetPizzaAsync(pizzaTypeId);
            
            return pizza.Select(p => p.Ingredient.Name);
        }

        /// <summary>
        /// Get Order Price
        /// </summary>
        /// <returns>Total Price</returns>
        public double GetOrderPrice(IEnumerable<Menu> menu, int locationId, int pizzaTypeId, int quantity)
        {
            var pizzaPrice = menu.FirstOrDefault(x => x.LocationId == locationId && x.PizzaTypeId == pizzaTypeId).Price;
            
            return pizzaPrice * quantity;
        }
    }
}
