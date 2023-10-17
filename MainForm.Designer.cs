namespace ModbusConnect
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.DrvBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DevComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BaudComboBox = new System.Windows.Forms.ComboBox();
            this.RefreshDeviceButton = new System.Windows.Forms.Button();
            this.ConnectDeviceButton = new System.Windows.Forms.Button();
            this.DrvBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DrvBox
            // 
            this.DrvBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DrvBox.Controls.Add(this.tableLayoutPanel1);
            this.DrvBox.Location = new System.Drawing.Point(12, 13);
            this.DrvBox.Name = "DrvBox";
            this.DrvBox.Size = new System.Drawing.Size(776, 79);
            this.DrvBox.TabIndex = 0;
            this.DrvBox.TabStop = false;
            this.DrvBox.Text = "设备";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.DevComboBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BaudComboBox, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.RefreshDeviceButton, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.ConnectDeviceButton, 7, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(764, 53);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DevComboBox
            // 
            this.DevComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.DevComboBox, 3);
            this.DevComboBox.FormattingEnabled = true;
            this.DevComboBox.Location = new System.Drawing.Point(98, 16);
            this.DevComboBox.Name = "DevComboBox";
            this.DevComboBox.Size = new System.Drawing.Size(279, 20);
            this.DevComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "串口号:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "波特率:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BaudComboBox
            // 
            this.BaudComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BaudComboBox.FormattingEnabled = true;
            this.BaudComboBox.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.BaudComboBox.Location = new System.Drawing.Point(478, 16);
            this.BaudComboBox.Name = "BaudComboBox";
            this.BaudComboBox.Size = new System.Drawing.Size(89, 20);
            this.BaudComboBox.TabIndex = 5;
            // 
            // RefreshDeviceButton
            // 
            this.RefreshDeviceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RefreshDeviceButton.Location = new System.Drawing.Point(580, 15);
            this.RefreshDeviceButton.Name = "RefreshDeviceButton";
            this.RefreshDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshDeviceButton.TabIndex = 6;
            this.RefreshDeviceButton.Text = "刷新";
            this.RefreshDeviceButton.UseVisualStyleBackColor = true;
            this.RefreshDeviceButton.Click += new System.EventHandler(this.RefreshDeviceButton_Click);
            // 
            // ConnectDeviceButton
            // 
            this.ConnectDeviceButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConnectDeviceButton.Location = new System.Drawing.Point(677, 15);
            this.ConnectDeviceButton.Name = "ConnectDeviceButton";
            this.ConnectDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectDeviceButton.TabIndex = 7;
            this.ConnectDeviceButton.Text = "打开";
            this.ConnectDeviceButton.UseVisualStyleBackColor = true;
            this.ConnectDeviceButton.Click += new System.EventHandler(this.ConnectDeviceButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DrvBox);
            this.Name = "MainForm";
            this.Text = "ModbusConnect";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DrvBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DrvBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox DevComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BaudComboBox;
        private System.Windows.Forms.Button RefreshDeviceButton;
        private System.Windows.Forms.Button ConnectDeviceButton;
    }
}

