using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "Form①";

            timer1.Interval = 1000;
            timer1.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text = "ファイル選択：";
            label1.ForeColor = Color.Black;

        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = "ファイル内容：";
            label2.ForeColor = Color.Black;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = Message_manage.Title1;
                ofd.Filter = "すべてのファイル (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = ofd.FileName;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(textBox1.Text))
                {
                    throw new FileNotFoundException();
                }
                label3.Text = File.ReadAllText(textBox1.Text);
            }
            catch
            {
                MessageBox.Show(
                    Message_manage.Msg2,
                    Message_manage.Title4,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                Message_manage.Msg1,
                Message_manage.Title3,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Form4 form4 = new Form4();
                form4.InputText = label3.Text;

                if (form4.ShowDialog() == DialogResult.OK)
                {
                    label4.Text = form4.ResultText;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                Message_manage.Msg1,
                Message_manage.Title3,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.Text = "Form2 ソースコード（返却値）";
            this.groupBox1.Location = new System.Drawing.Point(20, 250);
            this.groupBox1.Size = new System.Drawing.Size(500, 250);


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.BackColor = Color.Yellow;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            label4.BackColor = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label4.BackColor = Color.Blue;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(textBox1.Text))
                {
                    throw new FileNotFoundException();
                }
                File.WriteAllText(textBox1.Text, label4.Text);

                MessageBox.Show(
                    Message_manage.Msg3,
                    Message_manage.Title2,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception )
            {
                MessageBox.Show(
                    Message_manage.Msg2,
                    Message_manage.Title4,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
            label5.Invalidate(); // 再描画
        }

        private void LabelTime_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush =
                new LinearGradientBrush(label5.ClientRectangle,
                                        Color.White,
                                        Color.Blue,
                                        90F))
            {
                e.Graphics.FillRectangle(brush, label5.ClientRectangle);
            }

            TextRenderer.DrawText(
                e.Graphics,
                label5.Text,
                label5.Font,
                label5.ClientRectangle,
                Color.Black,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);


        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

