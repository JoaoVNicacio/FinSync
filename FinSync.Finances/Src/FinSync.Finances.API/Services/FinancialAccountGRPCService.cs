namespace FinSync.Finances.API.Services;

public class FinancialAccountGRPCService : FinancialAccountService.FinancialAccountServiceBase
{
  public async Task<FinancialAccount> Create(FinancialAccountForCreationDTO account)
  {
    return new();
  }

  public async Task<FinancialAccount?> GetById(IdRequest idRequest)
  {
    return null;
  }

  public async Task<FinancialAccount> Update(FinancialAccountForUpdateDTO account)
  {
    return new();
  }

  public async Task<DeleteResult> Delete(IdRequest idRequest)
  {
    return new() { WasSuccessful = false, };
  }

  public async Task<FinancialAccountList> ListByUser(UserRequest userRequest)
  {
    return new();
  }
}