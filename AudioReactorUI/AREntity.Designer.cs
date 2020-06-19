namespace AudioReactorUI {
    partial class AREntity {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.enableEntity = new System.Windows.Forms.CheckBox();
            this.deviceTypeBox = new System.Windows.Forms.ComboBox();
            this.deviceSelectorBox = new System.Windows.Forms.ComboBox();
            this.dataTypeBox = new System.Windows.Forms.ComboBox();
            this.EntityLabel = new System.Windows.Forms.Label();
            this.instr = new System.Windows.Forms.Label();
            this.instanceEntityRClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.entityData = new System.Windows.Forms.Panel();
            this.avgFPS = new System.Windows.Forms.Label();
            this.dataSum = new System.Windows.Forms.Panel();
            this.fpsLimitRange = new System.Windows.Forms.TrackBar();
            this.fpsSelectorLabel = new System.Windows.Forms.Label();
            this.fpsLimitLabel = new System.Windows.Forms.Label();
            this.instanceEntityRClick.SuspendLayout();
            this.entityData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsLimitRange)).BeginInit();
            this.SuspendLayout();
            // 
            // enableEntity
            // 
            this.enableEntity.AutoSize = true;
            this.enableEntity.BackColor = System.Drawing.Color.Transparent;
            this.enableEntity.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.enableEntity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.enableEntity.Location = new System.Drawing.Point(216, 8);
            this.enableEntity.Name = "enableEntity";
            this.enableEntity.Size = new System.Drawing.Size(65, 17);
            this.enableEntity.TabIndex = 0;
            this.enableEntity.Text = "Enabled";
            this.enableEntity.UseVisualStyleBackColor = false;
            this.enableEntity.CheckedChanged += new System.EventHandler(this.enableEntity_CheckedChanged);
            // 
            // deviceTypeBox
            // 
            this.deviceTypeBox.BackColor = System.Drawing.Color.White;
            this.deviceTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deviceTypeBox.ForeColor = System.Drawing.Color.Black;
            this.deviceTypeBox.FormattingEnabled = true;
            this.deviceTypeBox.Location = new System.Drawing.Point(8, 40);
            this.deviceTypeBox.Name = "deviceTypeBox";
            this.deviceTypeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.deviceTypeBox.Size = new System.Drawing.Size(121, 21);
            this.deviceTypeBox.TabIndex = 0;
            this.deviceTypeBox.Text = "Device Type";
            this.deviceTypeBox.SelectedIndexChanged += new System.EventHandler(this.deviceTypeBox_SelectedIndexChanged);
            // 
            // deviceSelectorBox
            // 
            this.deviceSelectorBox.BackColor = System.Drawing.Color.White;
            this.deviceSelectorBox.Enabled = false;
            this.deviceSelectorBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deviceSelectorBox.FormattingEnabled = true;
            this.deviceSelectorBox.Location = new System.Drawing.Point(144, 40);
            this.deviceSelectorBox.Name = "deviceSelectorBox";
            this.deviceSelectorBox.Size = new System.Drawing.Size(121, 21);
            this.deviceSelectorBox.TabIndex = 3;
            this.deviceSelectorBox.Text = "Select Device";
            this.deviceSelectorBox.SelectedIndexChanged += new System.EventHandler(this.deviceSelectorBox_SelectedIndexChanged);
            // 
            // dataTypeBox
            // 
            this.dataTypeBox.BackColor = System.Drawing.Color.White;
            this.dataTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataTypeBox.FormattingEnabled = true;
            this.dataTypeBox.Items.AddRange(new object[] {
            "Fourier",
            "PCM"});
            this.dataTypeBox.Location = new System.Drawing.Point(8, 80);
            this.dataTypeBox.Name = "dataTypeBox";
            this.dataTypeBox.Size = new System.Drawing.Size(121, 21);
            this.dataTypeBox.TabIndex = 4;
            this.dataTypeBox.Text = "Data Type";
            this.dataTypeBox.SelectedIndexChanged += new System.EventHandler(this.dataTypeBox_SelectedIndexChanged);
            // 
            // EntityLabel
            // 
            this.EntityLabel.AutoSize = true;
            this.EntityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EntityLabel.ForeColor = System.Drawing.Color.White;
            this.EntityLabel.Location = new System.Drawing.Point(8, 8);
            this.EntityLabel.Name = "EntityLabel";
            this.EntityLabel.Size = new System.Drawing.Size(43, 17);
            this.EntityLabel.TabIndex = 5;
            this.EntityLabel.Text = "Entity";
            // 
            // instr
            // 
            this.instr.AutoSize = true;
            this.instr.BackColor = System.Drawing.Color.Transparent;
            this.instr.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.instr.Location = new System.Drawing.Point(192, 72);
            this.instr.Name = "instr";
            this.instr.Size = new System.Drawing.Size(68, 26);
            this.instr.TabIndex = 6;
            this.instr.Text = "Drag this bar\r\nto the plugin.";
            // 
            // instanceEntityRClick
            // 
            this.instanceEntityRClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.instanceEntityRClick.Name = "rClickMenuLeft";
            this.instanceEntityRClick.Size = new System.Drawing.Size(155, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem1.Text = "Delete Instance";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // entityData
            // 
            this.entityData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.entityData.Controls.Add(this.avgFPS);
            this.entityData.Controls.Add(this.dataSum);
            this.entityData.Location = new System.Drawing.Point(176, 112);
            this.entityData.Name = "entityData";
            this.entityData.Size = new System.Drawing.Size(104, 24);
            this.entityData.TabIndex = 7;
            this.entityData.Click += new System.EventHandler(this.entityData_Click);
            this.entityData.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.entityData_QueryContinueDrag);
            this.entityData.MouseDown += new System.Windows.Forms.MouseEventHandler(this.entityData_MouseDown);
            this.entityData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.entityData_MouseMove);
            this.entityData.MouseUp += new System.Windows.Forms.MouseEventHandler(this.entityData_MouseUp);
            // 
            // avgFPS
            // 
            this.avgFPS.AutoSize = true;
            this.avgFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgFPS.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.avgFPS.Location = new System.Drawing.Point(40, 0);
            this.avgFPS.Name = "avgFPS";
            this.avgFPS.Size = new System.Drawing.Size(16, 17);
            this.avgFPS.TabIndex = 1;
            this.avgFPS.Text = "0";
            // 
            // dataSum
            // 
            this.dataSum.BackColor = System.Drawing.Color.Aqua;
            this.dataSum.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataSum.Location = new System.Drawing.Point(0, 0);
            this.dataSum.Name = "dataSum";
            this.dataSum.Size = new System.Drawing.Size(0, 24);
            this.dataSum.TabIndex = 0;
            // 
            // fpsLimitRange
            // 
            this.fpsLimitRange.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.fpsLimitRange.Location = new System.Drawing.Point(40, 112);
            this.fpsLimitRange.Maximum = 60;
            this.fpsLimitRange.Minimum = 1;
            this.fpsLimitRange.Name = "fpsLimitRange";
            this.fpsLimitRange.Size = new System.Drawing.Size(104, 45);
            this.fpsLimitRange.TabIndex = 8;
            this.fpsLimitRange.Value = 1;
            this.fpsLimitRange.ValueChanged += new System.EventHandler(this.fpsLimitRange_ValueChanged);
            // 
            // fpsSelectorLabel
            // 
            this.fpsSelectorLabel.AutoSize = true;
            this.fpsSelectorLabel.BackColor = System.Drawing.Color.Transparent;
            this.fpsSelectorLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fpsSelectorLabel.Location = new System.Drawing.Point(8, 112);
            this.fpsSelectorLabel.Name = "fpsSelectorLabel";
            this.fpsSelectorLabel.Size = new System.Drawing.Size(30, 13);
            this.fpsSelectorLabel.TabIndex = 9;
            this.fpsSelectorLabel.Text = "FPS:";
            // 
            // fpsLimitLabel
            // 
            this.fpsLimitLabel.AutoSize = true;
            this.fpsLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fpsLimitLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fpsLimitLabel.Location = new System.Drawing.Point(8, 128);
            this.fpsLimitLabel.Name = "fpsLimitLabel";
            this.fpsLimitLabel.Size = new System.Drawing.Size(14, 15);
            this.fpsLimitLabel.TabIndex = 10;
            this.fpsLimitLabel.Text = "0";
            // 
            // AREntity
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.fpsLimitLabel);
            this.Controls.Add(this.fpsSelectorLabel);
            this.Controls.Add(this.fpsLimitRange);
            this.Controls.Add(this.entityData);
            this.Controls.Add(this.instr);
            this.Controls.Add(this.EntityLabel);
            this.Controls.Add(this.dataTypeBox);
            this.Controls.Add(this.deviceSelectorBox);
            this.Controls.Add(this.deviceTypeBox);
            this.Controls.Add(this.enableEntity);
            this.Name = "AREntity";
            this.Size = new System.Drawing.Size(291, 150);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AREntity_MouseClick);
            this.instanceEntityRClick.ResumeLayout(false);
            this.entityData.ResumeLayout(false);
            this.entityData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsLimitRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox enableEntity;
        private System.Windows.Forms.ComboBox deviceTypeBox;
        private System.Windows.Forms.ComboBox deviceSelectorBox;
        private System.Windows.Forms.ComboBox dataTypeBox;
        private System.Windows.Forms.Label EntityLabel;
        private System.Windows.Forms.Label instr;
        private System.Windows.Forms.ContextMenuStrip instanceEntityRClick;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Panel entityData;
        private System.Windows.Forms.Panel dataSum;
        private System.Windows.Forms.Label avgFPS;
        private System.Windows.Forms.TrackBar fpsLimitRange;
        private System.Windows.Forms.Label fpsSelectorLabel;
        private System.Windows.Forms.Label fpsLimitLabel;
    }
}
