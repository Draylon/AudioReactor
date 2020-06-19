#define JANELAS
using System;
using System.Collections.Generic;
using System.Threading;

using FFTWSharp;
using NAudio.Wave;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AudioReactorLib {

    public enum AudioType {
        MICROPHONE,
        SPEAKER
    };
    public enum DataType {
        FOURIER,
        PCM
    }
    public class AudioTypeMethod {
        public static AudioType Parse(int i){
            switch (i){
                default:
                case 0:
                    return AudioType.MICROPHONE;
                case 1:
                    return AudioType.SPEAKER;
            }
        }
        public static int Parse(AudioType i){
            switch (i){
                case AudioType.MICROPHONE:
                    return 0;
                case AudioType.SPEAKER:
                    return 1;
                default:
                    return -1;
            }
        }
    }
    public class DataTypeMethod {
        public static DataType Parse(int i){
            switch (i){
                default:
                case 0:
                    return DataType.FOURIER;
                case 1:
                    return DataType.PCM;

            }
        }
        public static int Parse(DataType d){
            switch (d){
                case DataType.FOURIER:
                    return 0;
                case DataType.PCM:
                    return 1;
                default:
                    return -1;
            }
        }
    }

    public class AudioReactor {

        public event EventHandler<short> procSumFetchReadyEvent;
        public event EventHandler<short> procFPSEvent;
        public event EventHandler<double[]> procPCMDataFetchReadyEvent;
        public event EventHandler<double[]> procFourierDataFetchReadyEvent;

        private int _instanceID;
        public int instanceID {
            get { return _instanceID; }
        }

        private int _audioDeviceNumber;
        private AudioType _audioType;
        private DataType _dataType;

        private static int RATE = 44100; // sample rate of the sound card
        private static int BUFFERSIZE = (int)Math.Pow(2, 8); // must be a multiple of 2
        private static int BYTES_PER_POINT = 2;
        private short renderedFrames = 0;
        private short fpsLatch = 0;
        private short _fps = 25;
        public short fps_limit {
            get { return _fps; }
            set { _fps = value; }
        }
        private short _fpsMs = 0;
        public short fpsMs {
            get { return _fpsMs; }
        }
        private void setFpsMs(bool up) {
            if (up)
                fpsLatch++;
            else
                fpsLatch--;
            _fpsMs = (short)((1000 / _fps) + fpsLatch);
        }

        private double[] pcmData = new double[((BUFFERSIZE * 2) / BYTES_PER_POINT)];
        private double[] fourierData = new double[(BUFFERSIZE / BYTES_PER_POINT)];

        private bool fftProccess = false;

        private bool fetchDataBool = false;
        private bool proccessDataBool = false;
        private bool dynSensBool = false;
        private bool tickHandlerBool = false;

        //private AutoResetEvent waitTickHandle = new AutoResetEvent(false);
        //private AutoResetEvent pcmDataMutex = new AutoResetEvent(false);
        //private AutoResetEvent fourierDataMutex = new AutoResetEvent(false);
        //private AutoResetEvent readingDataMutex = new AutoResetEvent(false);
        //private AutoResetEvent dynamicSensitivityMutex = new AutoResetEvent(false);
        //private AutoResetEvent fftSumMutex = new AutoResetEvent(false);

        private double audioDataSensitivity = 1;
        private double fftSum = 0;

        private WaveInEvent wi;
        private BufferedWaveProvider bwp;

        //static ThreadStart dynSensTS = null;
        static ThreadStart tickHandleTS = null;
        static ThreadStart fetchDataTS = null;
        //static ThreadStart proccessDataTS = null;
        //Thread dynSensTH = null;
        Thread tickHandleTH = null;
        Thread fetchDataTH = null;
        //Thread proccessDataTH = null;

        IntPtr ptr;
        IntPtr plan;
        private AudioReactor(int adn, AudioType at, DataType dt) {
            _instanceID = instancesCreated;
            audioDeviceNumber = adn;
            audioType = at;
            dataType = dt;
            //dynSensTS = dynamicSensitivity;
            tickHandleTS = tickHandler;
            fetchDataTS = fetchData;
            //proccessDataTS = proccessData;
            //dynSensTH = new Thread(dynSensTS);
            tickHandleTH = new Thread(tickHandleTS);
            fetchDataTH = new Thread(fetchDataTS);
            //proccessDataTH = new Thread(proccessDataTS);
        }
        private AudioReactor() : this(0, AudioType.MICROPHONE, DataType.FOURIER) { }
        ~AudioReactor() {
            stop();
        }

        private void ClearBufferedWaveProvider() {
            try {
                bwp.ClearBuffer();
            } catch (Exception e) {
                Console.WriteLine(e);
                //probably still not initialized;
            }
        }

        //========================================================

        public int audioDeviceNumber {
            set { _audioDeviceNumber = value; }
            get { return _audioDeviceNumber; }
        }
        public AudioType audioType {
            set { _audioType = value; }
            get { return _audioType; }
        }
        public DataType dataType {
            set { _dataType = value; }
            get { return _dataType; }
        }
        private void AudioDataAvailable(object sender, WaveInEventArgs e) {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }
        private void StartListeningToAudioDevice() {
            try {
                wi.DeviceNumber = audioDeviceNumber;
                wi.WaveFormat = new NAudio.Wave.WaveFormat(RATE, 1);
                wi.BufferMilliseconds = (int)((double)BUFFERSIZE / (double)RATE * 1000.0);
                wi.DataAvailable += new EventHandler<WaveInEventArgs>(AudioDataAvailable);
                bwp = new BufferedWaveProvider(wi.WaveFormat);
                bwp.BufferLength = BUFFERSIZE * 2;
                bwp.DiscardOnBufferOverflow = true;
                wi.StartRecording();
            } catch (Exception e) {
                Console.WriteLine(e);
                string msg = "Could not record from audio device!\n\n";
                msg += "Is your microphone plugged in?\n";
                msg += "Is it set as your default recording device?";
                Console.WriteLine(msg);
            }
        }
        private void StopListeningToAudioDevice() {
            try {
                wi.StopRecording();
            } catch (Exception e) { Console.WriteLine(e);/*probably already stopped;*/}
        }


        //====================================================================

        protected virtual void returnFPSTrigger() {
            try {
                procFPSEvent?.Invoke(this, (short)(renderedFrames));
            } catch (Exception e) {
                Console.WriteLine("Fuckup return fps");
                Console.WriteLine(e);
                this.stop();
            }
        }

        protected virtual void returnSumTrigger() {
            try {
                procSumFetchReadyEvent?.Invoke(this, (short)(fftSum));
            } catch (Exception e) {
                Console.WriteLine("Fuckup return SUM");
                Console.WriteLine(e);
                this.stop();
            }
        }

        protected virtual void returnPCMTrigger() {
            try {
                procPCMDataFetchReadyEvent?.Invoke(this, pcmData);
            } catch (Exception e) {
                Console.WriteLine("Fuckup return pcm");
                Console.WriteLine(e);
                this.stop();
            }
        }
        protected virtual void returnFourierTrigger() {
            try {
                procFourierDataFetchReadyEvent?.Invoke(this, fourierData);
            } catch (Exception e) {
                Console.WriteLine("Fuckup return fourier");
                Console.WriteLine(e);
                this.stop();
            }
        }

        private void fetchData() {
            try{
                while (fetchDataBool) {
                    while (fetchDataBool) {
                        if (renderedFrames > fps_limit)
                            setFpsMs(true);
                        else
                            renderedFrames++;

                        byte[] audioBytes = new byte[BUFFERSIZE];
                        bwp.Read(audioBytes, 0, BUFFERSIZE);
                        if (audioBytes.Length == 0)
                            break;
                        if (audioBytes[BUFFERSIZE - 2] == 0)
                            break;
                        int graphPointCount = audioBytes.Length / BYTES_PER_POINT;
                        fftSum = 0;
                        for (int i = 0; i < graphPointCount; i++){
                            Int16 val = BitConverter.ToInt16(audioBytes, i * 2);
                            double v = (double)(val) / 65536 * audioDataSensitivity;
                            pcmData[i * 2] = v;
                            pcmData[(2 * i) + 1] = 0;
                            if (v > 0)
                                fftSum += v;
                            else
                                fftSum += (v * -1);
                        }
                        returnPCMTrigger();

                        fftSum /= fourierData.Length;
                        fftSum = Math.Max(0, Math.Min(255, fftSum * 100));
                        returnSumTrigger();

                        //PROCDATA
                        if (proccessDataBool){
                            Marshal.Copy(pcmData, 0, ptr, pcmData.Length);
                            plan = fftw.dft_1d(pcmData.Length / 2, ptr, ptr, fftw_direction.Forward, fftw_flags.Estimate);
                            fftw.execute(plan);
                            Marshal.Copy(ptr, fourierData, 0, fourierData.Length);
                            returnFourierTrigger();
                        }

                        //DYNSENS
                        if (dynSensBool)
                            if (audioDataSensitivity > 0.1 && fftSum > 0.0001) {
                                if (fftSum < 15 && audioDataSensitivity < 5) {
                                    audioDataSensitivity += 0.1;
                                }
                                if (fftSum > 400 && audioDataSensitivity > 0.1) {
                                    audioDataSensitivity -= 0.1;
                                }
                            }
                        //Console.WriteLine("Proccessed - " + instanceID + " -> "+fftSum);
                        Thread.Sleep(fpsMs);
                        }
                    //waitTickHandle.WaitOne();
                    Thread.Sleep(fpsMs);
                    }
            }catch(ThreadAbortException e){
                Console.WriteLine("DataFetch Closed");

            }catch(Exception e) {
                Console.WriteLine("Error fetching Data");
                MessageBox.Show("Error fetching Data: \n" + e);
            } finally {
                fetchDataBool = false;
            }
        }

        //private void proccessData(){
        //    try {
        //        while (proccessDataBool) {
        //            while (proccessDataBool) {
        //                if (!fetchDataTH.IsAlive || !tickHandleTH.IsAlive)
        //                    break;
        //                //Console.WriteLine("Proccessing Data " + callproc);
        //                if (!pcmDataReady)
        //                    pcmDataMutex.WaitOne();
        //                proccessedDataReady = false;
        //                Marshal.Copy(pcmData, 0, ptr, pcmData.Length);
        //                plan = fftw.dft_1d(pcmData.Length / 2, ptr, ptr, fftw_direction.Forward, fftw_flags.Estimate);
        //                fftw.execute(plan);

        //                Marshal.Copy(ptr, fourierData, 0, fourierData.Length);

        //                proccessedDataReady = true;
        //                fourierDataMutex.Set();
        //                //Console.WriteLine("Proccessing Done " + callproc);
        //                //waitTickHandle.WaitOne();
        //                Thread.Sleep(getFpsMilliseconds());
        //            }
        //            //waitTickHandle.WaitOne();
        //            Thread.Sleep(getFpsMilliseconds());
        //        }
        //    }catch(Exception e) {
        //        proccessDataBool = false;
        //        Console.WriteLine("Fuckup proccessing data");
        //        Console.WriteLine(e);
        //    }
        //}

        //private void dynamicSensitivity(){
        //    while (dynSensBool){
        //        //Console.WriteLine("DynSens Calibration");
        //        if (!dynamicSensitivityEnabled)
        //            dynamicSensitivityMutex.WaitOne();
        //        if (!proccessedDataReady)
        //            fourierDataMutex.WaitOne();
                
        //        waitTickHandle.WaitOne(fps_limit);
        //        if (audioDataSensitivity > 0.1 && fftSum > 0.0001){
        //            if (fftSum < 15 && audioDataSensitivity < 5){
        //                audioDataSensitivity += 0.1;
        //            }
        //            if (fftSum > 400 && audioDataSensitivity > 0.1){
        //                audioDataSensitivity -= 0.1;
        //            }
        //        }
        //    }
        //}

        private void tickHandler(){
            while (tickHandlerBool){
                Thread.Sleep(1000);
                //Console.WriteLine("Tick - " + instanceID + " @"+renderedFrames);
                returnFPSTrigger();
                if(fps_limit - renderedFrames > 5)
                    setFpsMs(false);
                renderedFrames = 0;
            }
        }

        public void enableDynamicSensitivity(){
            dynSensBool = true;
        }
        public void disableDynamicSensitivity(){
            dynSensBool = false;
        }

        public void start(){
            wi = new WaveInEvent();
            _fpsMs = (short)((1000 / _fps));
            if (!fftProccess)
                ptr = fftw.malloc(pcmData.Length * sizeof(double));
            Console.WriteLine("AudioReactor " + instanceID + " running");
            if (tickHandleTH.IsAlive || fetchDataTH.IsAlive)
                throw new ServiceRunningException("Service Still Running");

            fetchDataBool = true;
            if(dataType == DataType.FOURIER)
                proccessDataBool = true;
            tickHandlerBool = true;
            enableDynamicSensitivity();
            tickHandleTH = new Thread(tickHandleTS);
            fetchDataTH = new Thread(fetchDataTS);
            //dynSensTH = new Thread(dynSensTS);
            //proccessDataTH = new Thread(proccessDataTS);

            StartListeningToAudioDevice();
            tickHandleTH.Start();
            fetchDataTH.Start();
            //proccessDataTH.Start();
            //dynSensTH.Start();
        }
        public void stop(){
                tickHandlerBool = false;
                fetchDataBool = false;
                proccessDataBool = false;
                dynSensBool = false;

                Console.WriteLine("bools off");
            try{
                tickHandleTH.Abort();
            } catch (Exception e) {
                Console.WriteLine("Fuckup stopping tickHandle");
                Console.WriteLine(e);
            }
            try {
                fetchDataTH.Abort();
            }catch(Exception e) {
                Console.WriteLine("Fuckup stopping fetchData");
                Console.WriteLine(e);
            }
            Console.WriteLine("threads off");
            if (fftProccess){
                fftProccess = false;
                //stop proccessed data
                fftw.destroy_plan(plan);
                fftw.free(ptr);
                fftw.cleanup();
            }

            Console.WriteLine("fft off");

            StopListeningToAudioDevice();
            ClearBufferedWaveProvider();

            Console.WriteLine("waveProvider off");
        }

        //============

        //private double[] getProccessedData(){
        //    if (!fetchDataTH.IsAlive)
        //        return null; //is data fetching is actually working/running ?
        //    if (!proccessedDataReady){ // is proccessing data rn?
        //        proccessedDataMutex.WaitOne();
        //        if (!proccessedDataReady)
        //            return null;
        //    }
        //    readingData = true; // starts reading data
        //    double[] scr = new double[proccessedData.Length];
        //    Array.Copy(proccessedData, 0, scr, 0, proccessedData.Length);
        //    readingData = false;
        //    readingDataMutex.Set();
        //    return scr;
        //}
        
        //======================================================================
        //======================================================================
        //======================================================================
        //======================================================================
        //======================================================================
        //======================================================================
        //======================================================================

        private static List<AudioReactor> instances = new List<AudioReactor>();
        private static int instancesCreated = 0;
        public static int getInstancesCreated(){ return instancesCreated; }
        public static AudioReactor getInstance(int i) {
            try {return instances[i];
            }catch(Exception e) {return null;}
        }
        public static void removeAllInstances(){
            for(int i=0;i < instancesCreated;i++) {
                removeInstance(instances[i]);
            }
            //for(int i= instancesCreated-1;i >=0;i--){
            //    instances[i].stop();
            //    instances.RemoveAt(i);
            //    instancesCreated--;
            //    Console.WriteLine("AudioReactor "+i+" removed | "+instances.Count);
            //}
        }
        public static void removeInstance(int i) {
            removeInstance(getInstance(i));
        }
        public static void removeInstance(AudioReactor rf){
            try {
                try {
                    rf.stop();
                }catch(NullReferenceException e) {
                    Console.WriteLine("Issue stopping bufer "+e);
                }
                instances.Remove(rf);
                instancesCreated--;
                Console.WriteLine("AudioReactor Instance " + (instancesCreated-1) + " Removed");
            }catch(Exception e) {
                Console.WriteLine("Fuckup removing instance " + instancesCreated);
                Console.WriteLine(e);
            }
        }
        public static AudioReactor newInstance(){
            try {
                Console.WriteLine("AudioReactor Instance Created");
                instances.Add(new AudioReactor());
                instancesCreated++;
                return instances[instancesCreated - 1];
            }catch(Exception e) {
                Console.WriteLine(e);
                return null;
            }
        }
        public static void makeComplex(double[] from, double[] to){
            for (int i = 0; i < from.Length; i++){
                to[i * 2] = from[i];
                to[(2 * i) + 1] = 0;
            }
        }
        public static void makeReal(double[] from, double[] to){
            for (int i = 0; i < to.Length; i++)
                to[i] = from[2 * i];
        }

        public static Dictionary<int, string> getInputDeviceDict(){
            Dictionary<int, string> d = new Dictionary<int, string>();
            for (int n = -1; n < WaveIn.DeviceCount; n++){
                var caps = WaveIn.GetCapabilities(n);
                d.Add(n, caps.ProductName);
            }
            return d;
        }

        public static int selectMicrophoneDevice(){
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Selecione dispositivo: ");
            Console.SetCursorPosition(0, 3);
            Dictionary<int, string> d = getInputDeviceDict();

            foreach (KeyValuePair<int, string> entry in d){
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.Write("ID: ");
            string id = Console.ReadLine();
            if (id == ""){
                Console.WriteLine("Default");
                return 0;
            }
            if (d.ContainsKey(int.Parse(id))){
                //Console.WriteLine("Selected: |" + id + "|");
                return int.Parse(id);
            } else {
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Device not found!");
                return selectMicrophoneDevice();
            }
        }

        public static object[] toObjectList(Dictionary<int,string> d){
            object[] ol = new object[d.Count];
            int i = 0;
            foreach(KeyValuePair<int,string> q in d){
                ol[i] = q.Value;
            }
            return ol;
        }
    }
}

// note: missing extra step (conversion https://www.gamedev.net/forums/topic/562823-fftw---realtime-music-visualization/ )
// see the toComplex and toReal stuff: https://www.youtube.com/watch?v=9SwuRRe-2Jk  to refactor this fftw function 
// in case, 'complex' input as default, and throwing a real input
// https://dsp.stackexchange.com/questions/24458/fftw-log-log-plot
// https://dsp.stackexchange.com/questions/31251/fft-spectrogram-in-log-frequency-space-how


//also make an UI to show it (later)
//load -> console;form visualizer;Boreal!s_RGB;<custom>
//AudioReactor -> on;off
//DynamicSensivity -> on;off
//Input -> mix of inputType and inputDevice, iType is radio and iDev is the list
//Exit -> closes all Threads, shuts down audioreactor

//functioning like vst plugin
//audioreactor sends ready events to Threaded DLLs (loaded and put in a thread)