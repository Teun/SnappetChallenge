namespace SnappetChallenge.Mappers.Interfaces
{
    public interface IMapper<TInput, TOutput>
    {
        TOutput Map(TInput input);
    }
}
