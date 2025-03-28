using System;
using PriorityQueue;
using System.Collections.Generic;

public class AlarmManager
{
    // Use only one type argument since your queue accepts a single type
    private SortedArrayPriorityQueue<PriorityItem<Alarm>> alarmQueue;

    public AlarmManager(int size)
    {
        alarmQueue = new SortedArrayPriorityQueue<PriorityItem<Alarm>>(size);
    }

    // Add an alarm to the queue
    public void AddAlarm(Alarm alarm)
    {
        // Wrap the alarm and priority together in PriorityItem
        var alarmItem = new PriorityItem<Alarm>(alarm, (int)alarm.Time.Ticks);
        alarmQueue.Add(alarmItem, (int)alarm.Time.Ticks);  // Use Ticks as the priority
    }

    // Get the next alarm without removing it
    public Alarm GetNextAlarm()
    {
        if (!alarmQueue.IsEmpty())
        {
            return alarmQueue.Head().Item;  // Extract the Alarm object
        }
        return null;
    }

    // Remove and return the next alarm
    public Alarm RemoveNextAlarm()
    {
        if (!alarmQueue.IsEmpty())
        {
            var nextAlarm = alarmQueue.Head().Item;
            alarmQueue.Remove();
            return nextAlarm;
        }
        return null;
    }

    // Check if there are alarms in the queue
    public bool HasAlarms => !alarmQueue.IsEmpty();
}
