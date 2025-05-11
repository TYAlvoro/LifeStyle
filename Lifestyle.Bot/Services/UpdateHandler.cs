using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Lifestyle.Bot.Services;

public class UpdateHandler
{
    public static async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken token)
    {
        if (update.Type == UpdateType.Message && update.Message?.Text is { } text)
        {
            await bot.SendMessage(
                chatId: update.Message.Chat.Id,
                text:   text,
                cancellationToken: token
            );
        }
    }

    public static Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken token)
    {
        Console.WriteLine($"[Error] {exception.Message}");
        return Task.CompletedTask;
    }
}