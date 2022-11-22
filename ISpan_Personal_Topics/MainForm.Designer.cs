namespace ISpan_Personal_Topics
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.產品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用戶管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.業績紀錄ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帳號設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.登出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.產品ToolStripMenuItem,
            this.用戶管理ToolStripMenuItem,
            this.業績紀錄ToolStripMenuItem,
            this.帳號設定ToolStripMenuItem,
            this.登出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1167, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 產品ToolStripMenuItem
            // 
            this.產品ToolStripMenuItem.Name = "產品ToolStripMenuItem";
            this.產品ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.產品ToolStripMenuItem.Text = "產品";
            this.產品ToolStripMenuItem.Click += new System.EventHandler(this.產品ToolStripMenuItem_Click);
            // 
            // 用戶管理ToolStripMenuItem
            // 
            this.用戶管理ToolStripMenuItem.Name = "用戶管理ToolStripMenuItem";
            this.用戶管理ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.用戶管理ToolStripMenuItem.Text = "用戶管理";
            this.用戶管理ToolStripMenuItem.Click += new System.EventHandler(this.用戶管理ToolStripMenuItem_Click);
            // 
            // 業績紀錄ToolStripMenuItem
            // 
            this.業績紀錄ToolStripMenuItem.Name = "業績紀錄ToolStripMenuItem";
            this.業績紀錄ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.業績紀錄ToolStripMenuItem.Text = "業績紀錄";
            this.業績紀錄ToolStripMenuItem.Click += new System.EventHandler(this.業績紀錄ToolStripMenuItem_Click);
            // 
            // 帳號設定ToolStripMenuItem
            // 
            this.帳號設定ToolStripMenuItem.Name = "帳號設定ToolStripMenuItem";
            this.帳號設定ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.帳號設定ToolStripMenuItem.Text = "帳號設定";
            this.帳號設定ToolStripMenuItem.Click += new System.EventHandler(this.帳號設定ToolStripMenuItem_Click);
            // 
            // 登出ToolStripMenuItem
            // 
            this.登出ToolStripMenuItem.Name = "登出ToolStripMenuItem";
            this.登出ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.登出ToolStripMenuItem.Text = "登出";
            this.登出ToolStripMenuItem.Click += new System.EventHandler(this.登出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 596);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "首頁";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 產品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用戶管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 業績紀錄ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帳號設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 登出ToolStripMenuItem;
    }
}