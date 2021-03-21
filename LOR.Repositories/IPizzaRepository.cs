using System.Collections.Generic;
using System.Threading.Tasks;
using LOR.Models;

namespace LOR.Repositories
{
    public interface IPizzaRepository
    {
        /// <summary>
        /// Get Stores
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Location>> GetLocationsAsync();

        /// <summary>
        /// Get Pizza Types
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PizzaType>> GetPizzaTypesAsync();

        /// <summary>
        /// Get Pizza Ingredients
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Ingredient>> GetIngredientsAsync();

        /// <summary>
        /// Get Store Menu
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Menu>> GetMenuAsync();

        /// <summary>
        /// Get Pizzas with Ingredients
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pizza>> GetPizzasAsync();
    }
}
