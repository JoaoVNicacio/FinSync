using FinSync.Finances.Application.DTOs;
using FinSync.Finances.Application.UseCases;
using FinSync.Finances.Domain.Entities;

namespace FinSync.Finances.Application.Services.Contracts;

public interface IFinancialAccountService :
  ICreateAsyncUseCase<FinancialAccountForCreationDTO, FinancialAccount>,
  IGetByIdAsyncUseCase<Guid, FinancialAccount>,
  IUpdateAsyncUseCase<Guid, FinancialAccountForUpdateDTO, FinancialAccount>,
  IDeleteAsyncUseCase<Guid, bool>,
  IGetByUserAsyncUseCase<string, Collection<FinancialAccount>>;