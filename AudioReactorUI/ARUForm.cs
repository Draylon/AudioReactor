using AudioReactorLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AudioReactorUI {

    public partial class ARUForm : Form {

        private Point downPoint = Point.Empty;
        private static FlowLayoutPanel entityHolderReference;
        private static Dictionary<string, string> dlls_detected = new Dictionary<string, string>();
        private static CheckBox[] dlls_list;


        public ARUForm() {
            InitializeComponent();
            //_notify = new NotifyingSampleProvider(_prov.ToSampleProvider());
            //_notify.Sample += sendToChart;
            this.TransparencyKey = Color.LightGreen;
            this.BackColor = Color.LightGreen;
            entityHolderReference = entityHolder;
        }
        ~ARUForm() {
            StopAudio();
        }

        private void StopAudio() {
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            AREntity.removeAllInstances();
            DLLitem.removeAllInstances();
            AudioReactor.removeAllInstances();
            DLLObject.removeAllInstances();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //start doing stuff
            //base.OnLoad(e);

            //no, don't load dlls, just list it
            string pluginsPath = Directory.GetCurrentDirectory() + "\\plugins\\";
            if (!Directory.Exists(pluginsPath)) {
                Directory.CreateDirectory(pluginsPath);
            }
            string[] s = Directory.GetFiles(pluginsPath, "*.dll", SearchOption.TopDirectoryOnly);
            foreach(string ss in s) {
                string name = ss.Replace(pluginsPath, "").Replace(".dll","");
                dlls_detected.Add(name, ss);
            }
        }

        public static void removeFromEntityContainer(AREntity a) {
            entityHolderReference.Controls.Remove(a);
        }

        private void createDLLInstances(object sender, bool e) {
            if (e == true) {
                Console.WriteLine("Creating instances for selected DLLs");
                int ii = 0;
                foreach(KeyValuePair<string,string> entry in dlls_detected) {
                    if(dlls_list[ii].Checked == true) {
                        dllHolder.Controls.Add(DLLitem.newInstance(entry.Key, "this is " + entry.Key, null, DLLObject.newInstance(entry.Value, entry.Key)));
                    }
                }
            } else {
                Console.WriteLine("Canceled");
            }
        }


        //================================================================

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void Form1_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                this.ShowInTaskbar = false;
            } else if (FormWindowState.Normal == this.WindowState) {
                this.Show();
                notifyIcon1.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            StopAudio();
            //base.OnFormClosing(e);
        }

        private void entityHolder_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                rClickMenuLeft.Show(this.entityHolder,e.X,e.Y);
        }

        private void newInstanceToolStripMenu1_Click(object sender, EventArgs e) {
            //create instance
            //create arentity
            entityHolder.Controls.Add(AREntity.newInstance((AudioReactor.newInstance())));
        }
        private void deleteAllInstancesToolStripMenuItem_Click(object sender, EventArgs e) {
            AudioReactor.removeAllInstances();
            entityHolder.Controls.Clear();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            
        }

        private void customToolBar_MouseMove(object sender, MouseEventArgs e) {
            if (downPoint != Point.Empty)
                Location = new Point(Left + e.X - downPoint.X, Top + e.Y -downPoint.Y);
        }

        private void customToolBar_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                downPoint = new Point(e.X, e.Y);
        }

        private void customToolBar_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left)
                downPoint = Point.Empty;
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dllHolder_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right)
                rClickMenuRight.Show(this.dllHolder,e.X, e.Y);
        }

        private void newInstanceToolStripMenuItem1_Click(object sender, EventArgs e) {
            //show popup here
            dlls_list = new CheckBox[dlls_detected.Count];
            int i = 0;
            foreach(KeyValuePair<string,string> entry in dlls_detected) {
                dlls_list[i] = new CheckBox();
                dlls_list[i].Text = entry.Key;
                dlls_list[i].ForeColor = Color.White;
                i++;
            }
            int idResp = Prompt.createPrompt("Detected Plugins", dlls_list);
            Prompt.getFormAt(idResp).dataResponseEvent += createDLLInstances;
            Prompt.getFormAt(idResp).ShowDialog();
        }

        private void deleteAllInstancesToolStripMenuItem1_Click(object sender, EventArgs e) {

        }
    }
}