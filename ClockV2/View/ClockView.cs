using ClockV2.Helpers;
using ClockV2.Presenter;
using ClockV2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ClockV2
{
    public partial class ClockView : Form
    {
        private ClockPresenter presenter;
        private readonly ClockDrawingHelper drawingHelper = new ClockDrawingHelper();
        private DateTime currentTime;
        private List<Alarm> alarms = new List<Alarm>();  // Use a List instead of Queue
        private Timer alarmCheckTimer;

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

        private void ClockView_Load(object sender, EventArgs e)
        {
            UpdateAlarmList();
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


        // ✅ Edit an existing alarm
        private void Btn_EditAlarm_Click(object sender, EventArgs e)
        {
            if (listBox_Alarms.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an alarm to edit.", "No Alarm Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = listBox_Alarms.SelectedIndex;
            var selectedAlarm = alarms[index];

            using (var dialog = new AlarmDialog(selectedAlarm.Message, selectedAlarm.Time))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Update the alarm with new values
                    alarms[index] = new Alarm(dialog.AlarmTime, dialog.AlarmName);

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

        // ✅ Display alarms in ListBox
        private void UpdateAlarmList()
        {
            if (listBox_Alarms == null || lbl_NextAlarm == null) return;

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
        }

        // ✅ Check for triggered alarms every second
        private void CheckAlarms()
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
