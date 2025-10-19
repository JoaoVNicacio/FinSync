namespace FinSync.Mapper;

public class FluentMapper : IMapper
{
  private readonly Dictionary<(Type, Type), object> _mappings = new();
  private readonly object _lock = new();

  public void Register<TSource, TDestination>(Func<TSource, TDestination> map)
  {
    var key = (typeof(TSource), typeof(TDestination));
    lock (_lock)
    {
      _mappings[key] = new TypeMapConfig<TSource, TDestination>(map);
    }
  }

  public TDestination Map<TSource, TDestination>(TSource source)
  {
    var key = (typeof(TSource), typeof(TDestination));

    return _mappings.TryGetValue(key, out var config)
      ? ((TypeMapConfig<TSource, TDestination>)config).MappingFunc(source) 
      : throw new InvalidOperationException($"No mapping registered for {typeof(TSource)} → {typeof(TDestination)}");
  }
}
