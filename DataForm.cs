using System;
using System.Windows.Forms;

namespace ModbusConnect
{
    public partial class DataForm : Form
    {
        private readonly MainForm MainForm;

        public DataForm(MainForm mainForm)
        {
            InitializeComponent();

            MainForm = mainForm;
        }

        public void ShowDataSend(object sender, MainForm.DataEventArgs e)
        {
            string str = DateTime.Now.ToString("[HH:mm:ss.fff]") + "发 -> : ";
            for (int i = 0; i < e.Length; i++)
            {
                str += e.Data[i].ToString("X2") + " ";
            }
            try
            {
                DataTextBox.Invoke(new Action(() =>
                {
                    DataTextBox.AppendText(str + "\r\n");
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowDataReceive(object sender, MainForm.DataEventArgs e)
        {
            string str = DateTime.Now.ToString("[HH:mm:ss.fff]") + "收 <- : ";
            for (int i = 0; i < e.Length; i++)
            {
                str += e.Data[i].ToString("X2") + " ";
            }

            try
            {
                DataTextBox.Invoke(new Action(() =>
                {
                    DataTextBox.AppendText(str + "\r\n");
                }));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.DataReceived -= ShowDataReceive;
            MainForm.DataSend -= ShowDataSend;
            DataTextBox.Dispose();
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            MainForm.DataReceived += ShowDataReceive;
            MainForm.DataSend += ShowDataSend;
        }
    }
}
