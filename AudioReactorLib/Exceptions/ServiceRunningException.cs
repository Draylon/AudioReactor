using System;
using System.Runtime.Serialization;

namespace AudioReactorLib {
    [Serializable]
    internal class ServiceRunningException : Exception {
        public ServiceRunningException() {
        }

        public ServiceRunningException(string message) : base(message) {
        }

        public ServiceRunningException(string message, Exception innerException) : base(message, innerException) {
        }

        protected ServiceRunningException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}