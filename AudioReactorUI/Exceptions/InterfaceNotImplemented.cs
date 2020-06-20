using System;
using System.Runtime.Serialization;

namespace AudioReactorUI {
    [Serializable]
    internal class InterfaceNotImplemented : Exception {
        public InterfaceNotImplemented() {
        }

        public InterfaceNotImplemented(string message) : base(message) {
        }

        public InterfaceNotImplemented(string message, Exception innerException) : base(message, innerException) {
        }

        protected InterfaceNotImplemented(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}