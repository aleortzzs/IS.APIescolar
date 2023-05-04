﻿using System;
using System.Runtime.Serialization;

namespace cetys.APIs.Escolar.Interfaces.Escolar
{
    [Serializable]
    internal class ResponseException : Exception
    {
        public ResponseException()
        {
        }

        public ResponseException(string message) : base(message)
        {
        }

        public ResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}