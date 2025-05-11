using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace Lifestyle.Bot.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTelegramBot(this IServiceCollection services, IConfiguration config)
    {
        var token = config["TelegramBot:Token"]!;
        services.AddSingleton<ITelegramBotClient>(sp => new TelegramBotClient(token));
        services.AddSingleton<Services.UpdateHandler>();
        return services;
    }
}