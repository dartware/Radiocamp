﻿// <auto-generated />
using System;
using Dartware.Radiocamp.Clients.Windows.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dartware.Radiocamp.Clients.Windows.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("Dartware.Radiocamp.Clients.Windows.Core.Models.Hotkey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Command")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Key")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ModifierKey")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasAlternateKey("Command");

                    b.ToTable("Hotkeys");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d0e28a7d-193a-40c1-bf0a-26e16840c198"),
                            Command = 1,
                            IsEnabled = true,
                            Key = 62,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("2268b086-fffb-423f-a86a-f7657cdc2e6b"),
                            Command = 2,
                            IsEnabled = true,
                            Key = 44,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("8626d389-8c1e-48ce-ab1d-6296dba58b3d"),
                            Command = 3,
                            IsEnabled = true,
                            Key = 47,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("c21b1b88-4c01-4cc9-a127-054614c79df4"),
                            Command = 4,
                            IsEnabled = true,
                            Key = 24,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("fe674c8e-8f15-4f88-b24f-4b91d1b19879"),
                            Command = 5,
                            IsEnabled = true,
                            Key = 26,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("2d2bb85b-21f8-45c5-ba0b-bc27134f4fca"),
                            Command = 6,
                            IsEnabled = true,
                            Key = 67,
                            ModifierKey = 1
                        });
                });

            modelBuilder.Entity("Dartware.Radiocamp.Clients.Windows.Core.Models.WindowsSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ExportRadiostationsAll")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsCustomOnly")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsFavoritesOnly")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExportRadiostationsFormat")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsOnlyFavoritesOrCustom")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ExportRadiostationsPath")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ExportRadiostationsSaveFavoritesTags")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExportRadiostationsSaveSoundSettings")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HotkeysIsEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsNightMode")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Localization")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MainWindowHeight")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowLeft")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowTop")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowWidth")
                        .HasColumnType("REAL");

                    b.Property<int>("SearchEngine")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowFavoritesAtStart")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowOnlyCustomAtStart")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("StartMinimized")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("86a5bed0-5bd1-4bf9-99ab-68450eadbb6e"),
                            ExportRadiostationsAll = true,
                            ExportRadiostationsCustomOnly = false,
                            ExportRadiostationsFavoritesOnly = false,
                            ExportRadiostationsFormat = 0,
                            ExportRadiostationsOnlyFavoritesOrCustom = false,
                            ExportRadiostationsSaveFavoritesTags = true,
                            ExportRadiostationsSaveSoundSettings = true,
                            HotkeysIsEnabled = false,
                            IsNightMode = false,
                            Localization = 0,
                            MainWindowHeight = 0.0,
                            MainWindowLeft = 0.0,
                            MainWindowTop = 0.0,
                            MainWindowWidth = 0.0,
                            SearchEngine = 0,
                            ShowFavoritesAtStart = false,
                            ShowOnlyCustomAtStart = false,
                            StartMinimized = false
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
