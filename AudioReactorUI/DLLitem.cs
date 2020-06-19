using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using AudioReactorLib;
using System.IO;

namespace AudioReactorUI {
    public partial class DLLitem : UserControl {
        private static List<DLLitem> instances = new List<DLLitem>();
        private static int instancesCreated = 0;
        public static int getInstancesCreated() { return instancesCreated; }
        public static void removeAllInstances() {
            for (int i = instancesCreated - 1; i >= 0; i--) {
                instances.RemoveAt(i);
                instancesCreated--;
                Console.WriteLine("DLLItem "+i + " removed | " + instances.Count);
            }
        }
        public static void removeInstance(ref DLLitem rf) {
            instances.Remove(rf);
            instancesCreated--;
            Console.WriteLine("DLLItem Instance Removed");
        }
        public static DLLitem newInstance(string titler, string descr, Image iconr, DLLObject dllObjectr){
            Console.WriteLine("DLL new Instance");
            instances.Add(new DLLitem(titler,descr,iconr,dllObjectr));
            instancesCreated++;
            return instances[instancesCreated - 1];
        }

        //============================================================
        //============================================================
        //============================================================
        //============================================================

        public static void startedDragging() {
            foreach(DLLitem i in instances) {
                if(i.arSet)
                    continue;
                i.dropHere.BackColor = Color.DarkTurquoise;
            }
        }
        
        public static void endedDragging() {
            foreach (DLLitem i in instances) {
                if (i.arSet)
                    continue;
                i.dropHere.BackColor = Color.Teal;
            }
        }


        private DLLObject _dll;
        private int arEntity;
        private string _title;
        private string _desc;
        private Image _icon;
        private bool arSet=false;

        public string title {
            get { return _title; }
            set { _title = value; titleLabel.Text = _title; }
        }
        public string desc {
            get { return _desc; }
            set { _desc = value; descLabel.Text = _desc; }
        }

        public Image icon {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = _icon; }
        }
        public DLLObject dll{
            get { return _dll; }
        }

        private int _instanceID;
        public int instanceID {
            get { return _instanceID; }
        }
        private DLLitem(string titler,string descr,Image iconr,DLLObject dllObjectr) {
            _instanceID = instancesCreated;
            InitializeComponent();
            Console.WriteLine("Criando DLLItem do " + titler);
            this._title = titler;
            this._desc = descr;
            this._icon = iconr;
            this._dll = dllObjectr;
            titleLabel.Text = titler;
            descLabel.Text = descr;
            pictureBox1.Image = iconr;
        }

        private void dropHere_DragEnter(object sender, DragEventArgs e) {
            if (arSet)
                return;
            Console.WriteLine("Entered Dragging " + instanceID);
            if (e.Data.GetDataPresent(typeof(int)) ){
                dropHere.BackColor = Color.DarkMagenta;
                Console.WriteLine("Mathing Type");
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dropHere_DragLeave(object sender, EventArgs e) {
            if (arSet)
                return;
            if (AREntity.isDragged) {
                Console.WriteLine("Left Dragging " + instanceID);
                dropHere.BackColor = Color.DarkTurquoise;
            }
            //leftDragging(this);
        }

        private void dropHere_DragDrop(object sender, DragEventArgs e) {
            if (arSet)
                return;
            Console.WriteLine("DragDrop: ");
            int uiEntityID = (int)e.Data.GetData(typeof(int));
            if(uiEntityID == AREntity.beingDragged) {
                this.arEntity = AREntity.getDragged;
                Console.WriteLine("Audio component id: " + AudioReactor.getInstance(this.arEntity).instanceID);
                audioSourceLabel.Text = "AudioReactor entity: " + AudioReactor.getInstance(this.arEntity).instanceID;
                enableDLL.Enabled = true;
            }
            if (AudioReactor.getInstance(this.arEntity).dataType == DataType.PCM)
                AudioReactor.getInstance(this.arEntity).procPCMDataFetchReadyEvent += dataLoopSend;
            else
                AudioReactor.getInstance(this.arEntity).procFourierDataFetchReadyEvent += dataLoopSend;
        }
        private void dataLoopSend(object sender, double[] e) {
            dll.dllInstance.loop(e);
        }

        private void enableDLL_CheckedChanged(object sender, EventArgs e) {
            try {
                if (enableDLL.Checked == true) {
                    _dll.dllInstance.showForm();
                } else {
                    _dll.dllInstance.hideForm();
                }
            }catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ee) {
                Console.WriteLine("Unable to find form display functions!"+ee);
            }catch(Exception ee) {
                Console.WriteLine("RANDOM EXCEPTION "+ee);
            }
        }
    }

    //======================================================
    //======================================================
    //======================================================
    //======================================================
    //======================================================
    public class DLLObject {
        //https://stackoverflow.com/questions/18362368/loading-dlls-at-runtime-in-c-sharp
        private string dllName;
        private string dllPath;
        private Assembly _assembly;
        private Type _classType;
        private dynamic _dllInstance;
        public DLLObject(string s,string name) {
            dllName = name;
            dllPath = s;
            loadDLL();
            setClassType();
            Console.WriteLine("Classtype: "+classType);
            setDllInstance();
        }
        ~DLLObject() {
            _dllInstance.dispose();
        }

        public Assembly assembly {get { return _assembly; }}
        public Type classType {get { return _classType; }}
        public dynamic dllInstance {get { return _dllInstance; }}

        private void loadDLL(){
            string strDllPath = Path.GetFullPath(dllPath);
            Assembly DLL = null;
            try {
                if (File.Exists(strDllPath)){
                    DLL = Assembly.LoadFrom(strDllPath);
                    Console.WriteLine("Successfully loaded " + dllName + " | type: " + DLL.GetType());
                } else {throw new Exception("File "+dllPath+" not found!");}
            }catch(Exception e) {
                Console.WriteLine("Error loading " + dllName+". \n"+e);
            }
            this._assembly = DLL;
        }
        public void setClassType(){
            try {
                Console.WriteLine("Looking for "+dllName+ ".AudioReactorPlugin");
                _classType=_assembly.GetType(String.Format("{0}.{1}",dllName, "AudioReactorPlugin"));
            } catch(Exception e) { Console.WriteLine("Error getting type " + dllName + ". \n" + e); }
        }
        private void setDllInstance() {
            if (classType != null) {
                // Create class instance.
                try {
                    _dllInstance = Activator.CreateInstance(classType);
                    _dllInstance.stonks();
                }catch(Microsoft.CSharp.RuntimeBinder.RuntimeBinderException e) {
                    Console.WriteLine("Couldn't find function:\n"+e);
                }catch(Exception e) {
                    Console.WriteLine(e);
                }
                //foreach (Type type in _assembly.GetExportedTypes()) {
                //    if(type == classType) {
                //        _dllInstance = Activator.CreateInstance(type);
                //        _dllInstance.stonks();
                //    }
                //}
            }
        }
        //====================================================
        //====================================================
        //====================================================
        //====================================================
        //====================================================
        private static List<DLLObject> dll_instances = new List<DLLObject>();

        private static int instancesCreated = 0;
        public static int getInstancesCreated() { return instancesCreated; }
        public static void removeAllInstances() {
            for (int i = DLLObject.instancesCreated - 1; i >= 0; i--) {
                removeInstance(dll_instances[i]);
                Console.WriteLine("DLLObject " + i + " removed | " + dll_instances.Count);
            }
        }
        public static void removeInstance(DLLObject rf) {
            try {
                try {
                    rf.dllInstance.dispose();
                } catch (Exception e) {
                    Console.WriteLine("Random error trying to stop dll function");
                }
                DLLObject.dll_instances.Remove(rf);
                Console.WriteLine("DLLObject Instance " + instancesCreated + " Removed");
                DLLObject.instancesCreated--;
            }catch(Exception e) {
                Console.WriteLine("Fuckup removing instance " + e);
            }
        }
        public static DLLObject newInstance(string s, string name) {
            DLLObject.dll_instances.Add(new DLLObject(s, name));
            DLLObject.instancesCreated++;
            return DLLObject.dll_instances[instancesCreated - 1];
        }
    }
}
