using System.Collections.Generic;
using System.Threading.Tasks;
using LOR.Models;
using Microsoft.EntityFrameworkCore;

namespace LOR.Repositories
{
    public class PizzaRepository : BaseRepository, IPizzaRepository
    {
        public PizzaRepository(AppDbContext context) : base(context) { }

        /// <summary>
        /// Get Stores
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _context.Locations
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Pizza Types
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PizzaType>> GetPizzaTypesAsync()
        {
            return await _context.PizzaTypes
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Pizza Ingredients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
        {
            return await _context.Ingredients
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Store Menu
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Menu>> GetMenuAsync()
        {
            return await _context.Menu
                .Include(x => x.Location)
                .Include(x => x.PizzaType)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Get Pizzas with Ingredients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Pizza>> GetPizzasAsync()
        {
            return await _context.Pizzas
                .Include(x => x.PizzaType)
                .Include(x => x.Ingredient)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
