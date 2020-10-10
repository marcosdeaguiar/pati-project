using System;

namespace Pati.Messaging.Core
{
    /// <summary>
    /// Class that represents the message header.
    /// </summary>
    public class MessageHeader<T>
    {
        /// <summary>
        /// Correlation id of the message.
        /// </summary>
        public T MessageId { get; set; }

        /// <summary>
        /// Reply channel to the message.
        /// </summary>
        public string ReturnAddress { get; set; }
    }

    public class MessageHeader: MessageHeader<Guid>
    {
    }
}
