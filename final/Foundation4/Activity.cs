public abstract class Activity
{
    protected DateTime _date;
    protected int _minutes;

    protected Activity(DateTime date, int minutes)
    {
        if (minutes <= 0) throw new ArgumentOutOfRangeException(nameof(minutes));
        _date = date;
        _minutes = minutes;
    }

    protected int Minutes => _minutes;

    public abstract double GetDistance(); // Kilometers
    public abstract double GetSpeed(); // Kilometers per hour
    public abstract double GetPace(); // Minutes per kilometer

    public virtual string GetSummary() =>
        $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - Distance: {GetDistance():0.00} km, Speed: {GetSpeed():0.00} kph, Pace: {GetPace():0.00} min per km";
}
