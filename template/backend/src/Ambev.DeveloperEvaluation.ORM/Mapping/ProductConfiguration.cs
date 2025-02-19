using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);

        builder.HasIndex(column => column.Id);

        builder.Property(u => u.Id)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()");

        builder.HasIndex(column => column.ProductId);

        builder.Property(u => u.ProductId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.HasIndex(column => column.SaleId);

        builder.Property(x => x.SaleId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(u => u.Quantity)
            .HasColumnType("numeric(10,3)")
            .HasDefaultValue(0.000)
            .IsRequired();

        builder.Property(u => u.Price)
            .HasColumnType("numeric(10,2)")
            .HasDefaultValue(0.00)
            .IsRequired();

        builder.Property(u => u.Total)
            .HasColumnType("numeric(10,2)")
            .HasDefaultValue(0.00)
            .IsRequired();

        builder.Property(u => u.Discount)
            .HasColumnType("numeric(10,2)")
            .HasDefaultValue(0.00)
            .IsRequired();

        builder.Property(u => u.Canceled)
            .HasColumnType("boolean")
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(u => u.CreatedAt)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(u => u.UpdatedAt)
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
    }
}
