public class Outdoor : Event
{
    private string _weatherForecast;

    public Outdoor(string title, string description, string date, string time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        _weatherForecast = weatherForecast;
    }

    public override string GetFullDetails() =>
        $"{GetStandardDetails()}\nType: Outdoor Gathering\nWeather: {_weatherForecast}";

    public override string GetShortDescription() => $"Outdoor Gathering: {Title} - {Date}";
}
