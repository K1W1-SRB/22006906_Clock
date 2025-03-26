using System;

public class Alarm : IComparable<Alarm>
{
    public DateTime Time { get; set; }
    public string Label { get; set; } = "";
    public bool IsRecurring { get; set; }
    public bool IsActive { get; set; } = true;

    public Alarm(DateTime time, string label, bool isRecurring = false)
    {
        Time = time;
        Label = label;
        IsRecurring = isRecurring;
    }

    public int CompareTo(Alarm other)
    {
        if (other == null) return 1;
        return Time.CompareTo(other.Time);
    }

    public override string ToString()
    {
        string recurrence = IsRecurring ? "Recurring" : "One-time";
        string status = IsActive ? "Active" : "Inactive";
        return $"{Time:G} - {Label} ({recurrence}, {status})";
    }
}
