using FinSync.Finances.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinSync.Finances.Infra.Mappings;

public class TransactionCategoryMapping : IEntityTypeConfiguration<TransactionCategory>
{
  public void Configure(EntityTypeBuilder<TransactionCategory> builder)
  {
    builder.HasKey(entity => entity.Id);

    builder.Property(entity => entity.Id)
      .ValueGeneratedOnAdd();
  }
}