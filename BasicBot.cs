using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.GettingUpdates;
using Telegram.BotAPI.Stickers;

namespace BotTry
{
    public class BasicBot
    {
        private readonly BotClient _botClient;

        public BasicBot(string accessToken) 
        { 
            _botClient = new BotClient(accessToken);
        }

        public void GetBotGreeting()
        {
            var me = _botClient.GetMe();
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
        }

        public async Task ReceiveMessage()
        {
            var updates = _botClient.GetUpdates();

            while (true)
            {
                if (updates.Any())
                {
                    foreach (var update in updates)
                    {
                        // we don`t need to await it
                        HandleUpdateAsync(update);
                    }
                    var offset = updates.Last().UpdateId + 1;
                    updates = _botClient.GetUpdates(offset);
                }
                else
                {
                    updates = _botClient.GetUpdates();
                }
            }
        }

        async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken = default)
        {
            if (update.Message?.GetType() != typeof(Message)
                || update.Message?.Text?.GetType() != typeof(string))
            {
                return;
            }

            var chatId = update.Message.Chat.Id;

            Console.WriteLine($"Received a '{update.Message.Text}' message in chat {chatId}.");

            if (update.Message.Text.ToUpper().Contains("HI"))
            {

                // Echo received message text
                Message sentMessage = await _botClient.SendMessageAsync(
                    chatId: chatId,
                    text: "Hi! What a nice weather, eh?",
                    cancellationToken: cancellationToken);
            }
            else if (update.Message.Text.ToUpper().Contains("HELLO"))
            {

                // Echo received message text
                Message sentMessage = await _botClient.SendStickerAsync(
                        chatId: chatId,
                        sticker: "https://raw.githubusercontent.com/DeccemberGirl/BotTry/Resources/master/ZhadanHelloBrodyaga.webp",
                        cancellationToken: cancellationToken);
            }
        }

        static Task HandlePollingErrorAsync(Exception exception, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine(exception.ToString());
            return Task.CompletedTask;
        }
    }
}
