using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePrintPlugin{
    class ConsolePrintPlugin:DLLCall{
        private short _avgfps;
        private bool drawAvaliable=true;
        public short avgfps{get{ return _avgfps; }}

        static void Main(string[] args){
            Console.Write("AudioReactor");
        }

        internal void Dispose(){
            throw new NotImplementedException();
        }

        internal void loop(double[] d){
            if (drawAvaliable){
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("fps:" + avgfps);
                double s = 0;
                for (int ii = 0; ii < d.Length; ii += 2){
                    if (ii + 1 >= d.Length)
                        s = d[ii] + d[ii + 1];
                    else
                        s = d[ii];
                    for (int i = 0; i < s; i++)
                        Console.Write("=");
                    Console.WriteLine();
                }
            }
        }

        internal void Show(){
            throw new NotImplementedException();
        }

        internal void Hide(){
            throw new NotImplementedException();
        }

        public void setup(){
            throw new NotImplementedException();
        }

        void DLLCall.loop(double[] d){
            throw new NotImplementedException();
        }

        public void dispose(){
            throw new NotImplementedException();
        }

        public void fps(short fps){
            throw new NotImplementedException();
        }

        public void showForm(){
            throw new NotImplementedException();
        }

        public void hideForm(){
            throw new NotImplementedException();
        }
    }
}
