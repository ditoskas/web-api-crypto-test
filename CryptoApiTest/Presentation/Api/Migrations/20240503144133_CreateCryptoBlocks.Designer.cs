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
    [Migration("20240503144133_CreateCryptoBlocks")]
    partial class CreateCryptoBlocks
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
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4771),
                            Description = "Bitcoin",
                            Symbol = "BTC"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4773),
                            Description = "Ethereum",
                            Symbol = "ETH"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4774),
                            Description = "Litecoin",
                            Symbol = "LTC"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4775),
                            Description = "Dash",
                            Symbol = "Dash"
                        });
                });

            modelBuilder.Entity("Entities.Models.CryptoBlock", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CryptoBlockId");

                    b.Property<long?>("BaseFee")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Chain")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("TEXT");

                    b.Property<string>("CoinbaseAddr")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<long>("CryptoNetworkId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Depth")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("Fees")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<long?>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MrklRoot")
                        .HasColumnType("TEXT");

                    b.Property<int?>("NTx")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NextTxids")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nonce")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PrevBlock")
                        .HasColumnType("TEXT");

                    b.Property<string>("PrevBlockUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReceivedTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("RelayedBy")
                        .HasColumnType("TEXT");

                    b.Property<long?>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("Total")
                        .HasColumnType("TEXT");

                    b.Property<string>("TxUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Ver")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CryptoNetworkId");

                    b.HasIndex("Hash")
                        .IsUnique();

                    b.ToTable("CryptoBlocks");
                });

            modelBuilder.Entity("Entities.Models.CryptoInternalTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CryptoInternalTransactionId");

                    b.Property<long>("CryptoBlockId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CryptoBlockId");

                    b.HasIndex("Hash")
                        .IsUnique();

                    b.ToTable("CryptoInternalTransactions");
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
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4932),
                            CryptoId = 1L,
                            Description = "Main network for BTC",
                            Name = "main"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4934),
                            CryptoId = 1L,
                            Description = "Test network for BTC",
                            Name = "test3"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4935),
                            CryptoId = 2L,
                            Description = "Main network for ETH",
                            Name = "main"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4936),
                            CryptoId = 3L,
                            Description = "Main network for LTC",
                            Name = "main"
                        },
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(2024, 5, 3, 14, 41, 33, 276, DateTimeKind.Utc).AddTicks(4937),
                            CryptoId = 4L,
                            Description = "Main network for Dash",
                            Name = "main"
                        });
                });

            modelBuilder.Entity("Entities.Models.CryptoTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("CryptoTransactionId");

                    b.Property<long>("CryptoBlockId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CryptoBlockId");

                    b.HasIndex("Hash")
                        .IsUnique();

                    b.ToTable("CryptoTransactions");
                });

            modelBuilder.Entity("Entities.Models.CryptoBlock", b =>
                {
                    b.HasOne("Entities.Models.CryptoNetwork", "CryptoNetwork")
                        .WithMany()
                        .HasForeignKey("CryptoNetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CryptoNetwork");
                });

            modelBuilder.Entity("Entities.Models.CryptoInternalTransaction", b =>
                {
                    b.HasOne("Entities.Models.CryptoBlock", "CryptoBlock")
                        .WithMany("InternalTxids")
                        .HasForeignKey("CryptoBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CryptoBlock");
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

            modelBuilder.Entity("Entities.Models.CryptoTransaction", b =>
                {
                    b.HasOne("Entities.Models.CryptoBlock", "CryptoBlock")
                        .WithMany("Txids")
                        .HasForeignKey("CryptoBlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CryptoBlock");
                });

            modelBuilder.Entity("Entities.Models.Crypto", b =>
                {
                    b.Navigation("CryptoNetworks");
                });

            modelBuilder.Entity("Entities.Models.CryptoBlock", b =>
                {
                    b.Navigation("InternalTxids");

                    b.Navigation("Txids");
                });
#pragma warning restore 612, 618
        }
    }
}
