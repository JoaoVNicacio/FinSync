namespace FinSync.Mapper;

public class TypeMapConfig<TSource, TDestination>(
  Func<TSource, TDestination> mappingFunc)
{
  public Func<TSource, TDestination> MappingFunc { get; private set; } = mappingFunc;
}