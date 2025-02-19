using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);

        builder.HasIndex(column => column.Id);

        builder.Property(u => u.Id)
            .HasColumnType("uuid");

        builder.HasMany(column => column.Products)
            .WithOne()
            .HasForeignKey(opt => opt.SaleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(u => u.Number)
            .HasColumnType("character varying(50)")
            .IsRequired();

        builder.Property(u => u.OpenDate)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.Property(u => u.CustomerId)
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(u => u.CustomerName)
            .HasColumnType("character varying(100)")
            .IsRequired();

        builder.Property(u => u.BranchId)
           .HasColumnType("uuid")
           .IsRequired();

        builder.Property(u => u.BranchName)
            .HasColumnType("character varying(100)")
            .IsRequired();

        builder.Property(u => u.TotalValue)
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
