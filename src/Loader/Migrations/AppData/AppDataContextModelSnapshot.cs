﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StatStore.Loader;

#nullable disable

namespace StatStore.Loader.Migrations.AppData
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StatStore.Loader.Core.Models.TestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TestModels");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Test Model"
                        });
                });

            modelBuilder.Entity("StatStore.Shared.SportsDataIO.Models.TimeFrame", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ApiSeason")
                        .HasColumnType("longtext");

                    b.Property<string>("ApiWeek")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FirstGameEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("FirstGameStart")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("HasEnded")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("HasFirstGameEnded")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("HasFirstGameStarted")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("HasGames")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("HasLastGameEnded")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("HasStarted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("LastGameEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("Season")
                        .HasColumnType("int");

                    b.Property<int?>("SeasonType")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Week")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CurrentTimeFrame");
                });
#pragma warning restore 612, 618
        }
    }
}