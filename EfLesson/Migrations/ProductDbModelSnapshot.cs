﻿// <auto-generated />
using System;
using EfLesson.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfLesson.Migrations
{
    [DbContext(typeof(ProductDb))]
    partial class ProductDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfLesson.Models.BasketModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("basket_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("baskets");
                });

            modelBuilder.Entity("EfLesson.Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CountOfProduct")
                        .HasColumnType("integer")
                        .HasColumnName("count_of_product");

                    b.Property<DateTime>("OrderEndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_end_time");

                    b.Property<DateTime>("OrderStartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_star_time");

                    b.Property<bool>("OrderState")
                        .HasColumnType("boolean")
                        .HasColumnName("orders_state");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("EfLesson.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_category");

                    b.Property<int>("ProductCount")
                        .HasColumnType("integer")
                        .HasColumnName("product_count");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_name");

                    b.Property<string>("ProductPhoto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_photo");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("integer")
                        .HasColumnName("product_price");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("EfLesson.Models.ProductsFromBasket", b =>
                {
                    b.Property<int>("BasketId")
                        .HasColumnType("integer")
                        .HasColumnName("basket_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("BasketId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("products_from_basekt");
                });

            modelBuilder.Entity("EfLesson.Models.ProductsFromOrder", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("prodcuts_from_orders");
                });

            modelBuilder.Entity("EfLesson.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_address");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("integer")
                        .HasColumnName("user_phone");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("salt");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("EfLesson.Models.BasketModel", b =>
                {
                    b.HasOne("EfLesson.Models.UserModel", "User")
                        .WithOne("Basket")
                        .HasForeignKey("EfLesson.Models.BasketModel", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EfLesson.Models.OrderModel", b =>
                {
                    b.HasOne("EfLesson.Models.UserModel", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EfLesson.Models.ProductsFromBasket", b =>
                {
                    b.HasOne("EfLesson.Models.BasketModel", "Basket")
                        .WithMany("ProductsFromBaskets")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfLesson.Models.ProductModel", "Product")
                        .WithMany("ProductsFromBaskets")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EfLesson.Models.ProductsFromOrder", b =>
                {
                    b.HasOne("EfLesson.Models.OrderModel", "Order")
                        .WithMany("ProductsFromOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfLesson.Models.ProductModel", "Product")
                        .WithMany("ProductsFromOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EfLesson.Models.BasketModel", b =>
                {
                    b.Navigation("ProductsFromBaskets");
                });

            modelBuilder.Entity("EfLesson.Models.OrderModel", b =>
                {
                    b.Navigation("ProductsFromOrders");
                });

            modelBuilder.Entity("EfLesson.Models.ProductModel", b =>
                {
                    b.Navigation("ProductsFromBaskets");

                    b.Navigation("ProductsFromOrders");
                });

            modelBuilder.Entity("EfLesson.Models.UserModel", b =>
                {
                    b.Navigation("Basket")
                        .IsRequired();

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
