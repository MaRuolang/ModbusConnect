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
            this.label2 = new System.Windows.Forms.Label();
            this.DevComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BaudComboBox = new System.Windows.Forms.ComboBox();
            this.RefreshDeviceButton = new System.Windows.Forms.Button();
            this.ConnectDeviceButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RegisterDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.Func0x03CheckBox = new System.Windows.Forms.CheckBox();
            this.AddrNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RegNumNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DecimalConversionToolButton = new System.Windows.Forms.Button();
            this.Func0x10CheckBox = new System.Windows.Forms.CheckBox();
            this.DrvBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RegisterDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddrNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegNumNumericUpDown)).BeginInit();
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 59);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "波特率:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DevComboBox
            // 
            this.DevComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.DevComboBox, 3);
            this.DevComboBox.FormattingEnabled = true;
            this.DevComboBox.Location = new System.Drawing.Point(99, 19);
            this.DevComboBox.Name = "DevComboBox";
            this.DevComboBox.Size = new System.Drawing.Size(282, 20);
            this.DevComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "串口号:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BaudComboBox
            // 
            this.BaudComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BaudComboBox.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.BaudComboBox.Location = new System.Drawing.Point(483, 19);
            this.BaudComboBox.Name = "BaudComboBox";
            this.BaudComboBox.Size = new System.Drawing.Size(90, 20);
            this.BaudComboBox.TabIndex = 5;
            // 
            // RefreshDeviceButton
            // 
            this.RefreshDeviceButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RefreshDeviceButton.Location = new System.Drawing.Point(594, 18);
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
            this.ConnectDeviceButton.Location = new System.Drawing.Point(683, 18);
            this.ConnectDeviceButton.Name = "ConnectDeviceButton";
            this.ConnectDeviceButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectDeviceButton.TabIndex = 7;
            this.ConnectDeviceButton.Text = "打开";
            this.ConnectDeviceButton.UseVisualStyleBackColor = true;
            this.ConnectDeviceButton.Click += new System.EventHandler(this.ConnectDeviceButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.RegisterDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 268);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "寄存器";
            // 
            // RegisterDataGridView
            // 
            this.RegisterDataGridView.AllowUserToAddRows = false;
            this.RegisterDataGridView.AllowUserToDeleteRows = false;
            this.RegisterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RegisterDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RegisterDataGridView.Location = new System.Drawing.Point(3, 17);
            this.RegisterDataGridView.Name = "RegisterDataGridView";
            this.RegisterDataGridView.RowTemplate.Height = 23;
            this.RegisterDataGridView.Size = new System.Drawing.Size(770, 248);
            this.RegisterDataGridView.TabIndex = 0;
            this.RegisterDataGridView.VirtualMode = true;
            this.RegisterDataGridView.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.RegisterDataGridView_CellToolTipTextNeeded);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(12, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 66);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模拟从机信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Func0x03CheckBox, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddrNumericUpDown, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.RegNumNumericUpDown, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.DecimalConversionToolButton, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.Func0x10CheckBox, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(770, 46);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "地址:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Func0x03CheckBox
            // 
            this.Func0x03CheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Func0x03CheckBox.AutoSize = true;
            this.Func0x03CheckBox.Checked = true;
            this.Func0x03CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Func0x03CheckBox.Location = new System.Drawing.Point(600, 15);
            this.Func0x03CheckBox.Name = "Func0x03CheckBox";
            this.Func0x03CheckBox.Size = new System.Drawing.Size(48, 16);
            this.Func0x03CheckBox.TabIndex = 2;
            this.Func0x03CheckBox.Text = "0x03";
            this.Func0x03CheckBox.UseVisualStyleBackColor = true;
            // 
            // AddrNumericUpDown
            // 
            this.AddrNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AddrNumericUpDown.Location = new System.Drawing.Point(99, 12);
            this.AddrNumericUpDown.Name = "AddrNumericUpDown";
            this.AddrNumericUpDown.Size = new System.Drawing.Size(90, 21);
            this.AddrNumericUpDown.TabIndex = 4;
            this.AddrNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(502, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "使能功能码:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(214, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "寄存器数量:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegNumNumericUpDown
            // 
            this.RegNumNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RegNumNumericUpDown.Location = new System.Drawing.Point(291, 12);
            this.RegNumNumericUpDown.Name = "RegNumNumericUpDown";
            this.RegNumNumericUpDown.Size = new System.Drawing.Size(90, 21);
            this.RegNumNumericUpDown.TabIndex = 7;
            this.RegNumNumericUpDown.Value = new decimal(new int[] {
            47,
            0,
            0,
            0});
            this.RegNumNumericUpDown.ValueChanged += new System.EventHandler(this.RegNumNumericUpDown_ValueChanged);
            // 
            // DecimalConversionToolButton
            // 
            this.DecimalConversionToolButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DecimalConversionToolButton.Location = new System.Drawing.Point(394, 11);
            this.DecimalConversionToolButton.Name = "DecimalConversionToolButton";
            this.DecimalConversionToolButton.Size = new System.Drawing.Size(75, 23);
            this.DecimalConversionToolButton.TabIndex = 8;
            this.DecimalConversionToolButton.Text = "进制转换工具";
            this.DecimalConversionToolButton.UseVisualStyleBackColor = true;
            this.DecimalConversionToolButton.Click += new System.EventHandler(this.DecimalConversionToolButton_Click);
            // 
            // Func0x10CheckBox
            // 
            this.Func0x10CheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Func0x10CheckBox.AutoSize = true;
            this.Func0x10CheckBox.Location = new System.Drawing.Point(697, 15);
            this.Func0x10CheckBox.Name = "Func0x10CheckBox";
            this.Func0x10CheckBox.Size = new System.Drawing.Size(48, 16);
            this.Func0x10CheckBox.TabIndex = 3;
            this.Func0x10CheckBox.Text = "0x10";
            this.Func0x10CheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DrvBox);
            this.Name = "MainForm";
            this.Text = "ModbusConnect";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DrvBox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RegisterDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddrNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegNumNumericUpDown)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Func0x03CheckBox;
        private System.Windows.Forms.CheckBox Func0x10CheckBox;
        private System.Windows.Forms.NumericUpDown AddrNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView RegisterDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown RegNumNumericUpDown;
        private System.Windows.Forms.Button DecimalConversionToolButton;
    }
}

