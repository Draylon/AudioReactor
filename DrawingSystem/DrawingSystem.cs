using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DrawingSystem {

    public partial class DrawingSystem : Form,DLLCall{
        private bool drawFree;
        private bool hidden=false;
        public DrawingSystem() {
            Console.WriteLine("Drawing system initialized");
            InitializeComponent();
            drawFree = true;
        }
        public void dispose() {
            this.Dispose();
        }
        public void setup() {
            Console.WriteLine("Setup called");
        }
        
        public void stonks() {
            Console.WriteLine("Stonks indeed");
        }
        public void showForm() {
            this.Show();
        }
        public void hideForm() {
            this.Hide();
        }

        public void fps(short fps) {
            throw new NotImplementedException();
        }
        public void loop(double[] d){
            if (drawFree && !hidden){
                drawFree = false;
                if (d != null)
                    foreach (double i in d) {
                        stereoAudioWavePainter1.AddLeftRight(0,Math.Abs((float)i));
                    }
                drawFree = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void Form1_Resize_1(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
                hidden = true;
            } else if (FormWindowState.Normal == this.WindowState) {
                notifyIcon.Visible = false;
                this.ShowInTaskbar = true;
                hidden = false;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void chart2_Click(object sender, EventArgs e) {

        }
    }
}
