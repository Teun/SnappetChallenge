namespace Domain
{
	using Specifications;
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public static Specification<User> WithId(int id)
		{
			return new AdHocSpecification<User>(u => u.Id == id, nameof(WithId));
		}
	}
}
