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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        String fileName1;
        String str;
        String[] word = new String[100];
        int[,] pos = new int[100, 3];
        int i = 0, j = 0, k = 0, n = 0;
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";
            openFileDialog1.Filter = "文本文件|*.txt";

            dataGridView1.RowCount = 50;
            dataGridView1.ColumnCount = 50;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            for (j = 0; j < 50; j++)
                dataGridView1.Columns[j].Width = 20;

            label1.Text = "";
            label2.Text = "";
         }

        private void button1_Click(object sender, EventArgs e)
        {
           
            openFileDialog1.ShowDialog();//打开文件对话框
            fileName1 = openFileDialog1.FileName;//获取文件名

            str = File.ReadAllText(fileName1);//打开文件

            word = str.Split('\n');
          
            for (i = 0; word[i] != ""; i++)
                label2.Text += word[i];

            n = i;
            label2.Text += "\n\n共" + n + "个单词";
            //label1.Text = word[0][1].ToString();


            /*for (i = 0; i < n; i++)
                for (j = 0; j < word[i].Length;j++ )
                    dataGridView1[j, i].Value = word[i][j];
          */
            pos[0, 0] = 20;
            pos[0, 1] = 20;
            pos[0, 2] = 1;
           
         
            for(i=0;i<n;i++)
                for(j=0;j<word[i].Length-1;j++)
                    for(k=0;k<word[i+1].Length-1;k++)
                    {
                        if (word[i + 1][k] == word[i][j])

                        {

                            label1.Text += (i + 1) + " " + (j + 1) + " " + (i + 2) + " " + (k + 1) + "\n";
                            //查看相邻单词间所有可能的交叉情况
                        }
                    }


        }

        
    }
}
