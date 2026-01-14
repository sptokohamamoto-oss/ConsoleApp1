using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "課題Form";

            label1.Text = "あいうえお";
            label1.ForeColor = System.Drawing.Color.Blue;

            textBox1.Text = "入力可能";
            textBox1.ForeColor = System.Drawing.Color.Green;

            button1.Text = "Push!";
            button1.ForeColor = System.Drawing.Color.White;
            button1.BackColor = System.Drawing.Color.Red;
        }
    }
}
