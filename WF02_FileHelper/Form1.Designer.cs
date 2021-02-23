namespace WF02_FileHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtSourceAddr = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeSourcePath = new System.Windows.Forms.TreeView();
            this.bntRemove = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.treeFileIcon = new System.Windows.Forms.ImageList(this.components);
            this.txtSearchFile = new System.Windows.Forms.TextBox();
            this.btnSearchFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSourceAddr
            // 
            this.txtSourceAddr.Location = new System.Drawing.Point(30, 24);
            this.txtSourceAddr.Name = "txtSourceAddr";
            this.txtSourceAddr.Size = new System.Drawing.Size(319, 21);
            this.txtSourceAddr.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(371, 24);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(3, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(91, 3);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(75, 23);
            this.btnMove.TabIndex = 3;
            this.btnMove.Text = "Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(30, 67);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeSourcePath);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSearchFile);
            this.splitContainer1.Panel2.Controls.Add(this.txtSearchFile);
            this.splitContainer1.Panel2.Controls.Add(this.bntRemove);
            this.splitContainer1.Panel2.Controls.Add(this.dgvResult);
            this.splitContainer1.Panel2.Controls.Add(this.btnMove);
            this.splitContainer1.Panel2.Controls.Add(this.btnCopy);
            this.splitContainer1.Size = new System.Drawing.Size(997, 459);
            this.splitContainer1.SplitterDistance = 331;
            this.splitContainer1.TabIndex = 4;
            // 
            // treeSourcePath
            // 
            this.treeSourcePath.Location = new System.Drawing.Point(3, 29);
            this.treeSourcePath.Name = "treeSourcePath";
            this.treeSourcePath.Size = new System.Drawing.Size(325, 427);
            this.treeSourcePath.TabIndex = 0;
            // 
            // bntRemove
            // 
            this.bntRemove.Location = new System.Drawing.Point(182, 3);
            this.bntRemove.Name = "bntRemove";
            this.bntRemove.Size = new System.Drawing.Size(75, 23);
            this.bntRemove.TabIndex = 4;
            this.bntRemove.Text = "Remove";
            this.bntRemove.UseVisualStyleBackColor = true;
            this.bntRemove.Click += new System.EventHandler(this.bntRemove_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Location = new System.Drawing.Point(3, 29);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(656, 427);
            this.dgvResult.TabIndex = 0;
            // 
            // treeFileIcon
            // 
            this.treeFileIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeFileIcon.ImageStream")));
            this.treeFileIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.treeFileIcon.Images.SetKeyName(0, "folder.png");
            this.treeFileIcon.Images.SetKeyName(1, "file.png");
            // 
            // txtSearchFile
            // 
            this.txtSearchFile.Location = new System.Drawing.Point(304, 2);
            this.txtSearchFile.Name = "txtSearchFile";
            this.txtSearchFile.Size = new System.Drawing.Size(205, 21);
            this.txtSearchFile.TabIndex = 5;
            // 
            // btnSearchFile
            // 
            this.btnSearchFile.Location = new System.Drawing.Point(545, 2);
            this.btnSearchFile.Name = "btnSearchFile";
            this.btnSearchFile.Size = new System.Drawing.Size(75, 23);
            this.btnSearchFile.TabIndex = 6;
            this.btnSearchFile.Text = "Search";
            this.btnSearchFile.UseVisualStyleBackColor = true;
            this.btnSearchFile.Click += new System.EventHandler(this.btnSearchFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 570);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSourceAddr);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSourceAddr;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeSourcePath;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.ImageList treeFileIcon;
        private System.Windows.Forms.Button bntRemove;
        private System.Windows.Forms.Button btnSearchFile;
        private System.Windows.Forms.TextBox txtSearchFile;
    }
}

