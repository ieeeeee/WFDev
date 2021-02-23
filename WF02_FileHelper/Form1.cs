using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF02_FileHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static DataTable dt = new DataTable();

        //当前选中节点路径
        private string curFilePath = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            //01 加载TreeView
            loadTreeView();
            this.treeSourcePath.BeforeExpand += new TreeViewCancelEventHandler(treeSourcePath_BeforeExpand);
            this.treeSourcePath.AfterExpand += new TreeViewEventHandler(treeSourcePath_AfterExpand);
            //02 点击node时加载其所有的文件
            SetDataTableColumn(dt);
        }

        /// <summary>
        /// 加载TreeView
        /// </summary>
        public void loadTreeView()
        {
            this.treeSourcePath.ImageList = this.treeFileIcon;
            //01 加载root node
            TreeNode rootNode = new TreeNode("This PC");
            rootNode.Tag = "This PC";
            rootNode.Text = "This PC";
            this.treeSourcePath.Nodes.Add(rootNode);

            //02 加载Documents Folder
            var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            TreeNode docNode = new TreeNode(myDocuments);
            docNode.Tag = "Documents";
            docNode.Text = "Documents";
            rootNode.Nodes.Add(docNode);
            docNode.Nodes.Add("");

            //03 遍历获得所有磁盘 如C盘
            foreach (string drive in Environment.GetLogicalDrives())
            {
                //实例化drive对象
                var dir = new DriveInfo(drive);
                switch (dir.DriveType)
                {
                    case DriveType.Fixed:
                        {
                            //获取磁盘名称
                            TreeNode dirNode = new TreeNode(dir.Name.Split(':')[0]);
                            dirNode.Name = dir.Name;
                            dirNode.Tag = dir.Name;
                            dirNode.ImageIndex = 0;
                            dirNode.SelectedImageIndex = 0;
                            treeSourcePath.Nodes.Add(dirNode);
                            dirNode.Nodes.Add("");
                        }
                        break;
                }
            }

            //04 展开root node
            rootNode.Expand();
        }

        /// <summary>
        /// 节点展开之后发生 展开子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeSourcePath_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.Expand();

        }

        /// <summary>
        /// 在将要展开节点时 加载子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeSourcePath_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //01 加载子节点
            TreeViewItems.Add(e.Node);
            //curFilePath = e.Node.Name;
            dt.Rows.Clear();

            //02 加载文件到DataGridView
            if (e.Node.Tag.ToString() != "This PC")
            {
                // e.Node.Nodes.Clear();
                TreeNode tNode = e.Node;
                string path = tNode.Name;

                if (e.Node.Tag.ToString() == "Documents")
                {
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }
                curFilePath = path;
                //MessageBox.Show(curFilePath);
                foreach (var file in Directory.GetFiles(path, "*.*", e.Node.Level > 1 ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                {
                    FileInfo fileInfo = new FileInfo(file);
                    addToDtRow(dt, fileInfo);
                }
                dgvResult.DataSource = dt;
            }
        }

        /// <summary>
        /// 展开节点时 加载子节点
        /// </summary>
        public static class TreeViewItems
        {
            public static void Add(TreeNode pNode)
            {
                try
                {
                    if (pNode.Tag.ToString() != "This PC")
                    {
                        pNode.Nodes.Clear();
                        TreeNode tNode = pNode;
                        string path = tNode.Name;

                        if (pNode.Tag.ToString() == "Documents")
                        {
                            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        }
                        //获取指定路径path中的子目录并加载节点
                        string[] dics = Directory.GetDirectories(path);
                        foreach (string dic in dics)
                        {
                            TreeNode subNode = new TreeNode(new DirectoryInfo(dic).Name);
                            subNode.Name = (new DirectoryInfo(dic).FullName);
                            subNode.Tag = subNode.Name;
                            subNode.ImageIndex = 0;
                            subNode.SelectedImageIndex = 0;
                            tNode.Nodes.Add(subNode);
                            subNode.Nodes.Add("");
                        }

                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
        }
        /* 根据路径查询所有文件及子目录的文件*/
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sourceAddr = txtSourceAddr.Text.ToString();
            loadFiles(sourceAddr);

        }
        
        public void SetDataTableColumn(DataTable dt)
        {
            dt.Columns.Add("FileName", typeof(string));
            dt.Columns.Add("Size", typeof(string));
            //dt.Columns.Add("FileExtension", typeof(string));
            dt.Columns.Add("FilePath", typeof(string));
            //加checkbox
            DataGridViewCheckBoxColumn ckCol = new DataGridViewCheckBoxColumn();
            {
                ckCol.HeaderText = "Select";
                ckCol.Name = "ckCell";
                // ckCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                // ckCol.FlatStyle = FlatStyle.Standard;
                // ckCol.ThreeState = true;
                // ckCol.CellTemplate = new DataGridViewCheckBoxCell();
                // ckCol.CellTemplate.Style.BackColor = Color.Beige;
            }
            dgvResult.Columns.Insert(0, ckCol);
        }

        public void loadFiles(string path)
        {
            //清空datagridview
            //DataTable nullDt = (DataTable)dgvResult.DataSource;
            //nullDt.Rows.Clear();
            //dgvResult.DataSource = nullDt;

            dt.Rows.Clear();
            dgvResult.DataSource = dt;

            GetDirectories(dt, path);
            //输出
            dgvResult.DataSource = dt;
            //加checkbox
            DataGridViewCheckBoxColumn ckCol = new DataGridViewCheckBoxColumn();
            {
                ckCol.HeaderText = "Select";
                ckCol.Name = "ckCell";

            }
            this.dgvResult.Columns.Insert(0, ckCol);
        }
        public static void addToDtRow(DataTable dt, FileInfo fileInfo)
        {
            DataRow dr = dt.NewRow();
            dr[0] = fileInfo.Name; //名称
            dr[1] = (fileInfo.Length / 1024 + 1) + "kb";
            // dr[1] = file.Extension;
            dr[2] = fileInfo.FullName; //完整路径
            dt.Rows.Add(dr);
        }
        /* 01 获取目录下所有文件*/
        public static void GetFiles(DataTable dt, string path)
        {
            DirectoryInfo root = new DirectoryInfo(path);

            foreach (FileInfo file in root.GetFiles())
            {
                addToDtRow(dt, file);
            }
        }

        /* 02 获取目录及子目录下所有文件 */
        public static void GetDirectories(DataTable dt, string path)
        {
            GetFiles(dt, path);
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo dic in root.GetDirectories())
            {
                GetDirectories(dt, dic.FullName);
            }
        }
        /* 03 移动文件/修改文件名 path为全路径*/
        public static void fileMove(string sourcePath, string destPath)
        {
            if (File.Exists(destPath))
            {
                File.Delete(destPath);
            }
            File.Move(sourcePath, destPath);
        }
        public void filesMove(List<string> sourcePathes, List<string> destPathes)
        {
            foreach (var sourcePath in sourcePathes)
            {
                int index = sourcePathes.IndexOf(sourcePath);
                fileMove(sourcePath, destPathes[index]);
            }

        }
        /* 04 复制文件 path为全路径*/
        public static void fileCopy(string sourcePath, string destPath)
        {
            if (File.Exists(destPath))
            {
                File.Delete(destPath);
            }
            File.Copy(sourcePath, destPath);
        }
        /* 05 多个文件复制*/
        public void filesCopy(List<string> sourcePathes, List<string> destPathes)
        {
            foreach (var sourcePath in sourcePathes)
            {
                int index = sourcePathes.IndexOf(sourcePath);
                fileCopy(sourcePath, destPathes[index]);
            }

        }

        /* 06 删除文件*/
        public static void fileRemove(string sourcePath)
        {
            if (File.Exists(sourcePath))
            {
                File.Delete(sourcePath);
            }
        }

        /* 01 定义一个代理 */
       // private loadingForm myLoading = null;
       // private delegate bool InceraseHandle(string loadingMsg);
        //private InceraseHandle myIncrease = null; //声明代理
        public static int loadingFormCount = 0;
        //目标位置唯一
        public static string destDicPath = string.Empty;


        /// <summary>
        /// 批量复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopy_Click(object sender, EventArgs e)
        {
            //01 获得目标位置
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            //System.Diagnostics.Process.Start("Explorer.exe", "C:\\");
            destDicPath = fbd.SelectedPath; //获得选择的文件夹路径

            //02 打开进度框窗体  并能继续操作主窗体
            //Thread thdSubForm = new Thread(new ThreadStart(threadShowForm));
            //thdSubForm.IsBackground = true;
            //thdSubForm.Start();

            //03 开启子线程执行复制
            //Thread thdSub = new Thread(new ThreadStart(threadFun));
            //thdSub.IsBackground = true;
            //thdSub.Start();
            //04 子线程复制任务完成 关闭进度框
            string destDic = destDicPath;
            string destPath = string.Empty;
            List<string> sourcePathes = new List<string>();
            List<string> destPathes = new List<string>();
            if (dgvResult.Rows.Count > 0)
            {

                for (int i = 0; i < dgvResult.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ckCell = (DataGridViewCheckBoxCell)dgvResult.Rows[i].Cells["ckCell"];
                    if (Convert.ToBoolean(ckCell.Value))
                    {
                        destPath = destDic + "\\" + dgvResult.Rows[i].Cells["FileName"].Value.ToString();
                        destPathes.Add(destPath);
                        sourcePathes.Add(dgvResult.Rows[i].Cells["FilePath"].Value.ToString());
                    }
                }
            }
            Task copyTask = new Task(() => excecuteCopy(sourcePathes, destPathes));
            copyTask.Start();
        }
        private void threadShowForm()
        {
            MethodInvoker mi = new MethodInvoker(showLoadingForm);
            this.BeginInvoke(mi);
            Thread.Sleep(10000);
        }
        private void showLoadingForm()
        {
            loadingFormCount++;
            loadingForm myLoading = new loadingForm("Copy Process" + loadingFormCount.ToString());
            //myIncrease = new InceraseHandle(myLoading.Increase);
            myLoading.Show();
        }

        //private void threadFun()
        //{
        //    MethodInvoker mi = new MethodInvoker(excecuteCopy);
        //    this.BeginInvoke(mi);
        //    //Thread.Sleep(10000);
        //}


        private void excecuteCopy(List<string> sourcePathes, List<string> destPathes)
        {
            //string destDic = destDicPath;
            //string destPath = string.Empty;
            //List<string> sourcePathes = new List<string>();
            //List<string> destPathes = new List<string>();
            ////02 获取selectd filePath
            //if (dgvResult.Rows.Count > 0)
            //{

            //    for (int i = 0; i < dgvResult.Rows.Count; i++)
            //    {
            //        DataGridViewCheckBoxCell ckCell = (DataGridViewCheckBoxCell)dgvResult.Rows[i].Cells["ckCell"];
            //        if (Convert.ToBoolean(ckCell.Value))
            //        {
            //            destPath = destDic + "\\" + dgvResult.Rows[i].Cells["FileName"].Value.ToString();
            //            //fileCopy(dgvResult.Rows[i].Cells["FilePath"].Value.ToString(), destPath);
            //            destPathes.Add(destPath);
            //            sourcePathes.Add(dgvResult.Rows[i].Cells["FilePath"].Value.ToString());
            //        }
            //    }
            //    filesCopy(sourcePathes, destPathes);
            //}
           // loadingFormCount++;
           // loadingForm myLoading = new loadingForm("Copy Process" + loadingFormCount.ToString());
           //// myIncrease = new InceraseHandle(myLoading.Increase);
           // myLoading.Show();
            filesCopy(sourcePathes, destPathes);
            //Thread.Sleep(50000);
            //loadingFormCount--;
            //myLoading.Close();
            //myLoading = null;

        }
        /* 02 loading form 更新函数*/
        /* 03 函数实现*/
        /* 04 新的线程执行函数*/

        /* 移动*/
        private void btnMove_Click(object sender, EventArgs e)
        {
            //01 获取目标路径
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            //System.Diagnostics.Process.Start("Explorer.exe", "C:\\");
            string destDicPath = fbd.SelectedPath; //获得选择的文件夹路径
            string destPath = string.Empty;
            List<string> sourcePathes = new List<string>();
            List<string> destPathes = new List<string>();
            //02 获取selectd filePath
            if (dgvResult.Rows.Count > 0)
            {
                for (int i = 0; i < dgvResult.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ckCell = (DataGridViewCheckBoxCell)dgvResult.Rows[i].Cells["ckCell"];
                    if (Convert.ToBoolean(ckCell.Value))
                    {
                        destPath = destDicPath + "\\" + dgvResult.Rows[i].Cells["FileName"].Value.ToString();
                        destPathes.Add(destPath);
                        sourcePathes.Add(dgvResult.Rows[i].Cells["FilePath"].Value.ToString());
                        //fileMove(dgvResult.Rows[i].Cells["FilePath"].Value.ToString(), destPath);
                    }
                }
                Task moveTask = new Task(() => filesMove(sourcePathes, destPathes));
                moveTask.Start();

            }
        }

        /* 移除多个文件*/
        private void bntRemove_Click(object sender, EventArgs e)
        {
            if (dgvResult.Rows.Count > 0)
            {
                for (int i = 0; i < dgvResult.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ckCell = (DataGridViewCheckBoxCell)dgvResult.Rows[i].Cells["ckCell"];
                    if (Convert.ToBoolean(ckCell.Value))
                    {
                        fileRemove(dgvResult.Rows[i].Cells["FilePath"].Value.ToString());
                    }
                }
            }
        }


        /*搜索文件/文件夹*/
        private void btnSearchFile_Click(object sender, EventArgs e)
        {
            string fileName = this.txtSearchFile.Text.ToString();
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
            // 01 清空datagridview
            dt.Rows.Clear();
            dgvResult.DataSource = dt;
            // 02 多线程搜索文件/文件夹
            //MessageBox.Show(curFilePath);
            searchWithMultiThread(curFilePath, fileName);

        }
        /* 多线程搜索文件/文件夹 */
        private void searchWithMultiThread(string path, string fileName)
        {
            this.searchFileName = fileName;
            ThreadPool.SetMaxThreads(1000, 1000);
            ThreadPool.QueueUserWorkItem(new WaitCallback(Search), path); //选中的节点路径
        }

        private string searchFileName;
        /* 多线程搜索文件/文件夹 */
        public void Search(Object obj)
        {
            string path = obj.ToString();
            DirectorySecurity dicSecurity = new DirectorySecurity(path, AccessControlSections.Access);

            if (!dicSecurity.AreAccessRulesProtected)
            {
                //01 待搜索路径
                DirectoryInfo dicInfo = new DirectoryInfo(path);
                FileInfo[] fileInfos = dicInfo.GetFiles();
                //搜索文件
                if (fileInfos.Length > 0)
                {
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        try
                        {
                            if (fileInfo.Name.Split('.')[0].Contains(searchFileName)) //大小写
                            {
                                //添加文件到datagridview
                                loadFile(fileInfo.FullName);
                            }
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }

                //02 待搜索路径下的子文件夹
                DirectoryInfo[] dicInfos = dicInfo.GetDirectories();

                //搜索文件夹
                if (dicInfos.Length > 0)
                {
                    foreach (DirectoryInfo dic in dicInfos)
                    {
                        try
                        {
                            //if(dic.Name.Contains(searchFileName))
                            //{
                            //    //
                            //}
                            //else
                            //{
                            ThreadPool.QueueUserWorkItem(new WaitCallback(Search), dic.FullName);
                            //}
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }

            }
        }

        private void loadFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            addToDtRow(dt, fileInfo);
            dgvResult.DataSource = dt;
        }
        //是否第一次初始化treeview
        private bool isInitialTreeView = true;
        //当前选中的树节点
        private TreeNode curSelectedNode = null;
        //默认获取焦点，默认选中最顶端的节点，即索引等于0
        //private void treeSourcePath_AfterSelect(object sender, TreeViewEventArgs e)
        //{

        //    //第一次初始化treeview
        //    if(isInitialTreeView)
        //    {
        //        MessageBox.Show("init");
        //        curFilePath = @"This PC";
        //    }
        //    else
        //    {
        //        MessageBox.Show("not init");
        //        curSelectedNode = e.Node;
        //        curFilePath = e.Node.Name;
        //        //加载到datagridView
        //        loadFiles(curFilePath);
        //    }
        //}

        //用多任务执行复制/移动/删除操作


        public static void dataTableToListView(ListView lv, DataTable dt)
        {
            if (dt != null)
            {
                lv.Items.Clear();
                lv.Columns.Clear();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    lv.Columns.Add(dt.Columns[i].Caption.ToString());
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem lvItem = new ListViewItem(dr[0].ToString());
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        lvItem.SubItems.Add(dr[i].ToString());
                    }
                    lv.Items.Add(lvItem);
                }
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

    }
}
