namespace FinSync.Finances.Application.UseCases;

/// <summary>
/// This interface named defines an async use case to update an entry with three generic type
/// parameters: `TId`, `TUpdateParam`, and `TResult`.
/// The interface declares a method `UpdateAsync` that takes a
/// `TId` parameter, a TUpdateParam parameter and returns a Task of TResponse.
/// </summary>
public interface IUpdateAsyncUseCase<in TId, in TUpdateParam, TResult>
{
  Task<TResult> UpdateAsync(TId id, TUpdateParam updateDTO);
}