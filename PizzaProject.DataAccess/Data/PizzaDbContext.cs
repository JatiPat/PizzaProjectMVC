using Microsoft.EntityFrameworkCore;
using PizzaProject.Models;

namespace PizzaProject.DataAccess.Data
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) //whatever options PizzaDbContext has will be DbContext's options as well
        {
            //go to program.cs to see use
        }

        public DbSet<PizzaStyle> PizzaStyles {  get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaStyle>().HasData(
                new PizzaStyle { Id = 1, Name = "New York", DisplayOrder = 1 },
                new PizzaStyle { Id = 2, Name = "Chicago", DisplayOrder = 2 },
                new PizzaStyle { Id = 3, Name = "Detroit", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Five Cheese Pizza", Description = " Mozzarella , Feta, Parmesan, Cheddar, and Ricotta", Price = 19.20,PizzaStyleId = 1, ImageURL = "" },
                new Pizza { Id = 2, Name = "Killer Veggie Pizza", Description = " Green Pepper, Black Olives, and Sun Dried Tomatoes", Price = 13.50, PizzaStyleId = 2, ImageURL = "" },
                new Pizza { Id = 3, Name = "Ice Cream Pizza", Description = "Chocolate, Vanilla, or Strawberry", Price = 2.50, PizzaStyleId = 1, ImageURL = "" }
                );
        }
    }
}
