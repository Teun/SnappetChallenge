namespace Snappet.Assignment.Entities.Interfaces
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
