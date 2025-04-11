using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using ClockV2;

namespace ClockV2.Tests
{
    [TestFixture]
    public class ClockViewTests
    {
        public ClockView clockView;

        [SetUp]
        public void Setup()
        {
            clockView = new ClockView();
        }

        [Test]
        public void AddAlarm_ShouldIncreaseAlarmCount()
        {
            // Arrange
            int initialCount = clockView.alarms.Count;
            var alarm = new Alarm(DateTime.Now.AddMinutes(5), "Test Alarm");

            // Act
            clockView.alarms.Add(alarm);

            // Assert
            Assert.AreEqual(initialCount + 1, clockView.alarms.Count);
        }

        [Test]
        public void RemoveAlarm_ShouldDecreaseAlarmCount()
        {
            // Arrange
            var alarm = new Alarm(DateTime.Now.AddMinutes(5), "Test Alarm");
            clockView.alarms.Add(alarm);
            int initialCount = clockView.alarms.Count;

            // Act
            clockView.alarms.Remove(alarm);

            // Assert
            Assert.AreEqual(initialCount - 1, clockView.alarms.Count);
        }

        [Test]
        public void Checkalarms_ShouldRemoveTriggeredalarms()
        {
            // Arrange
            var pastAlarm = new Alarm(DateTime.Now.AddSeconds(-5), "Expired Alarm");
            clockView.alarms.Add(pastAlarm);

            // Act
            clockView.CheckAlarms();

            // Assert
            Assert.IsFalse(clockView.alarms.Contains(pastAlarm));
        }

        [Test]
        public void SavealarmsToFile_CreatesValidFile()
        {
            // Arrange
            string testFilePath = "test_alarms.ics";
            clockView.AlarmFilePath = testFilePath;
            clockView.alarms.Add(new Alarm(DateTime.Now.AddMinutes(10), "Test Alarm"));

            try
            {
                // Act
                clockView.SaveAlarmsToFile();

                // Assert
                Assert.IsTrue(File.Exists(testFilePath));
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }

        [Test]
        public void LoadalarmsFromFile_ShouldPopulateAlarmList()
        {
            // Arrange
            string testFilePath = "test_alarms.ics";
            File.WriteAllText(testFilePath, "BEGIN:VCALENDAR\nBEGIN:VEVENT\nSUMMARY:Test Alarm\nDTSTART:20250405T123000\nEND:VEVENT\nEND:VCALENDAR");
            clockView.AlarmFilePath = testFilePath;

            try
            {
                // Act
                clockView.LoadAlarmsFromFile();

                // Assert
                Assert.IsTrue(clockView.alarms.Count > 0);
            }
            finally
            {
                // Cleanup
                if (File.Exists(testFilePath))
                    File.Delete(testFilePath);
            }
        }
    }
}
