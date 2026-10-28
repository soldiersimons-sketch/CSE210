public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int minutes, double distanceKm) : base(date, minutes)
    {
        if (distanceKm <= 0) throw new ArgumentOutOfRangeException(nameof(distanceKm));
        _distanceKm = distanceKm;
    }

    public override double GetDistance() => _distanceKm;
    public override double GetSpeed() => GetDistance() / Minutes * 60;
    public override double GetPace() => Minutes / GetDistance();
}
