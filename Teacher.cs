using BotTry.Enums;
using BotTry.UnitsTutorials;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;

namespace BotTry
{
    public static class Teacher
    {
        public static async Task StartTeachingAsync(BotClient botClient, long chatId, CancellationToken cancellationToken = default)
        {
            await botClient.SendMessageAsync(
                chatId: chatId,
                text: Constants.TutorialStartMessage,
                cancellationToken: cancellationToken);

            await ShowMessageTypesAsync(botClient, chatId, cancellationToken);
        }

        public static async Task ShowMessageTypesAsync(BotClient botClient, long chatId, CancellationToken cancellationToken = default)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                // first row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: MessageType.TEXT.ToString(), callbackData: MessageType.TEXT.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.PHOTO.ToString(), callbackData: MessageType.PHOTO.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.STICKER.ToString(), callbackData: MessageType.STICKER.ToString()),
                },
                // second row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: MessageType.AUDIO.ToString(), callbackData: MessageType.AUDIO.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.VOICE.ToString(), callbackData: MessageType.VOICE.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.VIDEO.ToString(), callbackData: MessageType.VIDEO.ToString()),
                },
                // third row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: MessageType.VIDEO_NOTE.ToString(), callbackData: MessageType.VIDEO_NOTE.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.ALBUM.ToString(), callbackData: MessageType.ALBUM.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.DOCUMENT.ToString(), callbackData: MessageType.DOCUMENT.ToString()),
                },
                // fourth row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: MessageType.ANIMATION.ToString(), callbackData: MessageType.ANIMATION.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.POLL.ToString(), callbackData: MessageType.POLL.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.CONTACT.ToString(), callbackData: MessageType.CONTACT.ToString()),
                },
                // fifth row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: MessageType.VENUE.ToString(), callbackData: MessageType.VENUE.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: MessageType.LOCATION.ToString(), callbackData: MessageType.LOCATION.ToString()),
                }
            });

            var sentMessage = await botClient.SendMessageAsync(
                chatId: chatId,
                text: Constants.ChoiceMessage,
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }

        public static async Task ShowButtonTypesAsync(BotClient botClient, long chatId, CancellationToken cancellationToken = default)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                // first row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: ButtonType.SINGLE_ROW_REPLY.ToString(), callbackData: ButtonType.SINGLE_ROW_REPLY.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: ButtonType.MULTI_ROW_REPLY.ToString(), callbackData: ButtonType.MULTI_ROW_REPLY.ToString()),
                },
                // second row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: ButtonType.REQUEST_REPLY.ToString(), callbackData: ButtonType.REQUEST_REPLY.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: ButtonType.CALLBACK_INLINE.ToString(), callbackData: ButtonType.CALLBACK_INLINE.ToString()),
                },
                // third row
                new []
                {
                    InlineKeyboardButton.SetCallbackData(text: ButtonType.URL_INLINE.ToString(), callbackData: ButtonType.URL_INLINE.ToString()),
                    InlineKeyboardButton.SetCallbackData(text: ButtonType.SWITCH_INLINE.ToString(), callbackData: ButtonType.SWITCH_INLINE.ToString()),
                }
            });

            var sentMessage = await botClient.SendMessageAsync(
                chatId: chatId,
                text: Constants.ChoiceMessage,
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainMessageTypeAsync(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Data == null)
            {
                return;
            }

            var callbackTextToUpper = query.Data.ToUpper();

            var messageTypeFromCallback = default(MessageType);
            Enum.TryParse(callbackTextToUpper, out messageTypeFromCallback);

            switch (messageTypeFromCallback)
            {
                case MessageType.TEXT:
                    await MessageTypesTutorial.ExplainTextMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.PHOTO:
                    await MessageTypesTutorial.ExplainPhotoMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.STICKER:
                    await MessageTypesTutorial.ExplainStickerMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.AUDIO:
                    await MessageTypesTutorial.ExplainAudioMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.VOICE:
                    await MessageTypesTutorial.ExplainVoiceMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.VIDEO:
                    await MessageTypesTutorial.ExplainVideoMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.VIDEO_NOTE:
                    await MessageTypesTutorial.ExplainVideoNoteMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.ALBUM:
                    await MessageTypesTutorial.ExplainAlbumMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.DOCUMENT:
                    await MessageTypesTutorial.ExplainDocumentMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.ANIMATION:
                    await MessageTypesTutorial.ExplainAnimationMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.POLL:
                    await MessageTypesTutorial.ExplainPollMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.CONTACT:
                    await MessageTypesTutorial.ExplainContactMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.VENUE:
                    await MessageTypesTutorial.ExplainVenueMessage(botClient, query, cancellationToken);
                    break;
                case MessageType.LOCATION:
                    await MessageTypesTutorial.ExplainLocationMessage(botClient, query, cancellationToken);
                    break;
                default:
                    await new BasicBot(botClient).HandleUnknownMessageAsync(query.Message.Chat.Id, cancellationToken);
                    break;
            }

            await ShowMessageTypesAsync(botClient, query.Message.Chat.Id, cancellationToken);
        }

        public static async Task ExplainButtonTypeAsync(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Data == null)
            {
                return;
            }

            var callbackTextToUpper = query.Data.ToUpper();

            var buttonTypeFromCallback = default(ButtonType);
            Enum.TryParse(callbackTextToUpper, out buttonTypeFromCallback);

            switch (buttonTypeFromCallback)
            {
                case ButtonType.SINGLE_ROW_REPLY:
                    await ButtonTypesTutorial.ExplainSingleRowReplyButton(botClient, query, cancellationToken);
                    break;
                case ButtonType.MULTI_ROW_REPLY:
                    await ButtonTypesTutorial.ExplainMultiRowReplyButton(botClient, query, cancellationToken);
                    break;
                case ButtonType.REQUEST_REPLY:
                    await ButtonTypesTutorial.ExplainRequestReplyButton(botClient, query, cancellationToken);
                    break;
                case ButtonType.CALLBACK_INLINE:
                    await ButtonTypesTutorial.ExplainCallbackInlineButton(botClient, query, cancellationToken);
                    break;
                case ButtonType.URL_INLINE:
                    await ButtonTypesTutorial.ExplainUrlInlineButton(botClient, query, cancellationToken);
                    break;
                case ButtonType.SWITCH_INLINE:
                    await ButtonTypesTutorial.ExplainSwitchInlineButton(botClient, query, cancellationToken);
                    break;
                default:
                    await new BasicBot(botClient).HandleUnknownMessageAsync(query.Message.Chat.Id, cancellationToken);
                    break;
            }
        }
    }
}
