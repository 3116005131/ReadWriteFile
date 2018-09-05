using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadWriteFile
{
    public partial class Form3 : Form
    {
        private void SetFont(String fontname)
        {
            Font ft;
            textBox1.Text = richTextBox1.SelectionStart.ToString();
            int start = richTextBox1.SelectionStart;
            int end = richTextBox1.SelectionStart + richTextBox1.SelectionLength - 1;
            for (int i = start; i <= end; i++)
            {
                richTextBox1.Select(i, 1);
                ft = richTextBox1.SelectionFont;
                ft = new Font(fontname, ft.Size, ft.Style);
                richTextBox1.SelectionFont = ft;
            }
            richTextBox1.Select(start, end - start + 1);
            richTextBox1.Focus();
        }

        private void SetFont(int fontsize)
        {
            Font ft;
            textBox1.Text = richTextBox1.SelectionStart.ToString();
            int start = richTextBox1.SelectionStart;
            int end = richTextBox1.SelectionStart + richTextBox1.SelectionLength - 1;
            for (int i = start; i <= end; i++)
            {
                richTextBox1.Select(i, 1);
                ft = richTextBox1.SelectionFont;
                ft = new Font(ft.Name, fontsize, ft.Style);
                richTextBox1.SelectionFont = ft;
            }
            richTextBox1.Select(start, end - start + 1);
            richTextBox1.Focus();
        }

        private void SetFont(FontStyle style,char c)
        {
            Font ft;
            textBox1.Text = richTextBox1.SelectionStart.ToString();
            int start = richTextBox1.SelectionStart;
            int end = richTextBox1.SelectionStart + richTextBox1.SelectionLength - 1;
            for (int i = start; i <= end; i++)
            {
                richTextBox1.Select(i, 1);
                ft = richTextBox1.SelectionFont;
                System.Drawing.FontStyle fs = ft.Style;
                if (c == '+') fs = (System.Drawing.FontStyle)(fs | style);
                else fs = (System.Drawing.FontStyle)(fs - style);
                if (fs.ToString().IndexOf("Strikeout") >= 0)
                    fs = (System.Drawing.FontStyle)(fs - FontStyle.Strikeout);
                ft = new Font(ft.Name, ft.Size, fs);
                richTextBox1.SelectionFont = ft;
            }
            richTextBox1.Select(start, end - start + 1);
            richTextBox1.Focus();
        }
        public Form3()
        {
            InitializeComponent();
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            SetFont(16);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.FontStyle fs = FontStyle.Regular;
            if (button1.FlatStyle==FlatStyle.Flat)
            {
                button1.FlatStyle = FlatStyle.Standard;
                button1.BackColor = Color.White;
                fs = System.Drawing.FontStyle.Bold;
                SetFont(fs, '-');
            }
            else
            {
                button1.FlatStyle = FlatStyle.Flat;
                button1.BackColor = Color.Silver;
                fs = System.Drawing.FontStyle.Bold;
                SetFont(fs, '+');
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.FontStyle fs = FontStyle.Regular;
            if (button2.FlatStyle == FlatStyle.Flat)
            {
                button2.FlatStyle = FlatStyle.Standard;
                button2.BackColor = Color.White;
                fs = System.Drawing.FontStyle.Italic;
                SetFont(fs, '-');
            }
            else
            {
                button2.FlatStyle = FlatStyle.Flat;
                button2.BackColor = Color.Silver;
                fs = System.Drawing.FontStyle.Italic;
                SetFont(fs, '+');
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Drawing.FontStyle fs = FontStyle.Regular;
            if (button3.FlatStyle == FlatStyle.Flat)
            {
                button3.FlatStyle = FlatStyle.Standard;
                button3.BackColor = Color.White;
                fs = System.Drawing.FontStyle.Underline;
                SetFont(fs, '-');
            }
            else
            {
                button3.FlatStyle = FlatStyle.Flat;
                button3.BackColor = Color.Silver;
                fs = System.Drawing.FontStyle.Underline;
                SetFont(fs, '+');
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SetFont("宋体");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SetFont("楷体_GB2312");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetFont("隶书");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Black;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Blue;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            SetFont(13);
        }
    }
}
