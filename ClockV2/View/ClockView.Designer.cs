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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_EditAlarm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
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
            this.btn_AddAlarm.Location = new System.Drawing.Point(138, 395);
            this.btn_AddAlarm.Name = "btn_AddAlarm";
            this.btn_AddAlarm.Size = new System.Drawing.Size(152, 23);
            this.btn_AddAlarm.TabIndex = 4;
            this.btn_AddAlarm.Text = "Add Alarm";
            this.btn_AddAlarm.UseVisualStyleBackColor = true;
            this.btn_AddAlarm.Click += new System.EventHandler(this.btn_AddAlarm_Click_1);
            // 
            // listBox_Alarms
            // 
            this.listBox_Alarms.FormattingEnabled = true;
            this.listBox_Alarms.ItemHeight = 16;
            this.listBox_Alarms.Location = new System.Drawing.Point(23, 445);
            this.listBox_Alarms.Name = "listBox_Alarms";
            this.listBox_Alarms.Size = new System.Drawing.Size(400, 84);
            this.listBox_Alarms.TabIndex = 5;
            // 
            // lbl_NextAlarm
            // 
            this.lbl_NextAlarm.AutoSize = true;
            this.lbl_NextAlarm.Location = new System.Drawing.Point(23, 544);
            this.lbl_NextAlarm.Name = "lbl_NextAlarm";
            this.lbl_NextAlarm.Size = new System.Drawing.Size(44, 16);
            this.lbl_NextAlarm.TabIndex = 6;
            this.lbl_NextAlarm.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "List of All Alarms";
            // 
            // btn_EditAlarm
            // 
            this.btn_EditAlarm.Location = new System.Drawing.Point(148, 568);
            this.btn_EditAlarm.Name = "btn_EditAlarm";
            this.btn_EditAlarm.Size = new System.Drawing.Size(120, 28);
            this.btn_EditAlarm.TabIndex = 8;
            this.btn_EditAlarm.Text = "Edit Alarm";
            this.btn_EditAlarm.UseVisualStyleBackColor = true;
            this.btn_EditAlarm.Click += new System.EventHandler(this.btn_EditAlarm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(148, 612);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(120, 28);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "Cancel Alarm";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // ClockView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 711);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_EditAlarm);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_EditAlarm;
        private System.Windows.Forms.Button btn_cancel;
    }
}

