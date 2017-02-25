namespace Domain
{
	using System;

	public class SubmittedAnswer
	{
		public int Id { get; set; }
		public User User { get; set; }
		public Exercise Exercise { get; set; }
		public bool Correct { get; set; }
		public int Progress { get; set; }
		public DateTimeOffset SubmittedAt { get; set; }
	}
}
