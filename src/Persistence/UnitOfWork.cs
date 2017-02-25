namespace Persistence
{
	using Persistence.Users;

	public interface IUnitOfWork
	{
		IUserStatsRepository UserStatsRepository { get; }
	}
}
