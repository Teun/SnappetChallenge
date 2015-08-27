namespace SnappetChallenge.Services.Models
{
    public class StudentDeviationsModel
    {
        public StudentDeviationsModel()
        {
            Deviations = new DeviationsModel();
        }

        public string StudentName { get; set; }

        public long StudentId { get; set; }

        public DeviationsModel Deviations { get; set; }

    }
}
