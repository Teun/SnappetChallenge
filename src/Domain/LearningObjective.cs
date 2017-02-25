namespace Domain
{
	public class LearningObjective
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public KnowledgeDomain Domain { get; set; }
		public Subject Subject { get; set; }
	}
}
