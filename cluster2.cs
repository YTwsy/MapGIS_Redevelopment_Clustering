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
    public partial class cluster2 : Form
    {
        public cluster2()
        {
            InitializeComponent();
        }

        private void cluster2_Load(object sender, EventArgs e)
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
        public string cluster_eps = null;
        public int cluster_minpts = 0;


        #endregion

        #region 聚类实现
        //确认输入
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cluster_eps = Convert.ToString(textBox2.Text);
                cluster_minpts = Convert.ToInt32(numericUpDown2.Text);
            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

            FileStream fs = new("dbscan_eps_min_pts.txt", System.IO.FileMode.Create, FileAccess.Write);
            StreamWriter sw = new(fs);
            sw.WriteLine(cluster_eps);
            sw.WriteLine(cluster_minpts);
            sw.Close();

            MessageBox.Show("完成确认");
        }
        
        //开始聚类
        private void button3_Click(object sender, EventArgs e)
        {
            if (cluster_eps == null && cluster_minpts == 0)
            {
                MessageBox.Show("未选择属性");
            }
            else
            {
                Process p = new Process();
                //设置要启动的应用程序
                p.StartInfo.FileName = "Data_mining_dbscan_init.exe";
                //显示程序窗口
                p.StartInfo.CreateNoWindow = false;
                //启动程序
                p.Start();
                //等待程序执行完退出进程
                p.WaitForExit();
                p.Close();
                MessageBox.Show("聚类完成");
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
