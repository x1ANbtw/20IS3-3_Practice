using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Newtonsoft.Json;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace BotClient__task_10_
{
    internal class Program
    {
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message)
            {
                return;
            }
            if (message.Text is not { } messageText)
            {
                return;
            }
            var chatId = message.Chat.Id;

            Console.WriteLine($"Recieved a '{messageText}' message in a chat {chatId}.");

            //Ответ на сообщение
            Message sentmessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken
                );

            if (message.Text.ToLower() == "проверка")
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Проверка пройдена!",
                    cancellationToken: cancellationToken
                    );
            }
            else
            if (message.Text.ToLower() == "привет")
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Здравствуй, {message.Chat.FirstName}",
                    cancellationToken: cancellationToken
                    );
            }
            if (message.Text.ToLower() == "картинка")
            {
                await botClient.SendPhotoAsync(
                    chatId: chatId,
                    photo: InputFile.FromUri("https://github.com/x1ANbtw/20IS3-3_Practice_Bruev/assets/125022706/09d72142-b6a0-4075-9014-d2f4830fb06f"),
                    caption: "Ваша картинка",
                    cancellationToken: cancellationToken
                    );
            }
            if (message.Text.ToLower() == "видео")
            {
                await botClient.SendVideoAsync(
                    chatId: chatId,
                    video: InputFile.FromUri("https://video.twimg.com/ext_tw_video/1533667150560432128/pu/vid/540x540/16aNbjEFbuoq4BM5.mp4?tag=12"),
                    thumbnail: InputFile.FromUri("https://github.com/x1ANbtw/20IS3-3_Practice_Bruev/assets/125022706/59bebbf6-d627-44d3-ad3e-a3e182a54e9f"),
                    cancellationToken: cancellationToken
                    );
            };
            if (message.Text.ToLower() == "стикер")
            {
                await botClient.SendStickerAsync(
                    chatId: chatId,
                    sticker: InputFile.FromUri("https://github.com/x1ANbtw/20IS3-3_Practice_Bruev/assets/125022706/b07a5411-4052-4fdf-8567-1feb2ee0ac5d"),
                    cancellationToken: cancellationToken
                    );
            };
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}\n\n" + exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        static async Task Main(string[] args)
        {
            //TG
            var botClient = new TelegramBotClient("6176472028:AAF6LBbNsBMg6igeavcJjdjT7JHbr4zAcMk");
            using CancellationTokenSource cts = new();

            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
                );

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();

            //API
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://localhost:7178/api/User");
            Console.WriteLine(result);

            var test = await result.Content.ReadAsStringAsync();
            Console.WriteLine(test);

            Domain.Models.User[] users = JsonConvert.DeserializeObject<Domain.Models.User[]>(test);

            foreach (var user in users)
            {
                Console.WriteLine($"{user.UserId} {user.Username} {user.Password} {user.RoleId} {user.FirstName} {user.LastName} {user.FirstName} {user.PhoneNumber} {user.Email} {user.Addres} {user.IsDeleted}");
            }
        }
    }
}