using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioReactorLib;

namespace AudioReactorUI{
    delegate void setEntityDataValue(short v);
    delegate void setAvgFPSValue(short v);
    public partial class AREntity : UserControl{
        
        private static List<AREntity> instances = new List<AREntity>();
        private static int instancesCreated = 0;
        public static int getInstancesCreated(){ return instancesCreated; }
        public static void removeAllInstances(){
            for (int i = instancesCreated - 1; i >= 0; i--){
                instances.RemoveAt(i);
                instancesCreated--;
                Console.WriteLine("AREntity "+i + " removed | " + instances.Count);
            }
        }
        public static void removeInstance(AREntity rf){
            AudioReactor.removeInstance(rf.arEntity);
            instances.Remove(rf);
            instancesCreated--;
            Console.WriteLine("AREntity Instance Removed");
        }
        public static AREntity newInstance(AudioReactor ar){
            Console.WriteLine("AudioReactor Instance Created");
            instances.Add(new AREntity(ar));
            instancesCreated++;
            return instances[instancesCreated - 1];
        }
        //=====================================
        //=====================================
        //=====================================
        //=====================================
        //=====================================

        private int _instanceID;
        private int arEntity;
        private Point screenOffset;
        public int instanceID{
            get{ return _instanceID; }
        }
        private static bool _isBeingDragged;
        private static int _instanceDragged;
        private static int _draggedEntity = -1;

        public static int beingDragged{
            get{ return _instanceDragged; }
            set{ _instanceDragged = value; }
        }
        public static bool isDragged{
            get{ return _isBeingDragged; }
            set{ _isBeingDragged= value; }
        }
        public static int getDragged{
            get{ return _draggedEntity; }
        }

        private void setAvgFPSValue(short v) {
            if (this.avgFPS.InvokeRequired) {
                setAvgFPSValue d = new setAvgFPSValue(setAvgFPSValue);
                this.Invoke(d, new object[] { v });
            } else {
                this.avgFPS.Text = v.ToString();
            }
        }

        public void setAvgFPSValueEvent(object sender, short v) {
            setAvgFPSValue(v);
        }

        private void setEntityDataValue(short v){
            if (this.dataSum.InvokeRequired){
                setEntityDataValue d = new setEntityDataValue(setEntityDataValue);
                this.Invoke(d, new object[]{ v });
            } else{
                this.dataSum.Width = v;
            }
        }

        public void setEntityDataValueEvent(object sender,short v){
            setEntityDataValue(v);
        }
        public int getAudioReactorEntity() { return arEntity; }
        private AREntity(AudioReactor ar){
            _instanceID = instancesCreated;
            Console.WriteLine("this is "+ar.instanceID);
            InitializeComponent();
            arEntity = ar.instanceID;
            AudioReactor.getInstance(arEntity).procSumFetchReadyEvent += setEntityDataValueEvent;
            AudioReactor.getInstance(arEntity).procFPSEvent += setAvgFPSValueEvent;

            deviceTypeBox.Items.Add("Microphone");
            //deviceTypeBox.Items.Add("Speaker");

            fpsLimitLabel.Text = ar.fps_limit.ToString();
            fpsLimitRange.Value = ar.fps_limit;
        }
        ~AREntity(){
            if (arEntity != -1){
                AudioReactor.removeInstance(arEntity);
            }
        }

        private void deviceTypeBox_SelectedIndexChanged(object sender, EventArgs e){
            deviceSelectorBox.Items.Clear();
            deviceSelectorBox.Enabled = false;
            AudioReactor.getInstance(arEntity).audioDeviceNumber = 0;
            AudioReactor.getInstance(arEntity).audioType = AudioTypeMethod.Parse(deviceTypeBox.SelectedIndex);
            
            if (AudioTypeMethod.Parse(deviceTypeBox.SelectedIndex) == AudioType.MICROPHONE){
                deviceSelectorBox.Enabled = true;
                Dictionary<int, string> d = AudioReactor.getInputDeviceDict();
                int i = 0;
                foreach(KeyValuePair<int,string> entry in d){
                    deviceSelectorBox.Items.Add(entry.Key+" >-> "+entry.Value);
                    i++;
                }
            }
        }

        private void dataTypeBox_SelectedIndexChanged(object sender, EventArgs e){
            AudioReactor.getInstance(arEntity).dataType = DataTypeMethod.Parse(dataTypeBox.SelectedIndex);
        }

        private void deviceSelectorBox_SelectedIndexChanged(object sender, EventArgs e){
            AudioReactor.getInstance(arEntity).audioDeviceNumber = deviceSelectorBox.SelectedIndex - 1;
            Console.WriteLine("Entity capture from " + (deviceSelectorBox.SelectedIndex - 1));
        }

        private void enableEntity_CheckedChanged(object sender, EventArgs e){
            if (enableEntity.Checked){
                if ((AudioTypeMethod.Parse(AudioReactor.getInstance(arEntity).audioType) != -1) &&
                    (DataTypeMethod.Parse(AudioReactor.getInstance(arEntity).dataType) != -1 ))
                    AudioReactor.getInstance(arEntity).start();
                else
                    enableEntity.Checked = false;
            }else{
                AudioReactor.getInstance(arEntity).stop();
            }
        }
        private Point MouseDownLocation;
        private Point entityDataDefaultLocation;
        
        private void entityData_MouseDown(object sender, MouseEventArgs e){
            Console.WriteLine("Entity " + instanceID + " mouse down");
            if (e.Button == MouseButtons.Left){
                DLLitem.startedDragging();
                MouseDownLocation = e.Location;
                entityDataDefaultLocation = entityData.Location;
                beingDragged = this.instanceID;
                _draggedEntity = this.arEntity;
                isDragged = true;
            }
        }

        private void entityData_MouseMove(object sender, MouseEventArgs e){
            if (e.Button == System.Windows.Forms.MouseButtons.Left){
                entityData.Left = e.X + entityData.Left - MouseDownLocation.X;
                entityData.Top = e.Y + entityData.Top - MouseDownLocation.Y;
                screenOffset = SystemInformation.WorkingArea.Location;
                entityData.DoDragDrop(this.instanceID, DragDropEffects.Copy);
            }
        }

        private void entityData_MouseUp(object sender, MouseEventArgs e){
            Console.WriteLine("Entity " + instanceID + " mouse Up");
            DLLitem.endedDragging();
        }

        private void entityData_QueryContinueDrag(object sender, QueryContinueDragEventArgs e){
            if(e.Action == DragAction.Drop){
                Console.WriteLine("Entity " + instanceID + " Drag ended");
                isDragged = false;
                DLLitem.endedDragging();
            }
        }

        private void entityData_Click(object sender, EventArgs e){
            Console.WriteLine("Fetching data");
            //foreach(double d in arEntity.getProccessedData()){
            //    Console.Write(d.ToString("000") + " ");
            //}
        }

        private void AREntity_MouseClick(object sender, MouseEventArgs e){
            if(e.Button == MouseButtons.Right){
                instanceEntityRClick.Show(this, e.X, e.Y);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e){
            ARUForm.removeFromEntityContainer(this);
            AREntity.removeInstance(this);
        }

        private void fpsLimitRange_ValueChanged(object sender, EventArgs e) {
            AudioReactor.getInstance(arEntity).fps_limit = (short)fpsLimitRange.Value;
            fpsLimitLabel.Text = AudioReactor.getInstance(arEntity).fps_limit.ToString();
        }
    }
}
