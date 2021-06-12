
namespace BookingSystemGUI.User_Control
{
    partial class Uc_addBooking
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_addBooking));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTravelFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxTravelTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.searchBookingBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.availableBookings = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dateFromPicker = new System.Windows.Forms.DateTimePicker();
            this.dateTooPicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxTicketType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.addBookingPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.availableBookings)).BeginInit();
            this.addBookingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // comboBoxTravelFrom
            // 
            this.comboBoxTravelFrom.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.comboBoxTravelFrom, "comboBoxTravelFrom");
            this.comboBoxTravelFrom.FormattingEnabled = true;
            this.comboBoxTravelFrom.Name = "comboBoxTravelFrom";
            // 
            // comboBoxTravelTo
            // 
            resources.ApplyResources(this.comboBoxTravelTo, "comboBoxTravelTo");
            this.comboBoxTravelTo.FormattingEnabled = true;
            this.comboBoxTravelTo.Name = "comboBoxTravelTo";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Name = "label3";
            // 
            // searchBookingBtn
            // 
            resources.ApplyResources(this.searchBookingBtn, "searchBookingBtn");
            this.searchBookingBtn.FlatAppearance.BorderSize = 0;
            this.searchBookingBtn.ForeColor = System.Drawing.Color.White;
            this.searchBookingBtn.Name = "searchBookingBtn";
            this.searchBookingBtn.UseVisualStyleBackColor = true;
            this.searchBookingBtn.Click += new System.EventHandler(this.searchBookingBtn_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Name = "label5";
            // 
            // availableBookings
            // 
            this.availableBookings.AllowUserToAddRows = false;
            this.availableBookings.BackgroundColor = System.Drawing.Color.White;
            this.availableBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.availableBookings, "availableBookings");
            this.availableBookings.Name = "availableBookings";
            this.availableBookings.ReadOnly = true;
            this.availableBookings.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.availableBookings_CellDoubleClick);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Name = "label6";
            // 
            // dateFromPicker
            // 
            resources.ApplyResources(this.dateFromPicker, "dateFromPicker");
            this.dateFromPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFromPicker.Name = "dateFromPicker";
            // 
            // dateTooPicker
            // 
            resources.ApplyResources(this.dateTooPicker, "dateTooPicker");
            this.dateTooPicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTooPicker.Name = "dateTooPicker";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Name = "label8";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(103)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Name = "label9";
            // 
            // comboBoxTicketType
            // 
            this.comboBoxTicketType.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.comboBoxTicketType, "comboBoxTicketType");
            this.comboBoxTicketType.FormattingEnabled = true;
            this.comboBoxTicketType.Items.AddRange(new object[] {
            resources.GetString("comboBoxTicketType.Items"),
            resources.GetString("comboBoxTicketType.Items1")});
            this.comboBoxTicketType.Name = "comboBoxTicketType";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // addBookingPanel
            // 
            this.addBookingPanel.Controls.Add(this.panel1);
            this.addBookingPanel.Controls.Add(this.label10);
            this.addBookingPanel.Controls.Add(this.label1);
            this.addBookingPanel.Controls.Add(this.comboBoxTicketType);
            this.addBookingPanel.Controls.Add(this.comboBoxTravelFrom);
            this.addBookingPanel.Controls.Add(this.label9);
            this.addBookingPanel.Controls.Add(this.comboBoxTravelTo);
            this.addBookingPanel.Controls.Add(this.label2);
            this.addBookingPanel.Controls.Add(this.label8);
            this.addBookingPanel.Controls.Add(this.label3);
            this.addBookingPanel.Controls.Add(this.label7);
            this.addBookingPanel.Controls.Add(this.searchBookingBtn);
            this.addBookingPanel.Controls.Add(this.dateTooPicker);
            this.addBookingPanel.Controls.Add(this.label4);
            this.addBookingPanel.Controls.Add(this.dateFromPicker);
            this.addBookingPanel.Controls.Add(this.label5);
            this.addBookingPanel.Controls.Add(this.label6);
            this.addBookingPanel.Controls.Add(this.availableBookings);
            resources.ApplyResources(this.addBookingPanel, "addBookingPanel");
            this.addBookingPanel.Name = "addBookingPanel";
            // 
            // Uc_addBooking
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.addBookingPanel);
            this.Name = "Uc_addBooking";
            this.Load += new System.EventHandler(this.Uc_addBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.availableBookings)).EndInit();
            this.addBookingPanel.ResumeLayout(false);
            this.addBookingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTravelFrom;
        private System.Windows.Forms.ComboBox comboBoxTravelTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchBookingBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView availableBookings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateFromPicker;
        private System.Windows.Forms.DateTimePicker dateTooPicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxTicketType;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Panel addBookingPanel;
    }
}
