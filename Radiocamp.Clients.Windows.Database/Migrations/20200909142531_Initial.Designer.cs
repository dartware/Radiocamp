﻿// <auto-generated />
using System;
using Dartware.Radiocamp.Clients.Windows.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dartware.Radiocamp.Clients.Windows.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200909142531_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("3f554723-f57a-4ab4-9b5c-df9a8aeb7e47"),
                            Command = 1,
                            IsEnabled = true,
                            Key = 62,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("df7491c5-cd12-44cb-ab74-689d7b641a09"),
                            Command = 2,
                            IsEnabled = true,
                            Key = 44,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("683ce175-86d9-4d46-9f73-1398cfc72374"),
                            Command = 3,
                            IsEnabled = true,
                            Key = 47,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("5a1a8148-5ca6-4643-9524-fa531119387c"),
                            Command = 4,
                            IsEnabled = true,
                            Key = 24,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("88432ee0-4232-4f70-869f-fda1b94479e8"),
                            Command = 5,
                            IsEnabled = true,
                            Key = 26,
                            ModifierKey = 1
                        },
                        new
                        {
                            Id = new Guid("ef9d8acd-cead-4d07-9107-39e9a9aac2e6"),
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

                    b.Property<bool>("HotkeysIsEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MainWindowHeight")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowLeft")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowTop")
                        .HasColumnType("REAL");

                    b.Property<double>("MainWindowWidth")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Settings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4802fbc1-1e06-4ef4-afd4-dc82fb22fce6"),
                            HotkeysIsEnabled = false,
                            MainWindowHeight = 0.0,
                            MainWindowLeft = 0.0,
                            MainWindowTop = 0.0,
                            MainWindowWidth = 0.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
