using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private void textBox1_keyPress(object sender,KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;          

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int value))
            {
                label1.Text = "正しい数値を入力してください";
                return;
            }

            bool isLessThan5 = value < 5;
            bool isEven = value % 2 == 0;

            if (isLessThan5 && isEven)
                label1.Text = "5より小さい2の倍数";
            else if (isLessThan5 && !isEven)
                label1.Text = "5より小さい2の倍数ではない";
            else if (!isLessThan5 && isEven)
                label1.Text = "5以上　2の倍数";
            else
                label1.Text = "5以上　2の倍数ではない";
        }
       
        

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
