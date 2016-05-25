﻿using System;

namespace IO.Ably.Realtime
{
    /// <summary>
    /// Whenever the connection state changes, a ConnectionStateChange Event is emitted on the Connection object
    /// The ConnectionStateChange object contains the current state in attribute current, the previous state in attribute previous, and when the client is not connected and a connection attempt will be made automatically by the library, the amount of time in milliseconds until the next retry in the attribute retryIn
    /// If the connection state change includes error information, then the reason attribute will contain an ErrorInfo object describing the reason for the error
    /// <see cref="http://docs.ably.io/client-lib-development-guide/features/#TA1"/>
    /// </summary>
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        public ConnectionStateChangedEventArgs(ConnectionStateType previous, ConnectionStateType current, TimeSpan? retryIn = null,
            ErrorInfo reason = null)
        {
            PreviousState = previous;
            CurrentState = current;
            RetryIn = retryIn;
            Reason = reason;
        }

        public ConnectionStateType PreviousState { get; }

        public ConnectionStateType CurrentState { get; }

        public TimeSpan? RetryIn { get;  }

        public ErrorInfo Reason { get; }

        public bool HasError => Reason != null;
    }
}