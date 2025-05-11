using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lifestyle.Bot.Extensions;
using Lifestyle.Bot.Services;

await Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(cfg => cfg.AddJsonFile("appsettings.json", optional: false))
    .ConfigureServices((ctx, services) =>
    {
        services.AddTelegramBot(ctx.Configuration);
        services.AddHostedService<BotHostedService>();
    })
    .RunConsoleAsync();