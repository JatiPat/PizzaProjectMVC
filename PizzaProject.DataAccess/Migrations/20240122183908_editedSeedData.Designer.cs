﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaProject.DataAccess.Data;

#nullable disable

namespace PizzaProject.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20240122183908_editedSeedData")]
    partial class editedSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaProject.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PizzaStyleId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Veggie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PizzaStyleId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Large, foldable slices with a thin crust with five different cheeses",
                            ImageURL = "",
                            Ingredients = "Mozzarella, Feta, Parmesan, Cheddar, Ricotta",
                            Name = "Five Cheese Pizza",
                            PizzaStyleId = 1,
                            Price = 19.989999999999998,
                            Veggie = "Yes"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Rising crust slices with three different veggie options",
                            ImageURL = "",
                            Ingredients = "Green Pepper, Black Olives, and Sun Dried Tomatoes",
                            Name = "Killer Veggie Pizza",
                            PizzaStyleId = 1,
                            Price = 13.99,
                            Veggie = "Yes"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A quick dessert with three different ice cream options",
                            ImageURL = "",
                            Ingredients = "Homemade Ice Cream with Chocolate, Vanilla, or Strawberry options",
                            Name = "Ice Cream Pizza",
                            PizzaStyleId = 4,
                            Price = 2.9900000000000002,
                            Veggie = "Yes"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Traditional Italian pizza with a thin, soft crust",
                            ImageURL = "",
                            Ingredients = "Tomato Sauce, Mozzarella Cheese, Basil",
                            Name = "Classic Neapolitan",
                            PizzaStyleId = 4,
                            Price = 17.989999999999998,
                            Veggie = "Yes"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Deep-dish pizza known for its thick, buttery crust",
                            ImageURL = "",
                            Ingredients = "Tomato Sauce, Mozzarella Cheese, Sausage",
                            Name = "Classic Chicago",
                            PizzaStyleId = 2,
                            Price = 19.989999999999998,
                            Veggie = "No"
                        },
                        new
                        {
                            Id = 6,
                            Description = " Large, foldable slices with a thin crust.",
                            ImageURL = "",
                            Ingredients = "Tomato Sauce, Mozzarella Cheese, Pepperoni",
                            Name = "Classic New York",
                            PizzaStyleId = 1,
                            Price = 20.989999999999998,
                            Veggie = "No"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Square-shaped pizza with a thick crust",
                            ImageURL = "",
                            Ingredients = "Tomato Sauce, Mozzarella Cheese, Olives",
                            Name = "Classic Sicilian",
                            PizzaStyleId = 5,
                            Price = 19.989999999999998,
                            Veggie = "Yes"
                        },
                        new
                        {
                            Id = 8,
                            Description = " Rectangular pizza with a thick, crispy crust",
                            ImageURL = "",
                            Ingredients = "Tomato Sauce, Brick Cheese, Pepperoni",
                            Name = "Classic Detroit Pizza",
                            PizzaStyleId = 3,
                            Price = 21.989999999999998,
                            Veggie = "No"
                        });
                });

            modelBuilder.Entity("PizzaProject.Models.PizzaStyle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PizzaStyles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "New York"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Chicago"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Detroit"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Neapolitan"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 5,
                            Name = "Sicilian"
                        },
                        new
                        {
                            Id = 6,
                            DisplayOrder = 6,
                            Name = "Greek"
                        },
                        new
                        {
                            Id = 7,
                            DisplayOrder = 7,
                            Name = "California"
                        },
                        new
                        {
                            Id = 8,
                            DisplayOrder = 8,
                            Name = "St. Louis"
                        });
                });

            modelBuilder.Entity("PizzaProject.Models.Pizza", b =>
                {
                    b.HasOne("PizzaProject.Models.PizzaStyle", "PizzaStyle")
                        .WithMany()
                        .HasForeignKey("PizzaStyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PizzaStyle");
                });
#pragma warning restore 612, 618
        }
    }
}