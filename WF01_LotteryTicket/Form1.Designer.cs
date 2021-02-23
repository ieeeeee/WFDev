namespace WF01_LotteryTicket
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
            this.lblBetsCount = new System.Windows.Forms.Label();
            this.txtBetsCount = new System.Windows.Forms.TextBox();
            this.bntLaunch = new System.Windows.Forms.Button();
            this.listBoxResult = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblBetsCount
            // 
            this.lblBetsCount.AutoSize = true;
            this.lblBetsCount.Location = new System.Drawing.Point(31, 52);
            this.lblBetsCount.Name = "lblBetsCount";
            this.lblBetsCount.Size = new System.Drawing.Size(65, 12);
            this.lblBetsCount.TabIndex = 0;
            this.lblBetsCount.Text = "Bets Count";
            // 
            // txtBetsCount
            // 
            this.txtBetsCount.Location = new System.Drawing.Point(102, 49);
            this.txtBetsCount.Name = "txtBetsCount";
            this.txtBetsCount.Size = new System.Drawing.Size(130, 21);
            this.txtBetsCount.TabIndex = 1;
            // 
            // bntLaunch
            // 
            this.bntLaunch.Location = new System.Drawing.Point(250, 47);
            this.bntLaunch.Name = "bntLaunch";
            this.bntLaunch.Size = new System.Drawing.Size(75, 23);
            this.bntLaunch.TabIndex = 2;
            this.bntLaunch.Text = "Launch";
            this.bntLaunch.UseVisualStyleBackColor = true;
            this.bntLaunch.Click += new System.EventHandler(this.bntLaunch_Click);
            // 
            // listBoxResult
            // 
            this.listBoxResult.FormattingEnabled = true;
            this.listBoxResult.ItemHeight = 12;
            this.listBoxResult.Location = new System.Drawing.Point(33, 97);
            this.listBoxResult.Name = "listBoxResult";
            this.listBoxResult.Size = new System.Drawing.Size(292, 160);
            this.listBoxResult.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 303);
            this.Controls.Add(this.listBoxResult);
            this.Controls.Add(this.bntLaunch);
            this.Controls.Add(this.txtBetsCount);
            this.Controls.Add(this.lblBetsCount);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBetsCount;
        private System.Windows.Forms.TextBox txtBetsCount;
        private System.Windows.Forms.Button bntLaunch;
        private System.Windows.Forms.ListBox listBoxResult;
    }
}

