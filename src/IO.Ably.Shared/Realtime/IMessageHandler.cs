﻿using System;

namespace IO.Ably.Realtime
{
    internal static class MessageHandlerAction
    {
        public static MessageHandlerAction<PresenceMessage> ToHandlerAction(this Action<PresenceMessage> action)
        {
            return new MessageHandlerAction<PresenceMessage>(action);
        }

        public static MessageHandlerAction<Message> ToHandlerAction(this Action<Message> action)
        {
            return new MessageHandlerAction<Message>(action);
        }

        public static void SafeHandle<T>(this MessageHandlerAction<T> handler, T message, ILogger logger) where T : IMessage
        {
            try
            {
                handler.Handle(message);
            }
            catch (Exception ex)
            {
                logger.Error("Error notifying subscriber", ex);
            }
        }
    }

    /// <summary>Adapter to pass a delegate as IMessageHandler.</summary>
    internal class MessageHandlerAction<T> where T : IMessage
    {
        private readonly Action<T> action;

        public MessageHandlerAction(Action<T> action)
        {
            if (null == action)
                throw new ArgumentNullException();
            this.action = action;
        }

        public void Handle(T message)
        {
            action(message);
        }

        protected bool Equals(MessageHandlerAction<T> other)
        {
            return Equals(action, other.action);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MessageHandlerAction<T>) obj);
        }

        public override int GetHashCode()
        {
            return (action != null ? action.GetHashCode() : 0);
        }
    }
}