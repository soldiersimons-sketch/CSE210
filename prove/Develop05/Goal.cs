using System;
using System.Text;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _name;
    public int GetPoints() => _points;
    public virtual bool IsComplete() => false;
    public abstract int RecordEvent();
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }

    protected string SerializeCommon()
    {
        // Base64 keeps commas, colons, and newlines in user-entered names/descriptions safe.
        return $"{Encode(_name)}|{Encode(_description)}|{_points}";
    }

    protected static string Encode(string value) => Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
    public static string Decode(string value) => Encoding.UTF8.GetString(Convert.FromBase64String(value));
}
