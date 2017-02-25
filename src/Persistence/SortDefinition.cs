namespace Persistence
{
	using System.Linq.Expressions;


	public enum SortDirection {
		Ascending,
		Descending
	}

	public class SortDefinition
	{
		public LambdaExpression Expression { get; set; }

		public SortDirection Direction { get; set; }
	}
}