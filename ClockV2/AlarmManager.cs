using System;
using System.Collections.Generic;

public class AlarmManager
{
    // Priority queue with Alarm objects and DateTime as the priority
    private PriorityQueue<Alarm, DateTime> alarmQueue = new PriorityQueue<Alarm, DateTime>();

    // Add an alarm to the queue
    public void AddAlarm(Alarm alarm)
    {
        alarmQueue.Enqueue(alarm, alarm.Time);
    }

    // Get the next alarm without removing it (Peek)
    public Alarm GetNextAlarm()
    {
        if (alarmQueue.Count > 0)
        {
            return alarmQueue.Peek();
        }
        return null;
    }

    // Remove and return the next alarm
    public Alarm RemoveNextAlarm()
    {
        if (alarmQueue.Count > 0)
        {
            return alarmQueue.Dequeue();
        }
        return null;
    }

    // Check if there are alarms in the queue
    public bool HasAlarms => alarmQueue.Count > 0;
}
