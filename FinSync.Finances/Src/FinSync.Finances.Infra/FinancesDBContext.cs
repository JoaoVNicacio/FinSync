using FinSync.Finances.Domain.Entities;
using FinSync.Finances.Infra.Mappings;
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

    modelBuilder.Entity<FinancialAccount>(new FinancialAccountMapping().Configure);
    modelBuilder.Entity<RecurringExpense>(new RecurringExpenseMapping().Configure);
    modelBuilder.Entity<RecurringIncome>(new RecurringIncomeMapping().Configure);
    modelBuilder.Entity<Transaction>(new TransactionMapping().Configure);
    modelBuilder.Entity<TransactionCategory>(new TransactionCategoryMapping().Configure);
    modelBuilder.Entity<Budget>(new BudgetMapping().Configure);
  }
}