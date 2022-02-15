using Confluent.Kafka;
using System;
using System.Threading.Tasks;

namespace KafkaProducer
{
    /// <summary>
    /// Kafka producer
    /// </summary>
    internal class Program
    {
        private static ProducerConfig _configProducer = new ProducerConfig { BootstrapServers = "localhost:9092" };

        public static async Task Main(string[] args)
        {
            Console.WriteLine("==>> AJ Kafka Producer");
            Console.WriteLine("- Type anything you want to stream to a Kafka topic named 'demoAJ' and press <ENTER>");
            //The topic named "demoAJ" was created using the CONDUKTOR app
            Console.WriteLine("- Type 'exit' and press <ENTER> if you want to end the program.");

            await ReadInputAndPushToKafka();

        }

        private static async Task ReadInputAndPushToKafka()
        {
            using (var p = new ProducerBuilder<Null,string>(_configProducer).Build())
            {

                while (true)
                {
                    var userInput = Console.ReadLine();

                    if (userInput.Trim() == "exit")
                        break;

                    try
                    {
                        var dr = await p.ProduceAsync("demoAJ", new Message<Null, string> { Value = userInput });
                        Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                    }
                    catch (ProduceException<Null, string> ex)
                    {
                        Console.WriteLine($"Delivery faild: {ex.Error.Reason} ");

                    }
                }

            }

        }
    }
}
