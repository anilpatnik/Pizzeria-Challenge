using System.Collections.Generic;
using System.Threading.Tasks;
using LOR.Models;

namespace LOR.Services
{
    public interface IPizzaService
    {
        /// <summary>
        /// Get Stores
        /// </summary>
        Task<IEnumerable<Location>> GetLocationsAsync();

        /// <summary>
        /// Get Pizza Type
        /// </summary>
        /// <returns></returns>
        Task<PizzaType> GetPizzaTypeAsync(int pizzaTypeId);

        /// <summary>
        /// Get Store Menu
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Menu>> GetMenuAsync(int locationId);

        /// <summary>
        /// Get Pizza with Ingredients
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pizza>> GetPizzaAsync(int pizzaTypeId);

        /// <summary>
        /// Get Pizza Ingredients
        /// </summary>
        /// <returns>Ingredients</returns>
        Task<IEnumerable<string>> GetPizzaIngredientsAsync(int pizzaTypeId);

        /// <summary>
        /// Get Order Price
        /// </summary>
        /// <returns>Total Price</returns>
        double GetOrderPrice(IEnumerable<Menu> menu, int locationId, int pizzaTypeId, int quantity);
    }
}
