using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;

namespace ModbusConnect
{
    public partial class MainForm : Form
    {
        private SerialPort DevSerial = new SerialPort();

        private BackgroundWorker GetDevWorker = new BackgroundWorker();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetDevWorker.DoWork += GetDevWorkerDoWork;
            GetDevWorker.RunWorkerCompleted += GetDevWorkerRunWorkerCompleted;

            DevSerial.DataReceived += DevSerial_DataReceived;

            BaudComboBox.SelectedItem = "115200";

            DevComboBox.Enabled = false; // 禁用选择框
            RefreshDeviceButton.Enabled = false; // 禁用刷新按钮
            ConnectDeviceButton.Enabled = false; // 禁用连接按钮

            // 在后台线程中执行查询操作
            GetDevWorker.RunWorkerAsync();

            DrawDataGrid();

            SetupCellProperties();
            SetupContextMenu();

            CommInit();
        }

        #region 寄存器
        public enum DATA_TYPE
        {
            DATA_TYPE_SIGNED,
            DATA_TYPE_UNSIGNED,
            DATA_TYPE_HEX,
        };
        public struct CellProperties
        {
            public DATA_TYPE DataType;
        };

        // 创建一个字典来映射每个单元格的位置与对应的数据结构对象
        private Dictionary<Tuple<int, int>, CellProperties> cellPropertiesDict = new Dictionary<Tuple<int, int>, CellProperties>();


        private void DrawDataGrid()
        {
            RegisterDataGridView.Rows.Clear(); // 删除所有行
            RegisterDataGridView.Columns.Clear(); // 删除所有列

            int RegNumber = (int)RegNumNumericUpDown.Value;

            for (int i = 0; i < (RegNumber / 16) + 1; i++)
            {
                RegisterDataGridView.Columns.Add("Name" + i.ToString(), "Name");
                RegisterDataGridView.Columns.Add("Value" + i.ToString(), (i * 16).ToString("X4"));
            }

            RegisterDataGridView.Rows.Add(16);

            foreach (DataGridViewColumn column in RegisterDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            int rowNumber = 0;
            foreach (DataGridViewRow row in RegisterDataGridView.Rows)
            {
                row.HeaderCell.Value = rowNumber.ToString("X");
                rowNumber++;
            }
            RegisterDataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);

            RegisterDataGridView.Refresh();
        }

        private void SetupContextMenu()
        {
            // 创建右键菜单
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            // 添加菜单项
            ToolStripMenuItem signedMenuItem = new ToolStripMenuItem("设置为有符号");
            signedMenuItem.Click += (sender, e) => UpdateCellProperties(DATA_TYPE.DATA_TYPE_SIGNED);
            contextMenuStrip.Items.Add(signedMenuItem);

            ToolStripMenuItem unsignedMenuItem = new ToolStripMenuItem("设置为无符号");
            unsignedMenuItem.Click += (sender, e) => UpdateCellProperties(DATA_TYPE.DATA_TYPE_UNSIGNED);
            contextMenuStrip.Items.Add(unsignedMenuItem);

            ToolStripMenuItem hexMenuItem = new ToolStripMenuItem("设置为十六进制");
            hexMenuItem.Click += (sender, e) => UpdateCellProperties(DATA_TYPE.DATA_TYPE_HEX);
            contextMenuStrip.Items.Add(hexMenuItem);

            // 将右键菜单分配给 DataGridView
            RegisterDataGridView.ContextMenuStrip = contextMenuStrip;
        }

        private void UpdateCellProperties(DATA_TYPE dataType)
        {
            foreach (DataGridViewCell selectedCell in RegisterDataGridView.SelectedCells)
            {
                Tuple<int, int> cellPosition = Tuple.Create(selectedCell.RowIndex, selectedCell.ColumnIndex);

                if (cellPropertiesDict.ContainsKey(cellPosition))
                {
                    CellProperties properties = cellPropertiesDict[cellPosition];
                    properties.DataType = dataType;
                    cellPropertiesDict[cellPosition] = properties;
                }
            }
        }

        private void SetupCellProperties()
        {
            for (int row = 0; row < RegisterDataGridView.Rows.Count; row++)
            {
                for (int column = 0; column < RegisterDataGridView.Columns.Count; column++)
                {
                    Tuple<int, int> cellPosition = Tuple.Create(row, column);

                    // 创建一个包含解析方式和符号性质的数据结构
                    CellProperties properties = new CellProperties
                    {
                        DataType = DATA_TYPE.DATA_TYPE_UNSIGNED,
                    };

                    cellPropertiesDict[cellPosition] = properties;
                }
            }
        }

        private void RegNumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            DrawDataGrid();
        }

        private Panel tooltipPanel; // 浮动控件

        private void RegisterDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Tuple<int, int> cellPosition = Tuple.Create(e.RowIndex, e.ColumnIndex);
                string tooltipText = cellPropertiesDict[cellPosition].DataType.ToString(); ;

                // 创建浮动控件
                tooltipPanel = new Panel
                {
                    BackColor = Color.LightYellow,
                    BorderStyle = BorderStyle.FixedSingle,
                    AutoSize = true,
                    Size = new Size(150, 20)
                };

                // 获取当前单元格的边界信息
                Rectangle cellRect = RegisterDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

                // 设置浮动控件的位置
                tooltipPanel.Location = new Point(cellRect.Left, cellRect.Top);

                // 创建 Label 控件用于显示提示内容
                Label tooltipLabel = new Label
                {
                    Text = tooltipText,
                    AutoSize = true,
                    Location = new Point(5, 5) // 设置 Label 控件的位置
                };
                tooltipPanel.Controls.Add(tooltipLabel);

                // 将浮动控件添加到 DataGridView 的父容器中
                RegisterDataGridView.Parent.Controls.Add(tooltipPanel);
                tooltipPanel.BringToFront();
            }
        }

        private void RegisterDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // 隐藏或关闭浮动控件
            if (tooltipPanel != null)
            {
                tooltipPanel.Hide();
                tooltipPanel.Dispose();
                tooltipPanel = null;
            }
        }

        private void RegisterDataGridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Tuple<int, int> cellPosition = Tuple.Create(e.RowIndex, e.ColumnIndex);
                string tooltipText;

                switch (cellPropertiesDict[cellPosition].DataType)
                {
                    case DATA_TYPE.DATA_TYPE_SIGNED:
                        tooltipText = "有符号";
                        break;

                    case DATA_TYPE.DATA_TYPE_UNSIGNED:
                        tooltipText = "无符号";
                        break;

                    case DATA_TYPE.DATA_TYPE_HEX:
                        tooltipText = "十六进制";
                        break;

                    default:
                        tooltipText = "未知";
                        break;
                }

                // 为单元格设置工具提示文本
                e.ToolTipText = tooltipText;
            }
        }
        #endregion

        #region 设备
        private void GetDevWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            string query = "SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%)'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection results = searcher.Get();

            List<string> deviceNames = results.Cast<ManagementObject>()
                                              .Select(obj => obj["Name"].ToString())
                                              .ToList();

            e.Result = deviceNames;
        }

        private void GetDevWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string SelectedPortBackup;

                if (DevComboBox.SelectedItem != null)
                {
                    SelectedPortBackup = DevComboBox.SelectedItem.ToString();
                }
                else
                {
                    SelectedPortBackup = null;
                }

                DevComboBox.Items.Clear(); // 清空选择框

                List<string> deviceNames = (List<string>)e.Result;
                DevComboBox.Items.AddRange(deviceNames.ToArray());

                if (SelectedPortBackup != null && DevComboBox.Items.Contains(SelectedPortBackup))
                {
                    DevComboBox.SelectedItem = SelectedPortBackup;
                }
                else
                {
                    DevComboBox.Text = "";
                }
            }

            DevComboBox.Enabled = true; // 启用选择框
            RefreshDeviceButton.Enabled = true; // 启用刷新按钮
            ConnectDeviceButton.Enabled = true; // 启用连接按钮            
        }

        private void RefreshDeviceButton_Click(object sender, EventArgs e)
        {
            DevComboBox.Enabled = false; // 禁用选择框
            RefreshDeviceButton.Enabled = false; // 禁用刷新按钮
            ConnectDeviceButton.Enabled = false; // 禁用连接按钮

            // 在后台线程中执行查询操作
            GetDevWorker.RunWorkerAsync();
        }

        private void ConnectDeviceButton_Click(object sender, EventArgs e)
        {
            if (DevSerial != null && DevSerial.IsOpen)
            {
                DevSerial.Close();
                ConnectDeviceButton.Text = "打开";

                DevComboBox.Enabled = true; // 启用选择框
                BaudComboBox.Enabled = true; // 启用波特率选择框
                RefreshDeviceButton.Enabled = true; // 启用刷新按钮

                return;
            }

            if (DevComboBox.SelectedItem == null)
            {
                MessageBox.Show("请选择设备", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (BaudComboBox.SelectedItem == null)
            {
                MessageBox.Show("请选择波特率", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string SelectedPort = DevComboBox.SelectedItem.ToString();
            string SerialName = Regex.Match(SelectedPort, @"COM\d+").Value;

            int BaudValue = Convert.ToInt32(BaudComboBox.SelectedItem.ToString());

            DevSerial.PortName = SerialName;
            DevSerial.BaudRate = BaudValue;
            DevSerial.DataBits = 8;
            DevSerial.Parity = Parity.None;
            DevSerial.StopBits = StopBits.One;

            try
            {
                ConnectDeviceButton.Enabled = false; // 禁用连接按钮
                DevComboBox.Enabled = false; // 禁用选择框
                BaudComboBox.Enabled = false; // 禁用波特率选择框
                RefreshDeviceButton.Enabled = false; // 禁用刷新按钮

                DevSerial.Open();
                ConnectDeviceButton.Enabled = true; // 启用连接按钮

                ConnectDeviceButton.Text = "关闭";
            }
            catch (Exception ex)
            {
                // 处理串口打开失败的情况
                MessageBox.Show("无法打开串口：" + ex.Message);
                ConnectDeviceButton.Enabled = true; // 启用连接按钮
                DevComboBox.Enabled = true; // 启用选择框
                BaudComboBox.Enabled = true; // 启用波特率选择框
                RefreshDeviceButton.Enabled = true; // 启用刷新按钮
            }
        }
        #endregion

        #region 进制转换工具
        private void DecimalConversionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DecimalConversionToolButton.Enabled = true; // 启用按钮
        }

        private void DecimalConversionToolButton_Click(object sender, EventArgs e)
        {
            DecimalConversionToolButton.Enabled = false; // 禁用按钮

            // 创建新窗体实例
            DecimalConversion DecimalConversionForm = new DecimalConversion();

            // 绑定窗体关闭事件
            DecimalConversionForm.FormClosed += DecimalConversionForm_FormClosed;

            // 显示新窗体
            DecimalConversionForm.Show();
        }


        #endregion

        #region 通信
        // 定义事件参数类
        public class DataEventArgs : EventArgs
        {
            public byte[] Data { get; set; }
            public int Length { get; set; }
        }

        // 定义委托
        public delegate void DataReceivedEventHandler(object sender, DataEventArgs e);

        // 定义事件
        public event DataReceivedEventHandler DataReceived;
        public event DataReceivedEventHandler DataSend;

        DataForm DataFormShow;

        private void CommInit()
        {
            // 创建右键菜单
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            // 添加菜单项
            ToolStripMenuItem signedMenuItem = new ToolStripMenuItem("显示数据窗口");
            signedMenuItem.Click += (sender, e) =>
            {
                if (DataFormShow != null && !DataFormShow.IsDisposed)
                {
                    return;
                }
                DataFormShow = new DataForm(this);
                DataFormShow.Show();
            };
            contextMenuStrip.Items.Add(signedMenuItem);

            // 将右键菜单分配给 DataGridView 
            DrvBox.ContextMenuStrip = contextMenuStrip;

            DataSend += DevSerial_DataSend;
        }

        private void DevSerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int readlen;

            try
            {
                do
                {
                    readlen = DevSerial.BytesToRead;
                    Thread.Sleep(20);
                }
                while (readlen != DevSerial.BytesToRead);

                byte[] rxbuffer = new byte[readlen];

                DevSerial.Read(rxbuffer, 0, readlen);

                DataReceived?.Invoke(this, new DataEventArgs { Data = rxbuffer, Length = readlen });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DevSerial_DataSend(object sender, DataEventArgs e)
        {
            try
            {
                if (DevSerial != null && DevSerial.IsOpen)
                {
                    DevSerial.Write(e.Data, 0, e.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
