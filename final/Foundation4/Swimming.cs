
using System;

// Class Writing: Swimming
public class Swimming : Activity
{
    private double _laps;
    private string _type;

    public Swimming(DateTime date, int minutes, double laps, string type) : base(date, minutes)
    {
        if (laps <= 0) throw new ArgumentOutOfRangeException(nameof(laps));
        _laps = laps;
        _type = type;
    }

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        if (laps <= 0) throw new ArgumentOutOfRangeException(nameof(laps));
        _laps = laps;
        _type = "Swimming";
    }

    public override double GetDistance() => _laps * 50.0 / 1000;
    public override double GetSpeed() => GetDistance() / Minutes * 60;
    public override double GetPace() => Minutes / GetDistance();

    public string GetDescription() => $"{_type}: {_laps} laps";

    public override string GetSummary() =>
        $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min)-laps:{_laps} - Distance: {GetDistance():0.00} km, Speed: {GetSpeed():0.00} kph, Pace: {GetPace():0.00} min per km";
}