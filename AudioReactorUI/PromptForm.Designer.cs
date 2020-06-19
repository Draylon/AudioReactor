namespace AudioReactorUI {
    partial class Prompt {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prompt));
            this.formBody = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.titlePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.actionBar = new System.Windows.Forms.Panel();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.toolBar = new System.Windows.Forms.Panel();
            this.customToolBar = new System.Windows.Forms.Panel();
            this.customFormToolsDeco = new System.Windows.Forms.Panel();
            this.formToolsPanel = new System.Windows.Forms.Panel();
            this.customTitleDeco = new System.Windows.Forms.Panel();
            this.customTitlePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.formBody.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.actionBar.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.customToolBar.SuspendLayout();
            this.customTitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // formBody
            // 
            this.formBody.BackColor = System.Drawing.Color.Transparent;
            this.formBody.Controls.Add(this.flowLayoutPanel1);
            this.formBody.Controls.Add(this.titlePanel);
            this.formBody.Controls.Add(this.actionBar);
            this.formBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formBody.Location = new System.Drawing.Point(0, 32);
            this.formBody.Name = "formBody";
            this.formBody.Size = new System.Drawing.Size(406, 345);
            this.formBody.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(406, 265);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.Transparent;
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.titlePanel.Size = new System.Drawing.Size(406, 40);
            this.titlePanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.titleLabel.Location = new System.Drawing.Point(7, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(392, 40);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Default Title Text";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // actionBar
            // 
            this.actionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.actionBar.Controls.Add(this.applyButton);
            this.actionBar.Controls.Add(this.cancelButton);
            this.actionBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.actionBar.Location = new System.Drawing.Point(0, 305);
            this.actionBar.Name = "actionBar";
            this.actionBar.Size = new System.Drawing.Size(406, 40);
            this.actionBar.TabIndex = 0;
            // 
            // applyButton
            // 
            this.applyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.applyButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.applyButton.FlatAppearance.BorderSize = 0;
            this.applyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.applyButton.Location = new System.Drawing.Point(331, 0);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 40);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = false;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Red;
            this.cancelButton.Location = new System.Drawing.Point(0, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 40);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // toolBar
            // 
            this.toolBar.Controls.Add(this.customToolBar);
            this.toolBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(406, 32);
            this.toolBar.TabIndex = 0;
            // 
            // customToolBar
            // 
            this.customToolBar.BackColor = System.Drawing.Color.Transparent;
            this.customToolBar.Controls.Add(this.customFormToolsDeco);
            this.customToolBar.Controls.Add(this.formToolsPanel);
            this.customToolBar.Controls.Add(this.customTitleDeco);
            this.customToolBar.Controls.Add(this.customTitlePanel);
            this.customToolBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customToolBar.Location = new System.Drawing.Point(0, 0);
            this.customToolBar.Name = "customToolBar";
            this.customToolBar.Size = new System.Drawing.Size(406, 32);
            this.customToolBar.TabIndex = 6;
            this.customToolBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseDown);
            this.customToolBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseMove);
            this.customToolBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseUp);
            // 
            // customFormToolsDeco
            // 
            this.customFormToolsDeco.BackgroundImage = global::AudioReactorUI.Properties.Resources.toolboxCorner_R;
            this.customFormToolsDeco.Dock = System.Windows.Forms.DockStyle.Right;
            this.customFormToolsDeco.Location = new System.Drawing.Point(246, 0);
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
            this.formToolsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.formToolsPanel.Location = new System.Drawing.Point(278, 0);
            this.formToolsPanel.Name = "formToolsPanel";
            this.formToolsPanel.Size = new System.Drawing.Size(128, 32);
            this.formToolsPanel.TabIndex = 2;
            this.formToolsPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseDown);
            this.formToolsPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseMove);
            this.formToolsPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customToolBar_MouseUp);
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
            // PromptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(406, 377);
            this.ControlBox = false;
            this.Controls.Add(this.formBody);
            this.Controls.Add(this.toolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PromptForm";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Prompt_Load);
            this.formBody.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.actionBar.ResumeLayout(false);
            this.toolBar.ResumeLayout(false);
            this.customToolBar.ResumeLayout(false);
            this.customTitlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel formBody;
        private System.Windows.Forms.Panel actionBar;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel toolBar;
        private System.Windows.Forms.Panel customToolBar;
        private System.Windows.Forms.Panel customFormToolsDeco;
        private System.Windows.Forms.Panel formToolsPanel;
        private System.Windows.Forms.Panel customTitleDeco;
        private System.Windows.Forms.Panel customTitlePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Label titleLabel;
    }
}