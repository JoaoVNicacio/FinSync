namespace FinSync.Finances.Application.UseCases;

/// <summary>
/// This interface named defines an async delete use case with two generic type
/// parameters `TId` and `TResponse`. The interface declares a method `DeleteAsync` that takes an `id`
/// Of type `TId` as a parameter and returns a `Task` of type `TResponse`.
/// </summary>
public interface IDeleteAsyncUseCase<in TId, TResponse>
{
  Task<TResponse> DeleteAsync(TId id);
}