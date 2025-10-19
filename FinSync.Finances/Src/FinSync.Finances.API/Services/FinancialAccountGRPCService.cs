using FinSync.Finances.Application.UseCases;
using FinSync.Mapper;
using Grpc.Core;

namespace FinSync.Finances.API.Services;

public class FinancialAccountGRPCService(
  IMapper mapper,
  ICreateAsyncUseCase<ApplicationsDTOS.FinancialAccountForCreationDTO, DomainEntities.FinancialAccount>
    createAsyncUseCase
) : FinancialAccountService.FinancialAccountServiceBase
{
  private readonly IMapper _mapper = mapper;

  private readonly ICreateAsyncUseCase
    <ApplicationsDTOS.FinancialAccountForCreationDTO, DomainEntities.FinancialAccount>
    _createAsyncUseCase = createAsyncUseCase;

  public override async Task<FinancialAccount> Create(FinancialAccountForCreationDTO request, ServerCallContext context) =>
      _mapper.Map<DomainEntities.FinancialAccount, FinancialAccount>(
        await _createAsyncUseCase.CreateAsync(_mapper
          .Map<FinancialAccountForCreationDTO, ApplicationsDTOS.FinancialAccountForCreationDTO>(request)));

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