using System;
using System.Collections.Generic;
using System.Text;

namespace Pati.KafkaUtils.Option
{
    /// <summary>
    /// Represents settings for using kafka.
    /// </summary>
    public class KafkaSettings
    {
        /// <summary>
        /// Connection string for the Kafka cluster.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Message timeout in milliseconds, defaults to 1000.
        /// </summary>
        public int MessageTimeoutMs { get; set; } = 1000;
    }
}
