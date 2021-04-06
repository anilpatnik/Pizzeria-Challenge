using Microsoft.EntityFrameworkCore;
using LOR.Models;

namespace LOR.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated(); 
        }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<PizzaType> PizzaTypes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<Location>().HasData(MockDatabase.Locations);

            modelBuilder.Entity<PizzaType>().ToTable("PizzaTypes");
            modelBuilder.Entity<PizzaType>().HasData(MockDatabase.PizzaTypes);

            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<Ingredient>().HasData(MockDatabase.Ingredients);

            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<Menu>()
                .HasOne(x => x.Location)
                .WithMany()
                .HasForeignKey(x => x.LocationId);
            modelBuilder.Entity<Menu>()
                .HasOne(x => x.PizzaType)
                .WithMany()
                .HasForeignKey(x => x.PizzaTypeId);
            modelBuilder.Entity<Menu>().HasKey(x => new {x.LocationId, x.PizzaTypeId});
            modelBuilder.Entity<Menu>().HasData(MockDatabase.Menu);

            modelBuilder.Entity<Pizza>().ToTable("Pizzas");
            modelBuilder.Entity<Pizza>()
                .HasOne(x => x.PizzaType)
                .WithMany()
                .HasForeignKey(x => x.PizzaTypeId);
            modelBuilder.Entity<Pizza>()
                .HasOne(x => x.Ingredient)
                .WithMany()
                .HasForeignKey(x => x.IngredientId);
            modelBuilder.Entity<Pizza>().HasKey(x => new { x.PizzaTypeId, x.IngredientId });
            modelBuilder.Entity<Pizza>().HasData(MockDatabase.Pizzas);
        }
    }
}
