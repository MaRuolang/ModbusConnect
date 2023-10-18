using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModbusConnect
{
    public partial class DecimalConversion : Form
    {
        private CancellationTokenSource cancellationTokenSource;

        public DecimalConversion()
        {
            InitializeComponent();
        }

        private void SuccessLabelCtrl(bool isSuccessful)
        {
            if (isSuccessful)
            {
                CopySuccessLabel.Text = "复制成功!";
                CopySuccessLabel.ForeColor = Color.Green;
                CopySuccessLabel.Visible = true;
            }
            else
            {
                CopySuccessLabel.Text = "复制失败!";
                CopySuccessLabel.ForeColor = Color.Red;
                CopySuccessLabel.Visible = true;
            }

            // 取消前一个延迟任务
            cancellationTokenSource?.Cancel();

            // 创建新的延迟任务
            cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            Task.Delay(1000, cancellationToken).ContinueWith((t) =>
            {
                if (!t.IsCanceled)
                {
                    CopySuccessLabel.Invoke((MethodInvoker)(() =>
                    {
                        CopySuccessLabel.Visible = false;
                    }));
                }
            });
        }

        private void HEXCopyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(HEXTextBox.Text))
            {
                SuccessLabelCtrl(false);
                return;
            }

            try
            {
                string text = string.Format("0x{0}", HEXTextBox.Text);
                Clipboard.SetText(text);

                SuccessLabelCtrl(true);
            }
            catch (FormatException)
            {
                SuccessLabelCtrl(false);
            }
        }

        private void DECCopyButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DECTextBox.Text))
            {
                SuccessLabelCtrl(false);
                return;
            }

            try
            {
                Clipboard.SetText(DECTextBox.Text);

                SuccessLabelCtrl(true);
            }
            catch (FormatException)
            {
                SuccessLabelCtrl(false);
            }
        }

        private void HEXTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!HEXTextBox.Focused)
            {
                return;
            }

            try
            {
                if (!string.IsNullOrEmpty(HEXTextBox.Text))
                {
                    string hexText = HEXTextBox.Text;
                    int decValue = Convert.ToInt32(hexText, 16);
                    DECTextBox.Text = decValue.ToString();
                }
                WarnLabel.Visible = false;
            }
            catch (FormatException)
            {
                // 处理输入数据格式错误的情况
                DECTextBox.Text = "";
                WarnLabel.Visible = true;
            }
        }

        private void DECTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!DECTextBox.Focused)
            {
                return;
            }

            try
            {
                if (!string.IsNullOrEmpty(DECTextBox.Text))
                {
                    string decText = DECTextBox.Text;
                    int decValue = int.Parse(decText);
                    string hexValue = decValue.ToString("X");
                    HEXTextBox.Text = hexValue;
                }
                WarnLabel.Visible = false;
            }
            catch (FormatException)
            {
                // 处理输入数据格式错误的情况
                HEXTextBox.Text = "";
                WarnLabel.Visible = true;
            }
        }

        private void DecimalConversion_Load(object sender, EventArgs e)
        {
            WarnLabel.Visible = false;
        }
    }
}
