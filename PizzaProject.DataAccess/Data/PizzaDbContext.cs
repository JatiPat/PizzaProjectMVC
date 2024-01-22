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
                new PizzaStyle { Id = 3, Name = "Detroit", DisplayOrder = 3 },
                new PizzaStyle { Id = 4, Name = "Neapolitan", DisplayOrder = 4 },
                new PizzaStyle { Id = 5, Name = "Sicilian", DisplayOrder = 5 },
                new PizzaStyle { Id = 6, Name = "Greek", DisplayOrder = 6 },
                new PizzaStyle { Id = 7, Name = "California", DisplayOrder = 7 },
                new PizzaStyle { Id = 8, Name = "St. Louis", DisplayOrder = 8 }

                );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza
                {
                    Id = 1,
                    Name = "Five Cheese Pizza",
                    Description = "Large, foldable slices with a thin crust with five different cheeses",
                    Price = 19.99,
                    PizzaStyleId = 1,
                    ImageURL = "",
                    Ingredients = "Mozzarella, Feta, Parmesan, Cheddar, Ricotta",
                    Veggie = "Yes"
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Killer Veggie Pizza",
                    Description = "Rising crust slices with three different veggie options",
                    Price = 13.99,
                    PizzaStyleId = 1,
                    ImageURL = "",
                    Ingredients = "Green Pepper, Black Olives, and Sun Dried Tomatoes",
                    Veggie = "Yes"
                },
                new Pizza { 
                    Id = 3, 
                    Name = "Ice Cream Pizza", 
                    Description = "A quick dessert with three different ice cream options", 
                    Price = 2.99, 
                    PizzaStyleId = 4, 
                    ImageURL = "",
                    Ingredients = "Homemade Ice Cream with Chocolate, Vanilla, or Strawberry options",
                    Veggie = "Yes"

                },
                new Pizza
                {
                    Id = 4,
                    Name = "Classic Neapolitan",
                    Description = "Traditional Italian pizza with a thin, soft crust",
                    Price = 17.99,
                    PizzaStyleId = 4,
                    ImageURL = "",
                    Ingredients = "Tomato Sauce, Mozzarella Cheese, Basil",
                    Veggie = "Yes"
                },
                new Pizza
                {
                    Id = 5,
                    Name = "Classic Chicago",
                    Description = "Deep-dish pizza known for its thick, buttery crust",
                    Price = 19.99,
                    PizzaStyleId = 2,
                    ImageURL = "",
                    Ingredients = "Tomato Sauce, Mozzarella Cheese, Sausage",
                    Veggie = "No"
                },
                new Pizza
                {
                    Id = 6,
                    Name = "Classic New York",
                    Description = " Large, foldable slices with a thin crust.",
                    Price = 20.99,
                    PizzaStyleId = 1,
                    ImageURL = "",
                    Ingredients = "Tomato Sauce, Mozzarella Cheese, Pepperoni",
                    Veggie = "No"
                },
                new Pizza
                {
                    Id = 7,
                    Name = "Classic Sicilian",
                    Description = "Square-shaped pizza with a thick crust",
                    Price = 19.99,
                    PizzaStyleId = 5,
                    ImageURL = "",
                    Ingredients = "Tomato Sauce, Mozzarella Cheese, Olives",
                    Veggie = "Yes"
                },
                new Pizza
                {
                    Id = 8,
                    Name = "Classic Detroit Pizza",
                    Description = " Rectangular pizza with a thick, crispy crust",
                    Price = 21.99,
                    PizzaStyleId = 3,
                    ImageURL = "",
                    Ingredients = "Tomato Sauce, Brick Cheese, Pepperoni",
                    Veggie = "No"
                });
        }
    }
}
