namespace FinSync.Finances.Application.UseCases;

/// <summary>
/// This interface named defines an async fetch data by a user ID use case with two generic type
/// parameters `TUserId` and `TResponse`. The interface declares a method `ListByUserAsync` that takes a
/// `TUserId` parameter and returns a Task of TResponse.
/// </summary>
public interface IGetByUserAsyncUseCase<in TUserId, TResponse>
{
  Task<TResponse> ListByUserAsync(TUserId userId);
}