using System;

public class Alarm : IComparable<Alarm>
{
    public DateTime Time { get; set; }
    public string Message { get; set; }

    public Alarm(DateTime time, string message)
    {
        Time = time;
        Message = message;
    }

    // Compare alarms by their time for sorting
    public int CompareTo(Alarm other)
    {
        if (other == null) return 1;
        return Time.CompareTo(other.Time);
    }

    public override string ToString()
    {
        return $"{Time}: {Message}";
    }
}
