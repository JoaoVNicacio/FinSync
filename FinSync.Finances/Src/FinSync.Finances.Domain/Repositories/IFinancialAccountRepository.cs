namespace FinSync.Finances.Domain.Repositories;

public interface IFinancialAccountRepository
{
  Task<FinancialAccount> Create(FinancialAccount account);
  Task<FinancialAccount?> GetById(Guid id);
  Task<FinancialAccount> Update(FinancialAccount account);
  Task<bool> Delete(Guid id);
  Task<IEnumerable<FinancialAccount>> ListByUser(string userId);
}