using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.Management;
using System.Text.RegularExpressions;

namespace ModbusConnect
{
    public partial class MainForm : Form
    {
        private bool IsSerialConnected = false;

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

            BaudComboBox.SelectedItem = "115200";

            DevComboBox.Enabled = false; // 禁用选择框
            RefreshDeviceButton.Enabled = false; // 禁用刷新按钮
            ConnectDeviceButton.Enabled = false; // 禁用连接按钮

            // 在后台线程中执行查询操作
            GetDevWorker.RunWorkerAsync();
        }

        #region 设备
        private string GetDeviceNames(string portName)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%" + portName + "%'");
            foreach (ManagementObject obj in searcher.Get().Cast<ManagementObject>())
            {
                return obj["Name"].ToString();
            }
            return portName;
        }

        private void GetDevWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();
            List<string> deviceNames = new List<string>();

            foreach (string portName in portNames)
            {
                string deviceName = GetDeviceNames(portName);
                deviceNames.Add(deviceName);
            }

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
            if (IsSerialConnected)
            {
                DevSerial.Close();
                IsSerialConnected = false;
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

                IsSerialConnected = true;
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

    }
}
