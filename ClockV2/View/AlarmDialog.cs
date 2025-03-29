using System;
using System.Windows.Forms;

namespace ClockV2.View
{
    public partial class AlarmDialog : Form
    {
        // Properties to access alarm data
        public string AlarmName => textBox1.Text;
        public DateTime AlarmTime => dateTimePicker1.Value;

        private bool isEditMode = false;

        public AlarmDialog()
        {
            InitializeComponent();
        }

        // Overloaded constructor for editing an existing alarm
        public AlarmDialog(string alarmName, DateTime alarmTime) : this()
        {
            isEditMode = true;
            textBox1.Text = alarmName;
            dateTimePicker1.Value = alarmTime;
            Btn_Save.Text = "Update Alarm";  // Change button text when editing
        }

        private void AlarmDialog_Load(object sender, EventArgs e)
        {
            // Set minimum time to prevent past alarms
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            // Validate alarm name
            if (string.IsNullOrWhiteSpace(AlarmName))
            {
                MessageBox.Show("Please enter a valid alarm name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate alarm time
            if (AlarmTime <= DateTime.Now)
            {
                MessageBox.Show("The alarm time must be in the future.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;  // Close the dialog and confirm the data
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
