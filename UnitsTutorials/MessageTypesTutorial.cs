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

            await using (var stream = File.OpenRead("Resources\\CatTalking.ogg"))
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

        public static async Task ExplainVideoMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.VIDEO.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.VideoMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.VIDEO.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendVideoAsync(
                chatId: query.Message.Chat.Id,
                video: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/TNMK_Proyihaly.mp4",
                thumbnail: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/TNMK_Proyihaly.png",
                supportsStreaming: true,
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainVideoNoteMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.VIDEO_NOTE.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.VideoNoteMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.VIDEO_NOTE.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await using (var stream = File.OpenRead("Resources\\Sklo.mp4"))
            {
                await botClient.SendVideoNoteAsync(
                    chatId: query.Message.Chat.Id,
                    videoNote: new InputFile(new StreamContent(stream!), "Sklo.mp4"),
                    duration: 19,
                    length: 15, 
                    cancellationToken: cancellationToken);
            }

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainAlbumMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.ALBUM.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.AlbumMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.ALBUM.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendMediaGroupAsync(
                chatId: query.Message.Chat.Id,
                media: new List<InputMedia>
                {
                    new InputMediaPhoto("https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/Fish1.jpg"),
                    new InputMediaPhoto("https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/Fish2.jpg"),
                },
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainDocumentMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.DOCUMENT.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.DocumentMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.DOCUMENT.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendDocumentAsync(
                chatId: query.Message.Chat.Id,
                document: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/TextDoc.txt",
                caption: "<b>Weather question</b>. <i>Umbrella</i>: <a>To take or not?</a>",
                parseMode: ParseMode.HTML,
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainAnimationMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.ANIMATION.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.AnimationMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.ANIMATION.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendAnimationAsync(
                chatId: query.Message.Chat.Id,
                animation: "https://raw.githubusercontent.com/DeccemberGirl/BotTryFiles/master/Resources/SmileGIF.mp4",
                caption: "SmileGIF",
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainPollMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.POLL.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.PollMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.POLL.ToString().ToLower()),
                cancellationToken: cancellationToken);

            var message = await botClient.SendPollAsync(
                chatId: query.Message.Chat.Id,
                question: "Hey?",
                options: new[]
                {
                    "Ho!",
                    "Heee..."
                },
                cancellationToken: cancellationToken);

            //await botClient.StopPollAsync(
            //    chatId: message.Chat.Id,
            //    messageId: message.MessageId,
            //    cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainContactMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.CONTACT.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.ContactMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.CONTACT.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendContactAsync(
                chatId: query.Message.Chat.Id,
                phoneNumber: "+1234567890",
                firstName: "Stepan",
                lastName: "Bandera",
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainVenueMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.VENUE.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.VenueMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.VENUE.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendVenueAsync(
                chatId: query.Message.Chat.Id,
                latitude: 50.0840172f,
                longitude: 14.418288f,
                title: "Man Hanging out",
                address: "Husova, 110 00 Staré Město, Czechia",
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }

        public static async Task ExplainLocationMessage(BotClient botClient, CallbackQuery query, CancellationToken cancellationToken = default)
        {
            if (query.Message?.Chat == null)
            {
                return;
            }

            botClient.AnswerCallbackQuery(query.Id, MessageType.LOCATION.ToString());
            botClient.EditMessageText(new EditMessageTextArgs(Constants.LocationMessage)
            {
                ChatId = query.Message.Chat.Id,
                MessageId = query.Message.MessageId
            });

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: string.Format(Constants.ExampleMessage, MessageType.LOCATION.ToString().ToLower()),
                cancellationToken: cancellationToken);

            await botClient.SendLocationAsync(
                chatId: query.Message.Chat.Id,
                latitude: 33.747252f,
                longitude: -112.633853f,
                cancellationToken: cancellationToken);

            await botClient.SendMessageAsync(
                chatId: query.Message.Chat.Id,
                text: Constants.FurtherMessage,
                cancellationToken: cancellationToken);
        }
    }
}
