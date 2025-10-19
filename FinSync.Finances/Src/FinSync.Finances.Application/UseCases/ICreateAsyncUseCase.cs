namespace FinSync.Finances.Application.UseCases;

/// <summary>
///This interface named represents an async creation use case with two generic type
///parameters `TCreationDTO` and `TResult`. The interface declares a method `CreateAsync` that takes a
///parameter of type `TCreationDTO`.
/// </summary>
public interface ICreateAsyncUseCase<TCreationDTO, TResult>
{
  Task<TResult> CreateAsync(TCreationDTO account);
}