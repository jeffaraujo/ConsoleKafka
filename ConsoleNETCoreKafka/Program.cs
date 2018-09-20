using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace ConsoleNETCoreKafka
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            OpenProducer().Wait();
        }

        static async Task OpenProducer()
        {
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers", "localhost:2181" }
            };

            using (var producer = new Producer<Null, string>(
                       config,
                        null,
                        new StringSerializer(Encoding.UTF8)))
            {
                await producer.ProduceAsync("topic", null, "fiap");
            }
        }

    }
}
