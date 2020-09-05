using System.Threading.Tasks;

namespace Pati.Infrastructure
{
    /// <summary>
    /// Interface to abstract away the sending of messages.
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Send a message to a topic with a key.
        /// </summary>
        /// <typeparam name="T">Type of the object that will be serialized and sent.</typeparam>
        /// <param name="topic">Name of the topic to send the event.</param>
        /// <param name="eventKey">The key to put in the event message.</param>
        /// <param name="eventInstance">The instance to be serialized and sent.</param>
        /// <returns>Returns a tast for async operation.</returns>
        Task SendEventAsync<T>(string topic, string eventKey, T eventInstance);
    }
}
