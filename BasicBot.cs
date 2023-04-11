using BotTry.Enums;
using BotTry.Enums.CommandEnums;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableMethods.FormattingOptions;
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
            _botClient.SetMyCommands(
                new BotCommand("start", "start a dialog"),
                new BotCommand("help", "show commands"),
                new BotCommand("learn", "a bots creating tutorial"),
                new BotCommand("units", "choose a unit to learn"));
        }

        public BasicBot(BotClient botClient)
        {
            _botClient = botClient;
            _botClient.SetMyCommands(
                new BotCommand("start", "start a dialog"),
                new BotCommand("help", "show commands"),
                new BotCommand("learn", "a bots creating tutorial"),
                new BotCommand("units", "choose a unit to learn"));
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

        public async Task HandleUnknownMessageAsync(long chatId, CancellationToken cancellationToken = default)
        {
            await _botClient.SendStickerAsync(
                                chatId: chatId,
                                sticker: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/TogoNihtoNeZnaPoderevyansky.webp",
                                cancellationToken: cancellationToken);
            await _botClient.SendMessageAsync(
                    chatId: chatId,
                    text: Constants.UnknownMessage,
                    cancellationToken: cancellationToken);
        }

        async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken = default)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    if (update.Message == null)
                    {
                        return;
                    }

                    var chatId = update.Message.Chat.Id;
                    Console.WriteLine(string.Format(Constants.MessageReceivedNotification, update.Message.Text, chatId));

                    var updateTextToUpper = update.Message.Text?.ToUpper().Substring(1);
                    var basicCommand = default(BasicCommand);
                    var unitCommand = default(UnitCommand);
                    if (Enum.TryParse(updateTextToUpper, out basicCommand))
                    {
                        await HandleBasicCommandsAsync(basicCommand, chatId, cancellationToken);
                    }
                    else if (Enum.TryParse(updateTextToUpper, out unitCommand))
                    {
                        await HandleUnitCommandsAsync(unitCommand, chatId, cancellationToken);
                    }
                    else
                    {
                        await HandleUnknownMessageAsync(chatId, cancellationToken);
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
                    break;
                case UpdateType.CallbackQuery:
                    var query = update.CallbackQuery;
                    if (query?.Data == null) 
                    {
                        return;
                    }

                    var messageTypeFromCallback = default(MessageType);
                    if (Enum.TryParse(query.Data.ToUpper(), out messageTypeFromCallback))
                    {
                        await Teacher.ExplainMessageTypeAsync(_botClient, query, cancellationToken);                       
                    }
                    break;
            }
        }

        private async Task HandleBasicCommandsAsync(BasicCommand basicCommand, long chatId, CancellationToken cancellationToken = default)
        {
            switch (basicCommand)
            {
                case BasicCommand.START:
                    await StartDialog(chatId, cancellationToken);
                    break;
                case BasicCommand.HELP:
                    await _botClient.SendMessageAsync(
                            chatId: chatId,
                            text: Constants.CommandsListMessage,
                            cancellationToken: cancellationToken);
                    break;
                case BasicCommand.LEARN:
                    await Teacher.StartTeachingAsync(_botClient, chatId, cancellationToken);
                    break;
                case BasicCommand.UNITS:
                    await _botClient.SendMessageAsync(
                                chatId: chatId,
                                text: Constants.UnitsListMessage,
                                cancellationToken: cancellationToken);
                    break;
                default:
                    break;
            }
        }

        private async Task HandleUnitCommandsAsync(UnitCommand unitCommand, long chatId, CancellationToken cancellationToken = default)
        {
            switch (unitCommand)
            {
                case UnitCommand.MESSAGE_TYPES:
                    await Teacher.ShowMessageTypesAsync(_botClient, chatId, cancellationToken);
                    break;
                case UnitCommand.BUTTONS:
                    break;
                case UnitCommand.GETTING_UPDATES:
                    break;
                case UnitCommand.FILES:
                    break;
                case UnitCommand.SECURITY:
                    break;
                default:
                    break;
            }           
        }

        private async Task StartDialog(long chatId, CancellationToken cancellationToken = default)
        {
            await _botClient.SendStickerAsync(
                                chatId: chatId,
                                sticker: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/ZhadanHelloBrodyaga.webp",
                                cancellationToken: cancellationToken);
            // Echo received message text
            var sentMessage = await _botClient.SendMessageAsync(
                chatId: chatId,
                text: string.Format(Constants.BotIntroduction, _botClient.GetMe().Id, _botClient.GetMe().FirstName),
                cancellationToken: cancellationToken);
        }

        async Task HandleLinkIsPressed(long chatId, CancellationToken cancellationToken = default)
        {
            await _botClient.SendMessageAsync(
                    chatId: chatId,
                    text: "Link!",
                    cancellationToken: cancellationToken);
        }
    }
}
