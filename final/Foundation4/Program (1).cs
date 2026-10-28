List<Activity> activities = new List<Activity>
{
    new Running(new DateTime(2026, 10, 20), 30, 5.0),
    new Cycling(new DateTime(2026, 10, 21), 45, 18.0),
    new Swimming(new DateTime(2026, 10, 22), 25, 30)
};

Console.WriteLine("EXERCISE TRACKER");
Console.WriteLine("================");
foreach (Activity activity in activities)
    Console.WriteLine(activity.GetSummary());
