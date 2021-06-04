﻿// <auto-generated />
using System;
using ITProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ITProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210604002958_SeedData")]
    partial class SeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ITProject.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                //     b.HasData(
                //         new
                //         {
                //             Id = 1,
                //             Name = "Cairo"
                //         },
                //         new
                //         {
                //             Id = 2,
                //             Name = "Sharqia"
                //         },
                //         new
                //         {
                //             Id = 3,
                //             Name = "Luxor"
                //         },
                //         new
                //         {
                //             Id = 4,
                //             Name = "Aswan"
                //         },
                //         new
                //         {
                //             Id = 5,
                //             Name = "Alexandria"
                //         });
                });

            modelBuilder.Entity("ITProject.Models.Travel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("FromCityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("ToCityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FromCityId");

                    b.HasIndex("ToCityId");

                    b.ToTable("Travels");

                    // b.HasData(
                    //     new
                    //     {
                    //         Id = 1,
                    //         FromCityId = 1,
                    //         StartAt = new DateTime(2021, 6, 4, 14, 29, 58, 199, DateTimeKind.Local).AddTicks(6789),
                    //         Title = "Travel Cairo to Sharqia",
                    //         ToCityId = 2
                    //     },
                    //     new
                    //     {
                    //         Id = 2,
                    //         FromCityId = 2,
                    //         StartAt = new DateTime(2021, 6, 4, 14, 29, 58, 201, DateTimeKind.Local).AddTicks(3051),
                    //         Title = "Travel Sharqia to Luxor",
                    //         ToCityId = 3
                    //     },
                    //     new
                    //     {
                    //         Id = 3,
                    //         FromCityId = 3,
                    //         StartAt = new DateTime(2021, 6, 4, 14, 29, 58, 201, DateTimeKind.Local).AddTicks(3070),
                    //         Title = "Travel Luxor to Aswan",
                    //         ToCityId = 4
                    //     },
                    //     new
                    //     {
                    //         Id = 4,
                    //         FromCityId = 4,
                    //         StartAt = new DateTime(2021, 6, 4, 14, 29, 58, 201, DateTimeKind.Local).AddTicks(3074),
                    //         Title = "Travel Aswan to Alexandria",
                    //         ToCityId = 5
                    //     },
                    //     new
                    //     {
                    //         Id = 5,
                    //         FromCityId = 5,
                    //         StartAt = new DateTime(2021, 6, 4, 14, 29, 58, 201, DateTimeKind.Local).AddTicks(3076),
                    //         Title = "Travel Alexandria to Sharqia",
                    //         ToCityId = 2
                    //     });
                });

            modelBuilder.Entity("ITProject.Models.Travel", b =>
                {
                    b.HasOne("ITProject.Models.City", "FromCity")
                        .WithMany()
                        .HasForeignKey("FromCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITProject.Models.City", "ToCity")
                        .WithMany()
                        .HasForeignKey("ToCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromCity");

                    b.Navigation("ToCity");
                });
#pragma warning restore 612, 618
        }
    }
}