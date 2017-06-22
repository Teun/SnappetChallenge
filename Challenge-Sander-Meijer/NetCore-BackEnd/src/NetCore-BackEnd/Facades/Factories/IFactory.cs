namespace NetCore.BackEnd.Facades.Factories
{
	public interface IFactory<in TItem, out TResult>
	{
		TResult Create(TItem item);
	}
}