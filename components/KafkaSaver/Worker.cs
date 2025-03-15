using Confluent.Kafka;

namespace KafkaSaver
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ConsumerConfig _consumerConfig;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;

            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9093", // Kafka broker address
                GroupId = "my-consumer-group", // Consumer group ID
                AutoOffsetReset = AutoOffsetReset.Earliest // Start reading from the beginning if no offset is stored
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            using var consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build();
            consumer.Subscribe("topic-01");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Poll for messages
                    var consumeResult = consumer.Consume(stoppingToken);

                    if (consumeResult != null)
                    {
                        _logger.LogInformation($"Received message: {consumeResult.Message.Value} at: {DateTimeOffset.Now}");
                    }
                }
                catch (ConsumeException e)
                {
                    _logger.LogError($"Error occurred: {e.Error.Reason}");
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("Consumer stopped.");
                    break;
                }
            }

            consumer.Close();
        }
    }
}