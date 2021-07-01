﻿// <auto-generated />
using System;
using Adnc.Infra.EfCore.MySQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Adnc.Ord.Migrations.Migrations
{
    [DbContext(typeof(AdncDbContext))]
    [Migration("20210701085232_init20210701")]
    partial class init20210701
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasCharSet("utf8mb4 ")
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Adnc.Ord.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<long>("CreateBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("Remark")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<DateTime>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp(6)");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Adnc.Ord.Domain.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Adnc.Ord.Domain.Entities.Order", b =>
                {
                    b.OwnsOne("Adnc.Ord.Domain.Entities.OrderReceiver", "Receiver", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("varchar(64)")
                                .HasColumnName("ReceiverAddress");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(16)
                                .HasColumnType("varchar(16)")
                                .HasColumnName("ReceiverName");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("varchar(11)")
                                .HasColumnName("ReceiverPhone");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("Adnc.Ord.Domain.Entities.OrderStatus", "Status", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<string>("ChangesReason")
                                .HasMaxLength(32)
                                .HasColumnType("varchar(32)")
                                .HasColumnName("StatusChangesReason");

                            b1.Property<int>("Code")
                                .HasColumnType("int")
                                .HasColumnName("StatusCode");

                            b1.HasKey("OrderId");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Receiver");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Adnc.Ord.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("Adnc.Ord.Domain.Entities.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Adnc.Ord.Domain.Entities.OrderItemProduct", "Product", b1 =>
                        {
                            b1.Property<long>("OrderItemId")
                                .HasColumnType("bigint");

                            b1.Property<long>("Id")
                                .HasColumnType("bigint")
                                .HasColumnName("ProductId");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(64)
                                .HasColumnType("varchar(64)")
                                .HasColumnName("ProductName");

                            b1.Property<decimal>("Price")
                                .HasColumnType("decimal(18,4)")
                                .HasColumnName("ProductPrice");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Adnc.Ord.Domain.Entities.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
