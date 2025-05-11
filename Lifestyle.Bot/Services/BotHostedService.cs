using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace Lifestyle.Bot.Services;

public class BotHostedService(ITelegramBotClient bot) : IHostedService
{
    private CancellationTokenSource? _cts;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        bot.SetMyCommands([
            new BotCommand { Command = "start", Description = "Запустить бота" },
            new BotCommand { Command = "help",  Description = "Показать список команд" }
        ], cancellationToken: _cts.Token);

        
        bot.StartReceiving(
            updateHandler: UpdateHandler.HandleUpdateAsync,
            errorHandler: UpdateHandler.HandleErrorAsync,
            receiverOptions: new ReceiverOptions { AllowedUpdates = [] },
            cancellationToken: _cts.Token
        );
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _cts?.CancelAsync()!;
        await Task.CompletedTask;
    }
}