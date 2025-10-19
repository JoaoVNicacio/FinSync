using System.Collections.ObjectModel;
using FinSync.Finances.Domain.Entities;
using FinSync.Finances.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinSync.Finances.Infra.Repositories;

public class FinancialAccountRepository(FinancesDBContext context) : IFinancialAccountRepository
{
  private readonly FinancesDBContext _context = context;

  public async Task<FinancialAccount> Create(FinancialAccount account)
  {
    account = (await _context.FinancialAccounts.AddAsync(account)).Entity;
    await _context.SaveChangesAsync();
    return account;
  }

  public async Task<FinancialAccount?> GetById(Guid id)
    => await _context.FinancialAccounts
                     .AsNoTracking()
                     .FirstOrDefaultAsync(e => e.Id == id);

  public async Task<FinancialAccount> Update(FinancialAccount account)
  {
    account = _context.FinancialAccounts.Update(account).Entity;
    await _context.SaveChangesAsync();
    return account;
  }

  public async Task<bool> Delete(Guid id)
  {
    var entry = await GetById(id);
    if (entry is null) return false;

    _context.FinancialAccounts.Remove(entry);
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<IEnumerable<FinancialAccount>> ListByUser(string userId)
    => await _context.FinancialAccounts
                     .Where(e => e.UserId == userId)
                     .AsNoTracking()
                     .ToListAsync();
}