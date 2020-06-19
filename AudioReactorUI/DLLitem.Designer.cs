namespace AudioReactorUI {
    partial class DLLitem {
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
            this.dropHere = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.enableDLL = new System.Windows.Forms.CheckBox();
            this.audioSourceLabel = new System.Windows.Forms.Label();
            this.dropHere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dropHere
            // 
            this.dropHere.AllowDrop = true;
            this.dropHere.BackColor = System.Drawing.Color.Teal;
            this.dropHere.Controls.Add(this.pictureBox1);
            this.dropHere.Location = new System.Drawing.Point(0, 0);
            this.dropHere.Name = "dropHere";
            this.dropHere.Size = new System.Drawing.Size(96, 96);
            this.dropHere.TabIndex = 0;
            this.dropHere.DragDrop += new System.Windows.Forms.DragEventHandler(this.dropHere_DragDrop);
            this.dropHere.DragEnter += new System.Windows.Forms.DragEventHandler(this.dropHere_DragEnter);
            this.dropHere.DragLeave += new System.EventHandler(this.dropHere_DragLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(32, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(112, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(44, 21);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Title";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLabel.ForeColor = System.Drawing.Color.White;
            this.descLabel.Location = new System.Drawing.Point(128, 40);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(79, 17);
            this.descLabel.TabIndex = 2;
            this.descLabel.Text = "Description";
            // 
            // enableDLL
            // 
            this.enableDLL.AutoSize = true;
            this.enableDLL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.enableDLL.Enabled = false;
            this.enableDLL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enableDLL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.enableDLL.Location = new System.Drawing.Point(288, 8);
            this.enableDLL.Name = "enableDLL";
            this.enableDLL.Size = new System.Drawing.Size(78, 21);
            this.enableDLL.TabIndex = 3;
            this.enableDLL.Text = "enabled";
            this.enableDLL.UseVisualStyleBackColor = true;
            this.enableDLL.CheckedChanged += new System.EventHandler(this.enableDLL_CheckedChanged);
            // 
            // audioSourceLabel
            // 
            this.audioSourceLabel.AutoSize = true;
            this.audioSourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioSourceLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.audioSourceLabel.Location = new System.Drawing.Point(240, 64);
            this.audioSourceLabel.Name = "audioSourceLabel";
            this.audioSourceLabel.Size = new System.Drawing.Size(0, 15);
            this.audioSourceLabel.TabIndex = 4;
            // 
            // DLLitem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.audioSourceLabel);
            this.Controls.Add(this.enableDLL);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.dropHere);
            this.Name = "DLLitem";
            this.Size = new System.Drawing.Size(382, 96);
            this.dropHere.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel dropHere;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox enableDLL;
        private System.Windows.Forms.Label audioSourceLabel;
    }
}
