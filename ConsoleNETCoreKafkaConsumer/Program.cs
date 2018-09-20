using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;


namespace ConsoleNETCoreKafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var config = new Dictionary<string, object> {
                                        { "group.id", "test-consumer-group" },
                                        { "bootstrap.servers", "localhost:2181" },
                                        { "auto.commit.interval.ms", 5000 },
                                        { "auto.offset.reset", "earliest" }}; // latest

            using (var consumer = new Consumer<Null, string>(
            config,
            null,
            new StringDeserializer(Encoding.UTF8)))
            {
                consumer.OnMessage += (_, msg) => Console.WriteLine(msg.Value);
                consumer.Subscribe("topic");
                while (true) { consumer.Poll(TimeSpan.FromMilliseconds(100)); }
            }

        }
    }
}
