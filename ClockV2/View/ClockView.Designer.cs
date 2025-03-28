namespace ClockV2
{
    partial class ClockView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel_Clock = new System.Windows.Forms.Panel();
            this.btn_AddAlarm = new System.Windows.Forms.Button();
            this.listBox_Alarms = new System.Windows.Forms.ListBox();
            this.lbl_NextAlarm = new System.Windows.Forms.Label();
            this.txt_AlarmName = new System.Windows.Forms.TextBox();
            this.dateTimePicker_Alarm = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // Panel_Clock
            // 
            this.Panel_Clock.Location = new System.Drawing.Point(23, 6);
            this.Panel_Clock.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Clock.Name = "Panel_Clock";
            this.Panel_Clock.Size = new System.Drawing.Size(400, 369);
            this.Panel_Clock.TabIndex = 1;
            this.Panel_Clock.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Clock_Paint);
            // 
            // btn_AddAlarm
            // 
            this.btn_AddAlarm.Location = new System.Drawing.Point(23, 475);
            this.btn_AddAlarm.Name = "btn_AddAlarm";
            this.btn_AddAlarm.Size = new System.Drawing.Size(152, 23);
            this.btn_AddAlarm.TabIndex = 4;
            this.btn_AddAlarm.Text = "Add Alarm";
            this.btn_AddAlarm.UseVisualStyleBackColor = true;
            // 
            // listBox_Alarms
            // 
            this.listBox_Alarms.FormattingEnabled = true;
            this.listBox_Alarms.ItemHeight = 16;
            this.listBox_Alarms.Location = new System.Drawing.Point(23, 522);
            this.listBox_Alarms.Name = "listBox_Alarms";
            this.listBox_Alarms.Size = new System.Drawing.Size(120, 84);
            this.listBox_Alarms.TabIndex = 5;
            // 
            // lbl_NextAlarm
            // 
            this.lbl_NextAlarm.AutoSize = true;
            this.lbl_NextAlarm.Location = new System.Drawing.Point(23, 622);
            this.lbl_NextAlarm.Name = "lbl_NextAlarm";
            this.lbl_NextAlarm.Size = new System.Drawing.Size(44, 16);
            this.lbl_NextAlarm.TabIndex = 6;
            this.lbl_NextAlarm.Text = "label1";
            // 
            // txt_AlarmName
            // 
            this.txt_AlarmName.Location = new System.Drawing.Point(23, 438);
            this.txt_AlarmName.Name = "txt_AlarmName";
            this.txt_AlarmName.Size = new System.Drawing.Size(152, 22);
            this.txt_AlarmName.TabIndex = 7;
            this.txt_AlarmName.Text = "enter alarm name";
            // 
            // dateTimePicker_Alarm
            // 
            this.dateTimePicker_Alarm.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_Alarm.Location = new System.Drawing.Point(23, 394);
            this.dateTimePicker_Alarm.Name = "dateTimePicker_Alarm";
            this.dateTimePicker_Alarm.Size = new System.Drawing.Size(400, 22);
            this.dateTimePicker_Alarm.TabIndex = 8;
            this.dateTimePicker_Alarm.Value = new System.DateTime(2025, 3, 28, 11, 57, 27, 0);
            this.dateTimePicker_Alarm.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // ClockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 711);
            this.Controls.Add(this.dateTimePicker_Alarm);
            this.Controls.Add(this.txt_AlarmName);
            this.Controls.Add(this.lbl_NextAlarm);
            this.Controls.Add(this.listBox_Alarms);
            this.Controls.Add(this.btn_AddAlarm);
            this.Controls.Add(this.Panel_Clock);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClockView";
            this.Text = "Alarm App";
            this.Load += new System.EventHandler(this.ClockView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Clock;
        private System.Windows.Forms.Button btn_AddAlarm;
        private System.Windows.Forms.ListBox listBox_Alarms;
        private System.Windows.Forms.Label lbl_NextAlarm;
        private System.Windows.Forms.TextBox txt_AlarmName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Alarm;
    }
}

