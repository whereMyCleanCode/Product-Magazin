﻿// <auto-generated />
using System;
using System.Collections.Generic;
using EfLesson.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfLesson.Migrations
{
    [DbContext(typeof(ProductDb))]
    [Migration("20230505144316_InitialCreat")]
    partial class InitialCreat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfLesson.Models.BasketModel", b =>
                {
                    b.Property<int>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("basket_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BasketId"));

                    b.Property<List<int>>("ProductId")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("fk_product_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_user_id");

                    b.HasKey("BasketId");

                    b.HasIndex("UserId");

                    b.ToTable("baskets");
                });

            modelBuilder.Entity("EfLesson.Models.OrderModel", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("text")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("OrderEndTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_end_time");

                    b.Property<DateTime>("OrderStartTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_star_time");

                    b.Property<bool>("OrderState")
                        .HasColumnType("boolean")
                        .HasColumnName("orders_state");

                    b.Property<List<int>>("ProductsId")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("fk_products_id_from_order");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("fk_user_id_for_basket");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("EfLesson.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int?>("BasketModelBasketId")
                        .HasColumnType("integer");

                    b.Property<string>("OrderModelOrderId")
                        .HasColumnType("text");

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

                    b.HasKey("ProductId");

                    b.HasIndex("BasketModelBasketId");

                    b.HasIndex("OrderModelOrderId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("EfLesson.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.Property<List<int>>("OrdersId")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("fk_order_for_user_id_from_orders");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("integer")
                        .HasColumnName("user_phone");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("EfLesson.Models.BasketModel", b =>
                {
                    b.HasOne("EfLesson.Models.UserModel", "UserModel")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserModel");
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

            modelBuilder.Entity("EfLesson.Models.Product", b =>
                {
                    b.HasOne("EfLesson.Models.BasketModel", null)
                        .WithMany("ProductsFromBasket")
                        .HasForeignKey("BasketModelBasketId");

                    b.HasOne("EfLesson.Models.OrderModel", null)
                        .WithMany("ProductsFromOrder")
                        .HasForeignKey("OrderModelOrderId");
                });

            modelBuilder.Entity("EfLesson.Models.BasketModel", b =>
                {
                    b.Navigation("ProductsFromBasket");
                });

            modelBuilder.Entity("EfLesson.Models.OrderModel", b =>
                {
                    b.Navigation("ProductsFromOrder");
                });

            modelBuilder.Entity("EfLesson.Models.UserModel", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}