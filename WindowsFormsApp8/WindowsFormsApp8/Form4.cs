using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form4 : Form
    {
        private TextBox[] _boxes;

        public Form4()
        {
            InitializeComponent();
            _boxes = new[] { textBox1, textBox2, textBox3, textBox4 };
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label3.Text))
                return;

            string[] text = label3.Text
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();

            for (int i = 0; i < _boxes.Length; i++)
            {
                _boxes[i].Text = i < text.Length ? text[i] : string.Empty;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            foreach (var box in _boxes)
            {
                box.Text = box.Text.Trim();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            foreach (var box in _boxes)
            {
                box.Text = box.Text.Replace(" ", "");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string result = string.Join(",", _boxes
               .Select(b => b.Text)
               .Where(v => !string.IsNullOrEmpty(v)));

            textBox5.Text = result;
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
