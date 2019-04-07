namespace RReporter.Application.Domain
{
    public class Pupil
    {
        public Pupil (int userId, string name)
        {
            UserId = userId;
            Name = name;
        }
        public int UserId { get; private set; }

        public string Name { get; private set; }
    }
}