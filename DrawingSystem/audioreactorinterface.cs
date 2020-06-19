using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingSystem {
    public interface DLLCall {
        void setup();
        void loop(double[] d);
    }
}
