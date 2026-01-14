using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "課題form";

            label1.Text = "あいうえお";
            label1.ForeColor = System.Drawing.Color.Blue;

            textBox1.Text = "入力可能";
            textBox1.ForeColor = System.Drawing.Color.Green;

            button1.Text = "Push!";
            button1.ForeColor = System.Drawing.Color.White;
            button1.BackColor = System.Drawing.Color.Red;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
