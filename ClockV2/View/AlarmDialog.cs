using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClockV2.View
{
    public partial class AlarmDialog : Form
    {
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Cancel;
        public AlarmDialog()
        {
            InitializeComponent();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // dateTimePicker
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);

            // txtLabel
            this.txtLabel.Location = new System.Drawing.Point(12, 50);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(200, 22);

            // btn_Save
            this.Btn_Save.Location = new System.Drawing.Point(12, 90);
            this.Btn_Save.Name = "btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(75, 23);
            this.Btn_Save.Text = "Save";
            this.Btn_Save.UseVisualStyleBackColor = true;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);

            // btn_Cancel
            this.Btn_Cancel.Location = new System.Drawing.Point(137, 90);
            this.Btn_Cancel.Name = "btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);

            // AlarmDialog
            this.ClientSize = new System.Drawing.Size(230, 130);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Cancel);
            this.Name = "AlarmDialog";
            this.Text = "Set Alarm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {

        }

        private void AlarmDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
