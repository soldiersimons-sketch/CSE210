using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _completed;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed = 0)
        : base(name, description, points)
    {
        if (target <= 0) throw new ArgumentOutOfRangeException(nameof(target));
        if (completed < 0 || completed > target) throw new ArgumentOutOfRangeException(nameof(completed));
        _target = target;
        _completed = completed;
        _bonus = bonus;
    }

    public override bool IsComplete() => _completed >= _target;

    public override int RecordEvent()
    {
        if (IsComplete()) return 0;
        _completed++;
        return GetPoints() + (IsComplete() ? _bonus : 0);
    }

    public override string GetDetailsString() => $"{base.GetDetailsString()} -- Completed {_completed}/{_target} times";

    public override string GetStringRepresentation() => $"ChecklistGoal|{SerializeCommon()}|{_target}|{_bonus}|{_completed}";
}
