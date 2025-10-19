using FinSync.Finances.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinSync.Finances.Infra.Mappings;

public class RecurringExpenseMapping : IEntityTypeConfiguration<RecurringExpense>
{
  public void Configure(EntityTypeBuilder<RecurringExpense> builder)
  {
    builder.HasKey(entity => entity.Id);

    builder.Property(entity => entity.Id)
      .ValueGeneratedOnAdd();
  }
}