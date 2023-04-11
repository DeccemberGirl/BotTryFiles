using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.UpdatingMessages;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using BotTry.Enums;
using Telegram.BotAPI.AvailableMethods.FormattingOptions;
using Telegram.BotAPI.Stickers;
using File = System.IO.File;
using System;

namespace BotTry.UnitsTutorials
{
    public static class MessageTypesTutorial
    {
        public static async Task ExplainTextMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.TEXT.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.TextMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: "This message is an example of the plain text message." + Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainPhotoMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.PHOTO.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.PhotoMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.PHOTO.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendPhotoAsync(
                chatId: query.Message.Chat.Id,
                photo: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/GopherPhoto.jpg",
                caption: "<b>Gopher</b>. <i>State</i>: <a>Hungry</a>",
                parseMode: ParseMode.HTML,
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainStickerMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.STICKER.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.StickerMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.STICKER.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendStickerAsync(
                chatId: query.Message.Chat.Id,
                sticker: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/Otter.webp",
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainAudioMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.AUDIO.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.AudioMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.AUDIO.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendAudioAsync(
                chatId: query.Message.Chat.Id,
                audio: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/SurzhykMstyslavKrupenya.mp3",
                performer: "Mstyslav Krupenya",
                title: "Surzhyk",
                duration: 124, 
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainVoiceMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.VOICE.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.VoiceMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.VOICE.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await using (var stream = File.OpenRead("https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/CatTalking.ogg"))
            {
                await botClient.SendVoiceAsync(
                    chatId: query.Message.Chat.Id,
                    voice: new InputFile(new StreamContent(stream!), "CatTalking.ogg"),
                    duration: 22,
                    cancellationToken: cancellationToken);
            }

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }
    }
}
