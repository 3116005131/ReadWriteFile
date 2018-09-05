using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ReadWriteFile
{
    public partial class Form1 : Form
    {
        private int flag = 0;
        private string str = "";
        private string filename = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode(textBox2.Text,0,0);
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(node);
            TreeNode topnode = treeView1.TopNode;
            //获取指定目录下的所有文件
            string[] Files = Directory.GetFiles(textBox2.Text, "*.txt");
            for(int i = 0; i<Files.Length; i++)
            {
                string s = Files[i].Substring(Files[i].LastIndexOf('\\') + 1);
                node = new TreeNode(s, 1, 2);
                topnode.Nodes.Add(node);
            }
            topnode.Expand();
        }


        //"保存当前文件"按钮
        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename, false, System.Text.Encoding.Default);
                writer.WriteLine(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (writer != null) writer.Close();
            }
            
        }

        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            filename = textBox2.Text + "\\" + treeView1.SelectedNode.Text;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filename, System.Text.Encoding.Default);
                string line = reader.ReadLine();
                textBox1.Text = "";
                while (line != null)
                {
                    textBox1.Text += line + "\r\n";
                    line = reader.ReadLine();
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files(*.txt)|*.txt";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files( * .txt)| * .txt ";
            if(saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            str = textBox3.Text;
            if (flag == 1) str = str.ToLower();
            else if (flag == 2) str = str.ToUpper();
            //如果 flag = 0，则表示原样输出
            textBox4.Text = str;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            flag = 2;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int ascii = c;      //获取字符的ASCII码

            if((ascii >= 65 &&ascii <= 90) || (ascii >=97 && ascii <= 122))
            {                                               //c为字母
                if (checkBox1.Checked) str += c.ToString(); //如果允许输入字母
            }
            else if (ascii >= 48 && ascii <= 57)            //c为数字时
            {
                if (checkBox2.Checked) str += c.ToString();//如果允许输入数字
            }
            else
            {
                //如果允许输入其他可视字符
                if (checkBox3.Checked) str += c.ToString();
            }

        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            textBox3.Text = str;
            textBox3.Focus();
            textBox3.Select(textBox3.Text.Length, 0);
        }

        private void rTBoxEditerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
        }
    }
}
