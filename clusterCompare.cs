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
using System.Threading;
using System.Diagnostics;

namespace GIS_project
{
    public partial class clusterCompare : Form
    {
        public clusterCompare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            string filename = openFileDialog1.FileName;
            textBox1.Text = filename;
        }
        #region 获取聚类参数
        public string choose_cluster_distance = "";
        public int cluster_num = 0;
        public int cluster_redo = 0;
        public string cluster_eps = null;
        public int cluster_minpts = 0;
        #endregion

        #region 聚类实现
        //确认输入
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cluster_num = Convert.ToInt32(numericUpDown1.Text);
                cluster_redo = Convert.ToInt32(numericUpDown2.Text);
                cluster_eps = Convert.ToString(textBox2.Text);
                cluster_minpts = Convert.ToInt32(numericUpDown3.Text);
            }
            catch(Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            FileStream fs1 = new("k-means_K&max_cluster.txt", System.IO.FileMode.Create, FileAccess.Write);
            StreamWriter sw1 = new(fs1);
            sw1.WriteLine(cluster_num);
            sw1.WriteLine(cluster_redo);
            sw1.Close();

            FileStream fs2 = new("dbscan_eps_min_pts.txt", System.IO.FileMode.Create, FileAccess.Write);
            StreamWriter sw2 = new(fs2);
            sw2.WriteLine(cluster_eps);
            sw2.WriteLine(cluster_minpts);
            sw2.Close();

            MessageBox.Show("完成确认");
        }
        //开始聚类
        private void button4_Click(object sender, EventArgs e)
        {
            static void test1()
            {
                Process p = new Process();
                p.StartInfo.FileName = "K-means.exe";
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                p.WaitForExit();
                p.Close();


                p.StartInfo.FileName = "show_point_with_class_init.exe";
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                p.WaitForExit();
                p.Close();
            }

            static void test2()
            {
                Process p = new Process();
                p.StartInfo.FileName = "Data_mining_dbscan_init.exe";
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                p.WaitForExit();
                p.Close();
            }

            if (cluster_num == 0 && cluster_redo == 0 && cluster_eps == null && cluster_minpts == 0)
            {
                MessageBox.Show("未选择属性");
            }
            else
            {
                Thread primaryThread = new Thread(new ThreadStart(test1));
                //主线程
                primaryThread.Name = "K_means";
                //MessageBox.Show("123");
                primaryThread.Start();

                //次线程，该线程指向DB—scan方法
                Thread SecondThread = new Thread(new ThreadStart(test2));
                SecondThread.Name = "DB_Scan";
                //次线程开始执行指向的方法
                SecondThread.Start();
            }
        }
        //取消
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void clusterCompare_Load(object sender, EventArgs e)
        {

        }
    }
}
