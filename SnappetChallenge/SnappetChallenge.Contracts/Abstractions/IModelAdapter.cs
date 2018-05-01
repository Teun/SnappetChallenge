namespace SnappetChallenge.Contracts.Abstractions
{
    public interface IModelAdapter<in TIn, out TOut>
    {
        TOut Transform(TIn input);
    }

}
