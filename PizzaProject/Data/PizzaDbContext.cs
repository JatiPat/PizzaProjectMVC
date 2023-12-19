using Microsoft.EntityFrameworkCore;
using PizzaProject.Models;

namespace PizzaProject.Data
{
    public class PizzaDbContext : DbContext
    {
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options) //whatever options PizzaDbContext has will be DbContext's options as well
        {
            //go to program.cs to see use
        }

        public DbSet<PizzaStyle> PizzaStyles {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaStyle>().HasData(
                new PizzaStyle { Id = 1, Name = "New York", DisplayOrder = 1 },
                new PizzaStyle { Id = 2, Name = "Chicago", DisplayOrder = 2 },
                new PizzaStyle { Id = 3, Name = "Detroit", DisplayOrder = 3 }
                );
        }
    }
}
