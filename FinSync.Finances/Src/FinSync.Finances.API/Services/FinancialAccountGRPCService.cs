using FinSync.Finances.Application.UseCases;
using FinSync.Mapper;
using Grpc.Core;

namespace FinSync.Finances.API.Services;

public sealed class FinancialAccountGRPCService(
  IMapper mapper,
  ICreateAsyncUseCase<
    ApplicationsDTOS.FinancialAccountForCreationDTO,
    DomainEntities.FinancialAccount>
  createAsyncUseCase
) : FinancialAccountService.FinancialAccountServiceBase
{
  private readonly IMapper _mapper = mapper;

  private readonly ICreateAsyncUseCase<
    ApplicationsDTOS.FinancialAccountForCreationDTO,
    DomainEntities.FinancialAccount
  > _createAsyncUseCase = createAsyncUseCase;

  public override async Task<FinancialAccount> Create(
      FinancialAccountForCreationDTO request,
      ServerCallContext context) =>
    _mapper.Map<DomainEntities.FinancialAccount, FinancialAccount>(
      await _createAsyncUseCase.CreateAsync(_mapper.Map<
        FinancialAccountForCreationDTO,
        ApplicationsDTOS.FinancialAccountForCreationDTO>(request)));

  public async Task<FinancialAccount?> GetById(IdRequest idRequest)
  {
    return await Task.FromResult<FinancialAccount?>(null);
  }

  public async Task<FinancialAccount> Update(
    FinancialAccountForUpdateDTO account)
  {
    return await Task.FromResult<FinancialAccount>(new());
  }

  public async Task<DeleteResult> Delete(IdRequest idRequest)
  {
    return await Task.FromResult<DeleteResult>(
      new() { WasSuccessful = false, });
  }

  public async Task<FinancialAccountList> ListByUser(UserRequest userRequest)
  {
    return await Task.FromResult<FinancialAccountList>(new());
  }
}
