namespace SnappetChallenge.Application.Providers;

/// <summary>
/// this allows us to mock it during unit tests.. so handy
/// </summary>
public class DateProvider : IDateProvider
{
    public DateTime Today()
    {
        return new DateTime(2015, 03, 24, 11, 30, 00); //DateTime.Today;
    }
}