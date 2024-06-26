﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WonderFood.MySql.Context;

#nullable disable

namespace WonderFood.MySql.Migrations
{
    [DbContext(typeof(WonderfoodContext))]
    [Migration("20240511231726_AdicionaAutoIncrementNumeroPedido")]
    partial class AdicionaAutoIncrementNumeroPedido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WonderFood.Domain.Entities.Pedido", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("DataEntrada")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataSaída")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("NumeroPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("NumeroPedido"));

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(200)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("Id");

                    b.HasIndex("NumeroPedido")
                        .IsUnique();

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("WonderFood.Domain.Entities.Produto", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)");

                    b.Property<byte>("Categoria")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("WonderFood.Domain.Entities.ProdutosPedido", b =>
                {
                    b.Property<string>("PedidoId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ProdutoId")
                        .HasColumnType("varchar(36)");

                    b.Property<byte>("Quantidade")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosPedido", (string)null);
                });

            modelBuilder.Entity("WonderFood.Domain.Entities.ProdutosPedido", b =>
                {
                    b.HasOne("WonderFood.Domain.Entities.Pedido", "Pedido")
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WonderFood.Domain.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("WonderFood.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
