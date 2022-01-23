
namespace GIS_project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileopenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileopenmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesaveasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveaspointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveasmapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kmeansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbscanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clustercompareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clustercompareToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleclucompToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clusterToolStripMenuItem,
            this.clustercompareToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1584, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileopenToolStripMenuItem,
            this.filesaveToolStripMenuItem,
            this.filesaveasToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.fileToolStripMenuItem.Text = "开始";
            // 
            // fileopenToolStripMenuItem
            // 
            this.fileopenToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.fileopenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileopenmapToolStripMenuItem,
            this.newmapToolStripMenuItem});
            this.fileopenToolStripMenuItem.Name = "fileopenToolStripMenuItem";
            this.fileopenToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.fileopenToolStripMenuItem.Text = "打开";
            // 
            // fileopenmapToolStripMenuItem
            // 
            this.fileopenmapToolStripMenuItem.Name = "fileopenmapToolStripMenuItem";
            this.fileopenmapToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.fileopenmapToolStripMenuItem.Text = "打开地图文档";
            this.fileopenmapToolStripMenuItem.Click += new System.EventHandler(this.fileopenmapToolStripMenuItem_Click);
            // 
            // newmapToolStripMenuItem
            // 
            this.newmapToolStripMenuItem.Name = "newmapToolStripMenuItem";
            this.newmapToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newmapToolStripMenuItem.Text = "新建地图";
            this.newmapToolStripMenuItem.Click += new System.EventHandler(this.newmapToolStripMenuItem_Click);
            // 
            // filesaveToolStripMenuItem
            // 
            this.filesaveToolStripMenuItem.Name = "filesaveToolStripMenuItem";
            this.filesaveToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.filesaveToolStripMenuItem.Text = "保存";
            this.filesaveToolStripMenuItem.Click += new System.EventHandler(this.filesaveToolStripMenuItem_Click);
            // 
            // filesaveasToolStripMenuItem
            // 
            this.filesaveasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveaspointsToolStripMenuItem,
            this.saveasmapToolStripMenuItem});
            this.filesaveasToolStripMenuItem.Name = "filesaveasToolStripMenuItem";
            this.filesaveasToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.filesaveasToolStripMenuItem.Text = "另存为";
            // 
            // saveaspointsToolStripMenuItem
            // 
            this.saveaspointsToolStripMenuItem.Name = "saveaspointsToolStripMenuItem";
            this.saveaspointsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveaspointsToolStripMenuItem.Text = "导出点数据";
            // 
            // saveasmapToolStripMenuItem
            // 
            this.saveasmapToolStripMenuItem.Name = "saveasmapToolStripMenuItem";
            this.saveasmapToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveasmapToolStripMenuItem.Text = "导出地图数据";
            // 
            // clusterToolStripMenuItem
            // 
            this.clusterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kmeansToolStripMenuItem,
            this.dbscanToolStripMenuItem});
            this.clusterToolStripMenuItem.Name = "clusterToolStripMenuItem";
            this.clusterToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.clusterToolStripMenuItem.Text = "单聚类分析";
            // 
            // kmeansToolStripMenuItem
            // 
            this.kmeansToolStripMenuItem.Name = "kmeansToolStripMenuItem";
            this.kmeansToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.kmeansToolStripMenuItem.Text = "k均值聚类";
            this.kmeansToolStripMenuItem.Click += new System.EventHandler(this.kmeansToolStripMenuItem_Click);
            // 
            // dbscanToolStripMenuItem
            // 
            this.dbscanToolStripMenuItem.Name = "dbscanToolStripMenuItem";
            this.dbscanToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.dbscanToolStripMenuItem.Text = "密度聚类";
            this.dbscanToolStripMenuItem.Click += new System.EventHandler(this.dbscanToolStripMenuItem_Click);
            // 
            // clustercompareToolStripMenuItem
            // 
            this.clustercompareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clustercompareToolStripMenuItem1,
            this.multipleclucompToolStripMenuItem});
            this.clustercompareToolStripMenuItem.Name = "clustercompareToolStripMenuItem";
            this.clustercompareToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.clustercompareToolStripMenuItem.Text = "多重聚类分析";
            // 
            // clustercompareToolStripMenuItem1
            // 
            this.clustercompareToolStripMenuItem1.Name = "clustercompareToolStripMenuItem1";
            this.clustercompareToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.clustercompareToolStripMenuItem1.Text = "聚类比较分析";
            this.clustercompareToolStripMenuItem1.Click += new System.EventHandler(this.clustercompareToolStripMenuItem1_Click);
            // 
            // multipleclucompToolStripMenuItem
            // 
            this.multipleclucompToolStripMenuItem.Name = "multipleclucompToolStripMenuItem";
            this.multipleclucompToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.multipleclucompToolStripMenuItem.Text = "多重并行聚类";
            this.multipleclucompToolStripMenuItem.Click += new System.EventHandler(this.multipleclucompToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(1584, 836);
            this.splitContainer1.SplitterDistance = 528;
            this.splitContainer1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "GIS聚类分析";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileopenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileopenmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesaveasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveaspointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveasmapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kmeansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbscanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newmapToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem clustercompareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clustercompareToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem multipleclucompToolStripMenuItem;
    }
}

