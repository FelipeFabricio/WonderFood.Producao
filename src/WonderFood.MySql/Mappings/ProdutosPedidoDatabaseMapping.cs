﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WonderFood.Domain.Entities;

namespace WonderFood.MySql.Mappings;

public class ProdutosPedidoDatabaseMapping : IEntityTypeConfiguration<ProdutosPedido>
{
    public void Configure(EntityTypeBuilder<ProdutosPedido> builder)
    {
        builder.ToTable("ProdutosPedido");
        builder.HasKey(p => new { p.PedidoId, p.ProdutoId });
        builder.Property(p => p.PedidoId).HasColumnType("varchar(36)").IsRequired();
        builder.Property(p => p.ProdutoId).HasColumnType("varchar(36)").IsRequired();
        builder.Property(p => p.Quantidade).HasColumnType("tinyint unsigned").IsRequired();
        builder.HasOne(p => p.Pedido)
            .WithMany(p => p.Produtos)
            .HasForeignKey(p => p.PedidoId);
    }
}