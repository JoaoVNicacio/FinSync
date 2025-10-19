namespace FinSync.Finances.Application.UseCases;

/// <summary>
/// This interface defines an async fetch by id use case with two generic type
/// parameters `TId` and `TResult`. The interface declares a method `GetByIdAsync` that takes a
/// parameter of type `TId` and returns a `Task` of type `TResult?`.
/// </summary>
public interface IGetByIdAsyncUseCase<in TId, TResult>
{
  Task<TResult?> GetByIdAsync(TId Id);
}