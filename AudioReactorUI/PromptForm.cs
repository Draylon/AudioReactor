using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioReactorUI {

    public partial class Prompt : Form {
        private static int currentID=0;
        private int _instanceID;
        public int instanceID {get { return _instanceID;}}
        public event EventHandler<bool> dataResponseEvent;

        private Point downPoint = Point.Empty;

        private Prompt(string title,Control[] chList){
            _instanceID = currentID;
            currentID++;
            InitializeComponent();
            titleLabel.Text = title;
            flowLayoutPanel1.Controls.AddRange(chList);
        }

        private void Prompt_Load(object sender, EventArgs e){

        }

        //======================================================

        private void cancelButton_Click(object sender, EventArgs e){
            dataResponseEvent?.Invoke(this, false);
            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e){
            dataResponseEvent?.Invoke(this,true);
            this.Close();
        }

        private void customToolBar_MouseMove(object sender, MouseEventArgs e){
            if (downPoint != Point.Empty)
                Location = new Point(Left + e.X - downPoint.X, Top + e.Y - downPoint.Y);
        }

        private void customToolBar_MouseDown(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left)
                downPoint = new Point(e.X, e.Y);
        }

        private void customToolBar_MouseUp(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left)
                downPoint = Point.Empty;
        }
        
        //===============================
        
        private static List<Prompt> ongoingForms = new List<Prompt>();
        public static int createPrompt(string title, Control[] list){
            ongoingForms.Add(new Prompt(title, list));
            Console.WriteLine("Popup " + (ongoingForms.Count - 1) + " created");
            ongoingForms[(ongoingForms.Count - 1)].FormClosed += Prompt.disposePrompt;
            return ongoingForms.Count - 1;
        }
        public static void disposePrompt(int i) {
            for(int ii=0;ii < ongoingForms.Count; ii++) {
                if (ongoingForms[ii].instanceID == i)
                    ongoingForms.RemoveAt(ii);
            }
        }
        public static void disposePrompt(object theForm, FormClosedEventArgs e){
            disposePrompt(((Prompt)theForm).instanceID);
        }

        public static Prompt getFormAt(int i){
            try {
                return ongoingForms[i];
            } catch (Exception e) {
                Console.WriteLine("|| " + i + " Not accessible");
                return null;
            }
        }
    }
}
