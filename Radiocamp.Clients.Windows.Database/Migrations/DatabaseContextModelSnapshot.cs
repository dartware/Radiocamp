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
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("Dartware.Radiocamp.Clients.Windows.Core.Models.WindowsSettings", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

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
                            Id = new Guid("54760cde-e8e3-4bc4-91a2-981e1b616f10"),
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
