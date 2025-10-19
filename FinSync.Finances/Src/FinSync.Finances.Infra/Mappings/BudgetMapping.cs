using FinSync.Finances.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinSync.Finances.Infra.Mappings;

public class BudgetMapping : IEntityTypeConfiguration<Budget>
{
  public void Configure(EntityTypeBuilder<Budget> builder)
  {
    builder.HasKey(entity => entity.Id);

    builder.Property(entity => entity.Id)
      .ValueGeneratedOnAdd();
  }
}