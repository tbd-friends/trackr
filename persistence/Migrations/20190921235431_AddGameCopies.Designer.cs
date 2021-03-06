﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using persistence;

namespace persistence.Migrations
{
    [DbContext(typeof(GamesContext))]
    [Migration("20190921235431_AddGameCopies")]
    partial class AddGameCopies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("models.GameCopy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("PricePaid")
                        .HasColumnType("decimal(8,2)");

                    b.Property<DateTime?>("PurchasedOn");

                    b.Property<Guid>("SystemTitleId");

                    b.HasKey("Id");

                    b.ToTable("GameCopies");
                });

            modelBuilder.Entity("models.GameCopyAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Attribute");

                    b.Property<Guid>("GameCopyId");

                    b.HasKey("Id");

                    b.ToTable("GameCopyAttributes");
                });

            modelBuilder.Entity("models.GameSystem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Name");

                    b.Property<short?>("ReleaseYear");

                    b.HasKey("Id");

                    b.ToTable("Systems");
                });

            modelBuilder.Entity("models.GameTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GameTitles");
                });

            modelBuilder.Entity("models.SystemTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newid()");

                    b.Property<short?>("ReleaseYear");

                    b.Property<Guid>("SystemId");

                    b.Property<Guid>("TitleId");

                    b.HasKey("Id");

                    b.HasIndex("SystemId");

                    b.HasIndex("TitleId");

                    b.ToTable("SystemTitles");
                });

            modelBuilder.Entity("models.SystemTitle", b =>
                {
                    b.HasOne("models.GameSystem", "System")
                        .WithMany()
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("models.GameTitle", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
