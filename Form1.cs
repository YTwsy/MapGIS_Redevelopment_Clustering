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
using MapGIS.GISControl;
using MapGIS.GeoMap;
using MapGIS.UI.Controls;
using MapGIS.WorkSpaceEngine;
using MapGIS.GeoDataBase;
using MapGIS.GeoObjects;
using MapGIS.GeoObjects.Geometry;


namespace GIS_project
{
    public partial class Form1 : Form
    {
        #region 预定义
        //在SplitContainer添加MapControl控件
        MapControl mapCtrl = new MapControl();
        //在SplitContainer添加AttControl控件
        AttControl attCtrl = new AttControl();
        //工作空间树
        MapWorkSpaceTree _Tree = new MapWorkSpaceTree();
        #endregion

        // 初始化界面
        public void initControls()
        {
            //MapControl控件占Panel2的三分之二的空间
            this.splitContainer1.Panel2.Controls.Add(mapCtrl);
            mapCtrl.Width = this.splitContainer1.Panel2.Width;
            mapCtrl.Height = this.splitContainer1.Panel2.Height * 2 / 3;

            //AttControl控件占Panel2的三分之一的空间
            this.splitContainer1.Panel2.Controls.Add(attCtrl);
            attCtrl.Width = this.splitContainer1.Panel2.Width;
            attCtrl.Top = mapCtrl.Bottom;
            attCtrl.Height = this.splitContainer1.Panel2.Height - mapCtrl.Height;

            //工作空间树控件加载到Panel1上
            _Tree.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(_Tree);
        }

        string[] args = null;

        public Form1()
        {
            InitializeComponent();
            //初始化界面
            initControls();
            //文档树事件响应
            _Tree.Document.ClosedDocument += new Document.ClosedDocumentHandle(Document_ClosedDocument);
            _Tree.Document.ClosingDocument += new Document.ClosingDocumentHandle(Document_ClosingDocument);
            _Tree.MenuItemOnClickEvent += new MenuItemOnClickHandler(_Tree_MenuItemOnClickEvent);
            _Tree.Document.GetMaps().RemoveMap += new Maps.RemoveMapHandle(MainForm_RemoveMap);
        }

        public Form1(string[] args)
        {
            InitializeComponent();
            this.args = args;
            //初始化界面
            initControls();
            //文档树事件响应
            _Tree.Document.ClosedDocument += new Document.ClosedDocumentHandle(Document_ClosedDocument);
            _Tree.Document.ClosingDocument += new Document.ClosingDocumentHandle(Document_ClosingDocument);
            _Tree.MenuItemOnClickEvent += new MenuItemOnClickHandler(_Tree_MenuItemOnClickEvent);
            _Tree.Document.GetMaps().RemoveMap += new Maps.RemoveMapHandle(MainForm_RemoveMap);
        }


        #region 文档树事件响应
        //关闭文档
        void Document_ClosedDocument(object sender, EventArgs e)
        {
            this.mapCtrl.ActiveMap = null;
            this.mapCtrl.Restore();

            return;
        }
        //对关闭文档的提示
        void Document_ClosingDocument(object sender, ClosingDocumentEventArgs e)
        {
            if (this._Tree.Document.IsDirty)
            {
                if (MessageBox.Show("是否保存地图文档？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    this._Tree.Document.Save();
                }
            }

            return;
        }

        void _Tree_MenuItemOnClickEvent(string typeName, DocumentItem item)
        {
            //点击工作空间树中地图的右键菜单中的“预览地图”
            if (typeName == "MapGIS.WorkSpace.Style.PreviewMap" && item.DocItemType == DocItemType.Map)
            {
                //获取地图
                Map map = item as Map;
                this.mapCtrl.ActiveMap = map;
                this.mapCtrl.Restore();
            }
            return;
        }

        //移除地图操作触发的事件
        void MainForm_RemoveMap(object sender, MapsEventArgs e)
        {
            this.mapCtrl.ActiveMap = null;
            this.mapCtrl.Restore();
        }
        #endregion

        #region 窗体
        private void Form1_Load(object sender, EventArgs e)
        {
            //定义数据源、数据库变量
            Server Svr = null;
            DataBase GDB = null;
            SFeatureCls SFCls = null;
            string svr = "MapGisLocal";
            string gdb = "空间信息高性能计算实验";
            string sfcis = "wuhan_busstop";

            if (args!= null)
            {
                svr = args[0];
                gdb = args[1];
                sfcis = args[2];
            }                      

            Svr = new Server();
            //连接数据源
            Svr.Connect(svr, "", "");
            GDB = new DataBase();
            GDB = Svr.OpenGDB(gdb);
            SFCls = new SFeatureCls(GDB);

            //打开图层
            SFCls.Open(sfcis, 1);

            //新建一个文档树
            _Tree.WorkSpace.BeginUpdateTree();
            _Tree.Document.Title = "地图文档";
            _Tree.Document.New();

            //在地图文档下添加一个地图
            Map map = new Map();
            map.Name = "新地图";
            //附加矢量图层
            VectorLayer vecLayer = new VectorLayer(VectorLayerType.SFclsLayer);
            vecLayer.AttachData(SFCls);
            //将图层添加到地图中
            vecLayer.Name = SFCls.ClsName;
            map.Append(vecLayer);

            _Tree.Document.GetMaps().Append(map);
            //将该地图设置为MapConrol的激活地图
            this.mapCtrl.ActiveMap = map;
            this.mapCtrl.Restore();

            //展开所有的节点
            _Tree.ExpandAll();
            _Tree.WorkSpace.EndUpdateTree();

            vecLayer.DetachData();//附加解除 



            QueryDef _QueryDef = null;
            Rect rect = new Rect();
            RecordSet _RecordSet = null;
            IGeometry _Geometry = null;
            SpaQueryMode mode = new SpaQueryMode();
            GeoVarLine _GeoVarLine = null;
            GeoLines _GeoLines = null;
            GeoPoints _Geopoints = null;

            _QueryDef = new QueryDef();
            rect.XMax = SFCls.Range.XMax;
            rect.YMax = SFCls.Range.YMax;
            rect.YMin = SFCls.Range.YMin;
            rect.XMin = SFCls.Range.XMin;
            mode = SpaQueryMode.Intersect;

            _QueryDef = new QueryDef();
            _QueryDef.SetRect(rect, mode);
            _RecordSet = SFCls.Select(_QueryDef);


            bool rtn;
            rtn = _RecordSet.MoveFirst();

            //文件流
            FileStream fs = new("Pre_cluster_points.txt", System.IO.FileMode.Create, FileAccess.Write);
            StreamWriter sw = new(fs);

            int point_counts = 0;

            while (!_RecordSet.IsEOF)
            {
                _Geometry = _RecordSet.Geometry;//获取当前要素的空间信息
                GeometryType type = _Geometry.Type;//获取当前要素的几何约束类型

                int oid = (int)_RecordSet.CurrentID;

                if (_Geometry != null)
                {
                    switch (type)
                    {
                        //case GeometryType.VarLine:
                        //    {
                        //        _GeoVarLine = new GeoVarLine();
                        //        _GeoVarLine = _Geometry as GeoVarLine;
                        //    }
                        case GeometryType.Points:
                            {
                                _Geopoints = new GeoPoints();
                                _Geopoints = _Geometry as GeoPoints;

                                //Dot3D dot = _Geopoints.GetItem(oid);
                                Dots3D dots = _Geopoints.GetDots();
                                Dot3D dot = dots.GetItem(0);
                                double dot_x = dot.X;
                                double dot_y = dot.Y;
                                string str = dot_x.ToString() + "," + dot_y.ToString();
                                point_counts++;
                                //sw.WriteLine(dot_x.ToString());
                                //sw.WriteLine(dot_y.ToString());
                                sw.WriteLine(str);
                                break;
                            }
                        default:
                            break;
                    }
                }
                rtn = _RecordSet.MoveNext();

            }
            sw.Close();
            using (var file = new System.IO.StreamWriter("points_counts.txt"))
            {
                // ... 
                file.WriteLine(point_counts.ToString());
                // rest of code here ... 
            }
        }
        #endregion

        #region 开始
        private void fileopenmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //地图文档
            Document doc = _Tree.Document;

            if (doc.Close(false))
            {
                OpenFileDialog mapxDialog = new OpenFileDialog();
                mapxDialog.Filter = ".mapx(地图文档)|*.mapx|.map(地图文档)|*.map|.mbag(地图包)|*.mbag";
                if (mapxDialog.ShowDialog() != DialogResult.OK)
                    return;
                string mapUrl = mapxDialog.FileName;
                //打开地图文档
                doc.Open(mapUrl);
            }

            Maps maps = doc.GetMaps();
            if (maps.Count > 0)
            {
                //获取当前第一个地图
                Map map = maps.GetMap(0);
                //设置地图的第一个图层为激活状态
                map.get_Layer(0).State = LayerState.Active;
                this.mapCtrl.ActiveMap = map;
                this.mapCtrl.Restore();
            }
            return;
        }
        private void newmapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document doc = this._Tree.Document;

            _Tree.WorkSpace.BeginUpdateTree();

            if (!_Tree.Document.Close(false))
                return;
            doc.Title = "new Map";
            int rtn = doc.New();

            _Tree.WorkSpace.EndUpdateTree();

            return;
        }
        private void filesaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document doc = null;
            doc = this._Tree.Document;
            SaveFileDialog save = new SaveFileDialog();
            string path = "";
            //默认路径
            save.InitialDirectory = "E:\\";
            //文本格式筛选
            save.Filter = "地图文档*.mapx|*.mapx";
            //设置显示文件类型
            save.FilterIndex = 1;
            //关闭对话框时是否还原当前目录
            save.RestoreDirectory = true;
            //调用保存对话框方法
            if (save.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (doc != null)
            {
                path = save.FileName;
                doc.SaveAs(path);
                MessageBox.Show("保存成功");
            }
            return;
        }
        #endregion

        #region 跳转k均值聚类
        private cluster1 cluster1_form = null;
        public Form1(cluster1 form)
        {
            cluster1_form = form;
        }
        private void kmeansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cluster1 cluster1 = new cluster1();
            cluster1.Show();
        }
        #endregion

        #region 跳转密度聚类界面
        //跳转密度聚类
        private cluster2 cluster2_form = null;
        public Form1(cluster2 form)
        {
            cluster2_form = form;
        }
        private void dbscanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cluster2 cluster2 = new cluster2();
            cluster2.Show();
        }
        #endregion

        #region 跳转聚类比较分析界面
        private clusterCompare clusterCompare_form = null;
        public Form1(clusterCompare form)
        {
            clusterCompare_form = form;
        }
        private void clustercompareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clusterCompare clusterCompare = new clusterCompare();
            clusterCompare.Show();
        }
        #endregion

        #region 跳转多重并行聚类界面
        private multipleclucomp multipleclucomp_form = null;
        public Form1(multipleclucomp form)
        {
            multipleclucomp_form = form;
        }
        private void multipleclucompToolStripMenuItem_Click(object sender, EventArgs e)
        {
            multipleclucomp multipleclucomp = new multipleclucomp();
            multipleclucomp.Show();
        }
        #endregion
    }
}
