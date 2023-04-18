namespace Ecommerce.UI.BackgroundServices
{
    //public class ConsumerBackgroundServiceOderComplete : BackgroundService
    //{
    //    private readonly string topic = "eticket";
    //    private readonly string groupId = "test_group";
    //    private readonly string bootstrapServers = "localhost:9092";




    //    public Task StopAsync(CancellationToken cancellationToken)
    //    {
    //        return Task.CompletedTask;
    //    }

    //    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    //    {
    //        var config = new ConsumerConfig
    //        {
    //            GroupId = groupId,
    //            BootstrapServers = bootstrapServers,
    //            AutoOffsetReset = AutoOffsetReset.Earliest
    //        };

    //        try
    //        {
    //            using (var consumerBuilder = new ConsumerBuilder
    //            <Ignore, string>(config).Build())
    //            {
    //                consumerBuilder.Subscribe(topic);
    //                var cancelToken = new CancellationTokenSource();

    //                try
    //                {
    //                    while (true)
    //                    {
    //                        var consumer = consumerBuilder.Consume
    //                           (cancelToken.Token);
    //                        using (var writer = System.IO.File.CreateText(System.IO.Path.GetTempFileName()))
    //                        {
    //                            writer.WriteLine("Consumeed Messsage" + DateTime.Now.Date + " ", consumer.Message.Value); //or .Write(), if you wish
    //                        }
    //                        //var orderRequest = JsonSerializer.Deserialize
    //                        //    <SaveOrderOutput>
    //                        //        (consumer.Message.Value);
    //                        Debug.WriteLine($"Processing Order Id:{consumer.Message.Value} ");
    //                    }
    //                }
    //                catch (OperationCanceledException)
    //                {
    //                    consumerBuilder.Close();
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            System.Diagnostics.Debug.WriteLine(ex.Message);
    //        }

    //        return Task.CompletedTask;
    //    }





    //}
    //public class ConsumerBackgroundServiceOderComplete : BackgroundService
    //{
    //    private readonly ILogger<MatchEventBackgroundService> _logger;

    //    private readonly MessageConsumer _consumer;

    //    public ConsumerBackgroundServiceOderComplete(ILogger<MatchEventBackgroundService> logger,
    //        MessageConsumer consumer)
    //    {
    //        _logger = logger;
    //        _consumer = consumer;
    //    }

    //    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    //    {
    //        _logger.LogInformation("Running consumer");
    //        _consumer.Subscribe("match-events");

    //        try
    //        {
    //            while (!cancellationToken.IsCancellationRequested)
    //            {
    //                var result = _consumer.Consume(cancellationToken);
    //                if (!result.Message.Headers.TryGetLastBytes("gm.type", out var bytes))
    //                {
    //                    continue;
    //                }

    //                var s = Encoding.UTF8.GetString(bytes);
    //                _logger.LogInformation("{key}", s);
    //            }
    //        }
    //        catch (OperationCanceledException)
    //        {
    //        }
    //        finally
    //        {
    //            _consumer.Unsubscribe();
    //            _consumer.Close();
    //        }

    //        return Task.CompletedTask;

    //    }
    //}

    //public class ConsumerBackgroundServiceOderComplete : IHostedService
    //{
    //    private readonly string topic = "eticket";

    //    public Task StartAsync(CancellationToken cancellationToken)
    //    {
    //        var conf = new ConsumerConfig
    //        {
    //            GroupId = "test_group",
    //            BootstrapServers = "localhost:9092",
    //            AutoOffsetReset = AutoOffsetReset.Latest,
    //        };

    //        using (var builder = new ConsumerBuilder<Ignore, string>(conf).Build())
    //        {
    //            try
    //            {
    //                builder.Subscribe("eticket");
    //                var cancelToken = new CancellationTokenSource();
    //                try
    //                {
    //                    while (!cancellationToken.IsCancellationRequested)
    //                    {
    //                        var consumer = builder.Consume(cancelToken.Token);
    //                        Console.WriteLine($"Message Recived: {consumer.Message.Value} ");
    //                    }
    //                }
    //                catch (ConsumeException e)
    //                {
    //                    Console.WriteLine($"Error occured: {e.Error.Reason}");
    //                    builder.Close();
    //                }

    //                return Task.CompletedTask;
    //            }
    //            catch (OperationCanceledException)
    //            {
    //                // Ensure the consumer leaves the group cleanly and final offsets are committed.
    //                builder.Close();
    //                return Task.CompletedTask;
    //            }
    //        }
    //    }
    //    public Task StopAsync(CancellationToken cancellationToken)
    //    {
    //        return Task.CompletedTask;
    //    }
    //}
}

