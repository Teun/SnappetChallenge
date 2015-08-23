namespace SnappetChallenge.Services.Models
{
    public class StudentDeviationsModel
    {
        public StudentDeviationsModel()
        {
            Deviations = new Deviations();
        }

        public string StudentName { get; set; }

        public long StudentId { get; set; }

        public Deviations Deviations { get; set; }

    }
}
