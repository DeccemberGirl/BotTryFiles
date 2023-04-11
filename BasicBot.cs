using BotTry.Enums;
using BotTry.Enums.CommandEnums;
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
                    else if (update.Message.Text == Constants.ExampleCallBackWow
                        || update.Message.Text == Constants.ExampleCallBackHm
                        || update.Message.Text == Constants.ExampleCallBackGreat
                        || update.Message.Text == Constants.BotPrefixMessage + Constants.ExampleCallBackGreat
                        || update.Message.Contact != null)
                    {
                        await HandleExampleButtonCallbacksAsync(chatId, cancellationToken);
                    }
                    else
                    {
                        await HandleUnknownMessageAsync(chatId, cancellationToken);
                    }
                    break;
                case UpdateType.CallbackQuery:
                    var query = update.CallbackQuery;
                    if (query?.Data == null) 
                    {
                        return;
                    }

                    var messageTypeFromCallback = default(MessageType);
                    var buttonTypeFromCallback = default(ButtonType);
                    if (Enum.TryParse(query.Data.ToUpper(), out messageTypeFromCallback))
                    {
                        await Teacher.ExplainMessageTypeAsync(_botClient, query, cancellationToken);                       
                    }
                    else if (Enum.TryParse(query.Data.ToUpper(), out buttonTypeFromCallback))
                    {
                        await Teacher.ExplainButtonTypeAsync(_botClient, query, cancellationToken);
                    }
                    else if (query.Data == Constants.ExampleCallBackWow
                        || query.Data == Constants.ExampleCallBackHm
                        || query.Data == Constants.ExampleCallBackGreat)
                    {
                        await HandleExampleButtonCallbacksAsync(query.Message.Chat.Id, cancellationToken);
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
                    await Teacher.ShowButtonTypesAsync(_botClient, chatId, cancellationToken);
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

        public async Task HandleExampleButtonCallbacksAsync(long chatId, CancellationToken cancellationToken = default)
        {
            await _botClient.SendMessageAsync(
                            chatId: chatId,
                            text: "Ok",
                            replyMarkup: new ReplyKeyboardRemove(),
                            cancellationToken: cancellationToken);
            await _botClient.SendMessageAsync(
                chatId: chatId,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
            await Teacher.ShowButtonTypesAsync(_botClient, chatId, cancellationToken);
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
