using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioReactorUI
{
    public partial class Form11 : Form
    {


        private readonly WaveInEvent _waveIn;
        private readonly BufferedWaveProvider _prov;
        private readonly WaveOut _waveOut;

        private int _count;
        private const int Speed = 1;
        private float _leftMax, _rightMax;
        private readonly object _sampleObject;
        private readonly NotifyingSampleProvider _notify;

        public Form11()
        {
            //InitializeComponent();
            _waveIn = new WaveInEvent { WaveFormat = new WaveFormat(44100, WaveIn.GetCapabilities(0).Channels) };
            _waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(_waveIn_DataAvailable);
            _prov = new BufferedWaveProvider(new WaveFormat());
            _waveOut = new WaveOut();
            _sampleObject = new object();
            _notify = new NotifyingSampleProvider(_prov.ToSampleProvider());
            _notify.Sample += DrawAudioWave;
        }

        private void BufferPlay(byte[] recv)
        {
            if (recv.Length > 0)
            {
                _prov.AddSamples(recv, 0, recv.Length);
            }
        }

        private void StartAudio()
        {
            _waveIn.StartRecording();
            _waveOut.Init(_notify);
            _waveOut.Play();
        }

        private void _waveIn_DataAvailable(object sender, WaveInEventArgs e){
            BufferPlay(e.Buffer);
        }

        private void StopAudio(){
            if (_waveOut == null) return;
            _waveOut.Dispose();
            _waveOut.Stop();
            _prov.ClearBuffer();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            StartAudio();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            StopAudio();
        }

        private void DrawAudioWave(object sender, SampleEventArgs e)
        {
            lock (_sampleObject)
            {
                if (_count >= Speed)
                {
                    //stereoAudioWavePainter1.AddLeftRight(_leftMax, _rightMax);
                    _leftMax = 0;
                    _rightMax = 0;
                    _count = 0;
                }
                else
                {
                    if (Math.Abs(e.Left) + Math.Abs(e.Right) > Math.Abs(_leftMax) + Math.Abs(_rightMax))
                    {
                        _leftMax = e.Left;
                        _rightMax = e.Right;
                    }
                    _count++;
                }
            }
        }



        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void selectDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void turnOnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void turnOffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}