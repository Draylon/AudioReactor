namespace AudioReactorUI
{
    partial class ARUForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARUForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.rClickMenuLeft = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllInstancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.leftSide = new System.Windows.Forms.Panel();
            this.entityHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.leftTitle = new System.Windows.Forms.Panel();
            this.lsLabel = new System.Windows.Forms.Label();
            this.rightSide = new System.Windows.Forms.Panel();
            this.dllHolder = new System.Windows.Forms.FlowLayoutPanel();
            this.rightTitle = new System.Windows.Forms.Panel();
            this.rsLabel = new System.Windows.Forms.Label();
            this.customToolBar = new System.Windows.Forms.Panel();
            this.customFormToolsDeco = new System.Windows.Forms.Panel();
            this.formToolsPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Label();
            this.minimizeButton = new System.Windows.Forms.Label();
            this.customTitleDeco = new System.Windows.Forms.Panel();
            this.customTitlePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rClickMenuRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newInstanceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllInstancesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rClickMenuLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.leftSide.SuspendLayout();
            this.leftTitle.SuspendLayout();
            this.rightSide.SuspendLayout();
            this.rightTitle.SuspendLayout();
            this.customToolBar.SuspendLayout();
            this.formToolsPanel.SuspendLayout();
            this.customTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.rClickMenuRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Minimizado";
            this.notifyIcon1.BalloonTipTitle = "AudioReactor";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AudioReactor UI";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // rClickMenuLeft
            // 
            this.rClickMenuLeft.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInstanceToolStripMenuItem,
            this.deleteAllInstancesToolStripMenuItem});
            this.rClickMenuLeft.Name = "rClickMenuLeft";
            this.rClickMenuLeft.Size = new System.Drawing.Size(177, 48);
            // 
            // newInstanceToolStripMenuItem
            // 
            this.newInstanceToolStripMenuItem.Name = "newInstanceToolStripMenuItem";
            this.newInstanceToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.newInstanceToolStripMenuItem.Text = "New Instance";
            this.newInstanceToolStripMenuItem.Click += new System.EventHandler(this.newInstanceToolStripMenu1_Click);
            // 
            // deleteAllInstancesToolStripMenuItem
            // 
            this.deleteAllInstancesToolStripMenuItem.Name = "deleteAllInstancesToolStripMenuItem";
            this.deleteAllInstancesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.deleteAllInstancesToolStripMenuItem.Text = "Delete All Instances";
            this.deleteAllInstancesToolStripMenuItem.Click += new System.EventHandler(this.deleteAllInstancesToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(25)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.leftSide);
            this.splitContainer1.Panel1MinSize = 380;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rightSide);
            this.splitContainer1.Panel2MinSize = 380;
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 391;
            this.splitContainer1.TabIndex = 4;
            // 
            // leftSide
            // 
            this.leftSide.Controls.Add(this.entityHolder);
            this.leftSide.Controls.Add(this.leftTitle);
            this.leftSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSide.Location = new System.Drawing.Point(0, 0);
            this.leftSide.Name = "leftSide";
            this.leftSide.Size = new System.Drawing.Size(391, 561);
            this.leftSide.TabIndex = 3;
            // 
            // entityHolder
            // 
            this.entityHolder.AutoScroll = true;
            this.entityHolder.AutoScrollMargin = new System.Drawing.Size(20, 45);
            this.entityHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.entityHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entityHolder.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.entityHolder.Location = new System.Drawing.Point(0, 56);
            this.entityHolder.Margin = new System.Windows.Forms.Padding(15);
            this.entityHolder.Name = "entityHolder";
            this.entityHolder.Size = new System.Drawing.Size(391, 505);
            this.entityHolder.TabIndex = 7;
            this.entityHolder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entityHolder_MouseDown);
            // 
            // leftTitle
            // 
            this.leftTitle.Controls.Add(this.lsLabel);
            this.leftTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTitle.Location = new System.Drawing.Point(0, 0);
            this.leftTitle.Name = "leftTitle";
            this.leftTitle.Size = new System.Drawing.Size(391, 56);
            this.leftTitle.TabIndex = 0;
            // 
            // lsLabel
            // 
            this.lsLabel.BackColor = System.Drawing.Color.Transparent;
            this.lsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsLabel.ForeColor = System.Drawing.Color.Transparent;
            this.lsLabel.Location = new System.Drawing.Point(0, 0);
            this.lsLabel.Name = "lsLabel";
            this.lsLabel.Size = new System.Drawing.Size(391, 56);
            this.lsLabel.TabIndex = 0;
            this.lsLabel.Text = "Capture Instances";
            this.lsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightSide
            // 
            this.rightSide.Controls.Add(this.dllHolder);
            this.rightSide.Controls.Add(this.rightTitle);
            this.rightSide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSide.Location = new System.Drawing.Point(0, 0);
            this.rightSide.Name = "rightSide";
            this.rightSide.Size = new System.Drawing.Size(389, 561);
            this.rightSide.TabIndex = 4;
            // 
            // dllHolder
            // 
            this.dllHolder.AutoScrollMargin = new System.Drawing.Size(20, 45);
            this.dllHolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.dllHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dllHolder.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.dllHolder.Location = new System.Drawing.Point(0, 56);
            this.dllHolder.Name = "dllHolder";
            this.dllHolder.Size = new System.Drawing.Size(389, 505);
            this.dllHolder.TabIndex = 3;
            this.dllHolder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dllHolder_MouseDown);
            // 
            // rightTitle
            // 
            this.rightTitle.Controls.Add(this.rsLabel);
            this.rightTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightTitle.Location = new System.Drawing.Point(0, 0);
            this.rightTitle.Name = "rightTitle";
            this.rightTitle.Size = new System.Drawing.Size(389, 56);
            this.rightTitle.TabIndex = 0;
            // 
            // rsLabel
            // 
            this.rsLabel.BackColor = System.Drawing.Color.Transparent;
            this.rsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsLabel.ForeColor = System.Drawing.Color.Transparent;
            this.rsLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rsLabel.Location = new System.Drawing.Point(0, 0);
            this.rsLabel.Name = "rsLabel";
            this.rsLabel.Size = new System.Drawing.Size(389, 56);
            this.rsLabel.TabIndex = 0;
            this.rsLabel.Text = "Plugins Loaded";
            this.rsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customToolBar
            // 
            this.customToolBar.BackColor = System.Drawing.Color.Transparent;
            this.customToolBar.Controls.Add(this.customFormToolsDeco);
            this.customToolBar.Controls.Add(this.formToolsPanel);
            this.customToolBar.Controls.Add(this.customTitleDeco);
            this.customToolBar.Controls.Add(this.customTitlePanel);
            this.customToolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.customToolBar.Location = new System.Drawing.Point(0, 0);
            this.customToolBar.Name = "customToolBar";
            this.customToolBar.Size = new System.Drawing.Size(784, 32);
            this.customToolBar.TabIndex = 5;
            this.customToolBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseDown);
            this.customToolBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseMove);
            this.customToolBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseUp);
            // 
            // customFormToolsDeco
            // 
            this.customFormToolsDeco.BackgroundImage = global::AudioReactorUI.Properties.Resources.toolboxCorner_R;
            this.customFormToolsDeco.Dock = System.Windows.Forms.DockStyle.Right;
            this.customFormToolsDeco.Location = new System.Drawing.Point(624, 0);
            this.customFormToolsDeco.Name = "customFormToolsDeco";
            this.customFormToolsDeco.Size = new System.Drawing.Size(32, 32);
            this.customFormToolsDeco.TabIndex = 3;
            this.customFormToolsDeco.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseDown);
            this.customFormToolsDeco.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseMove);
            this.customFormToolsDeco.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseUp);
            // 
            // formToolsPanel
            // 
            this.formToolsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.formToolsPanel.Controls.Add(this.closeButton);
            this.formToolsPanel.Controls.Add(this.minimizeButton);
            this.formToolsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.formToolsPanel.Location = new System.Drawing.Point(656, 0);
            this.formToolsPanel.Name = "formToolsPanel";
            this.formToolsPanel.Size = new System.Drawing.Size(128, 32);
            this.formToolsPanel.TabIndex = 2;
            this.formToolsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseDown);
            this.formToolsPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseMove);
            this.formToolsPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.closeButton.Location = new System.Drawing.Point(96, 8);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(17, 14);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // minimizeButton
            // 
            this.minimizeButton.AutoSize = true;
            this.minimizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.minimizeButton.Location = new System.Drawing.Point(56, 8);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(19, 15);
            this.minimizeButton.TabIndex = 0;
            this.minimizeButton.Text = "－";
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // customTitleDeco
            // 
            this.customTitleDeco.BackgroundImage = global::AudioReactorUI.Properties.Resources.toolboxCorner_L;
            this.customTitleDeco.Dock = System.Windows.Forms.DockStyle.Left;
            this.customTitleDeco.Location = new System.Drawing.Point(120, 0);
            this.customTitleDeco.Name = "customTitleDeco";
            this.customTitleDeco.Size = new System.Drawing.Size(32, 32);
            this.customTitleDeco.TabIndex = 1;
            this.customTitleDeco.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseDown);
            this.customTitleDeco.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseMove);
            this.customTitleDeco.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseUp);
            // 
            // customTitlePanel
            // 
            this.customTitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.customTitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.customTitlePanel.Controls.Add(this.pictureBox1);
            this.customTitlePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.customTitlePanel.ForeColor = System.Drawing.Color.Transparent;
            this.customTitlePanel.Location = new System.Drawing.Point(0, 0);
            this.customTitlePanel.Name = "customTitlePanel";
            this.customTitlePanel.Size = new System.Drawing.Size(120, 32);
            this.customTitlePanel.TabIndex = 0;
            this.customTitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseDown);
            this.customTitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseMove);
            this.customTitlePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // rClickMenuRight
            // 
            this.rClickMenuRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newInstanceToolStripMenuItem1,
            this.deleteAllInstancesToolStripMenuItem1});
            this.rClickMenuRight.Name = "rClickMenuRight";
            this.rClickMenuRight.Size = new System.Drawing.Size(177, 48);
            // 
            // newInstanceToolStripMenuItem1
            // 
            this.newInstanceToolStripMenuItem1.Name = "newInstanceToolStripMenuItem1";
            this.newInstanceToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.newInstanceToolStripMenuItem1.Text = "New Instance";
            this.newInstanceToolStripMenuItem1.Click += new System.EventHandler(this.newInstanceToolStripMenuItem1_Click);
            // 
            // deleteAllInstancesToolStripMenuItem1
            // 
            this.deleteAllInstancesToolStripMenuItem1.Name = "deleteAllInstancesToolStripMenuItem1";
            this.deleteAllInstancesToolStripMenuItem1.Size = new System.Drawing.Size(176, 22);
            this.deleteAllInstancesToolStripMenuItem1.Text = "Delete All Instances";
            this.deleteAllInstancesToolStripMenuItem1.Click += new System.EventHandler(this.deleteAllInstancesToolStripMenuItem1_Click);
            // 
            // ARUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 591);
            this.Controls.Add(this.customToolBar);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "ARUForm";
            this.Text = "AudioReactor UI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.rClickMenuLeft.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.leftSide.ResumeLayout(false);
            this.leftTitle.ResumeLayout(false);
            this.rightSide.ResumeLayout(false);
            this.rightTitle.ResumeLayout(false);
            this.customToolBar.ResumeLayout(false);
            this.formToolsPanel.ResumeLayout(false);
            this.formToolsPanel.PerformLayout();
            this.customTitlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.rClickMenuRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip rClickMenuLeft;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel leftSide;
        private System.Windows.Forms.FlowLayoutPanel entityHolder;
        private System.Windows.Forms.Panel leftTitle;
        private System.Windows.Forms.Panel rightSide;
        private System.Windows.Forms.FlowLayoutPanel dllHolder;
        private System.Windows.Forms.Panel rightTitle;
        private System.Windows.Forms.Label lsLabel;
        private System.Windows.Forms.Label rsLabel;
        private System.Windows.Forms.Panel customToolBar;
        private System.Windows.Forms.ToolStripMenuItem newInstanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllInstancesToolStripMenuItem;
        private System.Windows.Forms.Panel customTitleDeco;
        private System.Windows.Forms.Panel formToolsPanel;
        private System.Windows.Forms.Panel customFormToolsDeco;
        private System.Windows.Forms.Panel customTitlePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Label minimizeButton;
        private System.Windows.Forms.ContextMenuStrip rClickMenuRight;
        private System.Windows.Forms.ToolStripMenuItem newInstanceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteAllInstancesToolStripMenuItem1;
    }
}

