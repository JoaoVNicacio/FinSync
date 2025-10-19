using FinSync.Finances.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinSync.Finances.Infra.Mappings;

public class RecurringIncomeMapping : IEntityTypeConfiguration<RecurringIncome>
{
  public void Configure(EntityTypeBuilder<RecurringIncome> builder)
  {
    builder.HasKey(entity => entity.Id);

    builder.Property(entity => entity.Id)
      .ValueGeneratedOnAdd();
  }
}