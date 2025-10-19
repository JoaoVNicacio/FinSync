namespace FinSync.Mapper;

public interface IMapper
{
  void Register<TSource, TDestination>(Func<TSource, TDestination> map);
  TDestination Map<TSource, TDestination>(TSource source);
}