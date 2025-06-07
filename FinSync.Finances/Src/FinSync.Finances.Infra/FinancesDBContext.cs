using FinSync.Finances.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinSync.Finances.Infra;

public class FinancesDBContext(DbContextOptions<FinancesDBContext> options) : DbContext(options)
{
  public DbSet<FinancialAccount> FinancialAccounts { get; private set; }
  public DbSet<RecurringExpense> RecurringExpenses { get; private set; }
  public DbSet<RecurringIncome> RecurringIncomes { get; private set; }
  public DbSet<Transaction> Transactions { get; private set; }
  public DbSet<TransactionCategory> TransactionCategories { get; private set; }
  public DbSet<Budget> Budgets { get; private set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<FinancialAccount>(); //new Mapping().Configure);
    modelBuilder.Entity<RecurringExpense>(); //new Mapping().Configure);
    modelBuilder.Entity<RecurringIncome>(); //new Mapping().Configure);
    modelBuilder.Entity<Transaction>(); //new Mapping().Configure);
    modelBuilder.Entity<TransactionCategory>(); //new Mapping().Configure);
    modelBuilder.Entity<Budget>(); //new Mapping().Configure);
  }
}