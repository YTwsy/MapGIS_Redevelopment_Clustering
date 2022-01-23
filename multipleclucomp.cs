using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace GIS_project
{
    public partial class multipleclucomp : Form
    {
        public multipleclucomp()
        {
            InitializeComponent();
        }

        private void multipleclucomp_Load(object sender, EventArgs e)
        {
            label5.Text = "当前并行次数为：" + Convert.ToString(Kcount+Dcount);
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "聚类数量";
            label3.Text = "迭代次数";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Text = "Eps(邻域半径)";
            label3.Text = "minPts(邻域点)";
        }

        #region 获取参数

        private string cluster1 = null;
        private string cluster2 = null;
        private int Kcount = 0;
        private int Dcount = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cluster1 = textBox1.Text;
                cluster2 = textBox2.Text;

                FileStream fs = new("k-means_K&max_cluster_" + Kcount + ".txt", System.IO.FileMode.Create, FileAccess.Write);
                StreamWriter sw = new(fs);
                sw.WriteLine(cluster1);
                sw.WriteLine(cluster2);
                sw.Close();
                Kcount += 1;
                MessageBox.Show("添加成功！");
                label5.Text = "当前并行次数为：" + Convert.ToString(Kcount+ Dcount);

            }
            else if (radioButton2.Checked)
            {
                cluster1 = textBox1.Text;
                cluster2 = textBox2.Text;
                FileStream fs = new("dbscan_eps_min_pts_" + Dcount + ".txt", System.IO.FileMode.Create, FileAccess.Write);
                StreamWriter sw = new(fs);
                sw.WriteLine(cluster1);
                sw.WriteLine(cluster2);
                sw.Close();
                Dcount += 1;
                MessageBox.Show("添加成功！");
                label5.Text = "当前并行次数为：" + Convert.ToString(Kcount + Dcount);
            }
            else
            {
                MessageBox.Show("未选择聚类类型");

            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Kcount = 0;
            Dcount = 0;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (radioButton1.Checked)
            //{
            //    createThread1(Convert.ToString(count));
            //    count = 0;
            //    label5.Text = "当前并行次数为：" + Convert.ToString(count);
            //}
            //else if (radioButton2.Checked)
            //{
            //    createThread2(Convert.ToString(count));
            //    count = 0;
            //    label5.Text = "当前并行次数为：" + Convert.ToString(count);
            //}
            //else
            //{
            //    MessageBox.Show("未选择聚类方式！");
            //}
            if  (radioButton1.Checked)
                { 
                   createThread1(Convert.ToString(Kcount));
                   createThread2(Convert.ToString(Dcount));

                   Kcount = 0;
                   Dcount = 0;

                   label5.Text = "当前并行次数为：" + Convert.ToString(Kcount+Dcount);
                }
            else if (radioButton2.Checked)
            {
                createThread1(Convert.ToString(Kcount));
                createThread2(Convert.ToString(Dcount));

                Kcount = 0;
                Dcount = 0;

                label5.Text = "当前并行次数为：" + Convert.ToString(Kcount + Dcount);
            }
            else
            {
                MessageBox.Show("未选择聚类方式！");
            }
        }

        private void createThread1(string n)
        {
            //Thread[] workThreads = new Thread[n];
            int a = 0;
            a = int.Parse(n);
            for (int i = 0; i < a; i++)
            {

                Thread newThread = new Thread(test1);
                newThread.Start(i.ToString());
                ;
            }
        }
        private void createThread2(string j)
        {
            //Thread[] workThreads = new Thread[j];
            int k = 0;
            k = int.Parse(j);

            for (int i = 0; i < k; i++)
            {

                Thread newThread1 = new Thread(test2);
                newThread1.Start(i.ToString());
            }
        }

        private void test1(object obj)
        {
            //throw new NotImplementedException();
            Process p = new Process();
            p.StartInfo.FileName = "K-means_PRO.exe";
            p.StartInfo.Arguments = obj.ToString();
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.WaitForExit();//关键，等待外部程序退出后才能往下执行          
            p.StartInfo.FileName = "show_point_with_class.exe";
            p.StartInfo.Arguments = obj.ToString();
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.WaitForExit();
            p.Close();
        }
        private static void test2(object obj)
        {
            //throw new NotImplementedException();

            Process p = new Process();
            p.StartInfo.FileName = "Data_mining_dbscan.exe";
            p.StartInfo.Arguments = obj.ToString();
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.WaitForExit();//关键，等待外部程序退出后才能往下执行
            p.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label5.Text = "当前并行次数为：" + Convert.ToString(Dcount+Kcount);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
