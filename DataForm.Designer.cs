namespace ModbusConnect
{
    partial class DataForm
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
            this.DataTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DataTextBox
            // 
            this.DataTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTextBox.Location = new System.Drawing.Point(0, 0);
            this.DataTextBox.MaxLength = 2147483647;
            this.DataTextBox.Multiline = true;
            this.DataTextBox.Name = "DataTextBox";
            this.DataTextBox.ReadOnly = true;
            this.DataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataTextBox.Size = new System.Drawing.Size(800, 450);
            this.DataTextBox.TabIndex = 0;
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataTextBox);
            this.Name = "DataForm";
            this.Text = "DataForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataForm_FormClosed);
            this.Load += new System.EventHandler(this.DataForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DataTextBox;
    }
}