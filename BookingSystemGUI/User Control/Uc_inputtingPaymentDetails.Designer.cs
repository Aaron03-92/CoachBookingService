
namespace BookingSystemGUI.User_Control
{
    partial class Uc_inputtingPaymentDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uc_inputtingPaymentDetails));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxCardType = new System.Windows.Forms.ComboBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtNameOnCard = new System.Windows.Forms.TextBox();
            this.txtSecurityCode = new System.Windows.Forms.TextBox();
            this.buyTicketBtn = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.paymentPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.dateOfPurchase = new System.Windows.Forms.DateTimePicker();
            this.paymentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(533, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(350, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Card type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(530, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Card number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(350, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Name on card";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(530, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Expiry date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(710, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Security code";
            // 
            // comboBoxCardType
            // 
            this.comboBoxCardType.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxCardType.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCardType.FormattingEnabled = true;
            this.comboBoxCardType.ItemHeight = 19;
            this.comboBoxCardType.Items.AddRange(new object[] {
            "Visa Credit",
            "Visa Debit",
            "Mastercard Credit",
            "Mastercard Debit",
            "Maestro",
            "American Express"});
            this.comboBoxCardType.Location = new System.Drawing.Point(354, 236);
            this.comboBoxCardType.Name = "comboBoxCardType";
            this.comboBoxCardType.Size = new System.Drawing.Size(150, 27);
            this.comboBoxCardType.TabIndex = 10;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCardNumber.Location = new System.Drawing.Point(534, 234);
            this.txtCardNumber.Multiline = true;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(150, 28);
            this.txtCardNumber.TabIndex = 11;
            // 
            // txtNameOnCard
            // 
            this.txtNameOnCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameOnCard.Location = new System.Drawing.Point(354, 338);
            this.txtNameOnCard.Multiline = true;
            this.txtNameOnCard.Name = "txtNameOnCard";
            this.txtNameOnCard.Size = new System.Drawing.Size(150, 28);
            this.txtNameOnCard.TabIndex = 12;
            // 
            // txtSecurityCode
            // 
            this.txtSecurityCode.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecurityCode.Location = new System.Drawing.Point(714, 337);
            this.txtSecurityCode.Multiline = true;
            this.txtSecurityCode.Name = "txtSecurityCode";
            this.txtSecurityCode.Size = new System.Drawing.Size(150, 28);
            this.txtSecurityCode.TabIndex = 14;
            // 
            // buyTicketBtn
            // 
            this.buyTicketBtn.BackColor = System.Drawing.Color.Transparent;
            this.buyTicketBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buyTicketBtn.BackgroundImage")));
            this.buyTicketBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buyTicketBtn.FlatAppearance.BorderSize = 0;
            this.buyTicketBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buyTicketBtn.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buyTicketBtn.ForeColor = System.Drawing.Color.White;
            this.buyTicketBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buyTicketBtn.Location = new System.Drawing.Point(753, 429);
            this.buyTicketBtn.Name = "buyTicketBtn";
            this.buyTicketBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.buyTicketBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buyTicketBtn.Size = new System.Drawing.Size(118, 37);
            this.buyTicketBtn.TabIndex = 15;
            this.buyTicketBtn.Text = "Buy ticket";
            this.buyTicketBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buyTicketBtn.UseVisualStyleBackColor = false;
            this.buyTicketBtn.Click += new System.EventHandler(this.buyTicketBtn_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.BackColor = System.Drawing.Color.Transparent;
            this.btnGoBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGoBack.BackgroundImage")));
            this.btnGoBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGoBack.FlatAppearance.BorderSize = 0;
            this.btnGoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoBack.Font = new System.Drawing.Font("Gadugi", 11.25F);
            this.btnGoBack.ForeColor = System.Drawing.Color.White;
            this.btnGoBack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGoBack.Location = new System.Drawing.Point(127, 118);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnGoBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGoBack.Size = new System.Drawing.Size(149, 33);
            this.btnGoBack.TabIndex = 27;
            this.btnGoBack.Text = "Modify Journey";
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoBack.UseVisualStyleBackColor = false;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(534, 339);
            this.dateTimePicker1.MaxDate = new System.DateTime(2030, 12, 28, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2020, 1, 28, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 27);
            this.dateTimePicker1.TabIndex = 23;
            this.dateTimePicker1.Value = new System.DateTime(2020, 12, 28, 0, 0, 0, 0);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(103)))), ((int)(((byte)(128)))));
            this.panel1.Location = new System.Drawing.Point(696, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(75, 5);
            this.panel1.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(540, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 19);
            this.label9.TabIndex = 20;
            this.label9.Text = "Confirm details";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(696, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Payment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(394, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 19);
            this.label7.TabIndex = 17;
            this.label7.Text = "Journey details";
            // 
            // paymentPanel
            // 
            this.paymentPanel.Controls.Add(this.label10);
            this.paymentPanel.Controls.Add(this.btnGoBack);
            this.paymentPanel.Controls.Add(this.dateOfPurchase);
            this.paymentPanel.Controls.Add(this.dateTimePicker1);
            this.paymentPanel.Controls.Add(this.buyTicketBtn);
            this.paymentPanel.Controls.Add(this.label4);
            this.paymentPanel.Controls.Add(this.panel1);
            this.paymentPanel.Controls.Add(this.label3);
            this.paymentPanel.Controls.Add(this.txtCardNumber);
            this.paymentPanel.Controls.Add(this.txtSecurityCode);
            this.paymentPanel.Controls.Add(this.label9);
            this.paymentPanel.Controls.Add(this.label2);
            this.paymentPanel.Controls.Add(this.comboBoxCardType);
            this.paymentPanel.Controls.Add(this.label5);
            this.paymentPanel.Controls.Add(this.label8);
            this.paymentPanel.Controls.Add(this.label1);
            this.paymentPanel.Controls.Add(this.txtNameOnCard);
            this.paymentPanel.Controls.Add(this.label6);
            this.paymentPanel.Controls.Add(this.label7);
            this.paymentPanel.Location = new System.Drawing.Point(-1, 0);
            this.paymentPanel.Name = "paymentPanel";
            this.paymentPanel.Size = new System.Drawing.Size(1128, 518);
            this.paymentPanel.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(350, 417);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 19);
            this.label10.TabIndex = 170;
            this.label10.Text = "Date of purchase";
            // 
            // dateOfPurchase
            // 
            this.dateOfPurchase.Enabled = false;
            this.dateOfPurchase.Font = new System.Drawing.Font("Gadugi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfPurchase.Location = new System.Drawing.Point(354, 439);
            this.dateOfPurchase.Name = "dateOfPurchase";
            this.dateOfPurchase.Size = new System.Drawing.Size(157, 27);
            this.dateOfPurchase.TabIndex = 171;
            // 
            // Uc_inputtingPaymentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.paymentPanel);
            this.Name = "Uc_inputtingPaymentDetails";
            this.Size = new System.Drawing.Size(1128, 518);
            this.Load += new System.EventHandler(this.Uc_inputtingPaymentDetails_Load);
            this.paymentPanel.ResumeLayout(false);
            this.paymentPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCardType;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtNameOnCard;
        private System.Windows.Forms.TextBox txtSecurityCode;
        private System.Windows.Forms.Button buyTicketBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnGoBack;
        public System.Windows.Forms.Panel paymentPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateOfPurchase;
    }
}
