using KafkaSaver;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
try
{
    host.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
