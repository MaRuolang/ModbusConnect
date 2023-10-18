namespace ModbusConnect
{
    partial class DecimalConversion
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HEXTextBox = new System.Windows.Forms.TextBox();
            this.DECTextBox = new System.Windows.Forms.TextBox();
            this.HEXCopyButton = new System.Windows.Forms.Button();
            this.DECCopyButton = new System.Windows.Forms.Button();
            this.WarnLabel = new System.Windows.Forms.Label();
            this.CopySuccessLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.HEXTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.DECTextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.HEXCopyButton, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.DECCopyButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.WarnLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.CopySuccessLabel, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(425, 262);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "HEX(0x):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "DEC:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HEXTextBox
            // 
            this.HEXTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.HEXTextBox.Location = new System.Drawing.Point(130, 41);
            this.HEXTextBox.Name = "HEXTextBox";
            this.HEXTextBox.Size = new System.Drawing.Size(121, 21);
            this.HEXTextBox.TabIndex = 2;
            this.HEXTextBox.TextChanged += new System.EventHandler(this.HEXTextBox1_TextChanged);
            // 
            // DECTextBox
            // 
            this.DECTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DECTextBox.Location = new System.Drawing.Point(130, 198);
            this.DECTextBox.Name = "DECTextBox";
            this.DECTextBox.Size = new System.Drawing.Size(121, 21);
            this.DECTextBox.TabIndex = 3;
            this.DECTextBox.TextChanged += new System.EventHandler(this.DECTextBox1_TextChanged);
            // 
            // HEXCopyButton
            // 
            this.HEXCopyButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HEXCopyButton.Location = new System.Drawing.Point(280, 40);
            this.HEXCopyButton.Name = "HEXCopyButton";
            this.HEXCopyButton.Size = new System.Drawing.Size(75, 23);
            this.HEXCopyButton.TabIndex = 4;
            this.HEXCopyButton.Text = "复制";
            this.HEXCopyButton.UseVisualStyleBackColor = true;
            this.HEXCopyButton.Click += new System.EventHandler(this.HEXCopyButton_Click);
            // 
            // DECCopyButton
            // 
            this.DECCopyButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DECCopyButton.Location = new System.Drawing.Point(280, 197);
            this.DECCopyButton.Name = "DECCopyButton";
            this.DECCopyButton.Size = new System.Drawing.Size(75, 23);
            this.DECCopyButton.TabIndex = 5;
            this.DECCopyButton.Text = "复制";
            this.DECCopyButton.UseVisualStyleBackColor = true;
            this.DECCopyButton.Click += new System.EventHandler(this.DECCopyButton_Click);
            // 
            // WarnLabel
            // 
            this.WarnLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WarnLabel.AutoSize = true;
            this.WarnLabel.ForeColor = System.Drawing.Color.Red;
            this.WarnLabel.Location = new System.Drawing.Point(161, 124);
            this.WarnLabel.Name = "WarnLabel";
            this.WarnLabel.Size = new System.Drawing.Size(59, 12);
            this.WarnLabel.TabIndex = 6;
            this.WarnLabel.Text = "输入错误!";
            // 
            // CopySuccessLabel
            // 
            this.CopySuccessLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CopySuccessLabel.AutoSize = true;
            this.CopySuccessLabel.Location = new System.Drawing.Point(317, 124);
            this.CopySuccessLabel.Name = "CopySuccessLabel";
            this.CopySuccessLabel.Size = new System.Drawing.Size(0, 12);
            this.CopySuccessLabel.TabIndex = 7;
            // 
            // DecimalConversion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 262);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DecimalConversion";
            this.Text = "进制转换工具";
            this.Load += new System.EventHandler(this.DecimalConversion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HEXTextBox;
        private System.Windows.Forms.TextBox DECTextBox;
        private System.Windows.Forms.Button HEXCopyButton;
        private System.Windows.Forms.Button DECCopyButton;
        private System.Windows.Forms.Label WarnLabel;
        private System.Windows.Forms.Label CopySuccessLabel;
    }
}