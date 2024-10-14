namespace backend.Models;

public class StudentPerformance
{
    public int UserId { get; set; }
    public int CorrectSubmissions { get; set; }
    public int IncorrectSubmissions { get; set; }
    public double TotalProgress { get; set; }
}