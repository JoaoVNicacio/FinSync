using FinSync.Finances.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinSync.Finances.Infra.Mappings;

public class FinancialAccountMapping : IEntityTypeConfiguration<FinancialAccount>
{
  public void Configure(EntityTypeBuilder<FinancialAccount> builder)
  {
    builder.HasKey(entity => entity.Id);

    builder.Property(entity => entity.Id)
           .ValueGeneratedOnAdd();
  }
}