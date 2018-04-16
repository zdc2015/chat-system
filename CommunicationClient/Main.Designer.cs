namespace CommunicationClient
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.lbaccount = new System.Windows.Forms.Label();
            this.lbnickname = new System.Windows.Forms.Label();
            this.friendlist = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbaccount
            // 
            this.lbaccount.AutoSize = true;
            this.lbaccount.Location = new System.Drawing.Point(12, 9);
            this.lbaccount.Name = "lbaccount";
            this.lbaccount.Size = new System.Drawing.Size(41, 12);
            this.lbaccount.TabIndex = 0;
            this.lbaccount.Text = "账号：";
            // 
            // lbnickname
            // 
            this.lbnickname.AutoSize = true;
            this.lbnickname.Location = new System.Drawing.Point(12, 35);
            this.lbnickname.Name = "lbnickname";
            this.lbnickname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbnickname.Size = new System.Drawing.Size(41, 12);
            this.lbnickname.TabIndex = 1;
            this.lbnickname.Text = "昵称：";
            // 
            // friendlist
            // 
            this.friendlist.ContextMenuStrip = this.contextMenuStrip1;
            this.friendlist.FormattingEnabled = true;
            this.friendlist.ItemHeight = 12;
            this.friendlist.Location = new System.Drawing.Point(14, 81);
            this.friendlist.Name = "friendlist";
            this.friendlist.Size = new System.Drawing.Size(120, 412);
            this.friendlist.TabIndex = 2;
            this.friendlist.SelectedIndexChanged += new System.EventHandler(this.friendlist_SelectedIndexChanged);
            this.friendlist.DoubleClick += new System.EventHandler(this.friendlist_DoubleClick);
            this.friendlist.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.friendlist_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 509);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "增加好友";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(149, 568);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.friendlist);
            this.Controls.Add(this.lbnickname);
            this.Controls.Add(this.lbaccount);
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbaccount;
        private System.Windows.Forms.Label lbnickname;
        private System.Windows.Forms.ListBox friendlist;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}