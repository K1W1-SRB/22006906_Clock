using ClockV2.Helpers;
using ClockV2.Presenter;
using ClockV2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;  // ✅ Added for File operations

namespace ClockV2
{
    public partial class ClockView : Form
    {
        private ClockPresenter presenter;
        private readonly ClockDrawingHelper drawingHelper = new ClockDrawingHelper();
        private DateTime currentTime;
        public List<Alarm> alarms = new List<Alarm>();  // Use a List instead of Queue
        public Timer alarmCheckTimer;

        // ✅ Add the file path constant
        public const string AlarmFilePath = "alarms.ics";

        public ClockView()
        {
            InitializeComponent();

            // Enable double buffering to avoid flicker
            Panel_Clock.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(Panel_Clock, true, null);

            currentTime = DateTime.Now;

            // Timer to periodically check for alarms
            alarmCheckTimer = new Timer
            {
                Interval = 1000  // Check every second
            };

            alarmCheckTimer.Tick += timer_Tick;
            alarmCheckTimer.Start();
        }

        public void ClockView_Load(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to load saved alarms?", "Load Alarms", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoadAlarmsFromFile();
            }
        }

        private void btn_AddAlarm_Click_1(object sender, EventArgs e)
        {
            using (var dialog = new AlarmDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string alarmName = dialog.AlarmName;
                    DateTime alarmTime = dialog.AlarmTime;

                    alarms.Add(new Alarm(alarmTime, alarmName));

                    UpdateAlarmList();
                }
            }
        }

        private void btn_EditAlarm_Click(object sender, EventArgs e)
        {
            if (listBox_Alarms.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an alarm to edit.");
                return;
            }

            int selectedIndex = listBox_Alarms.SelectedIndex;

            // Get the corresponding Alarm object
            var selectedAlarm = alarms[selectedIndex];

            // Open the dialog with the current alarm details
            using (var dialog = new AlarmDialog(selectedAlarm.Message, selectedAlarm.Time))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the alarm object directly
                    selectedAlarm.Message = dialog.AlarmName;
                    selectedAlarm.Time = dialog.AlarmTime;

                    // Refresh the ListBox
                    UpdateAlarmList();
                }
            }
        }

        // ✅ Remove an alarm
        private void Btn_RemoveAlarm_Click(object sender, EventArgs e)
        {
            if (listBox_Alarms.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an alarm to remove.", "No Alarm Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = listBox_Alarms.SelectedIndex;
            alarms.RemoveAt(index);
            UpdateAlarmList();
        }

        private void UpdateAlarmList()
        {
            if (listBox_Alarms == null || lbl_NextAlarm == null) return;

            // Save current selection
            int selectedIndex = listBox_Alarms.SelectedIndex;

            listBox_Alarms.Items.Clear();

            // Sort alarms by time
            alarms = alarms.OrderBy(a => a.Time).ToList();

            foreach (var alarm in alarms)
            {
                listBox_Alarms.Items.Add($"{alarm.Message} - {alarm.Time:HH:mm:ss}");
            }

            var nextAlarm = alarms.FirstOrDefault();

            lbl_NextAlarm.Text = nextAlarm != null
                ? $"Next Alarm: {nextAlarm.Message} at {nextAlarm.Time:HH:mm:ss}"
                : "Next Alarm: None";

            // Restore selection after refresh
            if (selectedIndex >= 0 && selectedIndex < listBox_Alarms.Items.Count)
            {
                listBox_Alarms.SelectedIndex = selectedIndex;
            }
        }

        public void SaveAlarmsToFile()
        {
            var sb = new StringBuilder();
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine("PRODID:-//MyClockApp//EN");

            foreach (var alarm in alarms)
            {
                sb.AppendLine("BEGIN:VEVENT");
                sb.AppendLine($"SUMMARY:{alarm.Message}");
                sb.AppendLine($"DTSTART:{alarm.Time:yyyyMMddTHHmmss}");
                sb.AppendLine("END:VEVENT");
            }

            sb.AppendLine("END:VCALENDAR");

            File.WriteAllText(AlarmFilePath, sb.ToString());
            MessageBox.Show($"Alarms saved to {AlarmFilePath}", "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ✅ Load alarms from file
        public void LoadAlarmsFromFile()
        {
            if (!File.Exists(AlarmFilePath)) return;

            try
            {
                var lines = File.ReadAllLines(AlarmFilePath);
                alarms.Clear();

                Alarm currentAlarm = null;

                foreach (var line in lines)
                {
                    if (line.StartsWith("SUMMARY:"))
                    {
                        currentAlarm = new Alarm(DateTime.Now, line.Substring(8));
                    }
                    else if (line.StartsWith("DTSTART:") && currentAlarm != null)
                    {
                        if (DateTime.TryParseExact(line.Substring(8), "yyyyMMddTHHmmss", null, System.Globalization.DateTimeStyles.None, out var alarmTime))
                        {
                            currentAlarm.Time = alarmTime;
                            alarms.Add(currentAlarm);
                        }
                    }
                }

                UpdateAlarmList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading alarms: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Check for triggered alarms every second
        public void CheckAlarms()
        {
            var currentTime = DateTime.Now;

            // Find and trigger alarms
            var triggeredAlarms = alarms.Where(a => a.Time <= currentTime).ToList();

            foreach (var alarm in triggeredAlarms)
            {
                MessageBox.Show($"ALARM: {alarm.Message}", "Alarm Triggered", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                alarms.Remove(alarm);
            }

            UpdateAlarmList();
        }

        // ✅ Timer event to check alarms and redraw clock
        private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
            CheckAlarms();
        }

        // ✅ Prompt the user to save alarms when closing the app
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            DialogResult result = MessageBox.Show("Do you want to save your alarms before exiting?", "Save Alarms", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SaveAlarmsToFile();
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;  // Cancel closing the form
            }
        }

        public void SetPresenter(ClockPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void UpdateClock(DateTime currentTime)
        {
            this.currentTime = currentTime;
            Panel_Clock.Invalidate();
        }

        private void Panel_Clock_Paint(object sender, PaintEventArgs e)
        {
            if (presenter == null) return;

            var g = e.Graphics;
            drawingHelper.DrawClock(g, currentTime, Panel_Clock.Width, Panel_Clock.Height);
        }
    }
}
