using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
              public string InputText { get; set; }
        　　  public string ResultText { get; set; }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.Text = "Form②";
            label3.Text = InputText;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 10;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label3.Text))
                return;

            string[] text = label3.Text
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();

            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4 };
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Text = i < text.Length ? text[i] : string.Empty;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label3.Text))
                return;

            string[] text = label3.Text
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();

            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4 };
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Text = i < text.Length ? text[i] : string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4 };
            foreach (var box in boxes)
            {
                box.Text = box.Text.Trim();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TextBox[] boxes = { textBox1, textBox2, textBox3, textBox4 };
            foreach (var box in boxes)
            {
                box.Text = box.Text.Replace(" ", "");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] arr =
           {
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text
            };
            string result = string.Join(",", arr.Where(v => !string.IsNullOrEmpty(v)));

            textBox5.Text = result;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int value = (int)numericUpDown1.Value;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i <= value; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    sb.Append(j);
                }
                sb.AppendLine();
            }
            richTextBox1.Text = sb.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ResultText = textBox5.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
       
    }
}
