﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Api.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240502075844_CreateCryptoNetworks")]
    partial class CreateCryptoNetworks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Entities.Models.Crypto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CryptoId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("Cryptos");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4743),
                            Description = "Bitcoin",
                            Symbol = "BTC"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4745),
                            Description = "Ethereum",
                            Symbol = "ETH"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4746),
                            Description = "Litecoin",
                            Symbol = "LTC"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4747),
                            Description = "Dash",
                            Symbol = "Dash"
                        });
                });

            modelBuilder.Entity("Entities.Models.CryptoNetwork", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CryptoNetworkId");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<long>("CryptoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CryptoId");

                    b.ToTable("CryptoNetworks");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4876),
                            CryptoId = 1L,
                            Description = "Main network for BTC",
                            Name = "main"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4877),
                            CryptoId = 1L,
                            Description = "Test network for BTC",
                            Name = "test3"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4879),
                            CryptoId = 2L,
                            Description = "Main network for ETH",
                            Name = "main"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4880),
                            CryptoId = 3L,
                            Description = "Main network for LTC",
                            Name = "main"
                        },
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(2024, 5, 2, 7, 58, 44, 307, DateTimeKind.Utc).AddTicks(4881),
                            CryptoId = 4L,
                            Description = "Main network for Dash",
                            Name = "main"
                        });
                });

            modelBuilder.Entity("Entities.Models.CryptoNetwork", b =>
                {
                    b.HasOne("Entities.Models.Crypto", "Crypto")
                        .WithMany("CryptoNetworks")
                        .HasForeignKey("CryptoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crypto");
                });

            modelBuilder.Entity("Entities.Models.Crypto", b =>
                {
                    b.Navigation("CryptoNetworks");
                });
#pragma warning restore 612, 618
        }
    }
}
