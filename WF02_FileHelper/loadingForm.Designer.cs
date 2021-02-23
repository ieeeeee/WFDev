namespace WF02_FileHelper
{
    partial class loadingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLoadingMsg = new System.Windows.Forms.Label();
            this.lblOptMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLoadingMsg
            // 
            this.lblLoadingMsg.AutoSize = true;
            this.lblLoadingMsg.Location = new System.Drawing.Point(58, 44);
            this.lblLoadingMsg.Name = "lblLoadingMsg";
            this.lblLoadingMsg.Size = new System.Drawing.Size(77, 12);
            this.lblLoadingMsg.TabIndex = 0;
            this.lblLoadingMsg.Text = "正在执行操作";
            // 
            // lblOptMsg
            // 
            this.lblOptMsg.AutoSize = true;
            this.lblOptMsg.Location = new System.Drawing.Point(141, 44);
            this.lblOptMsg.Name = "lblOptMsg";
            this.lblOptMsg.Size = new System.Drawing.Size(11, 12);
            this.lblOptMsg.TabIndex = 1;
            this.lblOptMsg.Text = "1";
            // 
            // loadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 105);
            this.Controls.Add(this.lblOptMsg);
            this.Controls.Add(this.lblLoadingMsg);
            this.Name = "loadingForm";
            this.Text = "loadingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoadingMsg;
        private System.Windows.Forms.Label lblOptMsg;
    }
}