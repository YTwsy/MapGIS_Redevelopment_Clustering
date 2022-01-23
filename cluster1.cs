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

namespace GIS_project
{
    public partial class cluster1 : Form
    {
        public cluster1()
        {
            InitializeComponent();
        }

        private void cluster1_Load(object sender, EventArgs e)
        {
        }

        // 输入数据
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

        #endregion

        #region 聚类实现
        //确认输入
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cluster_num = Convert.ToInt32(numericUpDown1.Text);
                cluster_redo = Convert.ToInt32(numericUpDown2.Text);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            FileStream fs = new("k-means_K&max_cluster.txt", System.IO.FileMode.Create, FileAccess.Write);
            StreamWriter sw = new(fs);
            sw.WriteLine(cluster_num);
            sw.WriteLine(cluster_redo);
            sw.Close();

            MessageBox.Show("完成确认");
        }

        //开始聚类
        private void button3_Click(object sender, EventArgs e)
        {
            if (cluster_num == 0 && cluster_redo == 0)
            {
                MessageBox.Show("未选择属性");
            }
            else
            {
                Process p = new Process();
                //设置要启动的应用程序
                p.StartInfo.FileName = "K-means.exe";

                //显示程序窗口
                p.StartInfo.CreateNoWindow = false;
                //启动程序
                p.Start();
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();

                Process result = new Process();
                result.StartInfo.FileName = "show_point_with_class_init.exe";
                result.StartInfo.CreateNoWindow = true;
                result.Start();
                result.WaitForExit();
                result.Close();

                this.Close();

            }
        }
        
        //取消
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
