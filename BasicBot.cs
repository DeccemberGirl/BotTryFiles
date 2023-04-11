using System.Threading;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableMethods.FormattingOptions;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.Games;
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
            Console.WriteLine(string.Format(Constants.BotIntroduction, me.Id, me.FirstName));
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

            Console.WriteLine(string.Format(Constants.MessageReceivedNotification, update.Message.Text, chatId));

            var updateTextToUpper = update.Message.Text.ToUpper();
            if (updateTextToUpper.Contains(BasicCommands.START.ToString()))
            {
                await _botClient.SendStickerAsync(
                        chatId: chatId,
                        sticker: "https://raw.githubusercontent.com/DeccemberGirl/BotTry/Resources/master/ZhadanHelloBrodyaga.webp",
                        cancellationToken: cancellationToken);
                // Echo received message text
                var sentMessage = await _botClient.SendMessageAsync(
                    chatId: chatId,
                    text: string.Format(Constants.BotIntroduction, _botClient.GetMe().Id, _botClient.GetMe().FirstName),
                    cancellationToken: cancellationToken);
            }
            else if (updateTextToUpper.Contains(BasicCommands.HELP.ToString()))
            {
                await _botClient.SendMessageAsync(
                    chatId: chatId,
                    text: Constants.CommandsListMessage,
                    cancellationToken: cancellationToken);
            }
            else if (updateTextToUpper.Contains(BasicCommands.LEARN.ToString()))
            {
                Teacher.StartTeaching();
            }
            else if (updateTextToUpper.Contains(BasicCommands.UNITS.ToString()))
            {
                await _botClient.SendMessageAsync(
                        chatId: chatId,
                        text: Constants.UnitsListMessage,
                        cancellationToken: cancellationToken);
                HandleUnitCommandsAsync();
            }
            else 
            {
                await _botClient.SendStickerAsync(
                        chatId: chatId,
                        sticker: "https://raw.githubusercontent.com/DeccemberGirl/BotTry/Resources/master/TogoNihtoNeZnaPoderevyansky.webp",
                        cancellationToken: cancellationToken);
                await _botClient.SendMessageAsync(
                        chatId: chatId,
                        text: Constants.UnknownMessage,
                        cancellationToken: cancellationToken);
            }


            //else if (update.Message.Text.ToUpper().Contains("BUTTON"))
            //{
                // INLINE BUTTON
                //var message = await _botClient.SendMessageAsync(
                //    chatId: chatId,
                //    text: "Trying *all the parameters* of `sendMessage` method",
                //    parseMode: ParseMode.MarkdownV2,
                //    disableNotification: true,
                //    replyToMessageId: update.Message.MessageId,
                //    replyMarkup: new InlineKeyboardMarkup(new List<InlineKeyboardButton>
                //    {
                //         new InlineKeyboardButton
                //         {
                //             Text = "Check sendMessage method",
                //             Url = "https://core.telegram.org/bots/api#sendmessage",
                //             CallbackData = Constants.LinkIsPressedButtonCallbackData
                //         }
                //    }), 
                //    cancellationToken: cancellationToken);

                // REPLY BUTTON ONE ROW
                //var replyKeyboardMarkup = new ReplyKeyboardMarkup(new[]
                //    {
                //        new KeyboardButton[] { 
                //            new KeyboardButton("Help me"), 
                //            new KeyboardButton("Call me ☎️") },
                //    })
                //{
                //    ResizeKeyboard = true
                //};

                //var sentMessage = await _botClient.SendMessageAsync(
                //    chatId: chatId,
                //    text: "Choose a response",
                //    replyMarkup: replyKeyboardMarkup,
                //    cancellationToken: cancellationToken);

                // HIDING BUTTON
                //await _botClient.SendMessageAsync(
                //    chatId: chatId,
                //    text: "Removing keyboard",
                //    replyMarkup: new ReplyKeyboardRemove(),
                //    cancellationToken: cancellationToken);

                // INLINE CALLBACK BUTTONS
                //var inlineKeyboard = new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>
                //{
                //    // first row
                //    new List<InlineKeyboardButton>
                //    {
                //        InlineKeyboardButton.SetCallbackData("1.1", "11"),
                //        InlineKeyboardButton.SetCallbackData("1.2", "12"),
                //    },
                //    // second row
                //    new List<InlineKeyboardButton>
                //    {
                //        InlineKeyboardButton.SetCallbackData("2.1","21"),
                //        InlineKeyboardButton.SetCallbackData("2.2", "22"),
                //    },
                //});

                //var sentMessage = await _botClient.SendMessageAsync(
                //    chatId: chatId,
                //    text: "A message with an inline keyboard markup",
                //    replyMarkup: inlineKeyboard,
                //    cancellationToken: cancellationToken);

            //    var inlineKeyboard = new InlineKeyboardMarkup(new[]
            //    {
            //        InlineKeyboardButton.SetSwitchInlineQuery(
            //            "send to the other chat", "sending message to the other chat: switch_inline_query"),
            //        InlineKeyboardButton.SetSwitchInlineQueryCurrentChat(
            //            "send to this chat", "sending message to this chat: switch_inline_query_current_chat"),
            //    });

            //    var sentMessage = await _botClient.SendMessageAsync(
            //        chatId: chatId,
            //        text: "A message with an inline keyboard markup",
            //        replyMarkup: inlineKeyboard,
            //        cancellationToken: cancellationToken);
            //}
        }

        static Task HandlePollingErrorAsync(Exception exception, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine(exception.ToString());
            return Task.CompletedTask;
        }

        async Task HandleLinkIsPressed(long chatId, CancellationToken cancellationToken = default)
        {
            await _botClient.SendMessageAsync(
                    chatId: chatId,
                    text: "Link!",
                    cancellationToken: cancellationToken);
        }

        async Task HandleUnitCommandsAsync()
        {

        }
    }
}
