using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                label1.Text = "からっぽ";
                label1.ForeColor = Color.Yellow;
            }
            else 
            {
                CheckInputContent(textBox1.Text);
            }
        }

        private void CheckInputContent(string InputText) 
        {
            bool containsYama = InputText.Contains("山");
            bool containsUmi = InputText.Contains("海");
            if (containsYama && containsUmi)
            {
                label1.Text = "どちらも含まれている";
                label1.ForeColor = Color.Red;
            }
            else if (containsYama)
            {
                label1.Text = "山が含まれている";
                label1.ForeColor = Color.Green;
            }
            else if (containsUmi)
            {
                label1.Text = "海が含まれている";
                label1.ForeColor = Color.Blue;
            }
            else 
            {
                label1.Text = "どちらも含まれていない";
                label1.ForeColor = Color.Black;
            
            }
        
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
