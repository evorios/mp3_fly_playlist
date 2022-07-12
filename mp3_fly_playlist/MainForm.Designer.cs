namespace mp3_fly_playlist
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPlaylist = new System.Windows.Forms.ListBox();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdChooseMp3 = new System.Windows.Forms.OpenFileDialog();
            this.sfdSavePlaylist = new System.Windows.Forms.SaveFileDialog();
            this.ofdChoosePlaylist = new System.Windows.Forms.OpenFileDialog();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbPlaylist
            // 
            this.lbPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPlaylist.Location = new System.Drawing.Point(0, 24);
            this.lbPlaylist.Name = "lbPlaylist";
            this.lbPlaylist.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbPlaylist.Size = new System.Drawing.Size(466, 238);
            this.lbPlaylist.TabIndex = 0;
            this.lbPlaylist.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbPlaylist_KeyUp);
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.directoryToolStripMenuItem,
            this.openToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(466, 24);
            this.msMain.TabIndex = 1;
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += openToolStripMenuItem1_Click;
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.directoryToolStripMenuItem.Text = "Add Dir";
            this.directoryToolStripMenuItem.Click += new System.EventHandler(this.directoryToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.openToolStripMenuItem.Text = "Add Files";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // ofdChooseMp3
            // 
            this.ofdChooseMp3.DefaultExt = "mp3";
            this.ofdChooseMp3.DereferenceLinks = false;
            this.ofdChooseMp3.Filter = "Mp3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            this.ofdChooseMp3.RestoreDirectory = true;
            this.ofdChooseMp3.ShowReadOnly = true;
            this.ofdChooseMp3.SupportMultiDottedExtensions = true;
            // 
            // sfdSavePlaylist
            // 
            this.sfdSavePlaylist.DereferenceLinks = false;
            this.sfdSavePlaylist.RestoreDirectory = true;
            this.sfdSavePlaylist.SupportMultiDottedExtensions = true;
            // 
            // ofdChoosePlaylist
            // 
            this.ofdChoosePlaylist.DereferenceLinks = false;
            this.ofdChoosePlaylist.RestoreDirectory = true;
            this.ofdChoosePlaylist.ShowReadOnly = true;
            this.ofdChoosePlaylist.SupportMultiDottedExtensions = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 262);
            this.Controls.Add(this.lbPlaylist);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "mainForm";
            this.Text = "MP3 Fly Playlist";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPlaylist;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem directoryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdChooseMp3;
        private System.Windows.Forms.SaveFileDialog sfdSavePlaylist;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.OpenFileDialog ofdChoosePlaylist;
    }
}

