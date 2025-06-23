using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Livlina.Import.Services.Interfaces;
using Livlina.Import;
using Livlina.Import.Services;
using NReco.Logging.File;
using MassTransit;

var builder = Host.CreateApplicationBuilder(args);


/*builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true);
}
if ( builder.Environment.IsProduction())
{
    builder.Configuration.AddJsonFile("appsettings.production.json");
}*/
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    var loggingSection = builder.Configuration.GetSection("Logging");
    loggingBuilder.AddFile(loggingSection);
    var errorLoggingSection = builder.Configuration.GetSection("ErrorLogging");
    loggingBuilder.AddFile(errorLoggingSection);
});
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");
    });
});
builder.Services.AddSingleton<ICophanaImporter, CophanaImporter>();
builder.Services.AddHostedService<CophanaImportWorker>();

var host = builder.Build();
host.Run();


