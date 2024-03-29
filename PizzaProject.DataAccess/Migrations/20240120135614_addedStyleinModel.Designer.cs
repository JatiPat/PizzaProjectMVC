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
    [Migration("20240120135614_addedStyleinModel")]
    partial class addedStyleinModel
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PizzaStyleId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PizzaStyleId");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = " Mozzarella , Feta, Parmesan, Cheddar, and Ricotta",
                            Name = "Five Cheese Pizza",
                            PizzaStyleId = 1,
                            Price = 19.199999999999999
                        },
                        new
                        {
                            Id = 2,
                            Description = " Green Pepper, Black Olives, and Sun Dried Tomatoes",
                            Name = "Killer Veggie Pizza",
                            PizzaStyleId = 2,
                            Price = 13.5
                        },
                        new
                        {
                            Id = 3,
                            Description = "Chocolate, Vanilla, or Strawberry",
                            Name = "Ice Cream Pizza",
                            PizzaStyleId = 1,
                            Price = 2.5
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
