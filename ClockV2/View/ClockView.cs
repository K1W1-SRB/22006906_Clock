using ClockV2.Helpers;
using ClockV2.Presenter;
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
        private AlarmManager alarmManager;
        private Timer alarmCheckTimer;

        private Queue<Alarm> alarmQueue = new Queue<Alarm>();

        public ClockView()
        {
            InitializeComponent();


            // btn_AddAlarm

            this.btn_AddAlarm.Name = "btn_AddAlarm";
           
            this.btn_AddAlarm.TabIndex = 4;
            this.btn_AddAlarm.Text = "Add Alarm";
            this.btn_AddAlarm.UseVisualStyleBackColor = true;

            this.btn_AddAlarm.Click += new System.EventHandler(this.Btn_AddAlarm_Click);  // Attach the event

            // dateTimePicker_Alarm
            this.dateTimePicker_Alarm.Format = System.Windows.Forms.DateTimePickerFormat.Time;
           
            this.dateTimePicker_Alarm.Name = "dateTimePicker_Alarm";
         
            this.dateTimePicker_Alarm.TabIndex = 8;
            this.dateTimePicker_Alarm.Value = new System.DateTime(2025, 3, 28, 11, 57, 27, 0);

            this.dateTimePicker_Alarm.ValueChanged += new System.EventHandler(this.dateTimePicker_Alarm_ValueChanged);

            // Enable double buffering to avoid flicker
            Panel_Clock.GetType()
                .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                .SetValue(Panel_Clock, true, null);

            currentTime = DateTime.Now;

            // Initialize AlarmManager with capacity for 50 alarms
            alarmManager = new AlarmManager(50);

            // Timer to periodically check for alarms
            alarmCheckTimer = new Timer
            {
                Interval = 1000  // Check every second
            };

            // Attach event handlers
            alarmCheckTimer.Tick += timer_Tick;
            alarmCheckTimer.Start();
        }

        private void ClockView_Load(object sender, EventArgs e)
        {
            // Initialize the alarm display with any preloaded data
            UpdateAlarmList();
        }

        private void Btn_AddAlarm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_AlarmName.Text))
            {
                MessageBox.Show("Please enter an alarm name.");
                return;
            }

            var alarm = new Alarm(dateTimePicker_Alarm.Value, txt_AlarmName.Text);

            alarmQueue.Enqueue(alarm);
            UpdateAlarmList();
        }

        private void UpdateAlarmList()
        {
            // Null-checks to prevent exceptions
            if (listBox_Alarms == null || lbl_NextAlarm == null) return;

            listBox_Alarms.Items.Clear();

            foreach (var alarm in alarmQueue)
            {
                listBox_Alarms.Items.Add($"{alarm.Message} - {alarm.Time:HH:mm:ss}");
            }

            var nextAlarm = alarmQueue.OrderBy(a => a.Time).FirstOrDefault();

            lbl_NextAlarm.Text = nextAlarm != null
                ? $"Next Alarm: {nextAlarm.Message} at {nextAlarm.Time:HH:mm:ss}"
                : "Next Alarm: None";
        }


        // Check for triggered alarms every second
        private void CheckAlarms()
        {
            var currentTime = DateTime.Now;

            if (alarmQueue.Count > 0 && alarmQueue.Peek().Time <= currentTime)
            {
                var triggeredAlarm = alarmQueue.Dequeue();
                MessageBox.Show($"ALARM: {triggeredAlarm.Message}", "Alarm Triggered", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                UpdateAlarmList();
            }
        }

        // Timer event to check alarms
        private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();  // Redraw clock
            CheckAlarms();
        }

        private void AlarmCheckTimer_Tick(object sender, EventArgs e)
        {
            var nextAlarm = alarmManager.GetNextAlarm();

            if (nextAlarm != null && DateTime.Now >= nextAlarm.Time)
            {
                MessageBox.Show($"Alarm Triggered: {nextAlarm.Message}", "Alarm!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Remove the triggered alarm
                alarmManager.RemoveNextAlarm();

                // Refresh the alarm list
                UpdateAlarmList();
            }
        }

        public void SetPresenter(ClockPresenter presenter)
        {
            this.presenter = presenter;
        }

        public void UpdateClock(DateTime currentTime)
        {
            this.currentTime = currentTime;
            Panel_Clock.Invalidate(); // Trigger a redraw of the panel
        }

        private void Panel_Clock_Paint(object sender, PaintEventArgs e)
        {
            if (presenter == null) return;

            var g = e.Graphics;
            drawingHelper.DrawClock(g, currentTime, Panel_Clock.Width, Panel_Clock.Height);
        }

        private void txt_AlarmName_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_Alarm_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
