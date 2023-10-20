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

            ModbusSerialRegister();
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
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip()
            {
                Items =
                {
                    new ToolStripMenuItem("设置为有符号", null, (sender, e) => UpdateCellProperties(DATA_TYPE.DATA_TYPE_SIGNED)),
                    new ToolStripMenuItem("设置为无符号", null, (sender, e) => UpdateCellProperties(DATA_TYPE.DATA_TYPE_UNSIGNED)),
                    new ToolStripMenuItem("设置为十六进制", null, (sender, e) => UpdateCellProperties(DATA_TYPE.DATA_TYPE_HEX))
                }
            };

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

                    switch (dataType)
                    {
                        case DATA_TYPE.DATA_TYPE_SIGNED:
                            selectedCell.ToolTipText = "有符号";
                            break;

                        case DATA_TYPE.DATA_TYPE_UNSIGNED:
                            selectedCell.ToolTipText = "无符号";
                            break;

                        case DATA_TYPE.DATA_TYPE_HEX:
                            selectedCell.ToolTipText = "十六进制";
                            break;

                        default:
                            selectedCell.ToolTipText = "未知";
                            break;
                    }
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

                    RegisterDataGridView.Rows[row].Cells[column].ToolTipText = "无符号";
                }
            }
        }

        private void RegNumNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            DrawDataGrid();
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

        #region Modbus
        private void ModbusSerialRegister()
        {
            DataReceived += ModbusSerial_DataReceived;
        }

        private void ModbusSerial_DataReceived(object sender, DataEventArgs e)
        {
            if (!CheckCRC(e.Data))
            {
                Console.WriteLine("CRC校验失败");
                return;
            }

            if (e.Data[0] != AddrNumericUpDown.Value)
            {
                Console.WriteLine("地址不匹配");
                return;
            }

            if (e.Data[1] != 0x03)
            {
                Console.WriteLine("命令不匹配");
                return;
            }

            if (e.Length != 8)
            {
                Console.WriteLine("数据长度不匹配");
                return;
            }

            int addrstart = e.Data[2] * 16 + e.Data[3];
            int regnum = e.Data[4] * 16 + e.Data[5];

            if ((addrstart + regnum) >= (RegisterDataGridView.Rows.Count * RegisterDataGridView.Columns.Count / 2))
            {
                Console.WriteLine("地址超出范围");
                return;
            }

            ushort[] regs = ReadHoldingRegisters();

            byte[] data = new byte[regnum * 2 + 5];

            data[0] = (byte)AddrNumericUpDown.Value;
            data[1] = 0x03;
            data[2] = (byte)regnum;

            for (int i = 0; i < regnum; i++)
            {
                data[3 + i * 2] = (byte)(regs[addrstart + i] >> 8);
                data[3 + i * 2 + 1] = (byte)(regs[addrstart + i] & 0xFF);
            }

            byte[] crc = Crc16(data, data.Length - 2);
            data[data.Length - 2] = crc[0];
            data[data.Length - 1] = crc[1];

            DataSend?.Invoke(this, new DataEventArgs { Data = data, Length = data.Length });
        }

        private ushort GetCellValue(DataGridViewCell cell)
        {
            if (cell.Value == null)
            {
                cell.Style.BackColor = Color.Yellow;
                return 0;
            }

            string Value = cell.Value.ToString();
            ushort reg;

            Tuple<int, int> cellPosition = Tuple.Create(cell.RowIndex, cell.ColumnIndex);

            try
            {
                switch (cellPropertiesDict[cellPosition].DataType)
                {
                    case DATA_TYPE.DATA_TYPE_SIGNED:
                        {
                            reg = (ushort)short.Parse(Value);
                        }
                        break;

                    case DATA_TYPE.DATA_TYPE_UNSIGNED:
                        {
                            reg = ushort.Parse(Value);
                        }
                        break;

                    case DATA_TYPE.DATA_TYPE_HEX:
                        {
                            reg = Convert.ToUInt16(Value, 16);
                        }

                        break;

                    default:
                        cell.Style.BackColor = Color.Red;
                        return 0;
                }
                cell.Style.BackColor = Color.White;
            }
            catch (Exception)
            {
                cell.Style.BackColor = Color.Red;
                reg = 0;
            }


            return reg;
        }

        private ushort[] ReadHoldingRegisters()
        {
            ushort[] regs = new ushort[RegisterDataGridView.Rows.Count * RegisterDataGridView.Columns.Count / 2];

            int i = 0;
            for (int column = 1; column < RegisterDataGridView.Columns.Count; column += 2)
            {
                // 遍历每一行
                for (int row = 0; row < RegisterDataGridView.Rows.Count; row++)
                {
                    // 获取当前单元格的值
                    DataGridViewCell cell = RegisterDataGridView.Rows[row].Cells[column];

                    regs[i++] = GetCellValue(cell);
                }
            }

            return regs;
        }
        #endregion

        #region  CRC校验
        private static readonly byte[] aucCRCHi = {
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x00, 0xC1, 0x81, 0x40,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40, 0x01, 0xC0, 0x80, 0x41, 0x01, 0xC0, 0x80, 0x41,
            0x00, 0xC1, 0x81, 0x40
        };
        private static readonly byte[] aucCRCLo = {
            0x00, 0xC0, 0xC1, 0x01, 0xC3, 0x03, 0x02, 0xC2, 0xC6, 0x06, 0x07, 0xC7,
            0x05, 0xC5, 0xC4, 0x04, 0xCC, 0x0C, 0x0D, 0xCD, 0x0F, 0xCF, 0xCE, 0x0E,
            0x0A, 0xCA, 0xCB, 0x0B, 0xC9, 0x09, 0x08, 0xC8, 0xD8, 0x18, 0x19, 0xD9,
            0x1B, 0xDB, 0xDA, 0x1A, 0x1E, 0xDE, 0xDF, 0x1F, 0xDD, 0x1D, 0x1C, 0xDC,
            0x14, 0xD4, 0xD5, 0x15, 0xD7, 0x17, 0x16, 0xD6, 0xD2, 0x12, 0x13, 0xD3,
            0x11, 0xD1, 0xD0, 0x10, 0xF0, 0x30, 0x31, 0xF1, 0x33, 0xF3, 0xF2, 0x32,
            0x36, 0xF6, 0xF7, 0x37, 0xF5, 0x35, 0x34, 0xF4, 0x3C, 0xFC, 0xFD, 0x3D,
            0xFF, 0x3F, 0x3E, 0xFE, 0xFA, 0x3A, 0x3B, 0xFB, 0x39, 0xF9, 0xF8, 0x38,
            0x28, 0xE8, 0xE9, 0x29, 0xEB, 0x2B, 0x2A, 0xEA, 0xEE, 0x2E, 0x2F, 0xEF,
            0x2D, 0xED, 0xEC, 0x2C, 0xE4, 0x24, 0x25, 0xE5, 0x27, 0xE7, 0xE6, 0x26,
            0x22, 0xE2, 0xE3, 0x23, 0xE1, 0x21, 0x20, 0xE0, 0xA0, 0x60, 0x61, 0xA1,
            0x63, 0xA3, 0xA2, 0x62, 0x66, 0xA6, 0xA7, 0x67, 0xA5, 0x65, 0x64, 0xA4,
            0x6C, 0xAC, 0xAD, 0x6D, 0xAF, 0x6F, 0x6E, 0xAE, 0xAA, 0x6A, 0x6B, 0xAB,
            0x69, 0xA9, 0xA8, 0x68, 0x78, 0xB8, 0xB9, 0x79, 0xBB, 0x7B, 0x7A, 0xBA,
            0xBE, 0x7E, 0x7F, 0xBF, 0x7D, 0xBD, 0xBC, 0x7C, 0xB4, 0x74, 0x75, 0xB5,
            0x77, 0xB7, 0xB6, 0x76, 0x72, 0xB2, 0xB3, 0x73, 0xB1, 0x71, 0x70, 0xB0,
            0x50, 0x90, 0x91, 0x51, 0x93, 0x53, 0x52, 0x92, 0x96, 0x56, 0x57, 0x97,
            0x55, 0x95, 0x94, 0x54, 0x9C, 0x5C, 0x5D, 0x9D, 0x5F, 0x9F, 0x9E, 0x5E,
            0x5A, 0x9A, 0x9B, 0x5B, 0x99, 0x59, 0x58, 0x98, 0x88, 0x48, 0x49, 0x89,
            0x4B, 0x8B, 0x8A, 0x4A, 0x4E, 0x8E, 0x8F, 0x4F, 0x8D, 0x4D, 0x4C, 0x8C,
            0x44, 0x84, 0x85, 0x45, 0x87, 0x47, 0x46, 0x86, 0x82, 0x42, 0x43, 0x83,
            0x41, 0x81, 0x80, 0x40
        };
        private byte[] Crc16(byte[] pucFrame, int usLen)
        {
            int i = 0;
            byte[] res = new byte[2] { 0xFF, 0XFF };
            ushort iIndex;

            while (usLen-- > 0)
            {
                iIndex = (ushort)(res[0] ^ pucFrame[i++]);
                res[0] = (byte)(res[1] ^ aucCRCHi[iIndex]);
                res[1] = aucCRCLo[iIndex];
            }
            return res;

        }
        private bool CheckCRC(byte[] value)
        {
            if (value == null) return false;
            if (value.Length <= 2) return false;
            int length = value.Length;
            byte[] buf = new byte[length - 2];
            Array.Copy(value, 0, buf, 0, buf.Length);
            byte[] CRCbuf = Crc16(buf, buf.Length);
            if (CRCbuf[0] == value[length - 2] && CRCbuf[1] == value[length - 1])
            {
                return true;
            }
            else return false;

        }
        #endregion
    }
}
