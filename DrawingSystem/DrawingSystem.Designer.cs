namespace DrawingSystem {
    partial class DrawingSystem {
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingSystem));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.stereoAudioWavePainter1 = new NAudio_Plotting.StereoAudioWavePainter();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Minimized";
            this.notifyIcon.BalloonTipTitle = "Stonks";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "AYYLMAO";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // stereoAudioWavePainter1
            // 
            this.stereoAudioWavePainter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.stereoAudioWavePainter1.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            this.stereoAudioWavePainter1.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
            this.stereoAudioWavePainter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stereoAudioWavePainter1.DrawMode = NAudio_Plotting.StereoAudioWavePainter.DisplayMode.Line;
            this.stereoAudioWavePainter1.ForeColor = System.Drawing.Color.White;
            this.stereoAudioWavePainter1.Gradient = true;
            this.stereoAudioWavePainter1.GradientColor = System.Drawing.Color.Teal;
            this.stereoAudioWavePainter1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.stereoAudioWavePainter1.Location = new System.Drawing.Point(0, 0);
            this.stereoAudioWavePainter1.MiddleLineColor = System.Drawing.Color.Empty;
            this.stereoAudioWavePainter1.Name = "stereoAudioWavePainter1";
            this.stereoAudioWavePainter1.Pinch = NAudio_Plotting.StereoAudioWavePainter.PinchMode.InsideCosine;
            this.stereoAudioWavePainter1.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            this.stereoAudioWavePainter1.Plot = NAudio_Plotting.StereoAudioWavePainter.Plotmode.PlusMinus;
            this.stereoAudioWavePainter1.QualityMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            this.stereoAudioWavePainter1.ShowMidLine = false;
            this.stereoAudioWavePainter1.Size = new System.Drawing.Size(800, 450);
            this.stereoAudioWavePainter1.TabIndex = 1;
            // 
            // DrawingSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.stereoAudioWavePainter1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DrawingSystem";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private NAudio_Plotting.StereoAudioWavePainter stereoAudioWavePainter1;
    }
}

