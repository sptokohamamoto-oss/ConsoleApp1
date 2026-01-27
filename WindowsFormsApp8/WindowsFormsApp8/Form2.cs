using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        string[] DaysArray = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
        string[] YearsArray = { "Jan.", "Feb.", "Mar.", "Apr.", "May.", "Jun.","Jul.", "Aug.", "Sep.", "Oct.",  "Nov.", "Dec." };
        RadioButton[] dayRadios;
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Form③";


            dayRadios = new RadioButton[]
             {
                radioButton1, radioButton2, radioButton3,
                radioButton4, radioButton5, radioButton6, radioButton7
            };
            for (int i = 0; i < DaysArray.Length; i++)
            {
                dayRadios[i].Text = DaysArray[i];
            }

            comboBox1.Items.Clear();
            for (int i = 1; i < DaysArray.Length; i++)
            {
                comboBox1.Items.Add(DaysArray[i]);
            }

            label1.Text = "Days";
            label2.Text = "Days";

            try
            {
                var path = "cat_mikeneko2.png";
                if (System.IO.File.Exists(path))
                {
                    pictureBox1.BackgroundImage = Image.FromFile(path);
                    pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    MessageBox.Show("画像ファイルが見つかりません。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("画像の読み込みに失敗しました。");
            }
        }
        private void DayRadio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                label1.Text = rb.Text;
            }
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";

            if (radioButton8.Checked)
            {
                foreach (var item in DaysArray)
                {
                    if (!string.IsNullOrEmpty(item))
                        comboBox1.Items.Add(item);
                }
                label2.Text = "Days";
            }
            else if (radioButton9.Checked)
            {
                foreach (var item in YearsArray)
                {
                    if (!string.IsNullOrEmpty(item))
                        comboBox1.Items.Add(item);
                }
                label2.Text = "Years";
            }
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "";

            if (radioButton8.Checked)
            {
                foreach (var item in DaysArray)
                {
                    if (!string.IsNullOrEmpty(item))
                        comboBox1.Items.Add(item);
                }
                label2.Text = "Days";
            }
            else if (radioButton9.Checked)
            {
                foreach (var item in YearsArray)
                {
                    if (!string.IsNullOrEmpty(item))
                        comboBox1.Items.Add(item);
                }
                label2.Text = "Years";
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                label2.Text = comboBox1.SelectedItem.ToString();
            }
        }

        private void UpdateButtonState()
        {
            button1.Enabled =
                checkBox1.Checked &&
                checkBox2.Checked &&
                checkBox3.Checked;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.Yellow;
            button1.Cursor = Cursors.Hand;

        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Yellow;
            button1.ForeColor = Color.Black;
            button1.Cursor = Cursors.Default;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            }

            else if (radioButton11.Checked)
            {
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else if (radioButton12.Checked)
            {
                pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(
                        Message_manage.Msg4,
                        Message_manage.Title3,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
        }
    }
}
